using PRM.DataLayer;//1 )Diger projeye bağladık
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Prj 
{
    public partial class PRJProjectAdd : BasePage //2)Base page miras aldık.
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                
                DrpFirmFill();
                DrpStatusFill();
            }

        }
        public void DrpFirmFill()//Firmaları dropboxa getirdim.
        {
            List<ENTVWFRMFIRM> list = DALFirm.GetAllListFirms();
            drpFirm.Items.Clear();
            drpFirm.DataSource = list;
            drpFirm.DataValueField = "ID";
            drpFirm.DataTextField = "NAME";

            drpFirm.DataBind();
            drpFirm.Items.Insert(0, new ListItem("Seçiniz", "0"));
        }

        public void DrpStatusFill()
        {
            List<ENTTYPEPROJECTSTATUS> list = DALProject.GetAllStatus();
            drpStatus.Items.Clear();
            drpStatus.DataSource = list;
            drpStatus.DataValueField = "ID";
            drpStatus.DataTextField = "NAME";


            drpStatus.DataBind();
            drpStatus.Items.Insert(0, new ListItem("Seçiniz", "0"));
        }

        protected void btnAddNew_Click(object sender, EventArgs e) // 3)Validate kontrolü yazıyoruz
        {
            if (ValidateRecord())
            {
                ENTPRJPROJECT prj = new ENTPRJPROJECT();
                prj.ID = Guid.NewGuid();
                prj.NAME = txtProjectName.Text;
                prj.TYPEPROJECTSTATUSID = Convert.ToByte(drpStatus.SelectedValue);
                prj.FIRMID = Guid.Parse(drpFirm.SelectedValue);


                DALProject.InsertTable(prj); //bu fonksiyona gider atama yapılmıs degerlerı tabloya dataya kayıt eder 
                Response.Redirect("/Prj/PRJProjects.aspx");
            }
        }
        private bool ValidateRecord() //4)Kontrolü farklı bir fonksiyonda yazıyoruz.
        {
            bool retval = true ;
            if (string.IsNullOrEmpty(txtProjectName.Text))
            {
                retval = false;
                AddMessage(lblError1, "Proje Adı alanı boş geçilemez!", false);
            }
            else if (drpFirm.SelectedValue=="0")
            {
                retval = false;
                AddMessage(lblError1, "Şirket Adı alanı boş geçilemez!", false);
            }
            else if (drpStatus.SelectedValue == "0")
            {
                retval = false;
                AddMessage(lblError1, "Durumu alanı boş geçilemez!", false);
            }
            return retval;
        }
        public void AddMessage(Literal lbl,string msg,bool type) // 5)Mesajı farklı bir fonksiyonda yazıyoruz.
        {
            lbl.Text= "<div class='alert alert-" + (type ? "success" : "danger") + "'>" + msg + "</div>";
        }
    }
}