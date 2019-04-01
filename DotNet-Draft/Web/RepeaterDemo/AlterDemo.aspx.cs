using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace RepeaterDemo
{
    /*
        WEB开发者网络 
        http://www.admin10000.com

        Repeater多行间隔显示分隔符的方法
        http://www.admin10000.com/Document/83.html
    */

    public partial class AlterDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                rptList.DataSource = GetTable();
                rptList.DataBind();
            }
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                Literal ltlTitle = (Literal)e.Item.FindControl("ltlTitle");
                ltlTitle.Text = drv.Row["title"].ToString();
                if ((e.Item.ItemIndex + 1) % 5 == 0 && (e.Item.ItemIndex + 1) < 15)
                {
                    System.Web.UI.LiteralControl ul = new LiteralControl("</ul><div class=\"sep\"></div><ul>");
                    e.Item.Controls.Add(ul);
                }
            }
        }

        DataTable GetTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("title", typeof(string));
            for (int i = 1; i <= 15; i++)
            {
                DataRow row = dt.NewRow();
                row["title"] = "这是文章标题 " + i + "";
                dt.Rows.Add(row);
            }
            return dt;
        }

    }
}
