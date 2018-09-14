using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class cookie : System.Web.UI.Page
    {
        public string LoginUserName { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //cookie:一小段文本，明文。存储在客户端的浏览器内存里面或者磁盘。cookie是跟网站相关，百度可以往客户端写cookie，sina也可写cookie，但是百度只能读取跟百度网站相关的cookie。
            //cookie会随着请求网站一块发送到后台【如果请求百度的时候，那么就把百度的cookie放到请求报文里面去，然后发送到后台。】


            //cookie可以设置一个Path来限制某个路径下面的页面才会把cookie发送到后台。
            //比如：请求图片，请求一个css、js，为了提高性能，可以通过 path设置页面的所在路径，来控制cookie的发送。


            // Cookie的域：浏览器往后台发送数据时候，要把cookie放到请求报文里面去，发送到后台。
            //那么有个问题：请求是子域的网页，那么主域的cookie会不会发送到后台呢？
            //答案：是的。一块发送。如果请求时主域页面，子域的cookie是不会发送到后台的。(Domain)
            //如果子域想让请求主域页面的时候也一块发送到后台，设置当前Cookie的域为主域可以了。


            //cookie是通过响应报文的方式写到前台。最终写入Cookie是通过响应报文头来的
            //cookie有限制（大多数浏览器）
            
            //创建cookie并指定过期时间 数据会存到磁盘上 不指定关闭浏览器失效
            //Response.Cookies["cp"].Value = "aaa";
            //Response.Cookies["cp"].Expires = DateTime.Now.AddDays(3);
            //Response.Cookies["cp"].Expires = DateTime.Now.AddDays(-1);

            ////cookie的其他属性
            //Response.Cookies["cp"].Value = "ccc";
            //Response.Cookies["cp"].Domain = "";//域名,跨域
            ////限定文件夹下请求报文发送cookie
            //Response.Cookies["cp"].Path = "";
            //Response.Cookies["cp"].Expires = DateTime.Now.AddDays(3);

            
            //记住登录名
            if (IsPostBack)
            {
                string userName = Request.Form["txtName"];
                Response.Cookies["userName"].Value = userName;
                Response.Cookies["userName"].Expires = DateTime.Now.AddDays(3);
                Response.Cookies["userName"].Path = "localhost";
                Response.Cookies["userPwd"].Expires = DateTime.Now.AddDays(3);
            }
            else
            {
                if (Request.Cookies["userName"]!=null)
                {
                    string userName = Request.Cookies["userName"].Value;
                    LoginUserName = userName; 
                    //第二次登录 更新登录时间 使过期时间不为绝对的
                    Response.Cookies["userName"].Value = userName;
                    //编码 在上一次存储时 没有具体的字符串编码 浏览器不能识别 当再次打开页面时  是响应的一个过程
                    //是因为在前一次访问时 没有存入数据
                    Response.Cookies["userName"].Value = Server.UrlEncode(userName);
                    Response.Cookies["userPwd"].Expires = DateTime.Now;
                }
            }


                //1:Cookie文件大小4KB
                //2：一个网站默认的最多创建20个Cookie.
                //3:某些浏览器会对访问的所有网站的Cookie限制为300.
                //4：创建Cookie另外一种方式:
                //    HttpCookie cookie1 = new HttpCookie("cp4", "saaaa");
                //            cookie1.Expires = DateTime.Now.AddDays(5);
                //            Response.Cookies.Add(cookie1);

                //5:多值Cookie
                //Response.Cookies["userInfo"]["userName"] = "patrick";
                //Response.Cookies["userInfo"]["lastVisit"] = DateTime.Now.ToString();
                //Response.Cookies["userInfo"].Expires = DateTime.Now.AddDays(1);

                //6:Cookie不安全。
                //Cookie尽量存储安全要求不高的数据。
                //一定要将需要存储的敏感的数据一定要加密以后存储到Cookie中。


        }
    }
}