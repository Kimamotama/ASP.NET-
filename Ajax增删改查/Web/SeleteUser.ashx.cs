using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web
{
    /// <summary>
    /// SeleteUser 的摘要说明
    /// </summary>
    public class SeleteUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //分页
            
            int pageIndex;//当前页码
            if (!int.TryParse(context.Request["pageIndex"],out pageIndex))
            {
                pageIndex = 1;
            }
            BLL.User_Service userSer = new BLL.User_Service();
            int pageSize = 5;//每页显示5条
            int pageCount = userSer.GetPageCount(pageSize);//总页数
            //判断当前页码取值范围
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            //单页
            List<Users_Model> list = userSer.GetPageList(pageIndex, pageSize);//获取
            //System.Web.Script.Serialization.JavaScriptSerializer json = new System.Web.Script.Serialization.JavaScriptSerializer();
            //context.Response.Write(json.Serialize(list));

            //获取分页页码条
            string strPageBar = BLL.pageBar.GetPageBar(pageIndex, pageSize);
            System.Web.Script.Serialization.JavaScriptSerializer json = new System.Web.Script.Serialization.JavaScriptSerializer();
            //添加一个匿名类 2个属性
            context.Response.Write(json.Serialize(new { user = list, MypageBar = strPageBar }));




            
            //List<Users_Model> list = userSer.GetUsers();
            ////通过该类可以将数据序列化成为json格式
            //System.Web.Script.Serialization.JavaScriptSerializer json = new System.Web.Script.Serialization.JavaScriptSerializer();
            //context.Response.Write(json.Serialize(list));

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