using Artech.MiniMvc;
using System;

namespace WebApp.MiniMvc
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add("default", new Route { Url = "{controller}/{action}" });
            ControllerBuilder.Current.SetControllerFactory(new DefaultControllerFactory());
            ControllerBuilder.Current.DefaultNamespaces.Add("WebApp.MiniMvc");
        }
    }
}