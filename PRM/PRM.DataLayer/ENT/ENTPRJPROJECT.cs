using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    [Serializable]
    public class ENTPRJPROJECT
    {
        public Guid ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public byte TYPEPROJECTSTATUSID { get; set; }
        public Guid FIRMID { get; set; }

        public ENTPRJPROJECT(Guid ID, string NAME, string DESCRIPTION, byte TYPEPROJECTSTATUSID, Guid FIRMID)
        {
            this.ID = ID;
            this.NAME = NAME;
            this.DESCRIPTION = DESCRIPTION;
            this.TYPEPROJECTSTATUSID = TYPEPROJECTSTATUSID;
            this.FIRMID = FIRMID;
        }
        public ENTPRJPROJECT()
        {

        }
    }
}
