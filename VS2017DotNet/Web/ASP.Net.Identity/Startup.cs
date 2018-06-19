using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASP.Net.Identity.Startup))]
namespace ASP.Net.Identity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
