using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    [Serializable]
    public class ENTVWRPTREPORTTASKS
    {
        public Guid PROJECTID { get; set; }
        public Guid PROJECTTASKID { get; set; }
        public string PROJECTTASKNAME { get; set; }
        public DateTime PROJECTTASKCREATEDATE { get; set; }
        public DateTime? PROJECTTASKDUEDATE { get; set; }
        public string TYPEPROJECTTASKSTATUSNAME { get; set; }
        public bool TYPEPROJECTTASKSTATUSISOPEN { get; set; }
      
        public ENTVWRPTREPORTTASKS(Guid PROJECTID, Guid PROJECTTASKID, string PROJECTTASKNAME, DateTime PROJECTTASKCREATEDATE, DateTime? PROJECTTASKDUEDATE, string TYPEPROJECTTASKSTATUSNAME, bool TYPEPROJECTTASKSTATUSISOPEN)
        {
            this.PROJECTID = PROJECTID;
            this.PROJECTTASKID = PROJECTTASKID;
            this.PROJECTTASKNAME = PROJECTTASKNAME;
            this.PROJECTTASKCREATEDATE = PROJECTTASKCREATEDATE;
            this.PROJECTTASKDUEDATE = PROJECTTASKDUEDATE;
            this.TYPEPROJECTTASKSTATUSNAME = TYPEPROJECTTASKSTATUSNAME;
            this.TYPEPROJECTTASKSTATUSISOPEN = TYPEPROJECTTASKSTATUSISOPEN;

        }
        public ENTVWRPTREPORTTASKS()
        {
        }


    }
}