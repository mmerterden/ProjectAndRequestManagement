using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Rpt
{
    public partial class RPTReportsFirmTask : BasePage
    {

        protected Guid FIRMID
        {
            get
            {
                if (ViewState["FIRMID"] == null)
                {
                    ViewState["FIRMID"] = Guid.Empty;
                }
                return Guid.Parse(ViewState["FIRMID"].ToString());
            }
            set { ViewState["FIRMID"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    FIRMID = DALReports.GetReportProject(Guid.Parse(Request.QueryString["ID"]));
                    FillTaskReports();
                }
                else
                {
                    Response.Redirect("/Rpt/RPTReportsProject.aspx");
                }

            }
        }

        private void FillTaskReports()
        {

            rptTaskReport.DataSource = DALReports.GetAllListTaskReport(Guid.Parse(Request.QueryString["ID"]));
            rptTaskReport.DataBind();

        }
    }
}