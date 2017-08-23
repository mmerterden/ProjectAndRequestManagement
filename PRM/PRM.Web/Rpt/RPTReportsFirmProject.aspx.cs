using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Rpt
{
    public partial class RPTReportsFirmProject : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    FillProjectReports();
                }
                else
                {
                    Response.Redirect("/Rpt/RPTReportsFirmandResourse.aspx");
                }

            }

        }

        private void FillProjectReports()
        {

            rptProjectReport.DataSource = DALReports.GetAllListProjectReport(Guid.Parse(Request.QueryString["ID"]));
            rptProjectReport.DataBind();

        }
    }
}