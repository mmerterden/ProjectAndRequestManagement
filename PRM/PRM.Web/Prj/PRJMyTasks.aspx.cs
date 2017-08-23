using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Prj
{
    public partial class PRJMyTasks : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillTasks();
            }
        }
        private void FillTasks()
        {
            rptTasks.DataSource = DALProjectTask.GetAllListProjects(ONLINEUSER.ID);
            rptTasks.DataBind();
        }

       
    }
}