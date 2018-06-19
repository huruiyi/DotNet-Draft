using System;
using System.Web;
using WebApp.WebForm.Services;

namespace WebApp.WebForm
{
    public class Global : System.Web.HttpApplication
    {
        //protected void Application_PostResolveRequestCache(object sender, EventArgs e)
        //{
        //    HttpApplication app = (HttpApplication)sender;
        //    if( app.Request.FilePath.EndsWith(".ashx", StringComparison.OrdinalIgnoreCase) )
        //        app.Context.RemapHandler(new MyTestHandler());
        //}

        // 或者是下面这样

        protected void Application_PostResolveRequestCache(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            if (app.Request.FilePath.EndsWith("/Handlers/TestRemapHandler.ashx", StringComparison.OrdinalIgnoreCase))
                app.Context.RemapHandler(new MyTestHandler());
        }

        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}