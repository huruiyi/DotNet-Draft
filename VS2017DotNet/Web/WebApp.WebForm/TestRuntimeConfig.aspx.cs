using System;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;

namespace WebApp.WebForm
{
    public partial class TestRuntimeConfig : System.Web.UI.Page
    {
        protected string HttpHandlers;

        protected void Page_Load(object sender, EventArgs e)
        {
            string typeName = typeof(HttpRequest).AssemblyQualifiedName
                .Replace("HttpRequest", "Configuration.RuntimeConfig");
            Type type = Type.GetType(typeName);

            bool useAppConfig = Request.QueryString["useAppConfig"] == "1";

            // 由于RuntimeConfig类型的可见性是internal，
            // 所以，我不能直接用它声明变量，只能使用object类型
            object config = null;

            if (useAppConfig)
                config = type.InvokeMember("GetAppConfig", BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.NonPublic, null, null, null);
            else
                config = type.InvokeMember("GetConfig", BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.NonPublic, null, null, new object[] { this.Context });

            HttpHandlersSection section = (HttpHandlersSection)type.InvokeMember("HttpHandlers", BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, config, null);

            HttpHandlers = string.Format("总共 {0} 个配置项。<br />", section.Handlers.Count) +
                           string.Join("<br />", (
                               from h in section.Handlers.Cast<HttpHandlerAction>()
                               let action = string.Format("path=\"{0}\" verb=\"{1}\" validate=\"{2}\" type=\"{3}\"", h.Path, h.Verb, h.Validate, h.Type)
                               select action).ToArray());
        }
    }
}