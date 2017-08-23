using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Prj
{
    public partial class PRJProjectTaskUpdate : BasePage
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
            if (!Page.IsPostBack)
            {
                CalDate.Visible = false;
                CalDate1.Visible = false;

                DrpStatusFill();
                if (!string.IsNullOrEmpty(Request.QueryString["PROJECTTASKID"]))
                {
                    ENTVWPRJPROJECTTASK ptsk = DALProjectTask.GetValueTask(Guid.Parse(Request.QueryString["PROJECTTASKID"]));
                    if (ptsk != null) 
                    {
                        PROJECTTASKID = ptsk.ID;
                        PROJECTID=ptsk.PROJECTID; //Project detaila dönmek icin projectıd degerini aldık.
                        lblProjectName.Text = ptsk.PROJECTNAME.ToString();
                        txtCreateDate.Text = ptsk.CREATEDATE.ToString();
                        txtDueDate.Text = ptsk.DUEDATE.ToString();
                        drpStatus.SelectedValue = ptsk.TYPEPROJECTTASKSTATUSID.ToString();
                        txtTaskName.Text = ptsk.NAME;
                        txtDescription.Text = ptsk.DESCRIPTION;
                    }
                    else
                    {
                        Response.Redirect("/Prj/PRJProjectTaskResourseDetail.aspx?ID=" + PROJECTTASKID);
                    }
                }
                else
                {
                    Response.Redirect("/Prj/PRJProjects.aspx");
                }

            }
            
        }

        public void DrpStatusFill()
        {
            List<ENTTYPEPROJECTTASKSTATUS> list = DALProjectTask.GetAllStatusTask();
            drpStatus.Items.Clear();
            drpStatus.DataSource = list;
            drpStatus.DataValueField = "ID";
            drpStatus.DataTextField = "NAME";


            drpStatus.DataBind();
            drpStatus.Items.Insert(0, new ListItem("Seçiniz", "0"));
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateRecord()) // 1) Valideta controle git hata kontrolu yapılsın. hata yok ise if içine girer.
            {
                ENTPRJPROJECTTASK ptsk = DALProjectTask.GetTask(Guid.Parse(Request.QueryString["PROJECTTASKID"]));
                if (ptsk != null)
                {
                  
                    ptsk.NAME = txtTaskName.Text;
                    ptsk.CREATEDATE = Convert.ToDateTime(txtCreateDate.Text);
                    if (!string.IsNullOrEmpty(txtDueDate.Text))
                    {
                        ptsk.DUEDATE = Convert.ToDateTime(txtDueDate.Text);
                    }
                    else
                    {
                        ptsk.DUEDATE = null;
                    }
                    ptsk.TYPEPROJECTTASKSTATUSID = Convert.ToByte(drpStatus.SelectedValue);
                    ptsk.DESCRIPTION = txtDescription.Text;

                    DALProjectTask.Update(ptsk);
                    Response.Redirect("/Prj/PRJProjectTaskResourseDetail.aspx?ID=" + PROJECTTASKID);

                }
            }
        }

     
        private bool ValidateRecord() // 2) kayıt yapılırken istenilen ozellikler bos mu degıl mı diye kontrol edılır. kontrolde hata yoksa validate fonksıyonunua 1. işleme geri doner
        {
            bool retval = true;


            if (string.IsNullOrEmpty(txtTaskName.Text))
            {
                retval = false;
                AddMessage(lblError1, "Görev adı boş geçilemez!", false);
            }
            else if (string.IsNullOrEmpty(txtCreateDate.Text))
            {
                retval = false;
                AddMessage(lblError1, "Termin tarihi boş geçilemez!", false);
            }
            else if (drpStatus.SelectedValue == "0")
            {
                retval = false;
                AddMessage(lblError1, "Durum seçiniz!", false);
            }
            else if (string.IsNullOrEmpty(txtDescription.Text))
            {
                retval = false;
                AddMessage(lblError1, "Açıklama boş geçilemez!", false);
            }

            return retval;

        }

        public void AddMessage(Literal lbl, string msg, bool type)
        {
            lbl.Text = "<div class='alert alert-" + (type ? "success" : "danger") + "'>" + msg + "</div>";
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
        protected void btnCal1_Click(object sender, EventArgs e)
        {
            updPanl1.Update();
            if (CalDate1.Visible == false)
            {
                CalDate1.Visible = true;
            }
            else CalDate1.Visible = false;
        }

        protected void CalDate_SelectionChanged(object sender, EventArgs e)
        { 
            txtCreateDate.Text= CalDate.SelectedDate.ToShortDateString();
            txtDueDate.Text= CalDate1.SelectedDate.ToShortDateString();

        }

      
    }
}
