using AcspNet.Owin;
using Owin;

namespace ASP.NETNowin
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseAcspNet();
        }
    }
}