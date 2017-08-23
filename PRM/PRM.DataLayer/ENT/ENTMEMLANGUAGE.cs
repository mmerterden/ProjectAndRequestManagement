using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    [Serializable]
    public class ENTMEMLANGUAGE
    {
        public byte ID { get; set; }
        public string NAME { get; set; }

        public ENTMEMLANGUAGE(byte ID, string NAME)//3)Constructorını oluşturuyoruz.
        {
            this.ID = ID;
            this.NAME = NAME;
        }
        public ENTMEMLANGUAGE()//4)Destructerını olusturuyoruz.
        {

        }
    }
}
