using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    public class ENTVWREQREQUESTDETAILUSER
    {
        public Guid ID { get; set; }
        public DateTime DATE { get; set; }
        public string MESSAGE { get; set; }
        public Guid REQUESTID { get; set; }
        public Guid USERID { get; set; }
        public string USERFULLNAME { get; set; }
        public String CLASS { get; set; }

        public String PICTURE { get; set; }
        public ENTVWREQREQUESTDETAILUSER(Guid ID, DateTime DATE, string MESSAGE,Guid REQUESTID, Guid USERID, string USERFULLNAME,string CLASS,string PICTURE)
        {
            this.ID = ID;
            this.DATE = DATE;
            this.MESSAGE = MESSAGE;
            this.REQUESTID = REQUESTID;
            this.USERID = USERID;
            this.USERFULLNAME = USERFULLNAME;
            this.CLASS = CLASS;
            this.PICTURE = PICTURE;

        }
        public ENTVWREQREQUESTDETAILUSER()
        {
        }
    }
}
