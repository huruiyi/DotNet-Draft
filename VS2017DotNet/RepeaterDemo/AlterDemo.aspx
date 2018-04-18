<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlterDemo.aspx.cs" Inherits="RepeaterDemo.AlterDemo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Repeater多行间隔显示分隔符的方法</title>
    <style type="text/css">
        ul
        {
            margin:15px 0px; 
            padding:0px;
            list-style-type:none;
            padding:4px;
        }
        .sep  
        {
            margin:5px 0px;
            border-bottom:1px dashed #333;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Repeater ID="rptList" runat="server" 
            onitemdatabound="rptList_ItemDataBound">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <asp:Literal ID="ltlTitle" runat="server"></asp:Literal></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul></FooterTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
