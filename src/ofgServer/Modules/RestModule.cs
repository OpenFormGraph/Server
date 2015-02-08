using System.Collections.Generic;
using System.IO;
using Nancy;
using Newtonsoft.Json;
using OpenFormGraph.Library.Managers;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_parameters"></param>
        /// <returns></returns>
        public string HandleUsersGet(DynamicDictionary _parameters)
        {
            OpenFormGraphManager manager = new OpenFormGraphManager();

            User jUser = AuthHelper.ValidateToken(manager, Request);
            if (jUser != null
                && jUser.IsUserAdmin)
            {
                List<TGUser> users = manager.GetUsers();

                List<User> jUsers = JsonHelper.GetUsers(manager, users);
                return JsonConvert.SerializeObject(jUsers);
            }

            return "[]";
        }
        
        public string HandleLoginPost(DynamicDictionary _parameters)
        {
            TGUser user;
            LoginRequest jLoginRequest = null;

            using (StreamReader sr = new StreamReader(Request.Body))
            {
                string json = sr.ReadToEnd();
                jLoginRequest = JsonConvert.DeserializeObject<LoginRequest>(json);
            }

            if (jLoginRequest != null)
            { 
                LoginResult jResult = AuthHelper.Authorize(m_Manager, jLoginRequest.Username, jLoginRequest.Password, out user);

                return JsonConvert.SerializeObject(jResult);
            }

            return null;
        }

    }
}