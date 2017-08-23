using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web
{
    public partial class Login : BasePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            LOGINREQUIRED = false;
            base.OnInit(e);
        }
        private string COOKIENAME= "ONLINEUSER-COOKIE-PM";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Cookies[COOKIENAME] != null)
                {
                   
                    HttpCookie cookie = Request.Cookies[COOKIENAME];
                    if(cookie != null)
                    {
                            string mail = cookie["MAIL"].ToString();
                            string password = cookie["PASSWORD"].ToString();
                            ENTMEMUSER user = DALUser.GetUser(mail, password);
                            if (user != null)
                            {
                                if (user.STATUS)
                                {
                                    ONLINEUSER.ID = user.ID;
                                    ONLINEUSER.NAME = user.NAME;
                                    ONLINEUSER.SURNAME = user.SURNAME;
                                    ONLINEUSER.FULLNAME = user.NAME + " " + user.SURNAME;
                                    ONLINEUSER.MAIL = user.MAIL;
                                    ONLINEUSER.TYPEUSERID = user.TYPEUSERID;
                                    ONLINEUSER.FIRMID = user.FIRMID;
                                    ONLINEUSER.ISADMIN = user.ISADMIN;
                                    ONLINEUSER.STATUS = user.STATUS;
                                   
                                    Response.Redirect("/Default.aspx");
                                }
                                else
                                {
                                    AddMessage(lblError, "Hesabınız pasiftir!", false);
                                }
                            }
                            else
                            {
                                AddMessage(lblError, "Kullanıcı adı yada Şifre yanlış!", false);
                            }
            
                    }
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateRecord())
            {
                ENTMEMUSER user = DALUser.GetUser(txtMail.Text, MD5(txtPassword.Text));
                if (user != null)
                {
                    if (user.STATUS)
                    {
                        ONLINEUSER.ID = user.ID;
                        ONLINEUSER.NAME = user.NAME;
                        ONLINEUSER.SURNAME = user.SURNAME;
                        ONLINEUSER.FULLNAME = user.NAME + " " + user.SURNAME;
                        ONLINEUSER.MAIL = user.MAIL;
                        ONLINEUSER.TYPEUSERID = user.TYPEUSERID;
                        ONLINEUSER.FIRMID = user.FIRMID;
                        ONLINEUSER.ISADMIN = user.ISADMIN;
                        ONLINEUSER.STATUS = user.STATUS;
                        if (chkRememberMe.Checked)
                        {
                            HttpCookie cookie = new HttpCookie(COOKIENAME);
                            cookie.Values.Add("MAIL", ONLINEUSER.MAIL);
                            cookie.Values.Add("PASSWORD", MD5(txtPassword.Text));
                            cookie.Expires = DateTime.Now.AddDays(1);
                            Response.Cookies.Add(cookie);
                        }
                        else
                        {
                            if (Request.Cookies[COOKIENAME] != null)
                            {
                                HttpCookie cookie = Request.Cookies[COOKIENAME];
                                cookie.Values.Clear();
                                cookie.Expires = DateTime.MinValue;
                                Response.Cookies.Add(cookie);
                            }
                        }
                        Response.Redirect("/Default.aspx");
                    }
                    else
                    {
                        AddMessage(lblError, "Hesabınız pasiftir!", false);
                    }
                }
                else
                {
                    AddMessage(lblError, "Kullanıcı adı yada Şifre yanlış!", false);
                }
            }
        }

        private bool ValidateRecord()
        {
            bool retval = true;

            if (string.IsNullOrEmpty(txtMail.Text))
            {
                retval = false;
                AddMessage(lblError, "Kullanıcı adı boş geçilemez!", false);
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                retval = false;
                AddMessage(lblError, "Şifre boş geçilemez!", false);
            }
            return retval;
        }
        public void AddMessage(Literal lbl, string msg, bool type)
        {
            lbl.Text = "<div class='alert alert-" + (type ? "success" : "danger") + "'>" + msg + "</div>";
        }

      
    }
}