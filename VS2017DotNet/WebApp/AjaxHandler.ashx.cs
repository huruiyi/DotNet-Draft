using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
                case "Demo1_Success":
                    Demo1_Success(context);
                    break;

                case "Demo2_Error":
                    Demo2_Error(context);
                    break;
            }
        }

        private void Demo2_Error(HttpContext context)
        {
            throw new NotImplementedException();
        }

        private void Demo1_Success(HttpContext context)
        {
            List<object> objList = new List<object>();
            for (int i = 0; i < 10; i++)
            {
                objList.Add(new
                {
                    Id = i,
                    Name = "Name" + i
                });
            }
            context.Response.Write(JsonConvert.SerializeObject(objList));
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