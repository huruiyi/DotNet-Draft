using AcspNet;
using AcspNet.Attributes;
using AcspNet.Responses;

namespace ASP.NETWindowsService.Controllers
{
    [Get("/")]
    public class DefaultController : Controller
    {
        public override ControllerResponse Invoke()
        {
            return new MessageBox("Hello world!");
        }
    }
}
