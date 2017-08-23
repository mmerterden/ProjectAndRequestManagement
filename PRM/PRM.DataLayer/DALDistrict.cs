using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    public class DALDistrict : DALSQLConfiguration
    {
        public static List<ENTSYSDISTRICT> GetAllListDistrict(byte cityID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT ID,CITYID,NAME FROM SYS_DISTRICT WHERE CITYID=@CITYID ORDER BY ID", con);
            cmd.Parameters.AddWithValue("@CITYID", cityID);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTSYSDISTRICT district = null;
            List<ENTSYSDISTRICT> districtlist = new List<ENTSYSDISTRICT> ();
            while (dr.Read())
            {
                district = new ENTSYSDISTRICT (Convert.ToInt16(dr["ID"].ToString()),Convert.ToByte(dr["CITYID"].ToString()), dr["NAME"].ToString());
                districtlist.Add(district);
            }
            con.Close();
            //return new List<ENTPRJPROJECT>();
            return districtlist;
        }
    }
}
