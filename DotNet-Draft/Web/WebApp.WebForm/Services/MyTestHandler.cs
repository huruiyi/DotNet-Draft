using System.Web;

namespace WebApp.WebForm.Services
{
    public class MyTestHandler : IHttpHandler
    {
        private CusCounter _counter = new CusCounter();

        public bool IsReusable
        {
            get { return true; }
            //get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            _counter.ShowCountAndRequestInfo(context);
        }
    }
}