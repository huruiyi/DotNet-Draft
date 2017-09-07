using System.ServiceProcess;
using Simplify.AutomatedWindowsServices;

namespace ASP.NETWindowsService
{
    class Program
    {
        static void Main()
        {
#if DEBUG
			System.Diagnostics.Debugger.Launch();
#endif

            ServiceBase.Run(new BasicServiceHandler<WebApplicationStartup>(true));
        }
    }
}
