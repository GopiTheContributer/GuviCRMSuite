using System.Web.Http;
using Owin;

namespace GuviCRMSuite
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // First Endpoint
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Second Endpoint
            config.Routes.MapHttpRoute(
                name: "Api1",
                routeTemplate: "api1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);
        }
    }
}