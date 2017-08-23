using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Req
{
    public partial class REQRequests : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillRequest();
            }
        }
        private void FillRequest()
        {
            rptRqst.DataSource = DALRequest.GetAllListRequest();
            rptRqst.DataBind();
        }
        protected void rptRqst_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete":
                    {
                        List<ENTREQREQUESTDETAIL> ProjectRequestDetailList = DALRequest.GetAllListRequestDetailsID(Guid.Parse(e.CommandArgument.ToString()));


                        foreach (ENTREQREQUESTDETAIL rqstdtl in ProjectRequestDetailList)
                        {
                            DALRequest.DeleteDetail(rqstdtl.ID);
                        }
                        DALRequest.Delete(Guid.Parse(e.CommandArgument.ToString()));

                        FillRequest();
                        break;
                    }     
            }
        }
    }
}