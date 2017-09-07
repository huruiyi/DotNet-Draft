using AcspNet;
using AcspNet.Attributes;
using AcspNet.Responses;

namespace ASP.NETNowin.Controllers
{
    [Get("/")]
    public class DefaultController : Controller
    {
        public override ControllerResponse Invoke()
        {
            return new Tpl("Hello world!");
        }
    }
}
