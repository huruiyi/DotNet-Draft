using AcspNet.Owin;
using Owin;

namespace ASP.NETWindowsService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseAcspNet();
        }
    }
}