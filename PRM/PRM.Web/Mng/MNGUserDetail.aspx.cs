using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Mng
{
    public partial class MNGUserDetail : BasePage
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
                
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    FIRMID = DALUser.GetFirmID(Guid.Parse(Request.QueryString["ID"]));
                    ENTVWMEMUSER usr = DALUser.GetUserInfo(Guid.Parse(Request.QueryString["ID"]));
                    if (usr != null)
                    {

                        USERID = usr.ID;
                        lblName.Text = usr.NAME;
                        lblSurname.Text = usr.SURNAME;
                        lblFirmName.Text = usr.FIRMNAME;
                        lblPhone.Text = usr.PHONE;
                        lblEmail.Text = usr.MAIL;
                        lblStatus.Text = usr.STATUS ? "Aktif" : "Pasif";
                        lblCreateDate.Text = usr.CREATEDATE.ToString();
                        lblLanguage.Text = usr.LANGUAGENAME;
                        lblUserType.Text = usr.TYPEUSERNAME;

                    }
                    else
                    {
                        Response.Redirect("/Mng/MNGFirmDetail.aspx");
                    }
                }
                else
                {
                    Response.Redirect("/Mng/MNGFirms.aspx");
                }
            }

        }
    }
}