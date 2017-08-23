using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Prj
{
    public partial class PRJProjectDetail : BasePage
    {
        protected Guid PROJECTID
        {
            get
            {
                if (ViewState["PROJECTID"] == null)
                {
                    ViewState["PROJECTID"] = Guid.Empty;
                }
                return Guid.Parse(ViewState["PROJECTID"].ToString());
            }
            set { ViewState["PROJECTID"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                FillProjectTasks();

                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    ENTVWPRJPROJECT prj = DALProject.GetProjectDetail(Guid.Parse(Request.QueryString["ID"]));
                    if (prj != null)
                    {
                        PROJECTID = prj.ID;
                        lblFirmName.Text = prj.FIRMNAME;
                        lblProjectName.Text = prj.NAME;
                        lblDescription.Text = prj.DESCRIPTION;
                        lblProjectTypeStatus.Text = prj.TYPEPROJECTSTATUSNAME;
                    }
                    else
                    {
                        Response.Redirect("/Prj/PRJProjects.aspx");
                    }
                }
                else
                {
                    Response.Redirect("/Prj/PRJProjects.aspx");
                }
            }

        }


        private void FillProjectTasks()
        {
            ENTPRJPROJECT prj = DALProject.GetProject(Guid.Parse(Request.QueryString["ID"]));
            if (prj != null)
            {
                PROJECTID = prj.ID;
                rptProjectsDetail.DataSource = DALProjectTask.GetAllListProjectsTasks(PROJECTID);
                rptProjectsDetail.DataBind();
            }
            else
            {
                Response.Redirect("/Prj/PRJProjects.aspx");
            }

        }

        protected void rptProjectsDetail_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete":
                    {
                        List<ENTPRJPROJECTTASKRESOURSE> ProjectTaskResourseList = DALProjectTaskResourse.GetAllListTaskResoursesID(Guid.Parse(e.CommandArgument.ToString()));


                        foreach (ENTPRJPROJECTTASKRESOURSE rsr in ProjectTaskResourseList)
                        {
                            List<ENTPRJPROJECTTASKRESOURSEACTIVITY> ProjectTaskResourseActivityList = DALProjectTaskResourseActivity.GetAllListTaskResoursesActivityID(rsr.ID);
                            foreach (ENTPRJPROJECTTASKRESOURSEACTIVITY act in ProjectTaskResourseActivityList)
                            {
                                DALProjectTaskResourseActivity.Delete(act.ID);
                            }
                            DALProjectTaskResourse.Delete(rsr.ID);
                        }


                        DALProjectTask.Delete(Guid.Parse(e.CommandArgument.ToString()));
                        FillProjectTasks();
                        break;
                    }

            }

        }
    }
}