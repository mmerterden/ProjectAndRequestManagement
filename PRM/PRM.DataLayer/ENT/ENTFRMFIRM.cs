using System;

namespace PRM.DataLayer
{
    [Serializable]
    public class ENTFRMFIRM
    {
        public Guid ID { get; set; }
        public string NAME { get; set; } 
        public string DESCRIPTION { get; set; }
        public byte CITYID { get; set; }
        public Int16 DISTRICTID { get; set; }
        public string ADDRESS { get; set; }

        public ENTFRMFIRM(Guid ID, string NAME, string DESCRIPTION, byte CITYID, Int16 DISTRICTID, string ADDRESS )
        {
            this.ID = ID;
            this.NAME = NAME;
            this.DESCRIPTION = DESCRIPTION;
            this.CITYID = CITYID;
            this.DISTRICTID = DISTRICTID;
            this.ADDRESS = ADDRESS;

        }
        public ENTFRMFIRM()
        {
        }
    }
}