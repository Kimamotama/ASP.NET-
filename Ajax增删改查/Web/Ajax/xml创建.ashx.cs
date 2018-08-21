using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Ajax
{
    /// <summary>
    /// xml创建 的摘要说明
    /// </summary>
    public class xml创建 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";


            //xml头部
            string xmlHeader = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
            //创建根节点
            string rootPage = xmlHeader + "<provice>";




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