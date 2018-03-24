using System;

namespace WebApp.Page
{
    public partial class ExecutePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("a=" + Request.QueryString["a"]);
            Response.Write("b=" + Request.QueryString["b"]);
        }
    }
}