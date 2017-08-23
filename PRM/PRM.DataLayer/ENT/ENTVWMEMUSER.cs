using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    public class ENTVWMEMUSER
    {
        public Guid ID { get; set; } //all elements are written 
        public string MAIL { get; set; }
        public string PASSWORD { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public DateTime CREATEDATE { get; set; }
        public byte TYPEUSERID { get; set; }
        public string PHONE { get; set; }
        public bool ISADMIN { get; set; }
        public bool STATUS { get; set; }
        public Guid? FIRMID { get; set; }
        public byte? LANGUAGEID { get; set; }
        public string LANGUAGENAME { get; set; }
        public string TYPEUSERNAME { get; set; }

        public string FIRMNAME { get; set; }

        public ENTVWMEMUSER(Guid ID, string MAIL, string PASSWORD, string NAME, string SURNAME, DateTime CREATEDATE, byte TYPEUSERID, string PHONE, bool ISADMIN, bool STATUS, Guid? FIRMID, byte? LANGUAGEID, string LANGUAGENAME, string TYPEUSERNAME,string FIRMNAME)
        {
            this.ID = ID; 
            this.MAIL = MAIL;
            this.NAME = NAME;
            this.SURNAME = SURNAME;
            this.PASSWORD = PASSWORD;
            this.CREATEDATE = CREATEDATE;
            this.TYPEUSERID = TYPEUSERID;
            this.PHONE = PHONE;
            this.ISADMIN = ISADMIN;
            this.STATUS = STATUS;
            this.FIRMID = FIRMID;
            this.LANGUAGEID = LANGUAGEID;
            this.LANGUAGENAME = LANGUAGENAME;
            this.TYPEUSERNAME = TYPEUSERNAME;
            this.FIRMNAME = FIRMNAME;
        }
        public ENTVWMEMUSER()
        {
        }
    }
}
