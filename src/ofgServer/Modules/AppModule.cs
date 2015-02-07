using Nancy;

namespace OpenFormGraph.Web.Modules
{
    public class AppModule : NancyModule
    {
        public AppModule()
        {
            Get["/"] = _parameters =>
            {
                return View["/index.sshtml"];
            }; 
        }
    }
}
