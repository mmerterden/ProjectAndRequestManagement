using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web.Mng
{
    public partial class MNGFirms : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillFirm();

            }
        }
        private void FillFirm()
        {
            rptFirms.DataSource = DALFirm.GetAllListFirms();
            rptFirms.DataBind();
        }

        protected void rptFirms_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete":

                    List<ENTMEMUSER> FirmUserList = DALUser.GetAllListUserID(Guid.Parse(e.CommandArgument.ToString()));

                    foreach (ENTMEMUSER user in FirmUserList)
                    {
                        List<ENTREQREQUESTS> FirmRequestList = DALRequest.GetAllListFirmRequestsID(user.ID);

                        foreach (ENTREQREQUESTS rqst in FirmRequestList)
                        {
                            List<ENTREQREQUESTDETAIL> FirmRequestDetailList = DALRequest.GetAllListRequestDetailsID(rqst.ID);

                            foreach (ENTREQREQUESTDETAIL rqstdtl in FirmRequestDetailList)
                            {
                                DALRequest.DeleteDetail(rqstdtl.ID);
                            }
                            DALRequest.Delete(rqst.ID);

                        }

                        List<ENTPRJPROJECTTASKRESOURSE> ProjectTaskResourseList = DALProjectTaskResourse.GetAllListFirmResoursesID(user.ID);


                        foreach (ENTPRJPROJECTTASKRESOURSE rsr in ProjectTaskResourseList)
                        {
                            List<ENTPRJPROJECTTASKRESOURSEACTIVITY> ProjectTaskResourseActivityList = DALProjectTaskResourseActivity.GetAllListTaskResoursesActivityID(rsr.ID);

                            foreach (ENTPRJPROJECTTASKRESOURSEACTIVITY act in ProjectTaskResourseActivityList)
                            {
                                DALProjectTaskResourseActivity.Delete(act.ID);
                            }
                            DALProjectTaskResourse.Delete(rsr.ID);

                        }
                        DALUser.Delete(user.ID);
                    }

                    List<ENTPRJPROJECT> FirmProjectList = DALProject.GetAllListTaskID(Guid.Parse(e.CommandArgument.ToString()));

                    foreach (ENTPRJPROJECT prj in FirmProjectList)
                    {
                        List<ENTPRJPROJECTTASK> ProjectTaskList = DALProjectTask.GetAllListTaskID(prj.ID);

                        foreach (ENTPRJPROJECTTASK tsk in ProjectTaskList)
                        {
                            DALProjectTask.Delete(tsk.ID);
                        }
                        DALProject.Delete(prj.ID);
                    }
                    
                    DALFirm.Delete(Guid.Parse(e.CommandArgument.ToString()));
                    
                    FillFirm();
                    break;
            }

        }
    }

}