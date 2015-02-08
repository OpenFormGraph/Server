using System;
using System.Linq;
using OpenFormGraph.Library.Managers;
using OpenFormGraph.Web.JsonObjects;
using Nancy;
using Newtonsoft.Json;
using TreeGecko.Library.Common.Helpers;
using TreeGecko.Library.Net.Objects;

namespace OpenFormGraph.Web.Helpers
{
    public static class AuthHelper
    {
        public static User ValidateToken(OpenFormGraphManager _manager, Request _request)
        {
            string username = _request.Headers["Username"].First();
            string token = _request.Headers["AuthToken"].First();

            TGUser user;
            if (_manager.ValidateUser(username, token, out user))
            {
                User result = new User(user);

                if (_manager.HasUserRole(user.Guid, "UserAdmin"))
                {
                    result.IsUserAdmin = true;
                }
                else
                {
                    result.IsUserAdmin = false;
                }

                if (_manager.HasUserRole(user.Guid, "DataAdmin"))
                {
                    result.IsDataAdmin = true;
                }
                else
                {
                    result.IsDataAdmin = false;
                }

                return result;
            }

            return null;
        }

        public static LoginResult Authorize(OpenFormGraphManager _manager, 
            string _username, string _password, out TGUser _user)
        {
            LoginResult result = new LoginResult();
            _user = _manager.GetUser(_username);

            if (_user != null)
            {
                if (_user.Active)
                {
                    if (_manager.ValidateUser(_user, _password))
                    {
                        string token = _manager.GetAuthorizationToken(_user.Guid, _password);

                        result.Result = "Success";
                        result.AuthToken = token;
                        result.Username = _username;

                        if (_manager.HasUserRole(_user.Guid, "UserAdmin"))
                        {
                            result.IsUserAdmin = true;
                        }
                        else
                        {
                            result.IsUserAdmin = false;
                        }

                        if (_manager.HasUserRole(_user.Guid, "DataAdmin"))
                        {
                            result.IsDataAdmin = true;
                        }
                        else
                        {
                            result.IsDataAdmin = false;
                        }

                    }
                    else
                    {
                        //Bad password or username
                        TraceFileHelper.Warning("User not found");
                        _user = null;

                        result.Result = "BadUserOrPassword";
                    }
                }
                else
                {
                    //user not active
                    //Todo - Log Something
                    TraceFileHelper.Warning("User Not Active");
                    _user = null;

                    result.Result = "NotActive";
                }
            }
            else
            {
                //User not found
                TraceFileHelper.Warning("User not found");
                result.Result = "BadUserOrPassword";
            }

            return result;
        }


        public static bool IsAuthorized(Request _request, out TGUser _user)
        {
            OpenFormGraphManager manager = new OpenFormGraphManager();
            
            string username = _request.Headers["Username"].First();
            string authToken = _request.Headers["AuthorizationToken"].First();

            TGUser user = manager.GetUser(username);
            if (user != null)
            {
                TGUserAuthorization userAuth = manager.GetUserAuthorization(user.Guid, authToken);

                if (userAuth != null
                    && !userAuth.IsExpired())
                {
                    _user = user;

                    return true;
                }
            }

            _user = null;
            return false;
        }

        public static string Authorize(string _username, string _password, out TGUser _user)
        {
            LoginResult result = new LoginResult();
            OpenFormGraphManager manager = new OpenFormGraphManager();
            _user = manager.GetUser(_username);

            if (_user != null)
            {
                if (_user.IsVerified)
                {
                    if (_user.Active)
                    {
                        if (manager.ValidateUser(_user, _password))
                        {
                            TGUserAuthorization authorization =
                                TGUserAuthorization.GetNew(_user.Guid, "unknown");
                            manager.Persist(authorization);

                            result.Result = "Success";
                            result.AuthToken = authorization.AuthorizationToken;
                            result.DisplayName = _user.DisplayName;
                            result.Username = _user.Username;
                        }

                        TGEula eula = manager.GetLatestEula();
                        if (eula != null)
                        {
                            TGEulaAgreement agreement = manager.GetEulaAgreement(_user.Guid, eula.Guid);

                            if (agreement == null)
                            {
                                result.NeedsEula = "True";
                                result.EulaGuid = eula.Guid.ToString();
                                result.EulaText = eula.Text;

                                _user.EulaAccepted = false;
                                manager.Persist(_user);
                            }
                            else
                            {
                                result.NeedsEula = "False";
                            }
                        }
                        else
                        {
                            //Bad password or username
                            manager.LogWarning(Guid.Empty, "User not found");
                            _user = null;

                            result.Result = "BadUserOrPassword";
                        }
                    }
                    else
                    {
                        //user not active
                        //Todo - Log Something
                        manager.LogWarning(_user.Guid, "User Not Active");
                        _user = null;

                        result.Result = "NotActive";
                    }
                }
                else
                {
                    //User not verified
                    //Todo - Log Something
                    manager.LogWarning(_user.Guid, "User not verified");
                    _user = null;

                    result.Result = "NotVerified";
                }
            }
            else
            {
                //User not found
                manager.LogWarning(Guid.Empty, "User not found");

                result.Result = "BadUserOrPassword";
            }

            return JsonConvert.SerializeObject(result);
        }

        public static string Authorize(Request _request, out TGUser _user)
        {
            string username = _request.Headers["Username"].First();
            string password = _request.Headers["Password"].First();

            return Authorize(username, password, out _user);
        }
    }
}