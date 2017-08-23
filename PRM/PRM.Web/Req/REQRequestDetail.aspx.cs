using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Req
{
    public partial class REQRequestDetail : BasePage
    {
        protected Guid REQUESTID
        {
            get
            {
                if (ViewState["REQUESTID"] == null)
                {
                    ViewState["REQUESTID"] = Guid.Empty;
                }
                return Guid.Parse(ViewState["REQUESTID"].ToString());
            }
            set { ViewState["REQUESTID"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                DrpStatusFill();

                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    
                    ENTVWREQREQUESTS rqst = DALRequest.GetRequest(Guid.Parse(Request.QueryString["ID"]));
                    if (rqst != null)
                    {
                        if(rqst.TYPEREQUESTID==3)
                        {
                            REQUESTID = rqst.ID;
                            lblProjectName.Text = rqst.PROJECTNAME;
                            drpRequestStatusName.SelectedValue = rqst.TYPEREQUESTID.ToString();
                            lblDescription.Text = rqst.DESCRIPTION;
                            lblRequestDate.Text = rqst.REQUESTDATE.ToString();
                            lblUserFullName.Text = rqst.USERFULLNAME;
                            msg.Visible = false;
                            msglist.Visible = false;
                        }
                        else
                        {
                            REQUESTID = rqst.ID;
                            lblProjectName.Text = rqst.PROJECTNAME;
                            drpRequestStatusName.SelectedValue = rqst.TYPEREQUESTID.ToString();
                            lblDescription.Text = rqst.DESCRIPTION;
                            lblRequestDate.Text = rqst.REQUESTDATE.ToString();
                            lblUserFullName.Text = rqst.USERFULLNAME;
                            msg.Visible = true;
                            msglist.Visible = true;
                            FillMessage();
                        }
                      
                    }
                    else
                    {
                        Response.Redirect("/Req/REQRequests.aspx");
                    }
                }
                else
                {
                    Response.Redirect("/Req/REQRequests.aspx");
                }


            }

        }
        

        private void FillMessage()
        {
            rptMessage.DataSource = DALRequest.GetAllListMessage(REQUESTID);
            rptMessage.DataBind();
        }

        public void DrpStatusFill()
        {
            List<ENTREQTYPEREQUEST> list = DALRequest.GetAllStatus();
            drpRequestStatusName.Items.Clear();
            drpRequestStatusName.DataSource = list;
            drpRequestStatusName.DataValueField = "ID";
            drpRequestStatusName.DataTextField = "NAME";

            drpRequestStatusName.DataBind();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (ValidateRecord())
            {
                ENTREQREQUESTDETAIL rqstdtl = new ENTREQREQUESTDETAIL();
                rqstdtl.ID = Guid.NewGuid();
                rqstdtl.REQUESTID = REQUESTID;
                rqstdtl.USERID = ONLINEUSER.ID;
                rqstdtl.MESSAGE = txtMessage.Text;
                rqstdtl.DATE = DateTime.Now;
                DALRequest.InsertMessage(rqstdtl);

                Response.Redirect("/Req/REQRequestDetail.aspx?ID="+REQUESTID);
            }
        }

        private bool ValidateRecord()
        {
            bool retval = true;

            if (string.IsNullOrEmpty(txtMessage.Text))
            {
                retval = false;
                AddMessage(lblError1, "Mesaj giriniz!", false);
            }

            return retval;

        }

        public void AddMessage(Literal lbl, string msg, bool type)
        {
            lbl.Text = "<div class='alert alert-" + (type ? "success" : "danger") + "'>" + msg + "</div>";
        }

        protected void drpRequestStatusName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpRequestStatusName.SelectedValue == "2")
            {
                ENTREQREQUESTS rqst = DALRequest.GetValueStatus(Guid.Parse(Request.QueryString["ID"]));
                rqst.TYPEREQUESTID = 2;
                DALRequest.UpdateStatus(rqst);
                Response.Redirect("/Req/REQRequestDetail.aspx?ID=" + REQUESTID);

            }
            else
            {
                ENTREQREQUESTS rqst = DALRequest.GetValueStatus(Guid.Parse(Request.QueryString["ID"]));
                rqst.TYPEREQUESTID = 3;
                DALRequest.UpdateStatus(rqst);
                Response.Redirect("/Req/REQRequests.aspx");

            }
        }

       
    }
}