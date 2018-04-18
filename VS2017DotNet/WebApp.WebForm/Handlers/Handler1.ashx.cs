using System.Web;
using WebApp.WebForm.Services;

namespace WebApp.WebForm.Handlers
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
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
                // 如果在配置文件中启用ReusableAshxHandlerFactory，那么这里将会被执行。
                // 可以尝试切换下面二行代码测试效果。

                //throw new Exception("这里不起作用。");
                return false;
            }
        }
    }
}