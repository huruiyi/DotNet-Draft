<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NestingDemo.aspx.cs" Inherits="RepeaterDemo.NestingDemo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>在Repeater中嵌套使用Repeater</title>
    <style type="text/css">
        .listBox
        {
            width: 300px;
        }
        .listBox .title
        {
            padding: 4px;
            background-color: #eee;
            color: #555;
            font-size: 16px;
            font-weight: bolder;
            border-bottom: 1px solid #000;
        }
        .listBox .content
        {
            padding: 5px;
            padding-left: 20px;
        }
        .listBox .content ul
        {
            margin: 0px;
            padding: 0px;
            list-style-type: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="rptCategoryList" runat="server" OnItemDataBound="rptCategoryList_ItemDataBound">
            <ItemTemplate>
                <div class="listBox">
                    <div class="title">
                        <asp:Literal ID="ltlTitle" runat="server"></asp:Literal></div>
                    <div class="content">
                        <ul>
                            <asp:Repeater ID="rptProductList" runat="server" OnItemDataBound="rptProductList_ItemDataBound">
                                <ItemTemplate>
                                    <li>
                                        <asp:Literal ID="ltlTitle" runat="server"></asp:Literal>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
