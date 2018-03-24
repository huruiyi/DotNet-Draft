<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ajax.aspx.cs" Inherits="WebApp.Ajax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/jquery-3.2.1.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnDemo1").unbind("click").bind("click",
                function () {
                    AjaxDemo("./AjaxHandler.ashx?action=Demo1_Success");
                }
            );
            $("#btnDemo2").unbind("click").bind("click",
                function () {
                    AjaxDemo("./AjaxHandler.ashx?action=Demo2_Error");
                }
            );
        });
        function AjaxDemo(url) {
            $.ajax({
                type: "post",
                url: url,
                async: true,
                data: {
                    "Id": 123,
                    "Name": "姓名",
                    "Age": "30"
                },
                dataType: "json",
                beforeSend: function (data) {
                    console.log(data);
                    console.log("beforeSend");
                },
                error: function (data) {
                    console.log(data);
                    console.log("error");
                },
                complete: function (data) {
                    console.log(data);
                    console.log("complete");
                },
                success: function (data) {
                    console.log(data);
                    console.log("success");
                },
                ajaxSend: function (data) {
                    console.log(data);
                    console.log("ajaxSend");
                },
                ajaxSuccess: function (data) {
                    console.log(data);
                    console.log("ajaxSuccess");
                },
                ajaxError: function (data) {
                    console.log(data);
                    console.log("ajaxError");
                },
                ajaxComplete: function (data) {
                    console.log(data);
                    console.log("ajaxComplete");
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" onsubmit="return false;">
        <div class="panel text-center ">
            <button class="btn btn-success" id="btnDemo1">测试请求成功</button>
            <button class="btn btn-danger" id="btnDemo2">请求请求失败</button>
        </div>
    </form>
    <%Response.Write(DateTime.Now); %>
</body>
</html>