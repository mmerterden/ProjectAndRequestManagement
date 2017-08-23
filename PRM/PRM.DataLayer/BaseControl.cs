using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace PRM.DataLayer
{
    public class BaseControl : System.Web.UI.UserControl
    {
        protected User ONLINEUSER
        {
            get
            {
                if (Session["#ONLINEUSER#"] == null)
                {
                    Session["#ONLINEUSER#"] = new User();
                }
                return Session["#ONLINEUSER#"] as User;
            }
            set { Session["#ONLINEUSER#"] = value; }
        }
        #region Message
        public enum MessageType
        {
            Info = 1,
            Error = 2,
            Success = 3
        }
        public string MessageSuccess
        {
            get { return "İşleminiz başarıyla tamamlandı"; }
        }
        public string MessageError
        {
            get { return "İşlem esnasında hata oluştu.<br> Lütfen daha sonra tekrar deneyiniz"; }
        }
        public void MessageAdd(MessageType msgType, string msg)
        {

            if (ScriptManager.GetCurrent(Page).IsInAsyncPostBack)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowMessage", "ShowMessage('" + msgType.ToString() + "','" + Server.HtmlEncode(msg) + "')", true);
            }
        }
        #endregion
    }
}
