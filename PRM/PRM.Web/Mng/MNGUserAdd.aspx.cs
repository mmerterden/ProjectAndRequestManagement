using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Mng
{
    public partial class MNGUserAdd : BasePage
    {
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
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    FIRMID = Guid.Parse(Request.QueryString["ID"]);
                    ENTFRMFIRM frm = DALFirm.GetFirm(FIRMID);
                    if (frm != null)
                    {

                        lblFirm.Text = frm.NAME;
                    }
                    else
                    {
                        Response.Redirect("/Mng/MNGFirmDetail.aspx?ID=" + FIRMID);
                    }
                }
                else
                {
                    Response.Redirect("/Mng/MNGFirmDetail.aspx?ID=" + FIRMID);
                }

                //DrpFirmFill();
                DrpTypeUser();
                DrpLanguage();
                CalDate.Visible = false;
            }

        }
        //public void DrpFirmFill()
        //{
        //    List<ENTVWFRMFIRM> list = DALFirm.GetAllListFirms();
        //    drpFirm.Items.Clear();
        //    drpFirm.DataSource = list;
        //    drpFirm.DataValueField = "ID";
        //    drpFirm.DataTextField = "NAME";

        //    drpFirm.DataBind();
        //    drpFirm.Items.Insert(0, new ListItem("Seçiniz", "0"));
        //}
        public void DrpTypeUser()
        {
            drpUserType.DataSource = DALTypeUser.GetAllListTypeUsers();
            drpUserType.Items.Clear();
            drpUserType.DataTextField = "NAME";
            drpUserType.DataValueField = "ID";
            drpUserType.DataBind();
            drpUserType.Items.Insert(0, new ListItem("Seçiniz", "0"));
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

        

       
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateRecord()) // 1) Valideta controle git hata kontrolu yapılsın. hata yok ise if içine girer.
            {

                //girilen değerleri atama yapar
                ENTMEMUSER user = new ENTMEMUSER();
                user.ID = Guid.NewGuid();
                user.MAIL = txtEposta.Text;
                user.PASSWORD = MD5("1");
                user.NAME = txtName.Text;
                user.SURNAME = txtSurname.Text;
                user.CREATEDATE = Convert.ToDateTime(txtRecorddate.Text);
                user.TYPEUSERID = Convert.ToByte(drpUserType.SelectedValue);
                user.ISADMIN = chkAdmin.Checked;
                user.PHONE = txtTelephone.Text;
                user.STATUS = Convert.ToBoolean(true);
                user.FIRMID = FIRMID;
                //user.FIRMID = Guid.Parse(drpFirm.SelectedValue);
                user.LANGUAGEID = byte.Parse(drpLanguage.SelectedValue);



                DALUser.InsertTable(user); //bu fonksiyona gider atama yapılmıs degerlerı tabloya dataya kayıt eder 
                Response.Redirect("/Mng/MNGFirmDetail.aspx?ID="+FIRMID);


            }

        }
        private bool ValidateRecord() // 2) kayıt yapılırken istenilen ozellikler bos mu degıl mı diye kontrol edılır. kontrolde hata yoksa validate fonksıyonunua 1. işleme geri doner
        {
            bool retval = true;

            if (string.IsNullOrEmpty(txtName.Text))
            {
                retval = false;
                AddMessage(lblError1, "Ad boş geçilemez!", false);
            }
            else if (txtName.Text.Length<=2 )
            {
                retval = false;
                AddMessage(lblError1, "Geçerli ad giriniz!", false);
            }
            else if (string.IsNullOrEmpty(txtSurname.Text))
            {
                retval = false;
                AddMessage(lblError1, "Soyadı boş geçilemez!", false);
            }
            else if (txtSurname.Text.Length <2)
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
            else if ((txtTelephone.Text.Length != 11)&&(txtTelephone.Text.Length != 0))
            {
                retval = false;
                AddMessage(lblError1, " Geçerli telefon numarası giriniz!", false);
            }
            //else if (drpFirm.SelectedValue == "0")
            //{
            //    retval = false;
            //    AddMessage(lblError1, "Şirket seçiniz!", false);
            //}
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
            txtRecorddate.Text = CalDate.SelectedDate.ToShortDateString(); 
        }

    }
}