using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    [Serializable]
    public class ENTSYSDISTRICT
    {
        public Int16 ID { get; set; }
        public byte CITYID { get; set; }
        public string NAME { get; set; }

        public ENTSYSDISTRICT(Int16 ID, byte CITYID, string NAME)//3)Constructorını oluşturuyoruz.
        {
            this.ID = ID;
            this.CITYID = CITYID;
            this.NAME = NAME;
        }
        public ENTSYSDISTRICT()//4)Destructerını olusturuyoruz.
        {

        }
    }
}
