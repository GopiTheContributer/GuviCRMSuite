using System.Web.Http;
using Owin;
using System.Web.Http.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
//using Microsoft.AspNet.Identity.Owin;
//using Microsoft.Owin.Security;
//using Microsoft.Owin.Security.Cookies;


namespace GuviCRMSuite
{
    public class Startup
    {
        static string PublicClientId = null;
        static OAuthAuthorizationServerOptions OAuthOptions = null;
        public void Configuration(IAppBuilder app)
        {
            // First Endpoint
            var config = new HttpConfiguration();
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            
            //for token based authentication
            //PublicClientId = "self";
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions {
                TokenEndpointPath = new Microsoft.Owin.PathString("/token"),
                Provider = new OAuthAuthorizationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                AllowInsecureHttp = true
            });
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            //Login route
            config.Routes.MapHttpRoute(
                name: "loginapi",
                routeTemplate: "apilogin/{controller}/");

            //Scheduler route
            config.Routes.MapHttpRoute(
                name: "schedulerapi",
                routeTemplate: "scheduler/{controller}/");

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