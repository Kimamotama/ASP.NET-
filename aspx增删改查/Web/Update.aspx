<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Web.Update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post">
     密码:<input type="text" name="txtpwd" value="<%=UserModel.LoginPwd %>"/><br />
        昵称:<input type="text" name="txtnick" value="<%=UserModel.NickName %>"/><br />
        性别:<input type="text" name="txtsex" value="<%=UserModel.Sex %>"/><br />
        年龄:<input type="text" name="txtage" value="<%=UserModel.Age %>"/><br />
        头像:<input type="text" name="txtface" value="<%=UserModel.FaceId %>"/><br />
        好友策略:<input type="text" name="txtfriend" value="<%=UserModel.Friend %>"/><br />
        姓名:<input type="text" name="txtname" value="<%=UserModel.Name %>"/><br />
        星座:<input type="text" name="txtstar" value="<%=UserModel.StarId %>"/><br />
        血型:<input type="text" name="txtblood" value="<%=UserModel.BloodId %>"/><br />
        <input type="hidden" name="id" value="<%=UserModel.Id %>"/>
        <input type="submit" value="添加"/>
    </form>
</body>
</html>
