using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    [Serializable]
    public class ENTMEMTYPEUSER
    {
        public byte ID { get; set; }
        public string NAME { get; set; }
        public ENTMEMTYPEUSER(Byte ID,string NAME)
        {
            this.ID = ID;
            this.NAME = NAME;
        }
        public ENTMEMTYPEUSER()
        {
        }
    }
}
