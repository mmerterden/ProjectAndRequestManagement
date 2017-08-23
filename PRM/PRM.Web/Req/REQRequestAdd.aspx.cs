using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Req
{
    public partial class REQRequestAdd : BasePage
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!Page.IsPostBack)
                {
                    DrpProjectFill();
                }
            }
        }

        public void DrpProjectFill()
        {
            List<ENTVWPRJPROJECT> list = DALProject.GetAllListProjectRequest(Guid.Parse(ONLINEUSER.FIRMID.ToString()));
            
            drpProjectName.Items.Clear();
            drpProjectName.DataSource = list;
            drpProjectName.DataValueField = "ID";
            drpProjectName.DataTextField = "NAME";
            drpProjectName.DataBind();
            drpProjectName.Items.Insert(0, new ListItem("Seçiniz", "0"));
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateRecord())
            {
                ENTREQREQUESTS rqst = new ENTREQREQUESTS();
                rqst.ID = Guid.NewGuid();
                rqst.NAME = txtRequestName.Text;
                rqst.DESCRIPTION = txtDescription.Text;
                rqst.USERID = ONLINEUSER.ID;
                rqst.PROJECTID = Guid.Parse(drpProjectName.SelectedValue);
                rqst.REQUESTDATE = DateTime.Now;
                rqst.TYPEREQUESTID = 1;
                DALRequest.InsertTable(rqst);

                Response.Redirect("/Req/REQRequests.aspx");
            }
        }
        private bool ValidateRecord()
        {
            bool retval = true;

            if (drpProjectName.SelectedValue == "0")
            {
                retval = false;
                AddMessage(lblError1, "Proje alanı geçilemez!", false);
            }
            else if (string.IsNullOrEmpty(txtRequestName.Text))
            {
                retval = false;
                AddMessage(lblError1, "Talep adı alanı boş geçilemez!", false);
            }
            else if (string.IsNullOrEmpty(txtDescription.Text))
            {
                retval = false;
                AddMessage(lblError1, "Açıklama alanı boş geçilemez!", false);
            }

            return retval;

        }

        public void AddMessage(Literal lbl, string msg, bool type)
        {
            lbl.Text = "<div class='alert alert-" + (type ? "success" : "danger") + "'>" + msg + "</div>";
        }
    }
}