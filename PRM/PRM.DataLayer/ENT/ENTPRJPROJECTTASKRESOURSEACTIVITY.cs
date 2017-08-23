using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    [Serializable]
    public class ENTPRJPROJECTTASKRESOURSEACTIVITY
    {
        public Guid ID { get; set; }
        public byte? RESOURSEDURATION { get; set; }
        public string DESCRIPTION { get; set; }
        public DateTime DATE { get; set; }
        public Guid PROJECTTASKRESOURSEID { get; set; }
        public ENTPRJPROJECTTASKRESOURSEACTIVITY(Guid ID, byte? RESOURSEDURATION, string DESCRIPTION, DateTime DATE, Guid PROJECTTASKRESOURSEID)
        {
            this.ID = ID;
            this.RESOURSEDURATION = RESOURSEDURATION;
            this.DESCRIPTION = DESCRIPTION;
            this.DATE = DATE;
            this.PROJECTTASKRESOURSEID = PROJECTTASKRESOURSEID;

        }
        public ENTPRJPROJECTTASKRESOURSEACTIVITY()
        {
        }
    }
}
