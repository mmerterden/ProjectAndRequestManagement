using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    public class ENTVWRPTREPORTPROJECT
    {
        public Guid PROJECTID { get; set; }
        public Guid FIRMID { get; set; }
        public string FIRMNAME { get; set; }
        public string PROJECTNAME { get; set; }
        public string TYPEPROJECTSTATUSNAME { get; set; }
        public bool TYPEPROJECTSTATUSISOPEN { get; set; }
        public ENTVWRPTREPORTPROJECT(Guid PROJECTID, Guid FIRMID, string FIRMNAME, string PROJECTNAME, string TYPEPROJECTSTATUSNAME, bool TYPEPROJECTSTATUSISOPEN)
        {
            this.PROJECTID = PROJECTID;
            this.FIRMID = FIRMID;
            this.FIRMNAME = FIRMNAME;
            this.PROJECTNAME = PROJECTNAME;
            this.TYPEPROJECTSTATUSNAME = TYPEPROJECTSTATUSNAME;
            this.TYPEPROJECTSTATUSISOPEN = TYPEPROJECTSTATUSISOPEN;
        }
        public ENTVWRPTREPORTPROJECT()
        {
        }

    }
}
