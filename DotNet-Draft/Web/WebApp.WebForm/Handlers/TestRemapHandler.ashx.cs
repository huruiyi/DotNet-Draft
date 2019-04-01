using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.WebForm.Handlers
{
    /// <summary>
    /// TestRemapHandler 的摘要说明
    /// </summary>
    public class TestRemapHandler : IHttpHandler
    {
        // 可以打开Global.asax，启用或者注释 Application_PostResolveRequestCache来查看效果
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello TestRemapHandler");

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}