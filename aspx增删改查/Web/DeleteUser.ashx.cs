using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web
{
    /// <summary>
    /// DeleteUser 的摘要说明
    /// </summary>
    public class DeleteUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id;
            if (int.TryParse(context.Request.QueryString["id"],out id))
            {
                BLL.User_Service userservice = new BLL.User_Service();
                if (userservice.DeleteUser(id))
                {
                    context.Response.Redirect("Index.aspx");
                }
                else
                {
                    context.Response.Redirect("Error.html");
                }
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