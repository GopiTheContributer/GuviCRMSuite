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

            
            //Login route
            config.Routes.MapHttpRoute(
                name: "loginapi",
                routeTemplate: "apilogin/{controller}/");

            //default Route
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);
        }
    }
}