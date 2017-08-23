using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    public class DALRequest :DALSQLConfiguration
    {
        public static void InsertTable(ENTREQREQUESTS rqst)
        {
            try
            {

                con = SQL.GetConnection();
                if (con.State == ConnectionState.Closed) con.Open();
                cmd = SQL.SetCommand("INSERT INTO REQ_REQUEST (ID,PROJECTID,NAME,TYPEREQUESTID,USERID,REQUESTDATE,DESCRIPTION) VALUES (@ID,@PROJECTID,@NAME,@TYPEREQUESTID,@USERID,@REQUESTDATE,@DESCRIPTION)", con);
                cmd.Parameters.AddWithValue("@ID", rqst.ID);
                cmd.Parameters.AddWithValue("@PROJECTID", rqst.PROJECTID);
                cmd.Parameters.AddWithValue("@NAME", rqst.NAME);
                cmd.Parameters.AddWithValue("@TYPEREQUESTID", rqst.TYPEREQUESTID);
                cmd.Parameters.AddWithValue("@USERID", rqst.USERID);
                cmd.Parameters.AddWithValue("@REQUESTDATE", rqst.REQUESTDATE);
                cmd.Parameters.AddWithValue("@DESCRIPTION", rqst.DESCRIPTION);

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
        public static List<ENTVWREQREQUESTS> GetAllListRequest()
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_REQ_Request", con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWREQREQUESTS rqst = null;
            List<ENTVWREQREQUESTS> rqstList = new List<ENTVWREQREQUESTS>();
            while (dr.Read())
            {
                rqst = new ENTVWREQREQUESTS(Guid.Parse(dr["ID"].ToString()), Guid.Parse(dr["PROJECTID"].ToString()), dr["NAME"].ToString(),Convert.ToByte(dr["TYPEREQUESTID"].ToString()), Guid.Parse(dr["USERID"].ToString()),Convert.ToDateTime(dr["REQUESTDATE"].ToString()),dr["DESCRIPTION"].ToString(), dr["PROJECTNAME"].ToString(),dr["TYPEREQUESTSTATUSNAME"].ToString(),Convert.ToBoolean( dr["ISOPEN"].ToString()),dr["USERFULLNAME"].ToString());
                rqstList.Add(rqst);
            }
            con.Close();
            return rqstList;
        }
        public static ENTVWREQREQUESTS GetRequest(Guid ID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_REQ_Request WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWREQREQUESTS rqst = null;

            while (dr.Read())
            {
                rqst = new ENTVWREQREQUESTS(Guid.Parse(dr["ID"].ToString()), Guid.Parse(dr["PROJECTID"].ToString()), dr["NAME"].ToString(), Convert.ToByte(dr["TYPEREQUESTID"].ToString()), Guid.Parse(dr["USERID"].ToString()), Convert.ToDateTime(dr["REQUESTDATE"].ToString()), dr["DESCRIPTION"].ToString(), dr["PROJECTNAME"].ToString(), dr["TYPEREQUESTSTATUSNAME"].ToString(), Convert.ToBoolean(dr["ISOPEN"].ToString()), dr["USERFULLNAME"].ToString());
                break;
            }
            con.Close();
            return rqst;
        }

        public static void InsertMessage(ENTREQREQUESTDETAIL rqstdtl)
        {
            try
            {

                con = SQL.GetConnection();
                if (con.State == ConnectionState.Closed) con.Open();
                cmd = SQL.SetCommand("INSERT INTO REQ_REQUESTDETAIL (ID,REQUESTID,USERID,MESSAGE,DATE) VALUES (@ID,@REQUESTID,@USERID,@MESSAGE,@DATE)", con);
                cmd.Parameters.AddWithValue("@ID", rqstdtl.ID);
                cmd.Parameters.AddWithValue("@REQUESTID", rqstdtl.REQUESTID);
                cmd.Parameters.AddWithValue("@USERID", rqstdtl.USERID);
                cmd.Parameters.AddWithValue("@MESSAGE", rqstdtl.MESSAGE);
                cmd.Parameters.AddWithValue("@DATE", rqstdtl.DATE);

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
        public static void UpdateStatus(ENTREQREQUESTS rqst)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("UPDATE REQ_REQUEST SET TYPEREQUESTID=@TYPEREQUESTID WHERE ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", rqst.ID);
            cmd.Parameters.AddWithValue("@TYPEREQUESTID", rqst.TYPEREQUESTID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static ENTREQREQUESTS GetValueStatus(Guid ID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM REQ_Request WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTREQREQUESTS rqst = null;

            while (dr.Read())
            {
                rqst = new ENTREQREQUESTS(Guid.Parse(dr["ID"].ToString()), Guid.Parse(dr["PROJECTID"].ToString()), dr["NAME"].ToString(), Convert.ToByte(dr["TYPEREQUESTID"].ToString()), Guid.Parse(dr["USERID"].ToString()), Convert.ToDateTime(dr["REQUESTDATE"].ToString()), dr["DESCRIPTION"].ToString());
                break;
            }
            con.Close();
            return rqst;
        }

        public static List<ENTVWREQREQUESTDETAILUSER> GetAllListMessage(Guid REQUESTID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM VW_REQ_RequestDetailUser WHERE REQUESTID=@REQUESTID ORDER BY DATE ", con);
            cmd.Parameters.AddWithValue("@REQUESTID", REQUESTID);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTVWREQREQUESTDETAILUSER msg = null;
            List<ENTVWREQREQUESTDETAILUSER> msglist = new List<ENTVWREQREQUESTDETAILUSER>();
            while (dr.Read())
            {
                msg = new ENTVWREQREQUESTDETAILUSER(Guid.Parse(dr["ID"].ToString()), Convert.ToDateTime(dr["DATE"].ToString()), dr["MESSAGE"].ToString(), Guid.Parse(dr["REQUESTID"].ToString()), Guid.Parse(dr["USERID"].ToString()),dr["USERFULLNAME"].ToString(),dr["CLASS"].ToString(), dr["PICTURE"].ToString());
                msglist.Add(msg);
            }
            con.Close();

            return msglist;
        }

        public static List<ENTREQTYPEREQUEST> GetAllStatus()
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM REQ_TYPEREQUEST WHERE ID>1", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTREQTYPEREQUEST requeststatus = null;
            List<ENTREQTYPEREQUEST> requeststatuslist = new List<ENTREQTYPEREQUEST>();
            while (dr.Read())
            {
                requeststatus = new ENTREQTYPEREQUEST(Convert.ToByte(dr["ID"].ToString()), dr["NAME"].ToString(), Convert.ToByte(dr["SORT"].ToString()), Convert.ToBoolean(dr["ISOPEN"].ToString()));
                requeststatuslist.Add(requeststatus);
            }
            con.Close();

            return requeststatuslist;
        }

        public static List<ENTREQREQUESTS> GetAllListRequestsID(Guid PROJECTID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM REQ_REQUEST WHERE PROJECTID=@PROJECTID", con);
            cmd.Parameters.AddWithValue("@PROJECTID", PROJECTID);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTREQREQUESTS ptsk = null;
            List<ENTREQREQUESTS> ptsklist = new List<ENTREQREQUESTS>();
            while (dr.Read())
            {
                ptsk = new ENTREQREQUESTS(Guid.Parse(dr["ID"].ToString()), Guid.Parse(dr["PROJECTID"].ToString()), dr["NAME"].ToString(), Convert.ToByte(dr["TYPEREQUESTID"].ToString()), Guid.Parse(dr["USERID"].ToString()), Convert.ToDateTime(dr["REQUESTDATE"].ToString()), dr["DESCRIPTION"].ToString());
                ptsklist.Add(ptsk);
            }
            con.Close();

            return ptsklist;
        }
        public static List<ENTREQREQUESTDETAIL> GetAllListRequestDetailsID(Guid REQUESTID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM REQ_REQUESTDETAIL WHERE REQUESTID=@REQUESTID", con);
            cmd.Parameters.AddWithValue("@REQUESTID", REQUESTID);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTREQREQUESTDETAIL ptsk = null;
            List<ENTREQREQUESTDETAIL> ptsklist = new List<ENTREQREQUESTDETAIL>();
            while (dr.Read())
            {
                ptsk = new ENTREQREQUESTDETAIL(Guid.Parse(dr["ID"].ToString()), Guid.Parse(dr["REQUESTID"].ToString()), Guid.Parse(dr["USERID"].ToString()), dr["MESSAGE"].ToString(), Convert.ToDateTime(dr["DATE"].ToString()));
                ptsklist.Add(ptsk);
            }
            con.Close();

            return ptsklist;
        }

        public static void Delete(Guid ID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("DELETE REQ_REQUEST WHERE ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void DeleteDetail(Guid ID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("DELETE REQ_REQUESTDETAIL WHERE ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static List<ENTREQREQUESTS> GetAllListFirmRequestsID(Guid USERID)
        {
            con = SQL.GetConnection();
            cmd = SQL.SetCommand("SELECT * FROM REQ_REQUEST WHERE USERID=@USERID", con);
            cmd.Parameters.AddWithValue("@USERID", USERID);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ENTREQREQUESTS ptsk = null;
            List<ENTREQREQUESTS> ptsklist = new List<ENTREQREQUESTS>();
            while (dr.Read())
            {
                ptsk = new ENTREQREQUESTS(Guid.Parse(dr["ID"].ToString()), Guid.Parse(dr["PROJECTID"].ToString()), dr["NAME"].ToString(), Convert.ToByte(dr["TYPEREQUESTID"].ToString()), Guid.Parse(dr["USERID"].ToString()), Convert.ToDateTime(dr["REQUESTDATE"].ToString()), dr["DESCRIPTION"].ToString());
                ptsklist.Add(ptsk);
            }
            con.Close();

            return ptsklist;
        }


    }
}
