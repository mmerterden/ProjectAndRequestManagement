using PRM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRM.Web
{
    public partial class PasswordReset : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                    
        }

   

        public void AddMessage(Literal lbl, string msg, bool type)
        {
            lbl.Text = "<div class='alert alert-" + (type ? "success" : "danger") + "'>" + msg + "</div>";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            AddMessage(lblError1, "Bilgilerinizi doğrulamak için mail gönderilmiştir!", true);
        }
    }
}