using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.UserControl
{
    public partial class UCTopMenu : BaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblFullName.Text = ONLINEUSER.FULLNAME;
            }
        }
    }
}