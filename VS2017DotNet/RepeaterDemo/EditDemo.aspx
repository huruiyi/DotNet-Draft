<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditDemo.aspx.cs" Inherits="RepeaterDemo.EditDemo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Repeater控件编辑、删除、更新记录</title>
    <style type="text/css">
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Repeater ID="rptUser" runat="server" onitemcommand="rptUser_ItemCommand" 
        onitemdatabound="rptUser_ItemDataBound">
        <HeaderTemplate>
            <table width="960" align="center" cellpadding="3" cellspacing="1" style="background-color: #ccc;">
                <thead style="background-color: #eee;">
                    <tr>
                        <th width="10%">
                            用户ID
                        </th>
                        <th>
                            用户名
                        </th>
                        <th width="22%">
                            邮件
                        </th>
                        <th width="20%">
                            QQ
                        </th>
                        <th width="15%">
                            注册时间
                        </th>
                        <th width="12%">
                            操作
                        </th>
                    </tr>
                </thead>
                <tbody style="background-color: #fff;">
        </HeaderTemplate>
        <ItemTemplate>
            <asp:Panel ID="plItem" runat="server">
                <tr style="text-align: center;">
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "UserId")%>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Name")%>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Email")%>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "QQ")%>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "AddTime","{0:yyyy-MM-dd}")%>
                    </td>
                    <td> <asp:LinkButton runat="server" ID="lbtEdit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UserId")%>'
                     CommandName="Edit" Text="编辑"></asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton runat="server" ID="lbtDelete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UserId")%>'
                     CommandName="Delete" Text="删除" OnClientClick="return confirm('确定要删除？')"></asp:LinkButton>
                    </td>
                </tr>
            </asp:Panel>
            <asp:Panel ID="plEdit" runat="server">
                <tr style="text-align: center;">
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "UserId")%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" Text='<%# DataBinder.Eval(Container.DataItem,"Name") %>'
                            runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" Text='<%# DataBinder.Eval(Container.DataItem,"Email") %>'
                            runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtQQ" Text='<%# DataBinder.Eval(Container.DataItem,"QQ") %>' runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "AddTime","{0:yyyy-MM-dd}")%>
                    </td>
                    <td>
                      <asp:LinkButton runat="server" ID="lbtUpdate" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UserId")%>'
                     CommandName="Update" Text="更新"></asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton runat="server" ID="lbtCancel" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UserId")%>'
                     CommandName="Cancel" Text="取消"></asp:LinkButton>
                    </td>
                </tr>
            </asp:Panel>
        </ItemTemplate>
        <FooterTemplate>
            </tbody></table>
        </FooterTemplate>
    </asp:Repeater>
    </form>
</body>
</html>
