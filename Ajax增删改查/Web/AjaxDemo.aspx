\<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxDemo.aspx.cs" Inherits="Web.AjaxDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="jquery-3.3.1.min.js"></script>
    <script>
        $(function () {
            $("#btn").click(function () {
                var xhr;
                if (XMLHttpRequest) {//高版本浏览器
                    xhr = new XMLHttpRequest();
                }
                else {
                    //IE5,6等低版本
                    xhr = new ActiveXObject("Microsoft.XMLHTTP");
                }

                //if (window.ActiveXObject) {
                //    xhr = new ActiveXObject("Microsoft.XMLHTTP");
                //}

                xhr.open("get", "AjaxDemo.ashx", true);//异步为true false就是传统方式
                xhr.send();//发送
                //回调函数 在服务器处理完成后 会将处理的结果返回给浏览器 浏览器会自动的调用该回调函数 
                //在该回调函数中可以拿到从服务器返回的结果
                //该事件不断监视Ajax状态变化
                xhr.onreadystatechange = function () {
                    if (xhr.readyState==4) {
                        //为4 表示数据已经从服务器返回给浏览器
                        if (xhr.status==200) {
                            //表示从服务端返回的响应状态吗是200 200表示服务端执行的代码没有出现异常
                            //此时浏览器端就可以呈现从服务端返回的数据
                            alert(xhr.responseText);//获取从服务器返回的数据(字符串)
                        }
                    }
                }
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="button" value="获取时间" id="btn"/>
    </div>
    </form>
</body>
</html>
