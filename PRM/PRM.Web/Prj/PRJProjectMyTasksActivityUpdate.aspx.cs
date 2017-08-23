using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Prj
{
    public partial class PRJProjectMyTasksActivityUpdate : BasePage
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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CalDate.Visible = false;
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                     ENTVWPRJPROJECTTASKRESOURSEACTIVITY activity = DALProjectTaskResourseActivity.GetValueTaskResourseActivity(Guid.Parse(Request.QueryString["ID"]));
                    if (activity != null)
                    {
                        PROJECTTASKRESOURSEID= activity.PROJECTTASKRESOURSEID;
                        PROJECTTASKID=activity.PROJECTTASKID;
                        lblProjectName.Text = activity.PROJECTNAME;
                        lblProjectTaskName.Text = activity.PROJECTTASKNAME;
                        txtDuration.Text = activity.RESOURSEDURATION.ToString();
                        txtDate.Text = activity.DATE.ToString();
                        txtDescription.Text = activity.DESCRIPTION;
                    }
                    else
                    {
                        Response.Redirect("/Prj/PRJMyActivity.aspx?ID="+PROJECTTASKRESOURSEID);
                    }
                }
                else
                {
                    Response.Redirect("/Prj/PRJMyTasks.aspx");
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateRecord())
            {
                ENTPRJPROJECTTASKRESOURSEACTIVITY activity = DALProjectTaskResourseActivity.GetValueTaskResourseActivityForUpdate(Guid.Parse(Request.QueryString["ID"]));
                if (activity != null)
                {
                    activity.ID = Guid.Parse(Request.QueryString["ID"]);
                    if (!string.IsNullOrEmpty(txtDuration.Text))
                    {
                        activity.RESOURSEDURATION = Convert.ToByte(txtDuration.Text);
                    }
                    else
                    {
                        activity.RESOURSEDURATION = null;
                    }
                    activity.DESCRIPTION = txtDescription.Text;
                    activity.DATE = DateTime.Parse(txtDate.Text);
                    DALProjectTaskResourseActivity.UpdateActivity(activity);
                    Response.Redirect("/Prj/PRJMyActivity.aspx?ID=" + PROJECTTASKRESOURSEID);

                }
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
