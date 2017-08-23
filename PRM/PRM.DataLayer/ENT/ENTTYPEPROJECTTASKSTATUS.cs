using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    [Serializable]
    public class ENTTYPEPROJECTTASKSTATUS
    {
        public byte ID { get; set; }
        public string NAME { get; set; }
        public byte SORT { get; set; }
        public bool ISOPEN { get; set; }

        public ENTTYPEPROJECTTASKSTATUS(byte ID, string NAME, byte SORT, bool ISOPEN)//3)Constructorını oluşturuyoruz.
        {
            this.ID = ID;
            this.NAME = NAME;
            this.SORT = SORT;
            this.ISOPEN = ISOPEN;
        }
        public ENTTYPEPROJECTTASKSTATUS()//4)Destructerını olusturuyoruz.
        {

        }
    }
}
