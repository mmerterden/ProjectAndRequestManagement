using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Mng
{
    public partial class MNGFirmUpdate : BasePage
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
                DrpCityFill();
                Guid.Parse(ONLINEUSER.ID.ToString());
                if (drpCity.SelectedValue != "0")
                {
                    DrpDistrictFill();
                   
                }


                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    ENTFRMFIRM firm = DALFirm.GetFirm(Guid.Parse(Request.QueryString["ID"]));
                    if (firm != null)
                    {
                        FIRMID = firm.ID;
                        txtFirmName.Text = firm.NAME;
                        txtDescription.Text = firm.DESCRIPTION;
                        txtAddress.Text = firm.ADDRESS;
                        drpCity.SelectedValue = firm.CITYID.ToString();
                        drpDistrict.SelectedValue = firm.DISTRICTID.ToString();
                    }
                    else
                    {
                        Response.Redirect("/Mng/MNGFirmDetail.aspx?ID="+FIRMID);
                    }
                }
                else
                {
                    Response.Redirect("/Mng/MNGFirms.aspx");
                }
            }
        }
        public void DrpCityFill()
        {
            List<ENTSYSCITY> list = DALCity.GetAllListCity();
            drpCity.Items.Clear();
            drpCity.DataSource = list;
            drpCity.DataValueField = "ID";
            drpCity.DataTextField = "NAME";
            drpCity.Items.Insert(0, new ListItem("Seçiniz", "0"));
            drpCity.DataBind();
        }

        public void DrpDistrictFill()
        {

            drpDistrict.Items.Clear();
            drpDistrict.Enabled = true;
            drpDistrict.DataSource = DALDistrict.GetAllListDistrict(Convert.ToByte(drpCity.SelectedValue));
            drpDistrict.DataValueField = "ID";
            drpDistrict.DataTextField = "NAME";
            drpDistrict.DataBind();
            drpDistrict.Items.Insert(0, new ListItem("Seçiniz", "0"));



        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateRecord()) 
            {
                ENTFRMFIRM firm = DALFirm.GetFirm(Guid.Parse(Request.QueryString["ID"]));
                if (firm != null)
                {
                    firm.NAME = txtFirmName.Text;
                    firm.DESCRIPTION = txtDescription.Text;
                    firm.ADDRESS = txtAddress.Text;
                    firm.CITYID = Convert.ToByte(drpCity.SelectedValue);
                    firm.DISTRICTID = Convert.ToInt16(drpDistrict.SelectedValue);
                    DALFirm.Update(firm);
                    Response.Redirect("/Mng/MNGFirmDetail.aspx?ID="+FIRMID);
                }
            }
        }
        private bool ValidateRecord()
        {
            bool retval = true;
            if (string.IsNullOrEmpty(txtFirmName.Text))
            {
                retval = false;
                AddMessage(lblError2, "Şirket Adı boş geçilemez!", false);

            }
             else if (drpCity.SelectedValue == "0")
            {
                retval = false;
                AddMessage(lblError2, "İl seçiniz!", false);

            }
            else if (drpDistrict.SelectedValue == "0")
            {
                retval = false;
                AddMessage(lblError2, "İlçe seçiniz!", false);

            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                retval = false;
                AddMessage(lblError2, "Adres Adı boş geçilemez!", false);
            }
            return retval;
        }

        public void AddMessage(Literal lbl, string msg, bool type)
        {
            lbl.Text = "<div class='alert alert-" + (type ? "success" : "danger") + "'>" + msg + "</div>";
        }
        protected void drpCity_SelectedIndexChanged(object sender, EventArgs e)
        {

            DrpDistrictFill();

        }
    

    }
}