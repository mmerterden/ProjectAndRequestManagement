using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    [Serializable]
    public class ENTREQREQUESTDETAIL
    {
        public Guid ID { get; set; }
        public Guid REQUESTID { get; set; }
        public Guid USERID { get; set; }
        public string MESSAGE { get; set; }
        public DateTime DATE { get; set; }

        public ENTREQREQUESTDETAIL(Guid ID, Guid REQUESTID, Guid USERID, string MESSAGE,DateTime DATE)
        {
            this.ID = ID;
            this.REQUESTID = REQUESTID;
            this.USERID = USERID;
            this.MESSAGE = MESSAGE;
            this.DATE = DATE;
        }
        public ENTREQREQUESTDETAIL()
        {
        }
    }
}
