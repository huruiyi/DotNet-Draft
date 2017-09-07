using AcspNet.Owin;
using Owin;

namespace ASP.NETKatana
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseAcspNet();
        }
    }
}