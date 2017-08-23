using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Prj
{
    public partial class PRJProjectTaskResourseDetail : BasePage
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
            if (!Page.IsPostBack)//8) Verileri tabloya doldur.
            {
                
                FillProjectTaskResourse();

                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    ENTVWPRJPROJECTTASK prjtsk = DALProjectTask.GetValueTask(Guid.Parse(Request.QueryString["ID"]));//VWPRJPROJECTTASK tabloma giderek ordaki verileri aldım ve labellara yazdırdım.
                    if (prjtsk != null)
                    {
                        PROJECTTASKID = prjtsk.ID;
                        PROJECTID = prjtsk.PROJECTID;
                        lblProjectName.Text = prjtsk.PROJECTNAME;
                        lblProjectTaskName.Text = prjtsk.NAME;
                        lblProjectCreateDate.Text = prjtsk.CREATEDATE.ToString();
                        lblStatus.Text = prjtsk.TYPEPROJECTTASKSTATUSNAME;
                        lblDescription.Text = prjtsk.DESCRIPTION;
                    }
                    else
                    {
                        Response.Redirect("/Prj/PRJProjectDetail.aspx?ID=" + PROJECTTASKID);
                    }
                }
                else
                {
                    Response.Redirect("/Prj/PRJProjectDetail.aspx?ID=" + PROJECTTASKID);
                }
            }
            
        }
        private void FillProjectTaskResourse()
        {
            ENTVWPRJPROJECTTASK prjtsk = DALProjectTask.GetValueTask(Guid.Parse(Request.QueryString["ID"]));
            if (prjtsk != null)
            {
                PROJECTTASKID = prjtsk.ID;
                rptProjectTaskResourceDetail.DataSource = DALProjectTaskResourse.GetAllListProjectsTaskResourse(PROJECTTASKID);
                rptProjectTaskResourceDetail.DataBind();
            }
            else
            {
                Response.Redirect("/Prj/PRJProjectDetail.aspx?ID="+PROJECTTASKID);
            }

        }

        protected void rptProjectTaskResourceDetail_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete":
                    {

                        List<ENTPRJPROJECTTASKRESOURSEACTIVITY> ProjectTaskResourseActivityList = DALProjectTaskResourseActivity.GetAllListTaskResoursesActivityID(Guid.Parse(e.CommandArgument.ToString()));
                        foreach (ENTPRJPROJECTTASKRESOURSEACTIVITY act in ProjectTaskResourseActivityList)
                        {
                            DALProjectTaskResourseActivity.Delete(act.ID);
                        }
                        DALProjectTaskResourse.Delete(Guid.Parse(e.CommandArgument.ToString()));
                        FillProjectTaskResourse();
                        break;
                    }

            }
        }
    }
}