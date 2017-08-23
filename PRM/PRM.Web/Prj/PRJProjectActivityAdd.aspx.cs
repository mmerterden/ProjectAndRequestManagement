using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Prj
{
    public partial class PRJProjectActivityAdd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CalDate.Visible = false;


            }

        }

        protected void CalDate_SelectionChanged(object sender, EventArgs e)
        {
            txtRecorddate.Text = CalDate.SelectedDate.ToShortDateString();
            updPanl.Update();
            if (CalDate.Visible == false)
            {
                CalDate.Visible = true;
            }
            else CalDate.Visible = false;
        }

        protected void btnCal_Click(object sender, EventArgs e)
        {
            updPanl.Update();
            if (CalDate.Visible == false)
            {
                CalDate.Visible = true;
            }
            else CalDate.Visible = false;
        }
    }
}