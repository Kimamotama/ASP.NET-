<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JsonDemo.aspx.cs" Inherits="Web.JsonDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="jquery-3.3.1.min.js"></script>
    <script>
        $(function () {
            $("#btn").click(function () {
                //1.
                //$.post("Json.ashx", {}, function (data) {
                //    alert(data.Name);
                //    console.log(data.Name);
                //}, "json");

                //2.
                //$.post("Json.ashx", {}, function (data) {
                //    //将json字符串转成json对象
                //    var serverdata = $.parseJSON(data);
                //    alert(serverdata.Name);
                //});   

                //3.
                $.getJSON("Json.ashx", {}, function (data) {
                    alert(data.Name+"1");
                })

            })
        })
    </script>
    <script>
        var data = xhr.resposnseText;
        //将json格式转换成json对象 eval()  第一种
        var strJson = eval("(" + data + ")");

        //第二种
        JSON.parse(res);

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="button" value="获取json数据" id="btn"/>
    </div>
    </form>
    <div><%=A %></div>
</body>
</html>
