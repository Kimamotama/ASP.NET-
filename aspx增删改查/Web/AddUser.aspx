<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Web.AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        密码:<input type="text" name="txtpwd"/><br />
        昵称:<input type="text" name="txtnick"/><br />
        性别:<input type="text" name="txtsex"/><br />
        年龄:<input type="text" name="txtage"/><br />
        头像:<input type="text" name="txtface"/><br />
        好友策略:<input type="text" name="txtfriend"/><br />
        姓名:<input type="text" name="txtname"/><br />
        星座:<input type="text" name="txtstar"/><br />
        血型:<input type="text" name="txtblood"/><br />
        <input type="submit" value="添加"/>
    </form>
</body>
</html>
