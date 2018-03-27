using System.ComponentModel.Composition;
using System.Web.Mvc;
using WebApp.Mvc.Interfaces;

namespace WebApp.Mvc.Controllers
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

        // GET: Home
        public ActionResult Index()
        {
            _logger.Write("MEFMVCApp: Executing the Index() action method.");

            return View();
        }
    }
}