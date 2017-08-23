using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    [Serializable]
    public class ENTVWRPTREPORTRESOURSE
    {
        public Guid USERID { get; set; }
        public string USERFULLNAME { get; set; }
        public bool STATUS { get; set; }
        public string TYPEUSERNAME { get; set; }
        public string LANGUAGENAME { get; set; }
        public byte TYPEUSERID { get; set; }

        public ENTVWRPTREPORTRESOURSE(Guid USERID, string USERFULLNAME, bool STATUS, string TYPEUSERNAME, string LANGUAGENAME, byte TYPEUSERID)
        {
            this.USERID = USERID;
            this.USERFULLNAME = USERFULLNAME;
            this.STATUS = STATUS;
            this.TYPEUSERNAME = TYPEUSERNAME;
            this.LANGUAGENAME = LANGUAGENAME;
            this.TYPEUSERID = TYPEUSERID;

        }
        public ENTVWRPTREPORTRESOURSE()
        {
        }
    }
}
