
using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Mng
{
    public partial class MNGUserUpdate : BasePage
    {
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
        protected Guid FIRMID
        {
            get
            {
                if (ViewState["FIRMID"] == null)
                {
                    ViewState["FIRMID"] = Guid.Empty;
                }
                return Guid.Parse(ViewState["FIRMID"].ToString());
            }
            set { ViewState["FIRMID"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                CalDate.Visible = false;
                DrpFirmFill();
                DrpTypeUser();
                DrpLanguage();
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    FIRMID=DALUser.GetFirmID(Guid.Parse(Request.QueryString["ID"]));
                    ENTMEMUSER user = DALUser.GetUser(Guid.Parse(Request.QueryString["ID"]));
                    if (user != null)
                    {
                        USERID=user.ID;
                        txtName.Text = user.NAME;
                        txtSurname.Text = user.SURNAME;
                        txtEposta.Text = user.MAIL;
                        txtRecorddate.Text = user.CREATEDATE.ToString();
                        txtTelephone.Text = user.PHONE.ToString();
                        drpStatus.SelectedValue = user.STATUS ? "1" : "2";
                        drpUserType.SelectedValue = user.TYPEUSERID.ToString();
                        drpFirm.SelectedValue = user.FIRMID.ToString();
                        drpLanguage.SelectedValue = user.LANGUAGEID.ToString();
                    }
                    else
                    {
                        Response.Redirect("/Mng/MNGUserDetail.aspx?ID=" + USERID);
                    }
                }
                else
                {
                    Response.Redirect("/Mng/MNGFirms.aspx");
                }
            }
        }
        public void DrpTypeUser()
        {
            drpUserType.DataSource = DALTypeUser.GetAllListTypeUsers();
            drpUserType.DataTextField = "NAME";
            drpUserType.DataValueField = "ID";
            drpUserType.DataBind();
            drpUserType.Items.Insert(0, new ListItem("Seçiniz", "0"));
        }
        public void DrpFirmFill()
        {
            List<ENTVWFRMFIRM> list = DALFirm.GetAllListFirms();
            drpFirm.Items.Clear();
            drpFirm.DataSource = list;
            drpFirm.DataValueField = "ID";
            drpFirm.DataTextField = "NAME";
            drpFirm.Items.Insert(0, new ListItem("Seçiniz", "0"));
            drpFirm.DataBind();
        }
        public void DrpLanguage()
        {
            drpLanguage.DataSource = DALLanguage.GetAllLanguage();
            drpLanguage.Items.Clear();
            drpLanguage.DataTextField = "NAME";
            drpLanguage.DataValueField = "ID";
            drpLanguage.DataBind();
            drpLanguage.Items.Insert(0, new ListItem("Seçiniz", "0"));
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateRecord())
            {
                ENTMEMUSER user = DALUser.GetUser(Guid.Parse(Request.QueryString["ID"]));
                if (user != null)
                {
                    user.NAME = txtName.Text;
                    user.SURNAME = txtSurname.Text;
                    user.CREATEDATE = Convert.ToDateTime(txtRecorddate.Text);
                    user.MAIL = txtEposta.Text;
                    user.FIRMID = Guid.Parse(drpFirm.SelectedValue);
                    user.PHONE = txtTelephone.Text;
                    user.STATUS = drpStatus.SelectedValue == "1";
                    user.TYPEUSERID = Convert.ToByte(drpUserType.SelectedValue);
                    user.LANGUAGEID = Convert.ToByte(drpLanguage.SelectedValue);
                    DALUser.Update(user);
                    Response.Redirect("/Mng/MNGUserDetail.aspx?ID="+USERID);
                }
            }

        }
        
        private bool ValidateRecord()
        {
            bool retval = true;

            if (string.IsNullOrEmpty(txtName.Text))
            {
                retval = false;
                AddMessage(lblError1, "Ad boş geçilemez!", false);
            }
            else if (txtName.Text.Length <= 2)
            {
                retval = false;
                AddMessage(lblError1, "Geçerli ad giriniz!", false);
            }
            else if (string.IsNullOrEmpty(txtSurname.Text))
            {
                retval = false;
                AddMessage(lblError1, "Soyadı boş geçilemez!", false);
            }
            else if (txtSurname.Text.Length < 2)
            {
                retval = false;
                AddMessage(lblError1, "Geçerli soyad giriniz!", false);
            }
            else if (string.IsNullOrEmpty(txtEposta.Text))
            {
                retval = false;
                AddMessage(lblError1, "E-Posta boş geçilemez!", false);
            }
            else if (!txtEposta.Text.Contains("@prm.com"))
            {
                retval = false;
                AddMessage(lblError1, " Geçerli E-Posta giriniz!", false);
            }
            else if ((txtTelephone.Text.Length != 11) && (txtTelephone.Text.Length != 0))
            {
                retval = false;
                AddMessage(lblError1, " Geçerli telefon numarası giriniz!", false);
            }
            else if (drpFirm.SelectedValue == "0")
            {
                retval = false;
                AddMessage(lblError1, "Şirket seçiniz!", false);
            }
            else if (drpStatus.SelectedValue == "0")
            {
                retval = false;
                AddMessage(lblError1, "Durum seçiniz!", false);
            }
            else if (drpUserType.SelectedValue == "0")
            {
                retval = false;
                AddMessage(lblError1, "Kullancı Tipi seçiniz!", false);
            }
            else if (drpLanguage.SelectedValue == "0")
            {
                retval = false;
                AddMessage(lblError1, "Dili seçiniz!", false);
            }

            return retval;

        }

        public void AddMessage(Literal lbl, string msg, bool type)
        {
            lbl.Text = "<div class='alert alert-" + (type ? "success" : "danger") + "'>" + msg + "</div>";
        }
        protected void CalDate_SelectionChanged(object sender, EventArgs e)
        {
            txtRecorddate.Text = CalDate.SelectedDate.ToShortDateString();
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