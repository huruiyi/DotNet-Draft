using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace RepeaterDemo
{
    /*
        WEB开发者网络 
        http://www.admin10000.com

        Repeater控件的分页实现 
        http://www.admin10000.com/Document/81.html
    */

    public partial class PageDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int pageIndex = 1;
                try
                {
                    pageIndex = Convert.ToInt32(Request.QueryString["Page"]);
                    if (pageIndex <= 0) pageIndex = 1;
                }
                catch
                {
                    pageIndex = 1;
                }
                DataTable dt = GetDocumentTable();
                // PagedDataSource 类封装那些允许数据源控件执行分页操作的属性。
                // 如果控件开发人员需对自定义数据绑定控件提供分页支持，即可使用此类。
                PagedDataSource pds = new PagedDataSource(); 
                pds.DataSource = dt.DefaultView; // 设置数据源
                pds.AllowPaging = true; // 设置指示是否启用分页的值
                pds.PageSize = 5; // 设置要在每页显示的数量
                pds.CurrentPageIndex = pageIndex - 1; // 设置当前页的索引。
                rptDocumentList.DataSource = pds;
                rptDocumentList.DataBind();
                ltlPageBar.Text = GetPageBar(pds);
            }
        }

        // 分页条
        private string GetPageBar(PagedDataSource pds)
        {
            string pageBar = string.Empty;
            int currentPageIndex = pds.CurrentPageIndex + 1;
            if (currentPageIndex == 1)
            {
                pageBar += "<a href=\"javascript:void(0)\">首页</a>";
            }
            else
            {
                pageBar += "<a href=\"" + Request.CurrentExecutionFilePath + "?Page=1\">首页</a>";
            }

            if ((currentPageIndex - 1) < 1)
            {
                pageBar += "<a href=\"javascript:void(0)\">上一页</a>";
            }
            else
            {
                pageBar += "<a href=\"" + Request.CurrentExecutionFilePath + "?Page=" + (currentPageIndex - 1) + "\">上一页</a>";
            }

            if ((currentPageIndex + 1) > pds.PageCount)
            {
                pageBar += "<a href=\"javascript:void(0)\">下一页</a>";
            }
            else
            {
                pageBar += "<a href=\"" + Request.CurrentExecutionFilePath + "?Page=" + (currentPageIndex + 1) + "\">下一页</a>";
            }
            if (currentPageIndex == pds.PageCount)
            {
                pageBar += "<a href=\"javascript:void(0)\">末页</a>";
            }
            else
            {
                pageBar += "<a href=\"" + Request.CurrentExecutionFilePath + "?Page=" + pds.PageCount + "\">末页</a>";
            }
            return pageBar;
        }

        // 创建测试表
        DataTable GetDocumentTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DocumentId", typeof(int));
            dt.Columns.Add("Title", typeof(string));
            for (int i = 1; i <= 30; i++)
            {
                DataRow row = dt.NewRow();
                row["DocumentId"] = i;
                row["Title"] = "文档标题 " + i + "";
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}
