using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Mng
{
    public partial class MNGFirmAdd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DrpCityFill();

            }
        }

        public void DrpCityFill()
        {
            List<ENTSYSCITY> list = DALCity.GetAllListCity();
            drpCity.Items.Clear();
            drpCity.DataSource = list;
            drpCity.DataValueField = "ID";
            drpCity.DataTextField = "NAME";

            drpCity.DataBind();
            drpCity.Items.Insert(0, new ListItem("Seçiniz", "0"));
        }

        public void DrpDistrictFill()
        {

            drpDistrict.Items.Clear();
            if (drpCity.SelectedValue == "0")
            {
                drpDistrict.Items.Insert(0, new ListItem("Önce İl Seçiniz", "0"));
                drpDistrict.Enabled = false;
            }
            else
            {
                drpDistrict.Enabled = true;
                drpDistrict.DataSource = DALDistrict.GetAllListDistrict(Convert.ToByte(drpCity.SelectedValue));
                drpDistrict.DataValueField = "ID";
                drpDistrict.DataTextField = "NAME";
                drpDistrict.DataBind();
                drpDistrict.Items.Insert(0, new ListItem("Seçiniz", "0"));
            }


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (ValidateRecord())
            {
                ENTFRMFIRM firm = new ENTFRMFIRM();
                firm.ID = Guid.NewGuid();
                firm.NAME = txtFirmName.Text;
                firm.DESCRIPTION = txtDescription.Text;
                firm.CITYID = Convert.ToByte(drpCity.SelectedValue);
                firm.DISTRICTID = Convert.ToInt16(drpCity.SelectedValue);
                firm.ADDRESS = txtAddress.Text;

                DALFirm.InsertTable(firm);
                Response.Redirect("/Mng/MNGFirms.aspx");

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
                AddMessage(lblError2, "Adres boş geçilemez!", false);
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