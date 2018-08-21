using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web
{
    /// <summary>
    /// Json 的摘要说明
    /// </summary>
    public class Json : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("{\"Name\":\"张三\"}");
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