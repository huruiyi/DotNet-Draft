using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Apress.Recipes.WebApi.Filters
{
    public class AcceptReturnType : ActionNameSelectorAttribute
    {
        private readonly IEnumerable<string> _withReturnType;
        private readonly IEnumerable<string> _withoutReturnType;

        public AcceptReturnType(string returnType)
        {
            string[] strArray = returnType.Split(',');
            this._withReturnType = strArray.Where(t => !t.StartsWith("!"));
            this._withoutReturnType = strArray.Where(t => t.StartsWith("!")).Select(t => t.Substring(1));
        }

        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            string str = controllerContext.RouteData.Values.TryGetValue("accept", out var obj)
                         && obj != null ? obj.ToString() : controllerContext.HttpContext.Request["accept"]
                  ?? controllerContext.HttpContext.Request.Headers["accept"];
            return (!this._withReturnType.Any() || this._withReturnType.Any(str.Contains))
                   && (!this._withoutReturnType.Any() || !this._withoutReturnType.Any(str.Contains));
        }
    }
}