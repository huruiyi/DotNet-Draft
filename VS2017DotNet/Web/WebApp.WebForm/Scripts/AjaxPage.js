$(function () {
    $("#btnSubmit").click(function () {
        $.ajax({
            // 注意：下面的二个url地址都是可以使用的。
            url: "/AjaxServices/GetMd5.aspx",
            //url: "/AjaxServices.GetMd5.aspx",

            // 注意：下面的二种type的设置也都是可以使用的。
            type: "POST",
            //type: "GET",

            data: { str: $("#txtInput").val() },
            dataType: "text",
            success: function (responseText) {
                $("#md5Result").text(responseText);
            }
        });
    });
});