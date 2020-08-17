using GravitonCarLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonCarLibrary
{
    public class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; }
        public static string FilePath { get; set; }
        public static void InitializeConnections()
        {
            SqlConnector sql = new SqlConnector();
            Connection = sql;
        }
        public static string getDatabaseConnectionString()
        {
            string server = "thethreefinanceprod.chohi5ea8jhs.ap-south-1.rds.amazonaws.com";
            string port = "5432";
            string user = "kugelblitzroot";
            string password = "Ashish3099";
            string database = "test123";
            string connectionString = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    server, port, user, password, database);
            return connectionString;
        }
    }
}
