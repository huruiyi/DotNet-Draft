using AcspNet;
using AcspNet.Attributes;
using AcspNet.Responses;

namespace ASP.NETKatana.Controllers
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