using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;

namespace WebApp.WebForm.Page
{
    public partial class ExportToWord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void Export()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "utf-8";

            string fileName = HttpUtility.UrlEncode("对账单" + ".doc");
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            Response.ContentEncoding = Encoding.GetEncoding("utf-8");

            Response.ContentType = "application/ms-word";
            Page.EnableViewState = false;

            StringWriter oStringWriter = new StringWriter();
            HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);

            exportTableInfo.RenderControl(oHtmlTextWriter);

            Response.Write(oStringWriter.ToString());
            Response.End();
        }
    }
}
