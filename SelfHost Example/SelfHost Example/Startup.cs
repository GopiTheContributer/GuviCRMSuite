using System.Web.Http;
using Owin;
using System.Web.Http.Cors;

namespace GuviCRMSuite
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // First Endpoint
            var config = new HttpConfiguration();
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            //var cors = new EnableCorsAttribute("*", "*", "GET, POST, OPTIONS");
           // var cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);

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