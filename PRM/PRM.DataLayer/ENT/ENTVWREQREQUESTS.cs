using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    [Serializable]
    public class ENTVWREQREQUESTS
    {
        public Guid ID { get; set; }
        public Guid PROJECTID { get; set; }
        public string NAME { get; set; }
        public byte TYPEREQUESTID { get; set; }
        public Guid USERID { get; set; }
        public DateTime REQUESTDATE { get; set; }

        public string DESCRIPTION { get; set; }
        public string PROJECTNAME { get; set; }
        public string TYPEREQUESTSTATUSNAME { get; set; }
        public bool ISOPEN { get; set; }
        public string USERFULLNAME { get; set; }
        

        public ENTVWREQREQUESTS(Guid ID, Guid PROJECTID, string NAME, byte TYPEREQUESTID, Guid USERID, DateTime REQUESTDATE, string DESCRIPTION,string PROJECTNAME, string TYPEREQUESTSTATUSNAME, bool ISOPEN, string USERFULLNAME)
        {
            this.ID = ID;
            this.PROJECTID = PROJECTID;
            this.NAME = NAME;
            this.TYPEREQUESTID = TYPEREQUESTID;
            this.USERID = USERID;
            this.REQUESTDATE = REQUESTDATE;
            this.DESCRIPTION = DESCRIPTION;
            this.PROJECTNAME = PROJECTNAME;
            this.TYPEREQUESTSTATUSNAME = TYPEREQUESTSTATUSNAME;
            this.ISOPEN = ISOPEN;
          
            this.USERFULLNAME = USERFULLNAME;
           
        }
        public ENTVWREQREQUESTS()
        {
        }
    }
}
