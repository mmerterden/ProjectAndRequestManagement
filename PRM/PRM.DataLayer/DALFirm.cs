using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    public class DALFirm : DALSQLConfiguration
    {

       
        public static List<ENTVWFRMFIRM> GetAllListFirms()
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_FRM_Firm ORDER BY NAME", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWFRMFIRM firm = null;
            List<ENTVWFRMFIRM> firmList = new List<ENTVWFRMFIRM>();
            while (dr.Read())
            {
                firm = new ENTVWFRMFIRM(Guid.Parse(dr["ID"].ToString()), dr["NAME"].ToString(), dr["DESCRIPTION"].ToString(), Convert.ToByte(dr["CITYID"].ToString()), Convert.ToInt16(dr["DISTRICTID"].ToString()), dr["ADDRESS"].ToString(), dr["FIRMCITYNAME"].ToString(), dr["FIRMDISTRICTNAME"].ToString());
                firmList.Add(firm);
            }
            con.Close();
            return firmList;
        }
        public static void InsertTable(ENTFRMFIRM firm)
        {
            try
            {

                con = SQL.GetConnection();
                if (con.State == ConnectionState.Closed) con.Open();

                cmd = SQL.SetCommand("INSERT INTO FRM_FIRM (ID,NAME,DESCRIPTION,CITYID,DISTRICTID,ADDRESS) VALUES (@ID,@NAME,@DESCRIPTION,@CITYID,@DISTRICTID,@ADDRESS)", con);
                cmd.Parameters.AddWithValue("@ID", firm.ID);
                cmd.Parameters.AddWithValue("@NAME",firm.NAME);
                cmd.Parameters.AddWithValue("@DESCRIPTION",firm.DESCRIPTION);
                cmd.Parameters.AddWithValue("@CITYID",firm.CITYID);
                cmd.Parameters.AddWithValue("@DISTRICTID",firm.DISTRICTID);
                cmd.Parameters.AddWithValue("@ADDRESS",firm.ADDRESS);


                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {

            }
        }

        public static void Delete(Guid ID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("DELETE FRM_FIRM WHERE ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void Update(ENTFRMFIRM firm)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("UPDATE FRM_FIRM SET NAME = @NAME,DESCRIPTION=@DESCRIPTION,CITYID=@CITYID,DISTRICTID=@DISTRICTID,ADDRESS=@ADDRESS  WHERE ID = @ID", con);
            cmd.Parameters.AddWithValue("@NAME", firm.NAME);
            cmd.Parameters.AddWithValue("@DESCRIPTION", firm.DESCRIPTION);
            cmd.Parameters.AddWithValue("@CITYID", firm.CITYID);
            cmd.Parameters.AddWithValue("@DISTRICTID", firm.DISTRICTID);
            cmd.Parameters.AddWithValue("@ADDRESS", firm.ADDRESS);
            cmd.Parameters.AddWithValue("@ID",firm.ID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
      

        public static ENTFRMFIRM GetFirm(Guid ID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM FRM_FIRM WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTFRMFIRM firm = null;
            
            while (dr.Read())
            {
                firm = new ENTFRMFIRM(Guid.Parse(dr["ID"].ToString()), dr["NAME"].ToString(), dr["DESCRIPTION"].ToString(), Convert.ToByte(dr["CITYID"].ToString()), Convert.ToInt16(dr["DISTRICTID"].ToString()), dr["ADDRESS"].ToString());
                break;
            }
            con.Close();
            return firm;
        }

        public static ENTVWFRMFIRM GetFirmInfo(Guid ID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_FRM_Firm WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWFRMFIRM firm = null;

            while (dr.Read())
            {
                firm = new ENTVWFRMFIRM(Guid.Parse(dr["ID"].ToString()), dr["NAME"].ToString(), dr["DESCRIPTION"].ToString(), Convert.ToByte(dr["CITYID"].ToString()), Convert.ToInt16(dr["DISTRICTID"].ToString()), dr["ADDRESS"].ToString(), dr["FIRMCITYNAME"].ToString(), dr["FIRMDISTRICTNAME"].ToString());
                break;
            }
            con.Close();
            return firm;
        }

        

    }
}
