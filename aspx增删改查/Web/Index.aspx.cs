using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Index : System.Web.UI.Page
    {
        public List<Users_Model> UserList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.User_Service userService = new BLL.User_Service();
            List<Users_Model> list = userService.GetList();
            UserList = list;

            //两个问号 ??，它表示左边的变量如果为null则值为右边的变量，否则就是左边的变量值
            string a = "3";
            var b = a ?? "123";
            Response.Write(b);
        }
    }
}