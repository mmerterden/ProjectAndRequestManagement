using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    [Serializable]
    public class ENTPRJPROJECTTASKRESOURSE
    {
        public Guid ID { get; set; }
        public Guid PROJECTTASKID { get; set; }
        public Guid USERID { get; set; }
        public byte? DURATION { get; set; }
        public byte TYPEPROJECTRESOURSESTATUSID { get; set; }

        public ENTPRJPROJECTTASKRESOURSE(Guid ID, Guid PROJECTTASKID, Guid USERID, byte? DURATION, byte TYPEPROJECTRESOURSESTATUSID)
        {
            this.ID = ID;
            this.PROJECTTASKID = PROJECTTASKID;
            this.USERID = USERID;
            this.DURATION = DURATION;
            this.TYPEPROJECTRESOURSESTATUSID = TYPEPROJECTRESOURSESTATUSID;

        }
        public ENTPRJPROJECTTASKRESOURSE()
        {
        }
    }
}
