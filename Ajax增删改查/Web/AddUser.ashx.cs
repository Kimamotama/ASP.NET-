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
            Users_Model usermodel = new Users_Model();
            usermodel.LoginPwd = context.Request["txtpwd"];
            usermodel.NickName = context.Request["txtnick"];
            usermodel.Sex = context.Request["txtsex"];
            usermodel.Age = Convert.ToInt32(context.Request["txtage"]);
            usermodel.FaceId = Convert.ToInt32(context.Request["txtface"]);
            usermodel.Friend = Convert.ToInt32(context.Request["txtfriend"]);
            usermodel.Name = context.Request["txtname"];
            usermodel.StarId = Convert.ToInt32(context.Request["txtstar"]);
            usermodel.BloodId = Convert.ToInt32(context.Request["txtblood"]);
            BLL.User_Service userSer = new BLL.User_Service();
            if (userSer.AddUser(usermodel))
            {
                context.Response.Write("yes");
            }
            else
            {
                context.Response.Write("no");
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