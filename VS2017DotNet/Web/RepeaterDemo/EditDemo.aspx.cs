using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace RepeaterDemo
{
    /*
        WEB开发者网络 
        http://www.admin10000.com

        Repeater控件实现编辑、更新、删除操作 
        http://www.admin10000.com/Document/82.html
    */

    public partial class EditDemo : System.Web.UI.Page
    {

        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
            }

        }

        private void BindGrid()
        {
           
            string strSQL = "SELECT * FROM [User]";
            OleDbConnection objConnection = new OleDbConnection(GetStrConnection());
            objConnection.Open();
            OleDbCommand objCommand = new OleDbCommand(strSQL, objConnection);
            OleDbDataReader reader = objCommand.ExecuteReader(CommandBehavior.CloseConnection);
            rptUser.DataSource = reader;
            rptUser.DataBind();
        }


        protected void rptUser_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                System.Data.Common.DbDataRecord record = (System.Data.Common.DbDataRecord)e.Item.DataItem;
                int userId = int.Parse(record["UserId"].ToString());
                if (userId != id)
                {
                    ((Panel)e.Item.FindControl("plItem")).Visible = true;
                    ((Panel)e.Item.FindControl("plEdit")).Visible = false;
                }
                else
                {
                    ((Panel)e.Item.FindControl("plItem")).Visible = false;
                    ((Panel)e.Item.FindControl("plEdit")).Visible = true;
                }
                
            }
        }

        protected void rptUser_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                id = int.Parse(e.CommandArgument.ToString());
            }
            else if (e.CommandName == "Cancel")
            {
                id = -1;
            }
            else if (e.CommandName == "Update")
            {
                string name = ((TextBox)this.rptUser.Items[e.Item.ItemIndex].FindControl("txtName")).Text.Trim();
                string email = ((TextBox)this.rptUser.Items[e.Item.ItemIndex].FindControl("txtEmail")).Text.Trim();
                string qq = ((TextBox)this.rptUser.Items[e.Item.ItemIndex].FindControl("txtQQ")).Text.Trim();
                string strSQL = "UPDATE [User] SET Name=@Name,Email=@Email,QQ=@QQ WHERE UserId=@UserId";
                OleDbConnection objConnection = new OleDbConnection(GetStrConnection());
                OleDbCommand objCommand = new OleDbCommand(strSQL, objConnection);
                objCommand.Parameters.Add("@Name", OleDbType.VarWChar);
                objCommand.Parameters["@Name"].Value = name;
                objCommand.Parameters.Add("@Email", OleDbType.VarWChar);
                objCommand.Parameters["@Email"].Value = email;
                objCommand.Parameters.Add("@QQ", OleDbType.VarWChar);
                objCommand.Parameters["@QQ"].Value = qq;
                objCommand.Parameters.Add("@UserId", OleDbType.Integer);
                objCommand.Parameters["@UserId"].Value = int.Parse(e.CommandArgument.ToString());
                objConnection.Open();
                objCommand.ExecuteNonQuery();
                objConnection.Close();

            }
            else if (e.CommandName == "Delete")
            {
                string strSQL = "DELETE * FROM [User] WHERE UserId=@UserId";
                OleDbConnection objConnection = new OleDbConnection(GetStrConnection());
                OleDbCommand objCommand = new OleDbCommand(strSQL, objConnection);
                objCommand.Parameters.Add("@UserId", OleDbType.Integer);
                objCommand.Parameters["@UserId"].Value = int.Parse(e.CommandArgument.ToString());
                objConnection.Open();
                objCommand.ExecuteNonQuery();
                objConnection.Close();
            }

            BindGrid();
        }


        private string GetStrConnection()
        {
            return "Provider=Microsoft.Jet.OleDb.4.0;data source=" + Server.MapPath("~/Database/test.mdb");
        }
    }
}
