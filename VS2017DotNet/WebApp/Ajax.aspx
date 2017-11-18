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
            $("#btnDemo1").unbind("click").bind("click", Demo1);
        });
        function Demo1() {
            $.ajax({
                type: "post",
                url: "./AjaxHandler.ashx?action=Demo1",
                data:{
                    "Id": 123,
                    "Name": "姓名",
                    "Age": "30"
                },
                dataType: "json",
                success: function (data) {

                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel text-center ">
            <button class="btn btn-danger" id="btnDemo1">测试1</button>
        </div>
    </form>
</body>
</html>