using System.Web;
using WebApp.WebForm.Services;

namespace WebApp.WebForm.Handlers
{
    /// <summary>
    /// Handler2 的摘要说明
    /// </summary>
    public class Handler2 : IHttpHandler
    {
        private CusCounter _counter = new CusCounter();

        public void ProcessRequest(HttpContext context)
        {
            _counter.ShowCountAndRequestInfo(context);
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}