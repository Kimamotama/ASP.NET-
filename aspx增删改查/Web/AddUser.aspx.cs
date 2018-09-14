using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //必须判断请求到底是get请求还是Post请求.???
            //如果获取了隐藏域的值，表示用户单击了提交按钮，发起post请求.
            //if (!string.IsNullOrEmpty(Request.Form["isPostBack"]))
            ////如果该属性的取值为true,那么就是post请求，否则是false那么就是get请求.
            //如果在建好的aspx页面中有一个<from runat="server">那么返回给浏览器的HTML代码中包含一个名称叫__VIEWSTATE的隐藏域。
            //那么单击表单中的提交按钮时，该隐藏域的值会提交到服务端。
            //那么IsPostBack这个属性就是根据__VIEWSTATE隐藏域的来进行判断是get请求还是POST请求。
            //如果能够拿到该隐藏域的值表示post请求否则为get请求.
            //    如果前端页面中没有__VIEWSTATE隐藏域那么就不能用IsPostBack属性来判断是get请求还是Post请求.
            if (IsPostBack)
            {
                AddInfo();
            }
        }

        private void AddInfo()
        {
            Users_Model usermodel = new Users_Model();
            usermodel.LoginPwd = Request.Form["txtpwd"];
            usermodel.NickName = Request.Form["txtnick"];
            usermodel.Sex = Request.Form["txtsex"];
            usermodel.Age = Convert.ToInt32(Request.Form["txtage"]);
            usermodel.FaceId = Convert.ToInt32(Request.Form["txtface"]);
            usermodel.Friend = Convert.ToInt32(Request.Form["txtfriend"]);
            usermodel.Name = Request.Form["txtname"];
            usermodel.StarId = Convert.ToInt32(Request.Form["txtstar"]);
            usermodel.BloodId = Convert.ToInt32(Request.Form["txtblood"]);
            BLL.User_Service userservice = new BLL.User_Service();
            if (userservice.AddUser(usermodel))
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                Response.Redirect("Error.html");
            }

        }
    }
}