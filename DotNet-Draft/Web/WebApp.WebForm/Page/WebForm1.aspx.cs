using System;

namespace WebApp.WebForm.Page
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string Name
        {
            get
            {
                return TextBox1.Text;
            }
        }

        public string EMail
        {
            get
            {
                return TextBox2.Text;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("webform2.aspx");
        }
    }
}