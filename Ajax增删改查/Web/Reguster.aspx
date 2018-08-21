<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reguster.aspx.cs" Inherits="Web.Reguster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>用户检测</title>
    <script src="jquery-3.3.1.min.js"></script>
    <script>
        $(function () {
            $("#txtName").blur(function () {
                var userName = $(this).val();
                if (userName!="") {
                    $.post("validateUserName.ashx", { "name": userName }, function (data) {
                        $("#msg").text(data);
                    })
                }
                else {
                    $("#nameMsg").text("用户名不为空");
                }
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        用户名:<input type="text" id="txtName"/>
        <span id="msg" style="font-size:14px;color:red;width:50px;height:auto"></span>
        <br/>
        密码:<input type="text" id="txtPwd"/><br/>
    </div>
    </form>
</body>
</html>
