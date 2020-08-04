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
        public static void InitializeConnections()
        {
            SqlConnector sql = new SqlConnector();
            Connection = sql;
        }
        public static string getDatabaseConnectionString()
        {
            string server = "mydb.ctmbums33jwn.ap-south-1.rds.amazonaws.com";
            string port = "5432";
            string user = "postgres";
            string password = "postgres";
            string database = "postgres";
            string connectionString = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    server, port, user, password, database);
            return connectionString;
        }
    }
}
