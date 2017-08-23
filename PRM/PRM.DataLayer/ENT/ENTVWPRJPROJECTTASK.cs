using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    [Serializable]
    public class ENTVWPRJPROJECTTASK
    {
        public Guid ID { get; set; }
        public Guid PROJECTID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public byte TYPEPROJECTTASKSTATUSID { get; set; }
        public DateTime CREATEDATE { get; set; }
        public DateTime? DUEDATE { get; set; }

        public string TYPEPROJECTTASKSTATUSNAME { get; set; }
        public bool TYPEPROJECTTASKSTATUSISOPEN { get; set; }//ısopen ekledim kontrol et
        public string PROJECTNAME { get; set; }
        public ENTVWPRJPROJECTTASK(Guid ID, Guid PROJECTID, string NAME, string DESCRIPTION, byte TYPEPROJECTTASKSTATUSID, DateTime CREATEDATE, DateTime? DUEDATE,string TYPEPROJECTTASKSTATUSNAME, bool TYPEPROJECTTASKSTATUSISOPEN, string PROJECTNAME)//ısopen ekledim kontrol et
        {
            this.ID = ID;
            this.PROJECTID = PROJECTID;
            this.NAME = NAME;
            this.DESCRIPTION = DESCRIPTION;
            this.TYPEPROJECTTASKSTATUSID = TYPEPROJECTTASKSTATUSID;
            this.CREATEDATE = CREATEDATE;
            this.DUEDATE = DUEDATE;
            this.TYPEPROJECTTASKSTATUSNAME = TYPEPROJECTTASKSTATUSNAME;
            this.TYPEPROJECTTASKSTATUSISOPEN = TYPEPROJECTTASKSTATUSISOPEN;//ısopen ekledim kontrol et
            this.PROJECTNAME = PROJECTNAME;

        }
        public ENTVWPRJPROJECTTASK()
        {
        }
    }
}
