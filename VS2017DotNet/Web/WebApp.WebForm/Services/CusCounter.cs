using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.WebForm.Services
{
    /// <summary>
    /// 一个简单的计数器
    /// </summary>
    public class CusCounter
    {
        private int _count;

        public void ShowCountAndRequestInfo(HttpContext context)
        {
            _count++;
            context.Response.ContentType = "text/plain";
            context.Response.Write("count: " + _count.ToString());
            context.Response.Write("\r\n");
            context.Response.Write("Request.RawUrl：" + context.Request.RawUrl);
            context.Response.Write("\r\n");
            context.Response.Write("本示例由 Fish Li 提供。");
            context.Response.Write("http://www.cnblogs.com/fish-li");
        }
    }
}