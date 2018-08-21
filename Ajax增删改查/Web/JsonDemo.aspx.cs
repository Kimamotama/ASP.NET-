using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class JsonDemo : System.Web.UI.Page
    {
        public string A { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            A = Model.isGuid.a;
        }
    }
}