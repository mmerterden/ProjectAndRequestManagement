using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    public class DALReports : DALSQLConfiguration
    {
        public static List<ENTVWRPTREPORTFIRM> GetAllListFirmReport()
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_RPT_ReportFirm ORDER BY NAME", con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWRPTREPORTFIRM firm = null;
            List<ENTVWRPTREPORTFIRM> firmList = new List<ENTVWRPTREPORTFIRM>();
            while (dr.Read())
            {
                firm = new ENTVWRPTREPORTFIRM(Guid.Parse(dr["ID"].ToString()), dr["NAME"].ToString(), dr["DESCRIPTION"].ToString(), Convert.ToByte(dr["CITYID"].ToString()), Convert.ToInt16(dr["DISTRICTID"].ToString()), dr["ADDRESS"].ToString(), dr["FIRMCITYNAME"].ToString(), dr["FIRMDISTRICTNAME"].ToString());
                firmList.Add(firm);
            }
            con.Close();
            return firmList;
        }
        public static List<ENTVWRPTREPORTPROJECT> GetAllListProjectReport(Guid FIRMID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_RPT_ReportProject WHERE FIRMID=@FIRMID ORDER BY PROJECTNAME", con);
            cmd.Parameters.AddWithValue("@FIRMID",FIRMID);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWRPTREPORTPROJECT prj = null;
            List<ENTVWRPTREPORTPROJECT> prjlist = new List<ENTVWRPTREPORTPROJECT>();
            while (dr.Read())
            {

                prj = new ENTVWRPTREPORTPROJECT(Guid.Parse(dr["PROJECTID"].ToString()), Guid.Parse(dr["FIRMID"].ToString()), dr["FIRMNAME"].ToString(), dr["PROJECTNAME"].ToString(), dr["TYPEPROJECTSTATUSNAME"].ToString(), Convert.ToBoolean(dr["TYPEPROJECTSTATUSISOPEN"]));
                prjlist.Add(prj);
            }
            con.Close();

            return prjlist;
        }

        public static List<ENTVWRPTREPORTTASKS> GetAllListTaskReport(Guid PROJECTID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_RPT_ReportTasks WHERE PROJECTID=@PROJECTID ORDER BY PROJECTTASKCREATEDATE", con);
            cmd.Parameters.AddWithValue("@PROJECTID", PROJECTID);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWRPTREPORTTASKS tsk = null;
            DateTime? duedate = null;
            List<ENTVWRPTREPORTTASKS> tsklist = new List<ENTVWRPTREPORTTASKS>();
            while (dr.Read())
            {
                duedate = null;
                if (!string.IsNullOrEmpty(dr["PROJECTTASKDUEDATE"].ToString()))
                {
                    duedate = Convert.ToDateTime(dr["PROJECTTASKDUEDATE"].ToString());
                }
                tsk = new ENTVWRPTREPORTTASKS(Guid.Parse(dr["PROJECTID"].ToString()), Guid.Parse(dr["PROJECTTASKID"].ToString()), dr["PROJECTTASKNAME"].ToString(),Convert.ToDateTime(dr["PROJECTTASKCREATEDATE"].ToString()),duedate, dr["TYPEPROJECTTASKSTATUSNAME"].ToString(), Convert.ToBoolean(dr["TYPEPROJECTTASKSTATUSISOPEN"].ToString()));
                tsklist.Add(tsk);
            }
            con.Close();

            return tsklist;
        }

        public static List<ENTVWRPTREPORTRESOURSE> GetAllListResourseReport()
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_RPT_ReportResourse WHERE TYPEUSERID=1 ORDER BY USERFULLNAME", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWRPTREPORTRESOURSE usr = null;
            List<ENTVWRPTREPORTRESOURSE> usrlist = new List<ENTVWRPTREPORTRESOURSE>();
            while (dr.Read())
            {

                usr = new ENTVWRPTREPORTRESOURSE(Guid.Parse(dr["USERID"].ToString()),dr["USERFULLNAME"].ToString(),Convert.ToBoolean(dr["STATUS"].ToString()),dr["TYPEUSERNAME"].ToString(), dr["LANGUAGENAME"].ToString(), Convert.ToByte(dr["TYPEUSERID"].ToString()));
                usrlist.Add(usr);
            }
            con.Close();

            return usrlist; 
        }
        

        public static Guid GetReportProject(Guid PROJECTID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT FIRMID FROM PRJ_PROJECT WHERE ID=@PROJECTID", con);
            cmd.Parameters.AddWithValue("@PROJECTID", PROJECTID);

            con.Open();
            Guid FIRMID = Guid.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            return FIRMID;
        }

        public static List<ENTVWRPTREPORTRESOURSEACTIVITY> GetAllListResourseActivityReport(Guid USERID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_RPT_ReportResourseActivity WHERE USERID=@USERID ORDER BY DATE", con);
            cmd.Parameters.AddWithValue("@USERID", USERID);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWRPTREPORTRESOURSEACTIVITY act = null;
            List<ENTVWRPTREPORTRESOURSEACTIVITY> actlist = new List<ENTVWRPTREPORTRESOURSEACTIVITY>();
            while (dr.Read())
            {
                act = new ENTVWRPTREPORTRESOURSEACTIVITY(Guid.Parse(dr["USERID"].ToString()),dr["DESCRIPTION"].ToString(), dr["PROJECTTASKNAME"].ToString(), dr["TYPEPROJECTTASKRESOURSESTATUSNAME"].ToString(),Convert.ToDateTime(dr["DATE"].ToString()),Convert.ToByte(dr["RESOURSEDURATION"].ToString()));
                actlist.Add(act);
            }
            con.Close();

            return actlist;
        }
        
       
      
        
    }
}
