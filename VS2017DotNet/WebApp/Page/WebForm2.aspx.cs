using System;

namespace WebApp.Page
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //创建原始窗体的实例
            WebForm1 wf1;
            //获得实例化的句柄
            wf1 = (WebForm1)Context.Handler;
            Label1.Text = wf1.Name;
            Label2.Text = wf1.EMail;
        }
    }
}