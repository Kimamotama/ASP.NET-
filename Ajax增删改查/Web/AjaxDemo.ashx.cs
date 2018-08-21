using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web
{
    /// <summary>
    /// AjaxDemo1 的摘要说明
    /// </summary>
    public class AjaxDemo1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
           // context.Response.Write(DateTime.Now.ToString());
            string str = context.Request["name"];
            context.Response.Write(context.Request["name"]);
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