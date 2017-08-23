using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    public class DALProjectTask : DALSQLConfiguration
    {
      
        public static void InsertTable(ENTPRJPROJECTTASK ptsk)
        {
            try
            {

                con = SQL.GetConnection();
                if (con.State == ConnectionState.Closed) con.Open();
                string sql = string.Empty;
                if (ptsk.DUEDATE.HasValue)
                {
                    sql = "INSERT INTO PRJ_PROJECTTASK (ID,PROJECTID,NAME,DESCRIPTION,TYPEPROJECTTASKSTATUSID ,CREATEDATE,DUEDATE) VALUES (@ID,@PROJECTID,@NAME,@DESCRIPTION,@TYPEPROJECTTASKSTATUSID ,@CREATEDATE,@DUEDATE)";
                }
                else
                {
                    sql = "INSERT INTO PRJ_PROJECTTASK (ID,PROJECTID,NAME,DESCRIPTION,TYPEPROJECTTASKSTATUSID,CREATEDATE) VALUES (@ID,@PROJECTID,@NAME,@DESCRIPTION,@TYPEPROJECTTASKSTATUSID,@CREATEDATE)";
                }
                cmd = SQL.SetCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", ptsk.ID);
                cmd.Parameters.AddWithValue("@PROJECTID",ptsk.PROJECTID);
                cmd.Parameters.AddWithValue("@NAME", ptsk.NAME);
                cmd.Parameters.AddWithValue("@DESCRIPTION", ptsk.DESCRIPTION);
                cmd.Parameters.AddWithValue("@TYPEPROJECTTASKSTATUSID", ptsk.TYPEPROJECTTASKSTATUSID);
                cmd.Parameters.AddWithValue("@CREATEDATE", ptsk.CREATEDATE);
                if (ptsk.DUEDATE.HasValue)
                {
                    cmd.Parameters.AddWithValue("@DUEDATE", ptsk.DUEDATE);
                }
               
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
        public static void Delete(Guid ID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("DELETE PRJ_PROJECTTASK WHERE ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static List<ENTVWPRJPROJECTTASK> GetAllListProjectsTasks(Guid PROJECTID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_PRJ_ProjectTask WHERE PROJECTID=@PROJECTID ORDER BY CREATEDATE DESC",con);
            cmd.Parameters.AddWithValue("@PROJECTID", PROJECTID);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWPRJPROJECTTASK ptsk = null;
            DateTime? dueDate = null;
            List<ENTVWPRJPROJECTTASK> ptsklist = new List<ENTVWPRJPROJECTTASK>();
            while (dr.Read())
            {
                dueDate = null;
                if(!string.IsNullOrEmpty(dr["DUEDATE"].ToString()))
                {
                    dueDate = Convert.ToDateTime(dr["DUEDATE"].ToString());
                }
                ptsk = new ENTVWPRJPROJECTTASK(Guid.Parse(dr["ID"].ToString()), Guid.Parse(dr["PROJECTID"].ToString()), dr["NAME"].ToString(), dr["DESCRIPTION"].ToString(), Byte.Parse(dr["TYPEPROJECTTASKSTATUSID"].ToString()),Convert.ToDateTime(dr["CREATEDATE"].ToString()), dueDate,dr["TYPEPROJECTTASKSTATUSNAME"].ToString(), bool.Parse(dr["TYPEPROJECTTASKSTATUSISOPEN"].ToString()), dr["PROJECTNAME"].ToString());//ısopen ekledim kontrol et
                ptsklist.Add(ptsk);
            }
            con.Close();

            return ptsklist;
        }
         
        public static void Update(ENTPRJPROJECTTASK ptsk)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("UPDATE PRJ_PROJECTTASK SET NAME = @NAME,TYPEPROJECTTASKSTATUSID=@TYPEPROJECTTASKSTATUSID,CREATEDATE=@CREATEDATE, DUEDATE=@DUEDATE, DESCRIPTION=@DESCRIPTION WHERE ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", ptsk.ID);
            cmd.Parameters.AddWithValue("@NAME", ptsk.NAME);
            cmd.Parameters.AddWithValue("@TYPEPROJECTTASKSTATUSID", ptsk.TYPEPROJECTTASKSTATUSID);
            cmd.Parameters.AddWithValue("@CREATEDATE", ptsk.CREATEDATE);
            if (String.IsNullOrEmpty(ptsk.DUEDATE.ToString()))
            {
                cmd.Parameters.AddWithValue("@DUEDATE", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@DUEDATE", ptsk.DUEDATE);
            }
            cmd.Parameters.AddWithValue("@DESCRIPTION", ptsk.DESCRIPTION);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static ENTPRJPROJECTTASK GetTask(Guid ID)//Id getiriyorum  update icin
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_PRJ_ProjectTask WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTPRJPROJECTTASK ptsk = null;
            DateTime? dueDate = null;
            Guid PROJECTID;
            while (dr.Read())
            {
                dueDate = null;
                if (!string.IsNullOrEmpty(dr["DUEDATE"].ToString()))
                {
                    dueDate = Convert.ToDateTime(dr["DUEDATE"].ToString());
                }
                PROJECTID = Guid.Parse(dr["PROJECTID"].ToString());
                ptsk = new ENTPRJPROJECTTASK(Guid.Parse(dr["ID"].ToString()), Guid.Parse(dr["PROJECTID"].ToString()), dr["NAME"].ToString(), dr["DESCRIPTION"].ToString(), Byte.Parse(dr["TYPEPROJECTTASKSTATUSID"].ToString()), Convert.ToDateTime(dr["CREATEDATE"].ToString()), dueDate);
                break;
            }
            con.Close();
            return ptsk;
        }
         
        public static ENTVWPRJPROJECTTASK GetValueTask(Guid ID)//Id getiriyorum detaildaki labellara yazdırmak için
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_PRJ_ProjectTask WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWPRJPROJECTTASK ptsk = null;
            DateTime? dueDate = null;
            Guid PROJECTID;
            while (dr.Read())
            {
                dueDate = null;
                if (!string.IsNullOrEmpty(dr["DUEDATE"].ToString()))
                {
                    dueDate = Convert.ToDateTime(dr["DUEDATE"].ToString());
                }
                PROJECTID = Guid.Parse(dr["PROJECTID"].ToString());
                ptsk = new ENTVWPRJPROJECTTASK(Guid.Parse(dr["ID"].ToString()), Guid.Parse(dr["PROJECTID"].ToString()), dr["NAME"].ToString(), dr["DESCRIPTION"].ToString(), Byte.Parse(dr["TYPEPROJECTTASKSTATUSID"].ToString()), Convert.ToDateTime(dr["CREATEDATE"].ToString()), dueDate,dr["TYPEPROJECTTASKSTATUSNAME"].ToString(),Convert.ToBoolean(dr["TYPEPROJECTTASKSTATUSISOPEN"].ToString()),dr["PROJECTNAME"].ToString());
                break;
            }
            con.Close();
            return ptsk;
        }

        public static List<ENTVWPRJPROJECTMYTASKS> GetAllListProjects(Guid USERID)//Görevlerim alanı icin listeleme
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_PRJ_ProjectMyTasks WHERE USERID=@USERID ORDER BY PROJECTTASKCREATEDATE ", con);
            cmd.Parameters.AddWithValue("@USERID", USERID);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWPRJPROJECTMYTASKS tasks = null;
            DateTime? dueDate = null;
            List<ENTVWPRJPROJECTMYTASKS> taskslist = new List<ENTVWPRJPROJECTMYTASKS>();
            while (dr.Read())
            {
                dueDate = null;
                if (!string.IsNullOrEmpty(dr["PROJECTTASKDUEDATE"].ToString()))
                {
                    dueDate = Convert.ToDateTime(dr["PROJECTTASKDUEDATE"].ToString());
                }
                tasks = new ENTVWPRJPROJECTMYTASKS(Guid.Parse(dr["PROJECTTASKRESOURSEID"].ToString()),Guid.Parse(dr["USERID"].ToString()), dr["USERFULLNAME"].ToString(), Guid.Parse(dr["FIRMID"].ToString()), dr["FIRMNAME"].ToString(), Guid.Parse(dr["PROJECTID"].ToString()), dr["PROJECTNAME"].ToString(), byte.Parse(dr["TYPEPROJECTSTATUSID"].ToString()), dr["TYPEPROJECTSTATUSNAME"].ToString(), Guid.Parse(dr["PROJECTTASKID"].ToString()), dr["PROJECTTASKNAME"].ToString(),Convert.ToDateTime(dr["PROJECTTASKCREATEDATE"]),dueDate,byte.Parse(dr["TYPEPROJECTTASKSTATUSID"].ToString()), dr["TYPEPROJECTTASKSTATUSNAME"].ToString(),bool.Parse(dr["TYPEPROJECTTASKSTATUSISOPEN"].ToString()));
                taskslist.Add(tasks);
            }
            con.Close();

            return taskslist;
        }

        public static List<ENTTYPEPROJECTTASKSTATUS> GetAllStatusTask()
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM PRJ_TYPEPROJECTTASKSTATUS WHERE ID>0 ", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTTYPEPROJECTTASKSTATUS taskstatus = null;
            List<ENTTYPEPROJECTTASKSTATUS> taskstatuslist = new List<ENTTYPEPROJECTTASKSTATUS>();
            while (dr.Read())
            {
                taskstatus = new ENTTYPEPROJECTTASKSTATUS(Convert.ToByte(dr["ID"].ToString()), dr["NAME"].ToString(), Convert.ToByte(dr["SORT"].ToString()), Convert.ToBoolean(dr["ISOPEN"].ToString()));
                taskstatuslist.Add(taskstatus);
            }
            con.Close();

            return taskstatuslist;
        }
        public static ENTVWPRJPROJECTMYTASKS GetActivity(Guid PROJECTTASKRESOURSEID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_PRJ_ProjectMyTasks WHERE PROJECTTASKRESOURSEID=@PROJECTTASKRESOURSEID", con);
            cmd.Parameters.AddWithValue("@PROJECTTASKRESOURSEID", PROJECTTASKRESOURSEID);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWPRJPROJECTMYTASKS act = null;
            DateTime? dueDate = null;
            while (dr.Read())
            {
                dueDate = null;
                if (!string.IsNullOrEmpty(dr["PROJECTTASKDUEDATE"].ToString()))
                {
                    dueDate = Convert.ToDateTime(dr["PROJECTTASKDUEDATE"].ToString());
                }
                act = new ENTVWPRJPROJECTMYTASKS(Guid.Parse(dr["PROJECTTASKRESOURSEID"].ToString()), Guid.Parse(dr["USERID"].ToString()), dr["USERFULLNAME"].ToString(), Guid.Parse(dr["FIRMID"].ToString()), dr["FIRMNAME"].ToString(), Guid.Parse(dr["PROJECTID"].ToString()), dr["PROJECTNAME"].ToString(), byte.Parse(dr["TYPEPROJECTSTATUSID"].ToString()), dr["TYPEPROJECTSTATUSNAME"].ToString(), Guid.Parse(dr["PROJECTTASKID"].ToString()), dr["PROJECTTASKNAME"].ToString(), Convert.ToDateTime(dr["PROJECTTASKCREATEDATE"]), dueDate, byte.Parse(dr["TYPEPROJECTTASKSTATUSID"].ToString()), dr["TYPEPROJECTTASKSTATUSNAME"].ToString(), bool.Parse(dr["TYPEPROJECTTASKSTATUSISOPEN"].ToString()));
             
            }
            con.Close();
            return act;
        }


        public static List<ENTPRJPROJECTTASK> GetAllListTaskID(Guid PROJECTID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM PRJ_PROJECTTASK WHERE PROJECTID=@PROJECTID", con);
            cmd.Parameters.AddWithValue("@PROJECTID", PROJECTID);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTPRJPROJECTTASK ptsk = null;
            DateTime? dueDate = null;
            List<ENTPRJPROJECTTASK> ptsklist = new List<ENTPRJPROJECTTASK>();
            while (dr.Read())
            {
                dueDate = null;
                if (!string.IsNullOrEmpty(dr["DUEDATE"].ToString()))
                {
                    dueDate = Convert.ToDateTime(dr["DUEDATE"].ToString());
                }
                ptsk = new ENTPRJPROJECTTASK(Guid.Parse(dr["ID"].ToString()), Guid.Parse(dr["PROJECTID"].ToString()), dr["NAME"].ToString(), dr["DESCRIPTION"].ToString(), Byte.Parse(dr["TYPEPROJECTTASKSTATUSID"].ToString()), Convert.ToDateTime(dr["CREATEDATE"].ToString()), dueDate);
                ptsklist.Add(ptsk);
            }
            con.Close();

            return ptsklist;
        }
    }
}
