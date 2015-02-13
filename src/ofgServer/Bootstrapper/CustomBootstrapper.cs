using OpenFormGraph.Web.Helpers;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.Session;
using Nancy.TinyIoc;

namespace OpenFormGraph.Web.Bootstrapper
{
    public class CustomBoostrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureRequestContainer(TinyIoCContainer _container, Nancy.NancyContext _context)
        {
            base.ConfigureRequestContainer(_container, _context);
            _container.Register<IUserMapper, UserMapper>();
        }

        protected override void ApplicationStartup(TinyIoCContainer _container, IPipelines _pipelines)
        {
            CookieBasedSessions.Enable(_pipelines);
            Nancy.Security.Csrf.Enable(_pipelines);
        }

        protected override void ConfigureConventions(NancyConventions _conventions)
        {
            base.ConfigureConventions(_conventions);
           
            _conventions.StaticContentsConventions.Add(
                StaticContentConventionBuilder.AddDirectory("css", @"css")
            );

            _conventions.StaticContentsConventions.Add(
                StaticContentConventionBuilder.AddDirectory("js", @"js")
            );

            _conventions.StaticContentsConventions.Add(
                StaticContentConventionBuilder.AddDirectory("js/controllers", @"js/controllers")
            );

            _conventions.StaticContentsConventions.Add(
                StaticContentConventionBuilder.AddDirectory("js/services", @"js/services")
            );

            _conventions.StaticContentsConventions.Add(
                StaticContentConventionBuilder.AddDirectory("images", @"images")
            );

            _conventions.StaticContentsConventions.Add(
                StaticContentConventionBuilder.AddDirectory("views", @"ClientViews")
            );
        }
    }
}