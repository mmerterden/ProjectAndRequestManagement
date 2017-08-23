using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    [Serializable]
    public class ENTPRJPROJECTTASK
    {
        public Guid ID { get; set; }
        public Guid PROJECTID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public byte TYPEPROJECTTASKSTATUSID { get; set; }
        public DateTime CREATEDATE { get; set; }
        public DateTime? DUEDATE { get; set; }
       
        public ENTPRJPROJECTTASK(Guid ID, Guid PROJECTID, string NAME, string DESCRIPTION, byte TYPEPROJECTTASKSTATUSID, DateTime CREATEDATE, DateTime? DUEDATE)
        {
            this.ID = ID;
            this.PROJECTID = PROJECTID;
            this.NAME = NAME;
            this.DESCRIPTION = DESCRIPTION;
            this.TYPEPROJECTTASKSTATUSID = TYPEPROJECTTASKSTATUSID;
            this.CREATEDATE = CREATEDATE;
            this.DUEDATE = DUEDATE;
            
        }
        public ENTPRJPROJECTTASK()
        {
        }
    }
}
