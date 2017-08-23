using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web
{
    public partial class MyInfo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(ONLINEUSER.ID.ToString()))
                {
                    ENTMEMUSER user = DALUser.GetUser(ONLINEUSER.ID);
                    if (user != null)
                    {
                        txtName.Text = user.NAME;
                        txtSurname.Text = user.SURNAME;
                        txtEposta.Text = user.MAIL;
                        txtTelephone.Text = user.PHONE.ToString();
                    }
                    else
                    {
                        Response.Redirect("/Default.aspx");
                    }
                }
                else
                {
                    Response.Redirect("/Default.aspx");
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateRecord())
            {
                ENTMEMUSER user = DALUser.GetUser(ONLINEUSER.ID);
                if (user != null)
                {
                    user.NAME = txtName.Text;
                    user.SURNAME = txtSurname.Text;
                    user.MAIL = txtEposta.Text;
                    user.PHONE = txtTelephone.Text;
                    user.PASSWORD = MD5(txtPassword.Text);  

                    DALUser.UpdateProfile(user);
                    Response.Redirect("/Login.aspx");
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
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                retval = false;
                AddMessage(lblError1, " Parola boş geçilemez!", false);
            }
            else if (string.IsNullOrEmpty(txtrePassword.Text))
            {
                retval = false;
                AddMessage(lblError1, " Parola(Tekrar) boş geçilemez!", false);
            }
            else if (txtPassword.Text!=txtrePassword.Text)
            {
                retval = false;
                AddMessage(lblError1, "Parola ve Parola(Tekrar) eşleşmiyor !", false);
            }


            return retval;

        }

        public void AddMessage(Literal lbl, string msg, bool type)
        {
            lbl.Text = "<div class='alert alert-" + (type ? "success" : "danger") + "'>" + msg + "</div>";
        }
    }
}