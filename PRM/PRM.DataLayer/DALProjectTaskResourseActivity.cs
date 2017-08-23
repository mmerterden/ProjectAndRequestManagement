using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    public class DALProjectTaskResourseActivity : DALSQLConfiguration
    {
        public static List<ENTVWPRJPROJECTTASKRESOURSEACTIVITY> GetAllListTaskActivity(Guid PROJECTTASKRESOURSEID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_PRJ_ProjectTaskUserActivity WHERE PROJECTTASKRESOURSEID=@PROJECTTASKRESOURSEID", con);
            cmd.Parameters.AddWithValue("@PROJECTTASKRESOURSEID", PROJECTTASKRESOURSEID);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWPRJPROJECTTASKRESOURSEACTIVITY activity = null;
            byte? resourseduration = null;
            List<ENTVWPRJPROJECTTASKRESOURSEACTIVITY> activitylist = new List<ENTVWPRJPROJECTTASKRESOURSEACTIVITY>();
            while (dr.Read())
            {
                resourseduration = null;
                if (!string.IsNullOrEmpty(dr["RESOURSEDURATION"].ToString()))
                {
                    resourseduration = Convert.ToByte(dr["RESOURSEDURATION"].ToString());
                }
                activity = new ENTVWPRJPROJECTTASKRESOURSEACTIVITY(Guid.Parse(dr["ID"].ToString()), Guid.Parse(dr["USERID"].ToString()), resourseduration, dr["DESCRIPTION"].ToString(), Convert.ToDateTime(dr["DATE"].ToString()), Guid.Parse(dr["PROJECTTASKRESOURSEID"].ToString()), Guid.Parse(dr["PROJECTTASKID"].ToString()), dr["PROJECTTASKNAME"].ToString(), Guid.Parse(dr["PROJECTID"].ToString()), dr["PROJECTNAME"].ToString());
                activitylist.Add(activity);
            }
            con.Close();

            return activitylist;
        }

        public static void InsertTable(ENTPRJPROJECTTASKRESOURSEACTIVITY activity)
        {
            try
            {
                con = SQL.GetConnection();
                if (con.State == ConnectionState.Closed) con.Open();

                cmd = SQL.SetCommand("INSERT INTO PRJ_PROJECTTASKUSERACTIVITY (ID,RESOURSEDURATION,DESCRIPTION,DATE,PROJECTTASKRESOURSEID) VALUES (@ID,@RESOURSEDURATION,@DESCRIPTION,@DATE,@PROJECTTASKRESOURSEID)", con);
                cmd.Parameters.AddWithValue("@ID", activity.ID);
                if (String.IsNullOrEmpty(activity.RESOURSEDURATION.ToString()))
                {
                    cmd.Parameters.AddWithValue("@RESOURSEDURATION", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@RESOURSEDURATION", activity.RESOURSEDURATION);
                }
                cmd.Parameters.AddWithValue("@DESCRIPTION", activity.DESCRIPTION);
                cmd.Parameters.AddWithValue("@DATE", activity.DATE);
                cmd.Parameters.AddWithValue("@PROJECTTASKRESOURSEID", activity.PROJECTTASKRESOURSEID);
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
        public static void UpdateComplete(ENTPRJPROJECTTASKRESOURSE ptskrsrs)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("UPDATE PRJ_PROJECTTASKRESOURSE SET TYPEPROJECTRESOURSESTATUSID=@TYPEPROJECTRESOURSESTATUSID WHERE ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", ptskrsrs.ID);
            cmd.Parameters.AddWithValue("@TYPEPROJECTRESOURSESTATUSID", ptskrsrs.TYPEPROJECTRESOURSESTATUSID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

       
        public static void UpdateActivity(ENTPRJPROJECTTASKRESOURSEACTIVITY activity)
        {
            con = SQL.GetConnection();

            if (con.State == ConnectionState.Closed) con.Open();

            cmd = SQL.SetCommand("UPDATE PRJ_PROJECTTASKUSERACTIVITY SET  RESOURSEDURATION=@RESOURSEDURATION, DESCRIPTION=@DESCRIPTION, DATE=@DATE,PROJECTTASKRESOURSEID=@PROJECTTASKRESOURSEID WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", activity.ID);
            if (String.IsNullOrEmpty(activity.RESOURSEDURATION.ToString()))//RAYNARD
            {
                cmd.Parameters.AddWithValue("@RESOURSEDURATION", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@RESOURSEDURATION", activity.RESOURSEDURATION);
            }
            cmd.Parameters.AddWithValue("@DESCRIPTION", activity.DESCRIPTION);
            cmd.Parameters.AddWithValue("@DATE", activity.DATE);
            cmd.Parameters.AddWithValue("@PROJECTTASKRESOURSEID", activity.PROJECTTASKRESOURSEID);
            cmd.ExecuteNonQuery();
        }
        public static ENTVWPRJPROJECTTASKRESOURSEACTIVITY GetValueTaskResourseActivity(Guid ID)//Aktivite güncellemek için verileri getirme
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_PRJ_ProjectTaskUserActivity WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWPRJPROJECTTASKRESOURSEACTIVITY activity = null;
            byte? resourseduration = null;

            while (dr.Read())
            {
                if (!string.IsNullOrEmpty(dr["RESOURSEDURATION"].ToString()))
                {
                    resourseduration = Convert.ToByte(dr["RESOURSEDURATION"].ToString());
                }
                activity = new ENTVWPRJPROJECTTASKRESOURSEACTIVITY(Guid.Parse(dr["ID"].ToString()), Guid.Parse(dr["USERID"].ToString()), resourseduration, dr["DESCRIPTION"].ToString(), Convert.ToDateTime(dr["DATE"].ToString()), Guid.Parse(dr["PROJECTTASKRESOURSEID"].ToString()), Guid.Parse(dr["PROJECTTASKID"].ToString()), dr["PROJECTTASKNAME"].ToString(), Guid.Parse(dr["PROJECTID"].ToString()), dr["PROJECTNAME"].ToString());
                break;
            }
            con.Close();
            return activity;
        }

        public static ENTPRJPROJECTTASKRESOURSEACTIVITY GetValueTaskResourseActivityForUpdate(Guid ID)//Aktivite güncellemek için verileri getirme
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM PRJ_PROJECTTASKUSERACTIVITY WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTPRJPROJECTTASKRESOURSEACTIVITY activity = null;
            byte? resourseduration = null;

            while (dr.Read())
            {
                if (!string.IsNullOrEmpty(dr["RESOURSEDURATION"].ToString()))
                {
                    resourseduration = Convert.ToByte(dr["RESOURSEDURATION"].ToString());
                }
                activity = new ENTPRJPROJECTTASKRESOURSEACTIVITY(Guid.Parse(dr["ID"].ToString()), resourseduration, dr["DESCRIPTION"].ToString(), Convert.ToDateTime(dr["DATE"].ToString()), Guid.Parse(dr["PROJECTTASKRESOURSEID"].ToString()));
                break;
            }
            con.Close();
            return activity;
        }

        public static void Delete(Guid ID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("DELETE PRJ_PROJECTTASKUSERACTIVITY WHERE ID=@ID ", con);
            cmd.Parameters.AddWithValue("@ID", ID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static List<ENTPRJPROJECTTASKRESOURSEACTIVITY> GetAllListTaskResoursesActivityID(Guid PROJECTTASKRESOURSEID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM PRJ_PROJECTTASKUSERACTIVITY WHERE PROJECTTASKRESOURSEID=@PROJECTTASKRESOURSEID", con);
            cmd.Parameters.AddWithValue("@PROJECTTASKRESOURSEID", PROJECTTASKRESOURSEID);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTPRJPROJECTTASKRESOURSEACTIVITY ptsk = null;
            byte? resourseduration = null;
            List<ENTPRJPROJECTTASKRESOURSEACTIVITY> ptsklist = new List<ENTPRJPROJECTTASKRESOURSEACTIVITY>();
            while (dr.Read())
            {
                if (!string.IsNullOrEmpty(dr["RESOURSEDURATION"].ToString()))
                {
                    resourseduration = Convert.ToByte(dr["RESOURSEDURATION"].ToString());
                }
                ptsk = new ENTPRJPROJECTTASKRESOURSEACTIVITY(Guid.Parse(dr["ID"].ToString()), resourseduration, dr["DESCRIPTION"].ToString(), Convert.ToDateTime(dr["DATE"].ToString()), Guid.Parse(dr["PROJECTTASKRESOURSEID"].ToString()));
                ptsklist.Add(ptsk);
            }
            con.Close();

            return ptsklist;
        }
        

    }
}
