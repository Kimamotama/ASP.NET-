using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web
{
    /// <summary>
    /// validateUserName 的摘要说明
    /// </summary>
    public class validateUserName : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //Reguster
            //string name = context.Request["name"];
            //User_Service userSer = new User_Service();
            //if (userSer.FindUser(name)!=null)
            //{
            //    context.Response.Write("此用户存在");
            //}
            //else
            //{
            //    context.Response.Write("可用");
            //}
            
            //Login
            string userName = context.Request["name"];
            string userPwd = context.Request["pwd"];
            User_Service userSer = new User_Service();
            string msg=string.Empty;
            Users_Model usermodel=null;
            if (userSer.CheckLoginUser(userName, userPwd, out msg, out usermodel))
            {
                context.Session["usermodel"] = usermodel;
                //ajax必须返回消息
                context.Response.Write("yes:" + msg);
            }
            else
            {
                context.Response.Write("no:" + msg);
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