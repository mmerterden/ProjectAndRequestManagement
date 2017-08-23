using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    public class DALUserFullName:DALSQLConfiguration
    {
    
        public static List<ENTVWFULLNAME> GetAllListUsersForResourse()//Kaynak ekle icin İSİMLERİ GETİRDİM VERİTABANINDAN.
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_PRJ_UserFullName WHERE TYPEUSERID=1", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWFULLNAME usr = null;
            List<ENTVWFULLNAME> usrlist = new List<ENTVWFULLNAME>();
            while (dr.Read())
            {

                usr = new ENTVWFULLNAME(Guid.Parse(dr["ID"].ToString()),dr["USERFULLNAME"].ToString(),Convert.ToByte(dr["TYPEUSERID"].ToString()));
                usrlist.Add(usr);
            }
            con.Close();

            return usrlist;
        }

        public static ENTVWFULLNAME GetValueUser(Guid ID)// ıd BİLGİSİ GETİRİYORUM USERID İCİN
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_PRJ_UserFullName WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWFULLNAME ptsk = null;
            while (dr.Read())
            {

                ptsk = new ENTVWFULLNAME(Guid.Parse(dr["ID"].ToString()), dr["USERFULLNAME"].ToString(), Convert.ToByte(dr["TYPEUSERID"].ToString()));
                break;
            }
            con.Close();
            return ptsk;
        }
    }
}
