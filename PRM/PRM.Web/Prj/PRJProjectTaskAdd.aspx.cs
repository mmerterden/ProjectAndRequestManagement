using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Prj
{
    public partial class PRJProjectTaskAdd : BasePage
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
                CalDate.Visible = false;

                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {

                }
                else if (!string.IsNullOrEmpty(Request.QueryString["PROJECTID"]))
                {
                    PROJECTID = Guid.Parse(Request.QueryString["PROJECTID"]);
                    ENTPRJPROJECT prj = DALProject.GetProject(PROJECTID);
                    if (prj != null)
                    {
                       
                        lblProjectName.Text = prj.NAME;
                    }
                    else
                    {
                        Response.Redirect("/Prj/PRJProjectDetail.aspx?ID=" + PROJECTID);
                    }
                }
                else
                {
                    Response.Redirect("/Prj/PRJProjectDetail.aspx?ID=" + PROJECTID);
                }
            }
            
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            if (ValidateRecord()) // 1) Valideta controle git hata kontrolu yapılsın. hata yok ise if içine girer.
            {

                //girilen değerleri atama yapar
                ENTPRJPROJECTTASK ptsk = new ENTPRJPROJECTTASK();
                ptsk.ID = Guid.NewGuid();
                ptsk.PROJECTID = PROJECTID;
                ptsk.NAME = txtTaskName.Text;
                ptsk.CREATEDATE = Convert.ToDateTime(txtCreateDate.Text);
                ptsk.DESCRIPTION = txtDescription.Text;
                ptsk.DUEDATE = null;
                ptsk.TYPEPROJECTTASKSTATUSID = 1;
                DALProjectTask.InsertTable(ptsk); //bu fonksiyona gider atama yapılmıs degerlerı tabloya dataya kayıt eder 

                Response.Redirect("/Prj/PRJProjectDetail.aspx?ID=" + PROJECTID);


            }
        }
        private bool ValidateRecord() // 2) kayıt yapılırken istenilen ozellikler bos mu degıl mı diye kontrol edılır. kontrolde hata yoksa validate fonksıyonunua 1. işleme geri doner
        {
            bool retval = true;

            if (string.IsNullOrEmpty(txtTaskName.Text))
            {
                retval = false;
                AddMessage(lblError1, "Görev Adı boş geçilemez!", false);
            }
            else if (string.IsNullOrEmpty(txtCreateDate.Text))
            {
                retval = false;
                AddMessage(lblError1, "Termin Tarihi boş geçilemez!", false);
            }
            else if (string.IsNullOrEmpty(txtDescription.Text))
            {
                retval = false;
                AddMessage(lblError1, "Açıklama alanı boş geçilemez!", false);
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

        protected void CalDate_SelectionChanged(object sender, EventArgs e)
        {
            txtCreateDate.Text = CalDate.SelectedDate.ToShortDateString();
        }   
    }
}