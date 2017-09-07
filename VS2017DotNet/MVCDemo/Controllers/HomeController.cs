using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        private ILogger _logger;

        public HomeController() :
            this(new TraceLogger())
        {
        }

        public HomeController([Import("myTraceLogger")]ILogger logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            _logger.Write("MEFMVCApp: Executing the Index() action method.");
            return View();
        }
    }
}