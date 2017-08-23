using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Prj
{
    public partial class PRJProjectTaskResourceAdd : BasePage
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

        protected Guid USERID
        {
            get
            {
                if (ViewState["USERID"] == null)
                {
                    ViewState["USERID"] = Guid.Empty;
                }
                return Guid.Parse(ViewState["USERID"].ToString());
            }
            set { ViewState["USERID"] = value; }
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

                DrpFullNameFill();
                DrpProjectTaskResourseStatusFill();


                if (!string.IsNullOrEmpty(Request.QueryString["PROJECTTASKID"]))//PROJECTTASKID VE GÖREV ADINI GETİRDİM GETİRDİM .
                {
                    ENTVWPRJPROJECTTASK ptsk = DALProjectTask.GetValueTask(Guid.Parse(Request.QueryString["PROJECTTASKID"]));


                    if (ptsk != null)
                    {
                        PROJECTID = ptsk.PROJECTID;
                        PROJECTTASKID = ptsk.ID;
                        lblProjectTaskName.Text = ptsk.NAME;

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

        public void DrpFullNameFill()
        {
            List<ENTVWFULLNAME> list = DALUserFullName.GetAllListUsersForResourse();
            drpFullName.Items.Clear();
            drpFullName.DataSource = list;
            drpFullName.DataValueField = "ID";
            drpFullName.DataTextField = "USERFULLNAME";
            drpFullName.DataBind();
            drpFullName.Items.Insert(0, new ListItem("Seçiniz", "0"));
        }
        public void DrpProjectTaskResourseStatusFill()
        {
            List<ENTPRJTYPEPROJECTTASKRESOURSESTATUS> list = DALProjectTaskResourse.GetAllProjectTaskResourseStatus();
            drpIsComplete.Items.Clear();
            drpIsComplete.DataSource = list;
            drpIsComplete.DataValueField = "ID";
            drpIsComplete.DataTextField = "NAME";
            drpIsComplete.DataBind();
            drpIsComplete.Items.Insert(0, new ListItem("Seçiniz", "0"));
        }
        
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            
           
            if (ValidateRecord() && ValidateControlUser())
            {
                ENTPRJPROJECTTASKRESOURSE ptskrsrs = new ENTPRJPROJECTTASKRESOURSE();
                ptskrsrs.ID = Guid.NewGuid();
                ptskrsrs.PROJECTTASKID = PROJECTTASKID;
                ptskrsrs.USERID = Guid.Parse(drpFullName.SelectedValue);
                ptskrsrs.DURATION = Convert.ToByte(txtHour.Text);
                ptskrsrs.TYPEPROJECTRESOURSESTATUSID = Convert.ToByte(drpIsComplete.SelectedValue);
                //ptskrsrs.ISCOMPLETE = false;
                
                DALProjectTaskResourse.InsertTable(ptskrsrs); //bu fonksiyona gider atama yapılmıs degerlerı tabloya dataya kayıt eder 
                Response.Redirect("/Prj/PRJProjectTaskResourseDetail.aspx?ID=" + PROJECTTASKID);


            }

        }
        private bool ValidateControlUser()
        {
            bool cntrl = true;
            USERID = Guid.Parse(drpFullName.SelectedValue);
            cntrl = DALProjectTaskResourse.ControltoUSER(PROJECTTASKID, USERID);
            if (cntrl)
            {
                cntrl = false;
                AddMessage(lblError1, "Bu göreve bu çalışan eklenmiştir.", false);
            }
            else
            {
                cntrl = true;
                return cntrl;
            }
            return cntrl;

        }
        private bool ValidateRecord() // 2) kayıt yapılırken istenilen ozellikler bos mu degıl mı diye kontrol edılır. kontrolde hata yoksa validate fonksıyonunua 1. işleme geri doner
        {
            bool retval = true;
            if (drpFullName.SelectedValue == "0")
            {
                retval = false;
                AddMessage(lblError1, "Ad Soyad seçiniz!", false);
            }
            else if (drpIsComplete.SelectedValue == "0")
            {
                retval = false;
                AddMessage(lblError1, "Durum  seçiniz!", false);
            }


            return retval;

        }
        public void AddMessage(Literal lbl, string msg, bool type)
        {
            lbl.Text = "<div class='alert alert-" + (type ? "success" : "danger") + "'>" + msg + "</div>";
        }


    }
}