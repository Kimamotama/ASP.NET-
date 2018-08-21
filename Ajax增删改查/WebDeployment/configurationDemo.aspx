<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="configurationDemo.aspx.cs" Inherits="WebDeployment.configurationDemo" %>
<%@ OutputCache Duration="5" VaryByParam="*" %>
<%--页面缓存 时间=5s--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>页面缓存</title>
</head>
<body>
    <%--将整个页面缓存HTML--%>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
