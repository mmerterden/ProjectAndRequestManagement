using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PRM.DataLayer;
using System.Collections;

namespace PRM.Web.Prj
{
    public partial class PRJProjects : BasePage
    {

        protected Guid PROJECTTASKID
        {
            get
            {
                if (ViewState["PROJECTTASKID"] == null)
                {
                    ViewState["PROJECTTASKID"] = Guid.Empty;
                }
                return Guid.Parse(ViewState["PROJECTTASKID"].ToString());
            }
            set { ViewState["PROJECTTASKID"] = value; }
        }
        protected Guid PROJECTTASKRESOURSEID
        {
            get
            {
                if (ViewState["PROJECTTASKRESOURSEID"] == null)
                {
                    ViewState["PROJECTTASKRESOURSEID"] = Guid.Empty;
                }
                return Guid.Parse(ViewState["PROJECTTASKRESOURSEID"].ToString());
            }
            set { ViewState["PROJECTTASKRESOURSEID"] = value; }
        }
        protected Guid PROJECTRESOURSEACTIVITYID
        {
            get
            {
                if (ViewState["PROJECTRESOURSEACTIVITYID"] == null)
                {
                    ViewState["PROJECTRESOURSEACTIVITYID"] = Guid.Empty;
                }
                return Guid.Parse(ViewState["PROJECTRESOURSEACTIVITYID"].ToString());
            }
            set { ViewState["PROJECTRESOURSEACTIVITYID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                FillProject();
            }


        }
        private void FillProject()
        {
            rptProjects.DataSource = DALProject.GetAllListProjects();
            rptProjects.DataBind();
        }

        protected void rptProjects_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete":
                    {
                        List<ENTPRJPROJECTTASK> ProjectTaskList = DALProjectTask.GetAllListTaskID(Guid.Parse(e.CommandArgument.ToString()));

                        foreach (ENTPRJPROJECTTASK tsk in ProjectTaskList)
                        {
                            List<ENTPRJPROJECTTASKRESOURSE> ProjectTaskResourseList = DALProjectTaskResourse.GetAllListTaskResoursesID(tsk.ID);


                            foreach (ENTPRJPROJECTTASKRESOURSE rsr in ProjectTaskResourseList)
                            {
                                List<ENTPRJPROJECTTASKRESOURSEACTIVITY> ProjectTaskResourseActivityList = DALProjectTaskResourseActivity.GetAllListTaskResoursesActivityID(rsr.ID);

                                foreach (ENTPRJPROJECTTASKRESOURSEACTIVITY act in ProjectTaskResourseActivityList)
                                {
                                    DALProjectTaskResourseActivity.Delete(act.ID);
                                }
                                DALProjectTaskResourse.Delete(rsr.ID);

                            }
                            DALProjectTask.Delete(tsk.ID);
                        }
                        List<ENTREQREQUESTS> ProjectRequestList = DALRequest.GetAllListRequestsID(Guid.Parse(e.CommandArgument.ToString()));

                        foreach (ENTREQREQUESTS rqst in ProjectRequestList)
                        {
                            List<ENTREQREQUESTDETAIL> ProjectRequestDetailList = DALRequest.GetAllListRequestDetailsID(rqst.ID);
                            
                            foreach (ENTREQREQUESTDETAIL rqstdtl in ProjectRequestDetailList)
                            {
                                DALRequest.DeleteDetail(rqstdtl.ID);
                            }
                            DALRequest.Delete(rqst.ID);

                        }
                        
                        DALProject.Delete(Guid.Parse(e.CommandArgument.ToString()));

                        FillProject();
                        break;
                    }  
            }
        }
    }
}
