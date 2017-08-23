using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    [Serializable]
    public class ENTVWPRJPROJECTTASKRESOURSEACTIVITY
    {
        public Guid ID { get; set; }
        public Guid USERID { get; set; }
        public byte? RESOURSEDURATION  { get; set; }
        public string DESCRIPTION { get; set; }
        public DateTime DATE { get; set; }
        public Guid PROJECTTASKRESOURSEID { get; set; }
        public Guid PROJECTTASKID { get; set; }
        public string PROJECTTASKNAME { get; set; }
        public Guid PROJECTID { get; set; }
        public string PROJECTNAME { get; set; }
        public ENTVWPRJPROJECTTASKRESOURSEACTIVITY(Guid ID, Guid USERID, byte? RESOURSEDURATION, string DESCRIPTION, DateTime DATE, Guid PROJECTTASKRESOURSEID, Guid PROJECTTASKID, string PROJECTTASKNAME ,Guid PROJECTID,string PROJECTNAME)
        {
            this.ID = ID;
            this.USERID = USERID;
            this.RESOURSEDURATION = RESOURSEDURATION;
            this.DESCRIPTION = DESCRIPTION;
            this.DATE = DATE;
            this.PROJECTTASKRESOURSEID = PROJECTTASKRESOURSEID;
            this.PROJECTTASKID = PROJECTTASKID;
            this.PROJECTTASKNAME = PROJECTTASKNAME;
            this.PROJECTID = PROJECTID;
            this.PROJECTNAME = PROJECTNAME;


        }
        public ENTVWPRJPROJECTTASKRESOURSEACTIVITY()
        {
        }
    }
}
