using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Rpt
{
    public partial class RPTReportsResourseActivity : BasePage
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    FillResourseActivityReport();
                    //Session["USERID"]= Request.QueryString["ID"];
                }
                else
                {
                    Response.Redirect("/Rpt/RPTReportsFirmandResourse.aspx");
                }

            }
        }

        private void FillResourseActivityReport()
        {

            rptResourseFirmReport.DataSource = DALReports.GetAllListResourseActivityReport(Guid.Parse(Request.QueryString["ID"]));
            rptResourseFirmReport.DataBind();

        }
    }
}