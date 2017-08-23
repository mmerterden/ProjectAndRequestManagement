using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Rpt
{
    public partial class RPTReportsFirmandResourse : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillFirmReports();
                FillResourseReports();
            }
        }
        private void FillFirmReports()
        {
            
            rptFirmReport.DataSource = DALReports.GetAllListFirmReport();
            rptFirmReport.DataBind();
        }

        private void FillResourseReports()
        {
            rptUserReport.DataSource = DALReports.GetAllListResourseReport();
            rptUserReport.DataBind();
        }


    }
}