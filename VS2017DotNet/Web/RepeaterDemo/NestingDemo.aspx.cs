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

        Repeater中嵌套使用Repeater
        http://www.admin10000.com/Document/84.html
    */

    public partial class NestingDemo : System.Web.UI.Page
    {
        DataTable dtCategory = null;
        DataTable dtProduct = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.dtCategory = GetCategoryTable();
                this.dtProduct = GetProductTable();
                rptCategoryList.DataSource = dtCategory;
                rptCategoryList.DataBind();
            }
        }

        // 准备一张分类表
        DataTable GetCategoryTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CategoryId", typeof(int));
            dt.Columns.Add("CategoryTitle", typeof(string));
            for (int i = 1; i <= 3; i++)
            {
                DataRow row = dt.NewRow();
                row["CategoryId"] = i;
                row["CategoryTitle"] = "分类名字 " + i + "";
                dt.Rows.Add(row);
            }
            return dt;
        }
        
        // 准备一张产品表
        DataTable GetProductTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductTitle", typeof(string));
            dt.Columns.Add("CategoryId", typeof(int));
            for (int i = 1; i <= 9; i++)
            {
                DataRow row = dt.NewRow();
                row["ProductTitle"] = "产品名字 " + i + "";
                if (i > 6) row["CategoryId"] = 3;
                else if (i > 3) row["CategoryId"] = 2;
                else row["CategoryId"] = 1;
                dt.Rows.Add(row);
            }
            return dt;
        }

        // 获取某个类别的产品
        DataTable GetProductTable(int categoryId)
        {
            DataView dv = this.dtProduct.DefaultView;
            dv.RowFilter = " CategoryId=" + categoryId + " ";
            return dv.ToTable();
        }

        protected void rptCategoryList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                Literal ltlTitle = (Literal)e.Item.FindControl("ltlTitle");
                ltlTitle.Text = drv["CategoryTitle"].ToString();
                Repeater rptProductList = (Repeater)e.Item.FindControl("rptProductList");
                rptProductList.DataSource = GetProductTable(Convert.ToInt32(drv["CategoryId"]));
                rptProductList.DataBind();
            }
        }

        protected void rptProductList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                Literal ltlTitle = (Literal)e.Item.FindControl("ltlTitle");
                ltlTitle.Text = drv["ProductTitle"].ToString();
            }
        }
    }
}
