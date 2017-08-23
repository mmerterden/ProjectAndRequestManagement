using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    [Serializable]
    public class ENTVWPRJPROJECTTASKRESOURCE
    {
        public Guid ID { get; set; }
        public Guid PROJECTTASKID { get; set; }
        public Guid USERID { get; set; }
        public byte TYPEPROJECTRESOURSESTATUSID { get; set; }
        public byte? DURATION { get; set; }
        public string PROJECTTASKNAME { get; set; }
        public DateTime PROJECTTASKCREATEDATE { get; set; }
        public string USERFULLNAME { get; set; }
        public string TYPEPROJECTRESOURSESTATUSNAME { get; set; }


        public ENTVWPRJPROJECTTASKRESOURCE(Guid ID,  Guid PROJECTTASKID, Guid USERID,byte TYPEPROJECTRESOURSESTATUSID, byte? DURATION, string PROJECTTASKNAME,DateTime PROJECTTASKCREATEDATE,string USERFULLNAME, string TYPEPROJECTRESOURSESTATUSNAME)//ısopen ekledim kontrol et
        {
            this.ID = ID;
            this.PROJECTTASKID = PROJECTTASKID;
            this.USERID = USERID;
            this.TYPEPROJECTRESOURSESTATUSID = TYPEPROJECTRESOURSESTATUSID;
            this.DURATION = DURATION;
            this.PROJECTTASKNAME = PROJECTTASKNAME;
            this.PROJECTTASKCREATEDATE = PROJECTTASKCREATEDATE;
            this.USERFULLNAME = USERFULLNAME;
            this.TYPEPROJECTRESOURSESTATUSNAME = TYPEPROJECTRESOURSESTATUSNAME;
        }
        public ENTVWPRJPROJECTTASKRESOURCE()
        {
        }
    }
}
