<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.WebForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p><a href="AjaxPage.aspx" target="_blank">AjaxPage.aspx</a></p>
        <p><a href="abc.test?id=1" target="_blank">abc.test</a></p>

        <p><a href="Handlers/TestRemapHandler.ashx" target="_blank">TestRemapHandler.ashx</a></p>
        <p><a href="Handlers/Handler1.ashx?id=2" target="_blank">Handler1.ashx  [IsReusable is false]</a></p>
        <p><a href="Handlers/Handler2.ashx?id=3" target="_blank">Handler2.ashx  [IsReusable is true]</a></p>

        <p><a href="TestRuntimeConfig.aspx" target="_blank">TestRuntimeConfig.aspx</a></p>
        <p><a href="TestRuntimeConfig.aspx?useAppConfig=1" target="_blank">TestRuntimeConfig.aspx?useAppConfig=1</a></p>

    </form>
</body>
</html>
