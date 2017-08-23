using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    [Serializable]
    public class ENTVWRPTREPORTRESOURSEACTIVITY
    {
        public Guid USERID { get; set; }
        public string DESCRIPTION { get; set; }
        public string PROJECTTASKNAME { get; set; }
        public string TYPEPROJECTTASKRESOURSESTATUSNAME { get; set; }
        public DateTime DATE { get; set; }
        public byte RESOURSEDURATION { get; set; }

        public ENTVWRPTREPORTRESOURSEACTIVITY(Guid USERID, string DESCRIPTION, string PROJECTTASKNAME, string TYPEPROJECTTASKRESOURSESTATUSNAME, DateTime DATE, byte RESOURSEDURATION)
        {
            this.USERID = USERID;
            this.DESCRIPTION = DESCRIPTION;
            this.PROJECTTASKNAME = PROJECTTASKNAME;
            this.TYPEPROJECTTASKRESOURSESTATUSNAME = TYPEPROJECTTASKRESOURSESTATUSNAME;
            this.DATE = DATE;
            this.RESOURSEDURATION = RESOURSEDURATION;

        }
        public ENTVWRPTREPORTRESOURSEACTIVITY()
        {
        }
    }
}
