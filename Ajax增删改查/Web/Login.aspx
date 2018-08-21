<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="jquery-3.3.1.min.js"></script>
    <script>
        $(function () {
            $("#btn").click(function () {
                UserLogin();
            })
        })

        function UserLogin() {
            var userName = $("#txtName").val();
            var userPwd = $("#txtPwd").val();
            if (userName!=""&&userPwd!="") {
                $.post("validateUserName.ashx", { "name": userName, "pwd": userPwd }, function (data) {
                    //字符串转换为数组 根据 : 分的组
                    var serverData = data.split(':');
                    if (serverData[0]=="yes") {
                        window.location.href = "JQueryAjax.aspx";
                    } else {
                        $("#msg").text(serverData[1]);
                    }

                    console.log(userName + ":" + userPwd + ":" + serverData);

                })
            } else {
                $("#msg").text("不为空");
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        用户名:<input type="text" id="txtName"/>
        <span id="msg" style="font-size:14px;color:red;width:50px;height:auto"></span>
        <br/>
        密码:<input type="password" id="txtPwd"/><br/>
        <input type="button" value="登录" id="btn"/>
    </div>
    </form>
</body>
</html>
