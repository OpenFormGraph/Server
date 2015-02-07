using Nancy;
using OpenFormGraph.Library.Managers;
using TreeGecko.Library.Common.Helpers;

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

            Get["/BuildDB"] = _parameters =>
            {
                bool devMode = Config.GetBooleanValue("DevMode", false);

                if (devMode)
                {
                    OpenFormGraphStructureManager structureManager = new OpenFormGraphStructureManager();
                    structureManager.BuildDB();

                    return View["dbbuildresult.sshtml"];
                }
                else
                {
                    return null;
                }

            };
        }
    }
}
