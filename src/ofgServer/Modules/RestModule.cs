using System;
using System.Collections.Generic;
using System.IO;
using Nancy;
using Newtonsoft.Json;
using OpenFormGraph.Library.Managers;
using OpenFormGraph.Web.Constants;
using OpenFormGraph.Web.Helpers;
using OpenFormGraph.Web.JsonObjects;
using TreeGecko.Library.Net.Objects;

namespace OpenFormGraph.Web.Modules
{
    public class RestModule : NancyModule
    {
        private readonly OpenFormGraphManager m_Manager = new OpenFormGraphManager();

        public RestModule()
        {
            Post["/rest/login"] = _parameters =>
            {
                Response response = HandleLoginPost(_parameters);
                response.ContentType = "application/json";
                return response;
            };

            Get["/rest/form/{guid}"] = _parameters =>
            {
                //Response response = HandleResetPassword(_parameters);
                //response.ContentType = "application/json";
                //return response;
                return null;
            };

            Post["/rest/form"] = _parameters =>
            {
                //Response response = HandleResetPassword(_parameters);
                //response.ContentType = "application/json";
                //return response;
                return null;
            };

            Get["/rest/form/list/{guid}"] = _parameters =>
            {
                //Return 
                return null;
            };

            Get["/rest/user/{guid}"] = _parameters =>
            {
                Response response = HandleUserGet(_parameters);
                response.ContentType = "application/json";
                return response;
            };

            Post["/rest/user/add"] = _parameters =>
            {
                Response response = HandleUserAddPost(_parameters);
                response.ContentType = "application/json";
                return response;
            };

            Get["/rest/users"] = _parameters =>
            {
                Response response = HandleUsersGet(_parameters);
                response.ContentType = "application/json";
                return response;
            };

            Get["/rest/formtemplates"] = _parameters =>
            {
                return null;
            };
        }

        public string HandleUserGet(DynamicDictionary _parameters)
        {
            OpenFormGraphManager manager = new OpenFormGraphManager();

            User jUser = AuthHelper.ValidateToken(manager, Request);
            if (jUser != null && jUser.IsUserAdmin)
            {
                string sGuid = _parameters["Guid"];
                Guid userGuid;

                if (Guid.TryParse(sGuid, out userGuid))
                {
                    TGUser user = manager.GetUser(userGuid);
                    User jOtherUser = new User(user);

                    return JsonConvert.SerializeObject(jOtherUser);
                }
            }

            return null;
        }

        public string HandleUserAddPost(DynamicDictionary _parameters)
        {
            OpenFormGraphManager manager = new OpenFormGraphManager();
            BaseResult result = new BaseResult();

            User jUser = AuthHelper.ValidateToken(manager, Request);
            if (jUser != null  && jUser.IsUserAdmin)
            {
                using (StreamReader sr = new StreamReader(Request.Body))
                {
                    string json = sr.ReadToEnd();
                    NewUser jNewUser = JsonConvert.DeserializeObject<NewUser>(json);

                    if (jNewUser != null)
                    {
                        jNewUser.Guid = Guid.NewGuid();

                        TGUser testUser = manager.GetUser(jNewUser.Username);
                        if (testUser == null)
                        {
                            TGUser newUser = new TGUser
                            {
                                FamilyName = jNewUser.LastName,
                                GivenName = jNewUser.FirstName,
                                EmailAddress = jNewUser.EmailAddress,
                                IsVerified = true,
                                DisplayName = jNewUser.Username,
                                Username = jNewUser.Username
                            };
                            manager.Persist(newUser);

                            TGUserPassword userPassword = TGUserPassword.GetNew(newUser.Guid, newUser.Username, jNewUser.Password);
                            manager.Persist(userPassword);

                            //Add Admin Roles as required
                            if (jNewUser.IsUserAdmin)
                            {
                                TGUserRole userAdminRole = new TGUserRole
                                {
                                    Active = true,
                                    ParentGuid = newUser.Guid, 
                                    Name = UserRoles.UserAdmin
                                };
                                manager.Persist(userAdminRole);
                            }

                            if (jNewUser.IsDataAdmin)
                            {
                                TGUserRole dataAdminRole = new TGUserRole
                                {
                                    Active = true,
                                    ParentGuid = newUser.Guid, 
                                    Name = UserRoles.DataAdmin
                                };
                                manager.Persist(dataAdminRole);
                            }

                            result.Result = "Success";
                        }
                        else
                        {
                            result.Result = "UsernameNotAvailable";
                        }
                    }
                }
            }

            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_parameters"></param>
        /// <returns></returns>
        public string HandleUsersGet(DynamicDictionary _parameters)
        {
            OpenFormGraphManager manager = new OpenFormGraphManager();

            User jUser = AuthHelper.ValidateToken(manager, Request);
            if (jUser != null && jUser.IsUserAdmin)
            {
                List<TGUser> users = manager.GetUsers();

                List<User> jUsers = JsonHelper.GetUsers(manager, users);
                return JsonConvert.SerializeObject(jUsers);
            }

            return "[]";
        }
        
        public string HandleLoginPost(DynamicDictionary _parameters)
        {
            LoginRequest jLoginRequest;

            using (StreamReader sr = new StreamReader(Request.Body))
            {
                string json = sr.ReadToEnd();
                jLoginRequest = JsonConvert.DeserializeObject<LoginRequest>(json);
            }

            if (jLoginRequest != null)
            {
                TGUser user;

                LoginResult jResult = AuthHelper.Authorize(m_Manager, 
                    jLoginRequest.Username, jLoginRequest.Password, out user);

                return JsonConvert.SerializeObject(jResult);
            }

            return null;
        }

    }
}