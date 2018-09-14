using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Web
{
    /// <summary>
    /// Update 的摘要说明
    /// </summary>
    public class Update : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int id;
            if (int.TryParse(context.Request.QueryString["id"],out id))
            {
                BLL.User_Service userSer = new BLL.User_Service();
                Model.User_Model usermodel = userSer.GetUser(id);
                string filePath = context.Request.MapPath("Update.html");
                string fileContent = File.ReadAllText(filePath);
                fileContent = fileContent.Replace("$pwd", usermodel.LoginPwd).Replace("$nick", usermodel.NickName)
                    .Replace("$sex", usermodel.Sex).Replace("$age", usermodel.Age.ToString()).Replace("$face", usermodel.FaceId.ToString())
                    .Replace("$friend", usermodel.Friend.ToString()).Replace("$name", usermodel.Name).Replace("$star", usermodel.StarId.ToString())
                    .Replace("$blood", usermodel.BloodId.ToString()).Replace("$id", usermodel.Id.ToString());
                context.Response.Write(fileContent);
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