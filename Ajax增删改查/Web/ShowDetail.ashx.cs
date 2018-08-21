using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web
{
    /// <summary>
    /// ShowDetail 的摘要说明
    /// </summary>
    public class ShowDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id = Convert.ToInt32(context.Request["id"]);
            BLL.User_Service userSer = new BLL.User_Service();
            Users_Model usermodel = userSer.FindUser(id);
            System.Web.Script.Serialization.JavaScriptSerializer js=new System.Web.Script.Serialization.JavaScriptSerializer();
            context.Response.Write(js.Serialize(usermodel));
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