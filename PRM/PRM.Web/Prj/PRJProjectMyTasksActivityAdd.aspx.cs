using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Prj
{
    public partial class PRJProjectMyTasksActivityAdd : BasePage
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

        protected Guid PROJECTASKRESOURSEID
        {
            get
            {
                if (ViewState["PROJECTASKRESOURSEID"] == null)
                {
                    ViewState["PROJECTASKRESOURSEID"] = Guid.Empty;
                }
                return Guid.Parse(ViewState["PROJECTASKRESOURSEID"].ToString());
            }
            set { ViewState["PROJECTASKRESOURSEID"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CalDate.Visible = false;
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    PROJECTASKRESOURSEID = Guid.Parse(Request.QueryString["ID"]);
                    ENTVWPRJPROJECTMYTASKS act = DALProjectTask.GetActivity(Guid.Parse(Request.QueryString["ID"]));
                    if (act != null)
                    {
                        PROJECTTASKID = act.PROJECTTASKID;
                        lblProjectName.Text = act.PROJECTNAME;
                        lblProjectTaskName.Text = act.PROJECTTASKNAME;
                    }
                    else
                    {
                        Response.Redirect("/Prj/PRJMyTasks.aspx?ID="+ PROJECTASKRESOURSEID); 
                    }
                }
                else
                {
                    Response.Redirect("/Prj/PRJProjects.aspx");
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ENTPRJPROJECTTASKRESOURSE rsrs = DALProjectTaskResourse.GetValueComplete(PROJECTTASKID, ONLINEUSER.ID);
            if (rsrs.TYPEPROJECTRESOURSESTATUSID == 1 || rsrs.TYPEPROJECTRESOURSESTATUSID == 2)
            {
                if (ValidateRecord())
                {
                    ENTPRJPROJECTTASKRESOURSEACTIVITY activity = new ENTPRJPROJECTTASKRESOURSEACTIVITY();
                    activity.ID = Guid.NewGuid();
                    activity.PROJECTTASKRESOURSEID = Guid.Parse(Request.QueryString["ID"]);
                    activity.DATE = Convert.ToDateTime(txtDate.Text);
                    activity.DESCRIPTION = txtDescription.Text;
                    if (!string.IsNullOrEmpty(txtDuration.Text))
                    {
                        activity.RESOURSEDURATION = Convert.ToByte(txtDuration.Text);
                    }
                    else
                    {
                        activity.RESOURSEDURATION = null;
                    }
                    DALProjectTaskResourseActivity.InsertTable(activity);

                    Response.Redirect("/Prj/PRJMyActivity.aspx?ID=" + PROJECTASKRESOURSEID);
                }
            }
            else
            {
                AddMessage(lblError1, "Bu aktivite tamamlanmıştır.!", false);
            }
        }

        private bool ValidateRecord()
        {
            bool retval = true;
            if (string.IsNullOrEmpty(txtDate.Text))
            {
                retval = false;
                AddMessage(lblError1, "Tarih alanı boş geçilemez!", false);
            }
            return retval;

        }
        public void AddMessage(Literal lbl, string msg, bool type)
        {
            lbl.Text = "<div class='alert alert-" + (type ? "success" : "danger") + "'>" + msg + "</div>";
        }

        protected void btnRecordAndOkey_Click(object sender, EventArgs e)
        {
            ENTPRJPROJECTTASKRESOURSE rsrs = DALProjectTaskResourse.GetValueComplete(PROJECTTASKID, ONLINEUSER.ID);
            if (rsrs.TYPEPROJECTRESOURSESTATUSID == 1 || rsrs.TYPEPROJECTRESOURSESTATUSID == 2)
            {
                if (ValidateRecord())
                {

                    if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                    {
                        rsrs.TYPEPROJECTRESOURSESTATUSID = 3;
                        DALProjectTaskResourseActivity.UpdateComplete(rsrs);
                        ENTPRJPROJECTTASKRESOURSEACTIVITY activity = new ENTPRJPROJECTTASKRESOURSEACTIVITY();
                        activity.ID = Guid.NewGuid();
                        activity.PROJECTTASKRESOURSEID = Guid.Parse(Request.QueryString["ID"]);
                        activity.DATE = Convert.ToDateTime(txtDate.Text);
                        activity.DESCRIPTION = txtDescription.Text;
                        if (!string.IsNullOrEmpty(txtDuration.Text))
                        {
                            activity.RESOURSEDURATION = Convert.ToByte(txtDuration.Text);
                        }
                        else
                        {
                            activity.RESOURSEDURATION = null;
                        }
                        DALProjectTaskResourseActivity.InsertTable(activity);

                        Response.Redirect("/Prj/PRJProjectTaskResourseDetail.aspx?ID="+PROJECTTASKID);
                    }
                    else
                    {
                        Response.Redirect("/Prj/PRJMyTasks.aspx");
                    }
                }
            }
            else
            {
                AddMessage(lblError1, "Bu aktivite tamamlanmıştır.!", false);
            }

        }

        protected void CalDate_SelectionChanged(object sender, EventArgs e)
        {
            txtDate.Text = CalDate.SelectedDate.ToShortDateString();
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