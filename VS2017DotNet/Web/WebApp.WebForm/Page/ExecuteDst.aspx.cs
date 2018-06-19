using System;

namespace WebApp.WebForm.Page
{
    //https://msdn.microsoft.com/zh-cn/library/ms178472.aspx
    /*
        1:Page_PreInit
        2:Page_Init
        3:Page_InitComplete
        4:Page_PreLoad
        5:Page_Load
        6:Page_LoadComplete
        7:Page_PreRender
        8:Page_PreRenderComplete
        9:Page_SaveStateComplete
     */

    public partial class ExecuteDst : System.Web.UI.Page
    {
        private int num;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            num++;
            Response.Write(num + ":Page_PreInit<br/>");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            num++;
            Response.Write(num + ":Page_Init<br/>");
        }

        protected void Page_InitComplete(object sender, EventArgs e)
        {
            num++;
            Response.Write(num + ":Page_InitComplete<br/>");
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            num++;
            Response.Write(num + ":Page_PreLoad<br/>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            num++;
            Response.Write(num + ":Page_Load<br/>");
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            num++;
            Response.Write(num + ":Page_LoadComplete<br/>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            num++;
            Response.Write(num + ":Page_PreRender<br/>");
        }

        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            num++;
            Response.Write(num + ":Page_PreRenderComplete<br/>");
        }

        protected void Page_SaveStateComplete(object sender, EventArgs e)
        {
            num++;
            Response.Write(num + ":Page_SaveStateComplete<br/>");
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            num++;
            //相应上下文不存在
            //Response.Write(num + ":Page_Unload<br/>");
        }
    }
}