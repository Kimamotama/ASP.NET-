using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Model;

namespace Web
{
    /// <summary>
    /// AddUser 的摘要说明
    /// </summary>
    public class AddUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Users_Model usermodel = new Users_Model();
            usermodel.LoginPwd = context.Request.Form["txtpwd"];
            usermodel.NickName = context.Request.Form["txtnick"];
            usermodel.Sex = context.Request.Form["txtsex"];
            usermodel.Age = Convert.ToInt32(context.Request.Form["txtage"]);
            usermodel.FaceId = Convert.ToInt32(context.Request.Form["txtface"]);
            usermodel.Friend = Convert.ToInt32(context.Request.Form["txtfriend"]);
            usermodel.Name = context.Request.Form["txtname"];
            usermodel.StarId = Convert.ToInt32(context.Request.Form["txtstar"]);
            usermodel.BloodId = Convert.ToInt32(context.Request.Form["txtblood"]);
            Users_Service userservice = new Users_Service();
            if (userservice.AddUser(usermodel))
            {
                context.Response.Redirect("Index.ashx");
            }
            else
            {
                context.Response.Redirect("Error.ashx");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}