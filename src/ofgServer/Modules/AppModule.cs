using Nancy;
using OpenFormGraph.Library.Managers;
using OpenFormGraph.Web.Constants;
using OpenFormGraph.Web.JsonObjects;
using TreeGecko.Library.Common.Helpers;
using TreeGecko.Library.Common.Security;
using TreeGecko.Library.Net.Objects;

namespace OpenFormGraph.Web.Modules
{
    public class AppModule : NancyModule
    {
        public AppModule()
        {
            Get["/"] = _parameters =>
            {
                return View["index.sshtml"];
            };

            Get["/dev/BuildDB"] = _parameters =>
            {
                bool devMode = Config.GetBooleanValue("DevMode", false);

                if (devMode)
                {
                    OpenFormGraphStructureManager structureManager = new OpenFormGraphStructureManager();
                    structureManager.BuildDB();

                    return View["dev_dbbuildresult.sshtml"];
                }

                return null;
            };

            Get["/dev/BuildAdminUser"] = _parameters =>
            {
                bool devMode = Config.GetBooleanValue("DevMode", false);

                if (devMode)
                {
                    OpenFormGraphManager manager = new OpenFormGraphManager();

                    TGUser user = manager.GetUser("OFGAdmin");
                    if (user == null)
                    {
                        user = new TGUser {Username = "OFGAdmin", GivenName = "Admin", FamilyName = "User"};
                        manager.Persist(user);

                        string password = RandomString.GetRandomString(10);

                        TGUserPassword tgPassword = TGUserPassword.GetNew(user.Guid, user.Username, password);
                        manager.Persist(tgPassword);

                        TGUserRole userAdminRole = new TGUserRole
                        {
                            Active = true,
                            Name = UserRoles.UserAdmin,
                            ParentGuid = user.Guid
                        };
                        manager.Persist(userAdminRole);

                        TGUserRole dataAdminRole = new TGUserRole
                        {
                            Active = true,
                            Name = UserRoles.DataAdmin,
                            ParentGuid = user.Guid
                        };
                        manager.Persist(dataAdminRole);

                        JsonObjects.NewUser jNewUser = new NewUser(user, password);

                        return View["dev_buildadminuserresult.sshtml", jNewUser]; 
                    }
                }

                return null;
            };
        }
    }
}
