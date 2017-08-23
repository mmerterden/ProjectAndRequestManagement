using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    [Serializable]
    public class ENTVWFULLNAME
    {
         
        public Guid ID { get; set; }
        public string USERFULLNAME { get; set; }
        public byte TYPEUSERID { get; set; }

        public ENTVWFULLNAME(Guid ID, string USERFULLNAME, byte TYPEUSERID)
        {
            this.ID = ID;
            this.USERFULLNAME = USERFULLNAME;
            this.TYPEUSERID = TYPEUSERID;
        }
        public ENTVWFULLNAME()
        {
        }

    }
}
