using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Mng
{
    public partial class MNGFirmDetail : BasePage
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
                FillUser();
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    ENTVWFRMFIRM frm = DALFirm.GetFirmInfo(Guid.Parse(Request.QueryString["ID"]));
                    if (frm != null)
                    {
                        FIRMID = frm.ID;
                        lblFirmName.Text = frm.NAME;
                        lblCity.Text = frm.FIRMCITYNAME;
                        lblDistrict.Text = frm.FIRMDISTRICTNAME;
                        lblAddress.Text = frm.ADDRESS;
                        lblDescription.Text = frm.DESCRIPTION;
                    }
                    else
                    {
                        Response.Redirect("/Mng/MNGFirms.aspx");
                    }
                }
                else
                {
                    Response.Redirect("/Mng/MNGFirms.aspx");
                }
            }
        }
        private void FillUser()
        {
            rptUsers.DataSource = DALUser.GetAllListUsers(Guid.Parse(Request.QueryString["ID"]));
            rptUsers.DataBind();
        }

        protected void rptUsers_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete":
                    {
                        DALUser.Delete(Guid.Parse(e.CommandArgument.ToString()));
                        FillUser();
                        break;
                    }
            }
        }



    }
    
}