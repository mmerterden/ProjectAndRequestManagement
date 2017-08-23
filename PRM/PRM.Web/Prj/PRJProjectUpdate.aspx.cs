using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Prj
{
    public partial class PRJProjectUpdate : BasePage
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
            if(!Page.IsPostBack)
            {

                Guid.Parse(ONLINEUSER.ID.ToString());
                DrpFirmFill();
                DrpStatusFill();

                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {

                }
                else if (!string.IsNullOrEmpty(Request.QueryString["PROJECTID"]))
                {
                    PROJECTID = Guid.Parse(Request.QueryString["PROJECTID"]);
                    ENTPRJPROJECT prjupdate = DALProject.GetProject(PROJECTID);
                    if (prjupdate != null)
                    {
                        txtProjectName.Text = prjupdate.NAME;
                        txtDescription.Text = prjupdate.DESCRIPTION;
                        drpFirm.SelectedValue = prjupdate.FIRMID.ToString();
                        drpStatus.SelectedValue = prjupdate.TYPEPROJECTSTATUSID.ToString();
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateRecord())
            {
                ENTPRJPROJECT prj = DALProject.GetProject(Guid.Parse(Request.QueryString["PROJECTID"]));
                if (prj != null)
                {
                    prj.NAME = txtProjectName.Text;
                    prj.DESCRIPTION =txtDescription.Text;
                    prj.FIRMID = Guid.Parse(drpFirm.SelectedValue);
                    prj.TYPEPROJECTSTATUSID = Convert.ToByte(drpStatus.SelectedValue);
                    DALProject.Update(prj);
                    Response.Redirect("/Prj/PRJProjectDetail.aspx?ID="+PROJECTID);
                }
            }
        }
        private bool ValidateRecord() //4)Kontrolü farklı bir fonksiyonda yazıyoruz.
        {
            bool retval = true;
            if (string.IsNullOrEmpty(txtProjectName.Text))
            {
                retval = false;
                AddMessage(lblError1, "Proje Adı alanı boş geçilemez!", false);
            }
            else if (drpFirm.SelectedValue == "0")
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
        public void AddMessage(Literal lbl, string msg, bool type) // 5)Mesajı farklı bir fonksiyonda yazıyoruz.
        {
            lbl.Text = "<div class='alert alert-" + (type ? "success" : "danger") + "'>" + msg + "</div>";
        }
    }
}