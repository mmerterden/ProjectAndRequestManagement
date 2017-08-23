using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.DataLayer
{
    public class SQL
    {
        public static SqlConnection GetConnection()
        {
           string url = "data source=DESKTOP-QJRHTLH;initial catalog=ProjectManagement;user id=sa;password=123456;";
                //File.ReadAllText(@"c:\connection.txt", Encoding.UTF8); 
            
            return new SqlConnection(url); 
        }
        public static SqlCommand SetCommand(string cmd, SqlConnection con)
        {

            return new SqlCommand(cmd, con);
        }

    }
}
