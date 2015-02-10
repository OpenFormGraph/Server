using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenFormGraph.Library.Managers;
using OpenFormGraph.Web.Constants;
using OpenFormGraph.Web.JsonObjects;
using TreeGecko.Library.Net.Objects;

namespace OpenFormGraph.Web.Helpers
{
    public static class JsonHelper
    {
        public static List<JsonObjects.User> GetUsers(OpenFormGraphManager _manager, List<TGUser> _users)
        {
            List<JsonObjects.User> jUsers = new List<User>();

            foreach (TGUser tgUser in _users)
            {
                JsonObjects.User user = new User(tgUser);

                if (_manager.HasUserRole(user.Guid, UserRoles.UserAdmin))
                {
                    user.IsUserAdmin = true;
                }
                else
                {
                    user.IsUserAdmin = false;
                }

                if (_manager.HasUserRole(user.Guid, UserRoles.DataAdmin))
                {
                    user.IsDataAdmin = true;
                }
                else
                {
                    user.IsDataAdmin = false;
                }

                jUsers.Add(user);
            }

            return jUsers;
        }

    }
}