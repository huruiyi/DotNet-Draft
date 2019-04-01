using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Artech.MiniMvc;

namespace WebApp.MiniMvc
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index(SimpleModel model)
        {
            string content = $"Controller: {model.Controller}<br/>Action:{model.Action}";
            return new RawContentResult(content);
        }
    }
}