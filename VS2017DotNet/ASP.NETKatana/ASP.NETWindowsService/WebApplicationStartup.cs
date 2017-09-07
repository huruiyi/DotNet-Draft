using Microsoft.Owin.Hosting;

namespace ASP.NETWindowsService
{
    public class WebApplicationStartup
    {
        public void Run()
        {
            WebApp.Start<Startup>("http://+:8080");
        }
    }
}