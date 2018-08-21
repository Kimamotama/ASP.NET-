using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web
{
    /// <summary>
    /// EidtUser 的摘要说明
    /// </summary>
    public class EidtUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Model.Users_Model usermodel = new Model.Users_Model();
            usermodel.LoginPwd = context.Request["edittxtpwd"];
            usermodel.NickName = context.Request["edittxtnick"];
            usermodel.Sex = context.Request["edittxtsex"];
            usermodel.Age = Convert.ToInt32(context.Request["edittxtage"]);
            usermodel.FaceId = Convert.ToInt32(context.Request["edittxtface"]);
            usermodel.Friend = Convert.ToInt32(context.Request["edittxtfriend"]);
            usermodel.Name = context.Request["edittxtname"];
            usermodel.StarId = Convert.ToInt32(context.Request["edittxtstar"]);
            usermodel.BloodId = Convert.ToInt32(context.Request["edittxtblood"]);
            usermodel.Id = Convert.ToInt32(context.Request["editId"]);
            BLL.User_Service userSer = new BLL.User_Service();
            if (userSer.UpdateUser(usermodel))
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