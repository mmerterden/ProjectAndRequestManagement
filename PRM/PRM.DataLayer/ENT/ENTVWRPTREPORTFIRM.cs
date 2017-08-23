using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    [Serializable]
    public class ENTVWRPTREPORTFIRM
    {

        public Guid ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public byte CITYID { get; set; }
        public Int16 DISTRICTID { get; set; }
        public string ADDRESS { get; set; }
        public string FIRMCITYNAME { get; set; }
        public string FIRMDISTRICTNAME { get; set; }


        public ENTVWRPTREPORTFIRM(Guid ID, string NAME, string DESCRIPTION, byte CITYID, Int16 DISTRICTID, string ADDRESS, string FIRMCITYNAME, string FIRMDISTRICTNAME)
        {
            this.ID = ID;
            this.NAME = NAME;
            this.DESCRIPTION = DESCRIPTION;
            this.CITYID = CITYID;
            this.DISTRICTID = DISTRICTID;
            this.ADDRESS = ADDRESS;
            this.FIRMCITYNAME = FIRMCITYNAME;
            this.FIRMDISTRICTNAME = FIRMDISTRICTNAME;

        }
        public ENTVWRPTREPORTFIRM()
        {
        }
    }
}
