using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    public class DALTypeUser : DALSQLConfiguration
    {
        public static List<ENTMEMTYPEUSER> GetAllListTypeUsers()
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM MEM_TYPEUSER ORDER BY ID", con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTMEMTYPEUSER type = null;
            List<ENTMEMTYPEUSER> typeList = new List<ENTMEMTYPEUSER>();
            while (dr.Read())
            {
                type = new ENTMEMTYPEUSER(Convert.ToByte(dr["ID"].ToString()), dr["NAME"].ToString());
                typeList.Add(type);
            }
            con.Close();
            return typeList;
        }
    }
}
