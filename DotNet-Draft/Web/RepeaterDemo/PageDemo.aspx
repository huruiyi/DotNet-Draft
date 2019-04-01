<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageDemo.aspx.cs" Inherits="RepeaterDemo.PageDemo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Repeater控件的分页实现</title>
    <style type="text/css">
        ul {
            margin: 0px;
            padding: 0px;
            list-style: none;
            line-height: 180%;
        }

        .pageBar {
            margin-top: 10px;
        }

            .pageBar a {
                color: #333;
                font-size: 12px;
                margin-right: 10px;
                padding: 4px;
                border: 1px solid #ccc;
                text-decoration: none;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="rptDocumentList" runat="server">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <%# DataBinder.Eval(Container.DataItem, "Title")%></li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="pageBar">
            <asp:Literal ID="ltlPageBar" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
