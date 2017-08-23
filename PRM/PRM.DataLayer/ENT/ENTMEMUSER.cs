using System;

namespace PRM.DataLayer
{
    [Serializable]
    public class ENTMEMUSER
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
        public ENTMEMUSER(Guid ID, string MAIL, string PASSWORD, string NAME, string SURNAME, DateTime CREATEDATE, byte TYPEUSERID, string PHONE, bool ISADMIN, bool STATUS, Guid? FIRMID,byte? LANGUAGEID)
        {
            this.ID = ID; //determined be Global ID
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
        }
        public ENTMEMUSER()
        {
        }
    }
}
