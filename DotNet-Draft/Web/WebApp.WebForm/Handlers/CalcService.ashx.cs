using System;
using System.Web;
using System.Web.Services;

namespace WebApp.WebForm.Handlers
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class CalcService : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int i = Convert.ToInt32(context.Request["i"]);
            context.Response.Write(i * 2);
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
