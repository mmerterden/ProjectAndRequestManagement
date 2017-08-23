using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    public class DALLanguage :DALSQLConfiguration
    {
        public static List<ENTMEMLANGUAGE> GetAllLanguage()
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM MEM_LANGUAGE WHERE ID>0 ", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTMEMLANGUAGE lang = null;
            List<ENTMEMLANGUAGE> langlist = new List<ENTMEMLANGUAGE>();
            while (dr.Read())
            {
                lang = new ENTMEMLANGUAGE(Convert.ToByte(dr["ID"].ToString()), dr["NAME"].ToString());
                langlist.Add(lang);
            }
            con.Close();

            return langlist;
        }
    }
}
