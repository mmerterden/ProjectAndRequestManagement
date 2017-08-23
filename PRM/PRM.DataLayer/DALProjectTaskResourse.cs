using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    public class DALProjectTaskResourse : DALSQLConfiguration
    {
        public static List<ENTVWPRJPROJECTTASKRESOURCE> GetAllListProjectsTaskResourse(Guid PROJECTTASKID)//Verileri listeliyoruz.
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_PRJ_ProjectTaskResource WHERE PROJECTTASKID=@PROJECTTASKID", con);
            cmd.Parameters.AddWithValue("@PROJECTTASKID", PROJECTTASKID);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWPRJPROJECTTASKRESOURCE tskrsrs = null;
            byte? duration = null;
            List<ENTVWPRJPROJECTTASKRESOURCE> ptskrsrlist = new List<ENTVWPRJPROJECTTASKRESOURCE>();
            while (dr.Read())
            {

                if (!string.IsNullOrEmpty(dr["DURATION"].ToString()))
                {
                    duration = Convert.ToByte(dr["DURATION"].ToString());
                }
                tskrsrs = new ENTVWPRJPROJECTTASKRESOURCE(Guid.Parse(dr["ID"].ToString()), Guid.Parse(dr["PROJECTTASKID"].ToString()), Guid.Parse(dr["USERID"].ToString()), byte.Parse(dr["TYPEPROJECTRESOURSESTATUSID"].ToString()), duration, dr["PROJECTTASKNAME"].ToString(),Convert.ToDateTime(dr["PROJECTTASKCREATEDATE"].ToString()), dr["USERFULLNAME"].ToString(), dr["TYPEPROJECTRESOURSESTATUSNAME"].ToString());
                ptskrsrlist.Add(tskrsrs);
            }
            con.Close();

            return ptskrsrlist;
        }

        public static void InsertTable(ENTPRJPROJECTTASKRESOURSE prjtskrsrs)//Veri ekliyoruz.
        {
            try
            {
                con = SQL.GetConnection();
                if (con.State == ConnectionState.Closed) con.Open();

                cmd = SQL.SetCommand("INSERT INTO PRJ_PROJECTTASKRESOURSE (ID,PROJECTTASKID,USERID,DURATION,TYPEPROJECTRESOURSESTATUSID) VALUES (@ID,@PROJECTTASKID,@USERID,@DURATION,@TYPEPROJECTRESOURSESTATUSID)", con);
                cmd.Parameters.AddWithValue("@ID", prjtskrsrs.ID);
                cmd.Parameters.AddWithValue("@PROJECTTASKID", prjtskrsrs.PROJECTTASKID);
                cmd.Parameters.AddWithValue("@USERID", prjtskrsrs.USERID);
                cmd.Parameters.AddWithValue("@DURATION", prjtskrsrs.DURATION);
                cmd.Parameters.AddWithValue("@TYPEPROJECTRESOURSESTATUSID", prjtskrsrs.TYPEPROJECTRESOURSESTATUSID);
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

        public static ENTVWPRJPROJECTTASKRESOURCE GetValueTaskResourse(Guid ID)//Id getiriyorum detaildaki labellara yazdırmak için
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_PRJ_ProjectTaskResource WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWPRJPROJECTTASKRESOURCE ptskrsrs = null;
            byte? Duration=null;
            while (dr.Read())
            {
                if (!string.IsNullOrEmpty(dr["DURATION"].ToString()))
                {
                    Duration = Convert.ToByte(dr["DURATION"].ToString());
                }
                ptskrsrs = new ENTVWPRJPROJECTTASKRESOURCE(Guid.Parse(dr["ID"].ToString()), Guid.Parse(dr["PROJECTTASKID"].ToString()), Guid.Parse(dr["USERID"].ToString()), byte.Parse(dr["TYPEPROJECTRESOURSESTATUSID"].ToString()), Duration,dr["PROJECTTASKNAME"].ToString(), Convert.ToDateTime(dr["PROJECTTASKCREATEDATE"].ToString()) ,dr["USERFULLNAME"].ToString(),dr["TYPEPROJECTRESOURSESTATUSNAME"].ToString());
                break;
            }
            con.Close();
            return ptskrsrs;
        }

        public static void Update(ENTPRJPROJECTTASKRESOURSE ptskrsrs)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("UPDATE PRJ_PROJECTTASKRESOURSE SET PROJECTTASKID = @PROJECTTASKID,USERID=@USERID, DURATION=@DURATION, TYPEPROJECTRESOURSESTATUSID=@TYPEPROJECTRESOURSESTATUSID WHERE ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", ptskrsrs.ID);
            cmd.Parameters.AddWithValue("@PROJECTTASKID", ptskrsrs.PROJECTTASKID);
            cmd.Parameters.AddWithValue("@USERID", ptskrsrs.USERID);
            cmd.Parameters.AddWithValue("@DURATION", ptskrsrs.DURATION);
            cmd.Parameters.AddWithValue("@TYPEPROJECTRESOURSESTATUSID", ptskrsrs.TYPEPROJECTRESOURSESTATUSID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public static ENTPRJPROJECTTASKRESOURSE GetValueTaskResourseNotVW(Guid ID)//Id getiriyorum detaildaki labellara yazdırmak için
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM PRJ_PROJECTTASKRESOURSE WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTPRJPROJECTTASKRESOURSE ptskrsrs = null;
            byte? Duration = null;
            while (dr.Read())
            {
                if (!string.IsNullOrEmpty(dr["DURATION"].ToString()))
                {
                    Duration = Convert.ToByte(dr["DURATION"].ToString());
                }
                ptskrsrs = new ENTPRJPROJECTTASKRESOURSE(Guid.Parse(dr["ID"].ToString()), Guid.Parse(dr["PROJECTTASKID"].ToString()), Guid.Parse(dr["USERID"].ToString()),Duration, byte.Parse(dr["TYPEPROJECTRESOURSESTATUSID"].ToString()));
                break;
            }
            con.Close();
            return ptskrsrs;
        }

        public static void Delete(Guid ID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("DELETE PRJ_PROJECTTASKRESOURSE WHERE ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static bool ControltoUSER(Guid PROJECTTASKID,Guid USERID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT CASE WHEN EXISTS (SELECT NULL FROM PRJ_PROJECTTASKRESOURSE WHERE PROJECTTASKID=@PROJECTTASKID AND USERID = @USERID) THEN 1 ELSE 0 END", con);
            cmd.Parameters.AddWithValue("@USERID", USERID);
            cmd.Parameters.AddWithValue("@PROJECTTASKID", PROJECTTASKID);

            con.Open();
            bool val = Convert.ToBoolean(Convert.ToByte(cmd.ExecuteScalar()));
            con.Close();
            return val;
        }

        public static List<ENTPRJTYPEPROJECTTASKRESOURSESTATUS> GetAllProjectTaskResourseStatus()
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM PRJ_TYPEPROJECTTASKRESOURSESTATUS WHERE ID>0 ", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTPRJTYPEPROJECTTASKRESOURSESTATUS taskstatus = null;
            List<ENTPRJTYPEPROJECTTASKRESOURSESTATUS> taskstatuslist = new List<ENTPRJTYPEPROJECTTASKRESOURSESTATUS>();
            while (dr.Read())
            {
                taskstatus = new ENTPRJTYPEPROJECTTASKRESOURSESTATUS(Convert.ToByte(dr["ID"].ToString()), dr["NAME"].ToString(), Convert.ToByte(dr["SORT"].ToString()), Convert.ToBoolean(dr["ISOPEN"].ToString()));
                taskstatuslist.Add(taskstatus);
            }
            con.Close();

            return taskstatuslist;
        }

        public static ENTPRJPROJECTTASKRESOURSE GetValueComplete(Guid PROJECTTASKID, Guid USERID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM PRJ_PROJECTTASKRESOURSE WHERE PROJECTTASKID=@PROJECTTASKID AND USERID=@USERID", con);
            cmd.Parameters.AddWithValue("@PROJECTTASKID", PROJECTTASKID);
            cmd.Parameters.AddWithValue("@USERID", USERID);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTPRJPROJECTTASKRESOURSE ptskrsrs = null;
            byte? Duration = null;
            while (dr.Read())
            {
                if (!string.IsNullOrEmpty(dr["DURATION"].ToString()))
                {
                    Duration = Convert.ToByte(dr["DURATION"].ToString());
                }
                ptskrsrs = new ENTPRJPROJECTTASKRESOURSE(Guid.Parse(dr["ID"].ToString()), Guid.Parse(dr["PROJECTTASKID"].ToString()), Guid.Parse(dr["USERID"].ToString()), Duration, byte.Parse(dr["TYPEPROJECTRESOURSESTATUSID"].ToString()));
                break;
            }
            con.Close();
            return ptskrsrs;
        }

   
        public static List<ENTPRJPROJECTTASKRESOURSE> GetAllListTaskResoursesID(Guid PROJECTTASKID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM PRJ_PROJECTTASKRESOURSE WHERE PROJECTTASKID=@PROJECTTASKID", con);
            cmd.Parameters.AddWithValue("@PROJECTTASKID", PROJECTTASKID);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTPRJPROJECTTASKRESOURSE ptsk = null;
            byte? Duration = null;
            List<ENTPRJPROJECTTASKRESOURSE> ptsklist = new List<ENTPRJPROJECTTASKRESOURSE>();
            while (dr.Read())
            {
                if (!string.IsNullOrEmpty(dr["DURATION"].ToString()))
                {
                    Duration = Convert.ToByte(dr["DURATION"].ToString());
                }
                ptsk = new ENTPRJPROJECTTASKRESOURSE(Guid.Parse(dr["ID"].ToString()), Guid.Parse(dr["PROJECTTASKID"].ToString()), Guid.Parse(dr["USERID"].ToString()), Duration, byte.Parse(dr["TYPEPROJECTRESOURSESTATUSID"].ToString()));
                ptsklist.Add(ptsk);
            }
            con.Close();

            return ptsklist;
        }

        public static List<ENTPRJPROJECTTASKRESOURSE> GetAllListFirmResoursesID(Guid USERID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM PRJ_PROJECTTASKRESOURSE WHERE USERID=@USERID", con);
            cmd.Parameters.AddWithValue("@USERID", USERID);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTPRJPROJECTTASKRESOURSE ptsk = null;
            byte? Duration = null;
            List<ENTPRJPROJECTTASKRESOURSE> ptsklist = new List<ENTPRJPROJECTTASKRESOURSE>();
            while (dr.Read())
            {
                if (!string.IsNullOrEmpty(dr["DURATION"].ToString()))
                {
                    Duration = Convert.ToByte(dr["DURATION"].ToString());
                }
                ptsk = new ENTPRJPROJECTTASKRESOURSE(Guid.Parse(dr["ID"].ToString()), Guid.Parse(dr["PROJECTTASKID"].ToString()), Guid.Parse(dr["USERID"].ToString()), Duration, byte.Parse(dr["TYPEPROJECTRESOURSESTATUSID"].ToString()));
                ptsklist.Add(ptsk);
            }
            con.Close();

            return ptsklist;
        }

    }


}

