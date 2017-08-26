using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GuviCRMSuiteUI.Startup))]
namespace GuviCRMSuiteUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
