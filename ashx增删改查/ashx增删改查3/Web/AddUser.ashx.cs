using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            User_Model usermodel = new User_Model();
            usermodel.LoginPwd = context.Request.Form["txtpwd"];
            usermodel.NickName = context.Request.Form["txtnick"];
            usermodel.Sex = context.Request.Form["txtsex"];
            usermodel.Age = Convert.ToInt32(context.Request.Form["txtage"]);
            usermodel.FaceId = Convert.ToInt32(context.Request.Form["txtface"]);
            usermodel.Friend = Convert.ToInt32(context.Request.Form["txtfriend"]);
            usermodel.Name = context.Request.Form["txtname"];
            usermodel.StarId = Convert.ToInt32(context.Request.Form["txtstar"]);
            usermodel.BloodId = Convert.ToInt32(context.Request.Form["txtblood"]);
            User_Service userSer = new User_Service();
            if (userSer.AddUser(usermodel))
            {
                context.Response.Redirect("Index.ashx");
            }
            else
            {
                context.Response.Redirect("Error.html");
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