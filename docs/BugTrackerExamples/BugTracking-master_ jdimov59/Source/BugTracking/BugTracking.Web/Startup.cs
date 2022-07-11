using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BugTracking.Web.Startup))]
namespace BugTracking.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
