using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Update : System.Web.UI.Page
    {
        public Users_Model UserModel { get; set; }
        BLL.User_Service userservice = new BLL.User_Service();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowEdit();
            }
            else
            {
                PostEditUser();
            }
        }
        /// <summary>
        ///展示要修改的数据
        /// </summary>
        private void ShowEdit()
        {
            int id;
            if (int.TryParse(Request.QueryString["id"],out id))
            {
                Users_Model usermodel = userservice.FindUser(id);
                UserModel = usermodel;
            }
        }

        private void PostEditUser()
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
            usermodel.Id = Convert.ToInt32(Request.Form["id"]);
            if (userservice.UpdateUser(usermodel))
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