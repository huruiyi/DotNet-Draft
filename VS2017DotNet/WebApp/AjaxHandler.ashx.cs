using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    /// <summary>
    /// AjaxHandler 的摘要说明
    /// </summary>
    public class AjaxHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"];
            switch (action)
            {
                case "Demo1":
                    Demo1Process(context);
                    break;
            }
        }

        void Demo1Process(HttpContext context)
        {
            
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