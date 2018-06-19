<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxPage.aspx.cs" Inherits="WebApp.WebForm.AjaxPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Scripts/jquery-3.3.1.js"></script>
    <script src="Scripts/AjaxPage.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            请输入要计算MD5的字符串：<br />
            <input type="text" style="width: 200px" id="txtInput" value="Fish Li" />
            <input type="button" value="计算" id="btnSubmit" />
        </p>
        <hr />
        <p id="md5Result"></p>
    </form>
</body>
</html>
