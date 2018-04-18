using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpeakingAspNetSite.Startup))]
namespace SpeakingAspNetSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
