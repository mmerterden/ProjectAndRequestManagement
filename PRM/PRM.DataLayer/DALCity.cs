using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    public class DALCity :DALSQLConfiguration
    {
        public static List<ENTSYSCITY> GetAllListCity()
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT ID,NAME FROM SYS_CITY WHERE ID>0 ORDER BY ID", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTSYSCITY city = null;
            List<ENTSYSCITY> citylist = new List<ENTSYSCITY>();
            while (dr.Read())
            {
                city = new ENTSYSCITY(Convert.ToByte(dr["ID"].ToString()), dr["NAME"].ToString());
                citylist.Add(city);
            }
            con.Close();
            //return new List<ENTPRJPROJECT>();
            return citylist;
        }
    }
}
