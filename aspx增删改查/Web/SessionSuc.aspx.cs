using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class SessionSuc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usermodel"]!=null)
            {
                Response.Write(((Users_Model)Session["usermodel"]).Name);
            }
        }
    }
}