using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer//0)ENT tagını sildik clasa ulasmak için.
{
    [Serializable]//1)serializable yapıyoruz.
    public class ENTVWPRJPROJECT//2)veritabanımızdaki verileri tanımlıyoruz.PUBLİC yapıyoruz.
    {
        
        public Guid ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public byte TYPEPROJECTSTATUSID { get; set; }
        public Guid FIRMID { get; set; }
        public bool TYPEPROJECTSTATUSISOPEN { get; set; }
        public string TYPEPROJECTSTATUSNAME { get; set; }
        public string FIRMNAME { get; set; }
        public string FIRMDESCRIPTION { get; set; }
        public Byte FIRMCITYID { get; set; }
        public Int16 FIRMDISTRICTID { get; set; }
        public string FIRMADDRESS { get; set; }
        public string CITYNAME { get; set; }
        public string DISTRICTNAME { get; set; }

        public ENTVWPRJPROJECT(Guid ID,string NAME,string DESCRIPTION,byte TYPEPROJECTSTATUSID,Guid FIRMID, bool TYPEPROJECTSTATUSISOPEN, string TYPEPROJECTSTATUSNAME, string FIRMNAME, string FIRMDESCRIPTION, Byte FIRMCITYID, Int16 FIRMDISTRICTID, string FIRMADDRESS, string CITYNAME, string DISTRICTNAME)//3)Constructorını oluşturuyoruz.
        {
            this.ID = ID;
            this.NAME = NAME;
            this.DESCRIPTION = DESCRIPTION;
            this.TYPEPROJECTSTATUSID = TYPEPROJECTSTATUSID;
            this.FIRMID = FIRMID;
            this.TYPEPROJECTSTATUSISOPEN = TYPEPROJECTSTATUSISOPEN;
            this.TYPEPROJECTSTATUSNAME = TYPEPROJECTSTATUSNAME;
            this.FIRMNAME = FIRMNAME;
            this.FIRMCITYID = FIRMCITYID;
            this.FIRMDISTRICTID = FIRMDISTRICTID;
            this.FIRMADDRESS = FIRMADDRESS;
            this.CITYNAME = CITYNAME;
            this.DISTRICTNAME = DISTRICTNAME;
        }
        public ENTVWPRJPROJECT()//4)Destructerını olusturuyoruz.
        {

        }

       

    }
}
