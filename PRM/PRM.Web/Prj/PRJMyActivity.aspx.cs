using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Prj
{
    public partial class PRJMyActivity : BasePage
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                FillTaskActivity();
            }
        }

        private void FillTaskActivity()
        {
            rptActivity.DataSource = DALProjectTaskResourseActivity.GetAllListTaskActivity(Guid.Parse(Request.QueryString["ID"]));
            rptActivity.DataBind();
        }

        protected void rptActivity_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete":
                    {
                        DALProjectTaskResourseActivity.Delete(Guid.Parse(e.CommandArgument.ToString()));
                        FillTaskActivity();
                        break;
                    }

            }
        }
    }
}