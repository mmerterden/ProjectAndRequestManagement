using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web
{
    public partial class Logout : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["ONLINEUSER-COOKIE-PM"] != null)
            {
                Response.Cookies["ONLINEUSER-COOKIE-PM"].Expires = DateTime.Now.AddDays(-1);
            }
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();

            Response.Redirect("/Login.aspx");

        }
    }
}