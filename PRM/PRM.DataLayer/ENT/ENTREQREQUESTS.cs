using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    [Serializable]
    public class ENTREQREQUESTS
    {

        public Guid ID { get; set; }
        public Guid PROJECTID { get; set; }
        public string NAME { get; set; }
        public byte TYPEREQUESTID { get; set; }
        public Guid USERID { get; set; }
        public DateTime REQUESTDATE { get; set; }
        public string DESCRIPTION { get; set; }
        public ENTREQREQUESTS(Guid ID, Guid PROJECTID, string NAME, byte TYPEREQUESTID, Guid USERID, DateTime REQUESTDATE,string DESCRIPTION)
        {
            this.ID = ID;
            this.PROJECTID = PROJECTID;
            this.NAME = NAME;
            this.TYPEREQUESTID = TYPEREQUESTID;
            this.USERID = USERID;
            this.REQUESTDATE = REQUESTDATE;
            this.DESCRIPTION = DESCRIPTION;
        }

        public ENTREQREQUESTS()
        {
        }
    }
}
