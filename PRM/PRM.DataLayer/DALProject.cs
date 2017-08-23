using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;//5)SQLCONfiration kütüphanemizi ekledik.
using System.Data;

namespace PRM.DataLayer
{
    public class DALProject : DALSQLConfiguration//6) SQLconfiguration classımıza bağlıyoruz.
    {
        //public static SqlConnection con = new SqlConnection();
        //public  static SqlCommand cmd = new SqlCommand();
        public static List<ENTVWPRJPROJECT> GetAllListProjects()
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_PRJ_Project ORDER BY NAME", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWPRJPROJECT project = null;
            List<ENTVWPRJPROJECT> projectlist = new List<ENTVWPRJPROJECT>();
            while (dr.Read())
            {
                project = new ENTVWPRJPROJECT(Guid.Parse(dr["ID"].ToString()), dr["NAME"].ToString(), dr["DESCRIPTION"].ToString(), Byte.Parse(dr["TYPEPROJECTSTATUSID"].ToString()), Guid.Parse(dr["FIRMID"].ToString()), bool.Parse(dr["TYPEPROJECTSTATUSISOPEN"].ToString()), dr["TYPEPROJECTSTATUSNAME"].ToString(), dr["FIRMNAME"].ToString(), dr["FIRMDESCRIPTION"].ToString(), byte.Parse(dr["FIRMCITYID"].ToString()), Int16.Parse(dr["FIRMDISTRICTID"].ToString()), dr["FIRMADDRESS"].ToString(), dr["CITYNAME"].ToString(), dr["DISTRICTNAME"].ToString());
                projectlist.Add(project);
            }
            con.Close();

            return projectlist;
        }

        public static void Delete(Guid ID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("DELETE PRJ_PROJECT WHERE ID=@ID ",con);
            cmd.Parameters.AddWithValue("@ID",ID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        
        public static void InsertTable(ENTPRJPROJECT prj)
        {
            try
            {

                con = SQL.GetConnection();
                if (con.State == ConnectionState.Closed) con.Open();

                cmd = SQL.SetCommand("INSERT INTO VW_PRJ_Project (ID,NAME,TYPEPROJECTSTATUSID,FIRMID) VALUES (@ID,@NAME,@TYPEPROJECTSTATUSID,@FIRMID)", con);
                cmd.Parameters.AddWithValue("@ID", prj.ID);
                cmd.Parameters.AddWithValue("@NAME", prj.NAME);
                cmd.Parameters.AddWithValue("@TYPEPROJECTSTATUSID", prj.TYPEPROJECTSTATUSID);
                cmd.Parameters.AddWithValue("@FIRMID", prj.FIRMID);
                cmd.ExecuteNonQuery();

        }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }
        public static void Update(ENTPRJPROJECT prj)
        {

            con = SQL.GetConnection();
            cmd = SQL.SetCommand("UPDATE PRJ_PROJECT SET NAME = @NAME,DESCRIPTION=@DESCRIPTION,TYPEPROJECTSTATUSID=@TYPEPROJECTSTATUSID,FIRMID=@FIRMID  WHERE ID =@ID", con);
            cmd.Parameters.AddWithValue("@ID", prj.ID);
            cmd.Parameters.AddWithValue("@NAME", prj.NAME);
            cmd.Parameters.AddWithValue("@DESCRIPTION", prj.DESCRIPTION);
            cmd.Parameters.AddWithValue("@TYPEPROJECTSTATUSID", prj.TYPEPROJECTSTATUSID);
            cmd.Parameters.AddWithValue("@FIRMID", prj.FIRMID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static ENTPRJPROJECT GetProject(Guid ID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM PRJ_Project WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTPRJPROJECT prj = null;

            while (dr.Read())
            {
                prj = new ENTPRJPROJECT(Guid.Parse(dr["ID"].ToString()), dr["NAME"].ToString(), dr["DESCRIPTION"].ToString(), Byte.Parse(dr["TYPEPROJECTSTATUSID"].ToString()), Guid.Parse(dr["FIRMID"].ToString()));
                break;
            }
            con.Close();
            return prj;
        }

        public static List<ENTTYPEPROJECTSTATUS> GetAllStatus()
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM PRJ_TYPEPROJECTSTATUS WHERE ID>0", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTTYPEPROJECTSTATUS taskstatus = null;
            List<ENTTYPEPROJECTSTATUS> taskstatuslist = new List<ENTTYPEPROJECTSTATUS>();
            while (dr.Read())
            {
                taskstatus = new ENTTYPEPROJECTSTATUS(Convert.ToByte(dr["ID"].ToString()), dr["NAME"].ToString(), Convert.ToByte(dr["SORT"].ToString()), Convert.ToBoolean(dr["ISOPEN"].ToString()));
                taskstatuslist.Add(taskstatus);
            }
            con.Close();

            return taskstatuslist;
        }


        public static ENTVWPRJPROJECT GetProjectDetail(Guid ID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_PRJ_Project WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWPRJPROJECT prj = null;

            while (dr.Read())
            {
                prj = new ENTVWPRJPROJECT(Guid.Parse(dr["ID"].ToString()), dr["NAME"].ToString(), dr["DESCRIPTION"].ToString(), Byte.Parse(dr["TYPEPROJECTSTATUSID"].ToString()), Guid.Parse(dr["FIRMID"].ToString()), bool.Parse(dr["TYPEPROJECTSTATUSISOPEN"].ToString()), dr["TYPEPROJECTSTATUSNAME"].ToString(), dr["FIRMNAME"].ToString(), dr["FIRMDESCRIPTION"].ToString(), byte.Parse(dr["FIRMCITYID"].ToString()), Int16.Parse(dr["FIRMDISTRICTID"].ToString()), dr["FIRMADDRESS"].ToString(), dr["CITYNAME"].ToString(), dr["DISTRICTNAME"].ToString());
                break;
            }
            con.Close();
            return prj;
        }
        public static List<ENTVWPRJPROJECT> GetAllListProjectRequest(Guid FIRMID)//kontrol et
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_PRJ_Project WHERE FIRMID=@FIRMID ORDER BY NAME", con);
            cmd.Parameters.AddWithValue("@FIRMID", FIRMID);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWPRJPROJECT project = null;
            List<ENTVWPRJPROJECT> projectlist = new List<ENTVWPRJPROJECT>();
            while (dr.Read())
            {
                project = new ENTVWPRJPROJECT(Guid.Parse(dr["ID"].ToString()), dr["NAME"].ToString(), dr["DESCRIPTION"].ToString(), Byte.Parse(dr["TYPEPROJECTSTATUSID"].ToString()), Guid.Parse(dr["FIRMID"].ToString()), bool.Parse(dr["TYPEPROJECTSTATUSISOPEN"].ToString()), dr["TYPEPROJECTSTATUSNAME"].ToString(), dr["FIRMNAME"].ToString(), dr["FIRMDESCRIPTION"].ToString(), byte.Parse(dr["FIRMCITYID"].ToString()), Int16.Parse(dr["FIRMDISTRICTID"].ToString()), dr["FIRMADDRESS"].ToString(), dr["CITYNAME"].ToString(), dr["DISTRICTNAME"].ToString());
                projectlist.Add(project);
            }
            con.Close();

            return projectlist;
        }

        public static List<ENTPRJPROJECT> GetAllListTaskID(Guid FIRMID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM PRJ_PROJECT WHERE FIRMID=@FIRMID", con);
            cmd.Parameters.AddWithValue("@FIRMID", FIRMID);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTPRJPROJECT ptsk = null;
            List<ENTPRJPROJECT> ptsklist = new List<ENTPRJPROJECT>();
            while (dr.Read())
            {
                ptsk = new ENTPRJPROJECT(Guid.Parse(dr["ID"].ToString()), dr["NAME"].ToString(), dr["DESCRIPTION"].ToString(), Byte.Parse(dr["TYPEPROJECTSTATUSID"].ToString()), Guid.Parse(dr["FIRMID"].ToString()));
                ptsklist.Add(ptsk);
            }
            con.Close();

            return ptsklist;
        }

    }

}
