using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    [Serializable]
    public class ENTVWPRJPROJECTMYTASKS
    {
        public Guid PROJECTTASKRESOURSEID { get; set; }
        public Guid USERID { get; set; }
        public string USERFULLNAME { get; set; }
        public Guid FIRMID { get; set; }
        public string FIRMNAME { get; set; }
        public Guid PROJECTID { get; set; }
        public string PROJECTNAME { get; set; }
        public byte TYPEPROJECTSTATUSID { get; set; }
        public string TYPEPROJECTSTATUSNAME { get; set; }
        public Guid PROJECTTASKID { get; set; }
        public string PROJECTTASKNAME { get; set; }
        public DateTime PROJECTTASKCREATEDATE { get; set; }
        public DateTime? PROJECTTASKDUEDATE { get; set; }

        public byte TYPEPROJECTTASKSTATUSID { get; set; }
        public string TYPEPROJECTTASKSTATUSNAME { get; set; }

        public bool TYPEPROJECTTASKSTATUSISOPEN { get; set; }


        public ENTVWPRJPROJECTMYTASKS(Guid PROJECTTASKRESOURSEID, Guid USERID, string USERFULLNAME, Guid FIRMID, string FIRMNAME, Guid PROJECTID, string PROJECTNAME, byte TYPEPROJECTSTATUSID, string TYPEPROJECTSTATUSNAME, Guid PROJECTTASKID, string PROJECTTASKNAME, DateTime PROJECTTASKCREATEDATE, DateTime? PROJECTTASKDUEDATE, byte TYPEPROJECTTASKSTATUSID, string TYPEPROJECTTASKSTATUSNAME, bool TYPEPROJECTTASKSTATUSISOPEN)
        {
            this.PROJECTTASKRESOURSEID = PROJECTTASKRESOURSEID;
            this.USERID = USERID;
            this.USERFULLNAME = USERFULLNAME;
            this.FIRMID = FIRMID;
            this.FIRMNAME = FIRMNAME;
            this.PROJECTID = PROJECTID;
            this.PROJECTNAME = PROJECTNAME;
            this.TYPEPROJECTSTATUSID = TYPEPROJECTSTATUSID;
            this.TYPEPROJECTSTATUSNAME = TYPEPROJECTSTATUSNAME;
            this.PROJECTTASKID = PROJECTTASKID;
            this.PROJECTTASKNAME = PROJECTTASKNAME;
            this.PROJECTTASKCREATEDATE = PROJECTTASKCREATEDATE;
            this.PROJECTTASKDUEDATE = PROJECTTASKDUEDATE;
            this.TYPEPROJECTTASKSTATUSID = TYPEPROJECTTASKSTATUSID;
            this.TYPEPROJECTTASKSTATUSNAME = TYPEPROJECTTASKSTATUSNAME;
            this.TYPEPROJECTTASKSTATUSISOPEN = TYPEPROJECTTASKSTATUSISOPEN;

        }
        public ENTVWPRJPROJECTMYTASKS()
        {
        }
    }
}
