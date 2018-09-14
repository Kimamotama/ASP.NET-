using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Session : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //1：Session是服务端一种状态保持机制，可以将各种类型数据存储到Session,最终这些数据是存储到服务端器的内存中。
            //2：怎样使用Session?
            // string userName=Request.Form["txtName"];
            //            //可以将用户输入的用户名存储到Session中。
            //            Session["name"] = userName;
            //            Response.Redirect("TestUser.aspx");
				
            //            然后取值的时候?
            //             if (Session["name"] != null)
            //        {
            //            Response.Write(Session["name"]);
            //        }
			
            //在网站中的某个页面给Session赋值以后，在网站的其它任意的页面中，都可以拿到SSession中存储的值。		
	
            //3：Session的原理
	
            //如图    SessionId会放在响应报文返回给浏览器 浏览器下次访问 请求报文会带着session
	
            //4：Session的应用场景.
	
            // 就是用来存储登录用户的信息。
            //用户在登录时，输入完成用户名密码以后，单击提交按钮，判断完用户名密码以后，
            //将正确的用户的信息存储到Session中。Session["userInfo"],然后再其它页面中判断该Session的值，如果有值表示登录了，如果没有值表示没有登录。

            //5.生命周期
            //划过的时间(静止)
            //页面保持静止 不操作任何数据 如果静止时间超过20分钟 session自动清除数据 如果在默认的20分之内过了10分 再次操作页面session默认时间会
            //重新以当前时间开始   setTimeout() 设置session时间

            //基本登录效果

            if (IsPostBack)
            {
                CheckUser();

            }
            else
            {
                //判断Cookie中是否有值。如果有值，并且值是正确的，那么跳转，不需要用户在输入用户名和密码了。
                //如果Cookie没有值，或者值是错误的，那么继续呈现登录表单，让用户输入用户名密码进行登录。
                CheckCookie();
            }

	
        }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string Checked { get; set; }
        /// <summary>
        /// 对cookie进行校检
        /// </summary>
        private void CheckCookie()
        {
            if (Request.Cookies["ck1"]!=null&&Request.Cookies["ck2"]!=null)
            {
                string userName = Request.Cookies["ck1"].Value;
                string userPwd = Request.Cookies["ck2"].Value;
                BLL.User_Service userService = new BLL.User_Service();
                Users_Model usermodel = userService.FindUser(userName);
                if (usermodel!=null)
                {
                    //判断用户数据库中存储的密码是否与cookie中存储的密码一致
                    if (userPwd==usermodel.LoginPwd)
                    {
                        //先赋值 才能跳转
                        Session["usermodel"] = usermodel;
                        
                        //Response.Redirect("SessionSuc.aspx");
                        UserPwd = userPwd;
                        UserName = userName;
                        Checked = "checked";
                        //Request.Cookies["ck1"].Expires = DateTime.Now.AddDays(-1);
                        //Request.Cookies["ck2"].Expires = DateTime.Now.AddDays(-1);
                    }


                }
                //如果Cookie中是有值的，但是Cookie存储的用户名或密码不正确，表示用户名和密码被篡改了，那么只能继续出现登录页面。那么该 cOOKIE也没有必要存在了。
                Response.Cookies["ck1"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["ck2"].Expires = DateTime.Now.AddDays(-1);
            }
        }
        public string ErrorMsg { get; set; }
        private void CheckUser()
        {
            string userName = Request.Form["txtClientID"];
            string userPwd = Request.Form["txtPassword"];
            BLL.User_Service userService = new BLL.User_Service()
;
            //提示信息
            string msg = string.Empty;
            Users_Model usermodel = null;
            if (userService.CheckLoginUser(userName,userPwd,out msg,out usermodel))
            {
                //判断用户是否选择了自动登录
                if (!string.IsNullOrEmpty(Request.Form["autoLogin"]))
                {
                    HttpCookie cookie1 = new HttpCookie("ck1", userName);
                    HttpCookie cookie2 = new HttpCookie("ck2", userPwd);
                    //HttpCookie cookie = new HttpCookie("ck", Common.MD5Com.GetMd5String(userPwd));
                    cookie1.Expires = DateTime.Now.AddDays(3);
                    cookie2.Expires = DateTime.Now.AddDays(3);
                    Response.Cookies.Add(cookie1);
                    Response.Cookies.Add(cookie2);


                }


                Session["usermodel"] = usermodel;

                Session.Timeout = 3;

                Response.Redirect("SessionSuc.aspx");
            }
            else
            {
                ErrorMsg = msg;
            }
        }
    }
}