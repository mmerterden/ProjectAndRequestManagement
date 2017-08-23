using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    public class DALUser : DALSQLConfiguration
    {

        public static ENTMEMUSER GetUser(string mail, string password)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT TOP 1 * FROM MEM_USER WHERE MAIL=@MAIL AND PASSWORD=@PASSWORD", con);
            cmd.Parameters.AddWithValue("@MAIL", mail);
            cmd.Parameters.AddWithValue("@PASSWORD", password);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTMEMUSER user = null;
            Guid? firmID = null;
            byte? languageıd = null;
            while (dr.Read())
            {
                if (!string.IsNullOrEmpty(dr["FIRMID"].ToString()) || !string.IsNullOrEmpty(dr["LANGUAGEID"].ToString()))
                {
                    firmID = Guid.Parse(dr["FIRMID"].ToString());
                }
                else
                {
                    firmID = null;
                }
                if (!string.IsNullOrEmpty(dr["LANGUAGEID"].ToString()))
                {
                    languageıd = Convert.ToByte(dr["LANGUAGEID"].ToString());
                }
                else
                {
                    languageıd = null;
                }
                user = new ENTMEMUSER(Guid.Parse(dr["ID"].ToString()), dr["MAIL"].ToString(), dr["PASSWORD"].ToString(), dr["NAME"].ToString(), dr["SURNAME"].ToString(), Convert.ToDateTime(dr["CREATEDATE"].ToString()), Convert.ToByte(dr["TYPEUSERID"].ToString()), dr["PHONE"].ToString(), Convert.ToBoolean(dr["ISADMIN"]), Convert.ToBoolean(dr["STATUS"]), firmID,languageıd);
                break;
            }
            con.Close();
            return user;
        }

        public static ENTMEMUSER GetUser(Guid ID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM MEM_USER WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTMEMUSER user = null;
            Guid? firmID = null;
            byte? languageıd = null;
            while (dr.Read())
            {
                if (!string.IsNullOrEmpty(dr["FIRMID"].ToString()))
                {
                    firmID = Guid.Parse(dr["FIRMID"].ToString());
                }
                else
                {
                    firmID = null;
                    
                }
                if (!string.IsNullOrEmpty(dr["LANGUAGEID"].ToString()))
                {
                    languageıd = Convert.ToByte(dr["LANGUAGEID"].ToString());
                }
                else
                {
                    languageıd = null;
                }
                user = new ENTMEMUSER(Guid.Parse(dr["ID"].ToString()), dr["MAIL"].ToString(), dr["PASSWORD"].ToString(), dr["NAME"].ToString(), dr["SURNAME"].ToString(), Convert.ToDateTime(dr["CREATEDATE"].ToString()), Convert.ToByte(dr["TYPEUSERID"].ToString()), dr["PHONE"].ToString(), Convert.ToBoolean(dr["ISADMIN"]), Convert.ToBoolean(dr["STATUS"]), firmID, languageıd);
                break;
            }
            con.Close();
            return user;
        }

        public static List<ENTVWMEMUSER> GetAllListUsers(Guid FIRMID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_MEM_User WHERE FIRMID=@FIRMID", con);
            cmd.Parameters.AddWithValue("@FIRMID", FIRMID);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWMEMUSER user = null;
            List<ENTVWMEMUSER> userList = new List<ENTVWMEMUSER>();
            Guid? firmID = null;
            byte? languageıd = null;
            while (dr.Read())
            {
                if (!string.IsNullOrEmpty(dr["FIRMID"].ToString()))
                {
                    firmID = Guid.Parse(dr["FIRMID"].ToString());
                }
                else
                {
                    firmID = null;
                    
                }
                if (!string.IsNullOrEmpty(dr["LANGUAGEID"].ToString()))
                {
                    languageıd = Convert.ToByte(dr["LANGUAGEID"].ToString());
                }
                else
                {
                    languageıd = null;
                }
                    user = new ENTVWMEMUSER(Guid.Parse(dr["ID"].ToString()), dr["MAIL"].ToString(), dr["PASSWORD"].ToString(), dr["NAME"].ToString(), dr["SURNAME"].ToString(), Convert.ToDateTime(dr["CREATEDATE"].ToString()), Convert.ToByte(dr["TYPEUSERID"].ToString()), dr["PHONE"].ToString(), Convert.ToBoolean(dr["ISADMIN"]), Convert.ToBoolean(dr["STATUS"]), firmID,languageıd, dr["LANGUAGENAME"].ToString(), dr["TYPEUSERNAME"].ToString(),dr["FIRMNAME"].ToString());
                userList.Add(user);
            }
            con.Close();
            return userList;
        }
        public static void Delete(Guid ID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("DELETE MEM_USER WHERE ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void Update(ENTMEMUSER user)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("UPDATE MEM_USER SET NAME = @NAME, SURNAME=@SURNAME,CREATEDATE=@CREATEDATE,MAIL=@MAIL,FIRMID=@FIRMID,PHONE=@PHONE,STATUS=@STATUS,TYPEUSERID=@TYPEUSERID,LANGUAGEID=@LANGUAGEID WHERE ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", user.ID);
            cmd.Parameters.AddWithValue("@NAME", user.NAME);
            cmd.Parameters.AddWithValue("@SURNAME", user.SURNAME);
            cmd.Parameters.AddWithValue("@CREATEDATE", user.CREATEDATE);
            cmd.Parameters.AddWithValue("@MAIL", user.MAIL);
            cmd.Parameters.AddWithValue("@FIRMID", user.FIRMID);
            cmd.Parameters.AddWithValue("@PHONE", user.PHONE);
            cmd.Parameters.AddWithValue("@STATUS", user.STATUS);
            cmd.Parameters.AddWithValue("@TYPEUSERID", user.TYPEUSERID);
            cmd.Parameters.AddWithValue("@LANGUAGEID", user.LANGUAGEID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void InsertTable(ENTMEMUSER user)
        {
            try
            {

                con = SQL.GetConnection();
                if (con.State == ConnectionState.Closed) con.Open();

                cmd = SQL.SetCommand("INSERT INTO MEM_USER (ID,MAIL,PASSWORD,NAME, SURNAME,CREATEDATE,TYPEUSERID,ISADMIN,PHONE,STATUS,FIRMID,LANGUAGEID) VALUES (@ID,@MAIL,@PASSWORD,@NAME,@SURNAME,@CREATEDATE,@TYPEUSERID,@ISADMIN,@PHONE,@STATUS,@FIRMID,@LANGUAGEID)", con);
                cmd.Parameters.AddWithValue("@ID", user.ID);
                cmd.Parameters.AddWithValue("@MAIL", user.MAIL);
                cmd.Parameters.AddWithValue("@PASSWORD", user.PASSWORD);
                cmd.Parameters.AddWithValue("@NAME", user.NAME);
                cmd.Parameters.AddWithValue("@SURNAME", user.SURNAME);
                cmd.Parameters.AddWithValue("@CREATEDATE", user.CREATEDATE);
                cmd.Parameters.AddWithValue("@TYPEUSERID", user.TYPEUSERID);
                cmd.Parameters.AddWithValue("@ISADMIN", user.ISADMIN);
                cmd.Parameters.AddWithValue("@PHONE", user.PHONE);
                cmd.Parameters.AddWithValue("@STATUS", user.STATUS);
                cmd.Parameters.AddWithValue("@FIRMID", user.FIRMID);
                cmd.Parameters.AddWithValue("@LANGUAGEID", user.LANGUAGEID);
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


        public static void UpdateProfile(ENTMEMUSER user)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("UPDATE MEM_USER SET NAME = @NAME, SURNAME=@SURNAME,MAIL=@MAIL,PASSWORD=@PASSWORD,PHONE=@PHONE WHERE ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", user.ID);
            cmd.Parameters.AddWithValue("@NAME", user.NAME);
            cmd.Parameters.AddWithValue("@SURNAME", user.SURNAME);
            cmd.Parameters.AddWithValue("@MAIL", user.MAIL);
            cmd.Parameters.AddWithValue("@PASSWORD", user.PASSWORD);
            cmd.Parameters.AddWithValue("@PHONE", user.PHONE);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static ENTVWMEMUSER GetUserInfo(Guid ID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_MEM_User WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWMEMUSER user = null;
            Guid? firmID = null;
            byte? languageıd = null;
            while (dr.Read())
            {
                if (!string.IsNullOrEmpty(dr["FIRMID"].ToString()))
                {
                    firmID = Guid.Parse(dr["FIRMID"].ToString());
                }
                else
                {
                    firmID = null;

                }
                if (!string.IsNullOrEmpty(dr["LANGUAGEID"].ToString()))
                {
                    languageıd = Convert.ToByte(dr["LANGUAGEID"].ToString());
                }
                else
                {
                    languageıd = null;
                }
                user = new ENTVWMEMUSER(Guid.Parse(dr["ID"].ToString()), dr["MAIL"].ToString(), dr["PASSWORD"].ToString(), dr["NAME"].ToString(), dr["SURNAME"].ToString(), Convert.ToDateTime(dr["CREATEDATE"].ToString()), Convert.ToByte(dr["TYPEUSERID"].ToString()), dr["PHONE"].ToString(), Convert.ToBoolean(dr["ISADMIN"]), Convert.ToBoolean(dr["STATUS"]), firmID, languageıd, dr["LANGUAGENAME"].ToString(), dr["TYPEUSERNAME"].ToString(), dr["FIRMNAME"].ToString());
                break;
            }
            con.Close();
            return user;
        }

        public static Guid GetFirmID(Guid USERID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT FIRMID FROM MEM_USER WHERE ID=@USERID", con);
            cmd.Parameters.AddWithValue("@USERID", USERID);

            con.Open();
            Guid FIRMID = Guid.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            return FIRMID;
        }

        public static List<ENTMEMUSER> GetAllListUserID(Guid FIRMID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM MEM_USER WHERE FIRMID=@FIRMID", con);
            cmd.Parameters.AddWithValue("@FIRMID", FIRMID);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTMEMUSER user = null;
            Guid? firmID = null;
            byte? languageıd = null;
            List<ENTMEMUSER> userlist = new List<ENTMEMUSER>();
            while (dr.Read())
            {
                if (!string.IsNullOrEmpty(dr["FIRMID"].ToString()))
                {
                    firmID = Guid.Parse(dr["FIRMID"].ToString());
                }
                else
                {
                    firmID = null;

                }
                if (!string.IsNullOrEmpty(dr["LANGUAGEID"].ToString()))
                {
                    languageıd = Convert.ToByte(dr["LANGUAGEID"].ToString());
                }
                else
                {
                    languageıd = null;
                }
                user = new ENTMEMUSER(Guid.Parse(dr["ID"].ToString()), dr["MAIL"].ToString(), dr["PASSWORD"].ToString(), dr["NAME"].ToString(), dr["SURNAME"].ToString(), Convert.ToDateTime(dr["CREATEDATE"].ToString()), Convert.ToByte(dr["TYPEUSERID"].ToString()), dr["PHONE"].ToString(), Convert.ToBoolean(dr["ISADMIN"]), Convert.ToBoolean(dr["STATUS"]), firmID, languageıd);
                userlist.Add(user);
            }
            con.Close();

            return userlist;
        }

    }


}
