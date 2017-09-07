using AcspNet;
using AcspNet.Attributes;
using AcspNet.Responses;

namespace ASP.NETSelf_Host.Controllers
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
