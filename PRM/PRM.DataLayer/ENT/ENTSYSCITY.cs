using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    [Serializable]
    public class ENTSYSCITY
    {
       
        public byte ID { get; set; }
        public string NAME { get; set; }

        public ENTSYSCITY(byte ID, string NAME)//3)Constructorını oluşturuyoruz.
        {
            this.ID = ID;
            this.NAME = NAME;
        }
        public ENTSYSCITY()//4)Destructerını olusturuyoruz.
        {

        }
    }
}
