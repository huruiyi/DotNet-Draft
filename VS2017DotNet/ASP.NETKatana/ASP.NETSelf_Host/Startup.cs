using AcspNet.Owin;
using Owin;

namespace ASP.NETSelf_Host
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseAcspNet();
        }
    }
}