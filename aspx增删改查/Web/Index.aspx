<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web.Index" %>
<%@ Import Namespace="Model" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="jquery-3.3.1.min.js"></script>
    <script>
        $(function () {
            $(".del").click(function () {
                if (!confirm("确定删除?")) {
                    return false;
                }
            })
        })
    </script>
</head>
<body>
    <a href="AddUser.aspx">添加用户</a>
    <table>
        <tr><th>编号</th><th>密码</th><th>昵称</th><th>性别</th><th>年龄</th><th>头像</th><th>好友类型</th><th>血型</th><th>姓名</th><th>星座</th><th>删除</th><th>修改</th></tr>
        <%foreach (Users_Model user in UserList){%>
              <tr>
                  <td><%=user.Id %></td>
                  <td><%=user.LoginPwd %></td>
                  <td><%=user.NickName %></td>
                  <td><%=user.Sex %></td>
                  <td><%=user.Age %></td>
                  <td><%=user.FaceId %></td>
                  <td><%=user.Friend %></td>
                  <td><%=user.BloodId %></td>
                  <td><%=user.Name %></td>
                  <td><%=user.StarId %></td>
                  <td><a href="DeleteUser.ashx?id=<%=user.Id %>" class="del">删除</a></td>
                  <td><a href="Update.aspx?id=<%=user.Id %>">修改</a></td>
              </tr>
         <% } %>

    </table>
</body>
</html>
