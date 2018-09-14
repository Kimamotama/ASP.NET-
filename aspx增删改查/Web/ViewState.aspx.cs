using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class ViewState : System.Web.UI.Page
    {
        public int Count { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //客户端状态保持 信息存在客户端
            //服务器会将viewstate存储的值进行base64编码
            //然后将编码后的内容存储到_VIEWSTATE隐藏域中 然后返回给浏览器
            //下次点提交_VIEWSTATE隐藏域的值会提交到服务器 服务端将内容接受并且反base64编码 重新给viewstate赋值
            //runat="server" 
            int count = 0;
            if (ViewState["txtCount"]!=null)
            {
                count = Convert.ToInt32(ViewState["txtCount"]);
                count++;
                Count = count;
            }
            ViewState["txtCount"] = Count;
        }
    }
}