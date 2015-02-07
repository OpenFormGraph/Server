using System;
using OpenFormGraph.Library.Managers;
using OpenFormGraph.Web.Objects;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Security;
using TreeGecko.Library.Net.Objects;

namespace OpenFormGraph.Web.Helpers
{
    public class UserMapper : IUserMapper
    {
        public IUserIdentity GetUserFromIdentifier(Guid _identifier, NancyContext _context)
        {
            OpenFormGraphManager manager = new OpenFormGraphManager();

            TGUser user = manager.GetUser(_identifier);

            if (user != null
                && user.IsVerified)
            {
                if (user.EulaAccepted || _context.Request.Path.Contains("signeula"))
                {
                    NancyUser nUser = new NancyUser {UserName = user.Username};
                    return nUser;
                }
            }

            return null;
        }
    }
}