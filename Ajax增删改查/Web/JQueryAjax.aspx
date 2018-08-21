<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JQueryAjax.aspx.cs" Inherits="Web.JQueryAjax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="jquery-3.3.1.min.js"></script>
    <script>
        $(function () {
            $("#btn").click(function () {
                $.get("AjaxDemo.ashx", { "name": "list" }, function (data) {
                    alert(data);
                });
            })

            $("#btn2").click(function () {
                $.post("AjaxDemo.ashx", { "name": "maliu" }, function (data) {
                    alert(data);
                })
            });

            $("#btnAjax").click(function () {
                $.ajax({
                    type: "post",
                    url: "AjaxDemo.ashx",
                    data: "name=john",
                    success: function (msg) {
                        alert(msg);

                        //xml
                        var a = $(data).find("book").length;

                    }
                })
            })

            //load()方法的传递方式根据参数data来自动指定。如果没有参数传递，则采用GET方式传递；反之，则自动转换为POST方式。 

            //responseTxt - 包含调用成功时的结果内容
            //statusTXT - 包含调用的状态 success  error  等
            //xhr - 包含 XMLHttpRequest 对象

            $("#btn3").click(function () {
                //$("#div").load("test.txt");
                $("#div").load("AjaxDemo.ashx", { "name": "load" }, function (responseTxt) {
                    //alert(responseText);
                    alert(responseTxt);
                });
            })


        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="button" value="JQuery的Ajax" id="btn" />
            <input type="button" value="JQuery的AjaxPost" id="btn2" />
            <input type="button" value="JQuery的Ajax" id="btnAjax" />
            <input type="button" value="JQuery的Ajax" id="btn3" />
        </div>
        <div id="div"></div>
    </form>
</body>
</html>
