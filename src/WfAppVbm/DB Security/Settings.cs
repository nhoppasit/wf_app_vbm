using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB_Security
{
    public static class Settings
    {
        // static string _connectionString = @"Data Source=10.40.146.11\sqlexpress;Initial Catalog=DB_FIXED_ASSET;User ID=sa;Password=System1234";
        static string typedatabase = "MYSQL"; // MSSQL or MYSQL

        //static string server_name = "127.0.0.1";
        //static string user_Name = "root";
        //static string password = "System1234";

        static string server_name = "119.59.96.92";
        static string user_Name = "db_pettag";
        static string password = "Pett@g2024";

        static string db_Name = "db_pettag";
        static string port = "3306";

        static string ConnectionTimeOut = "120";
        public static string ConnectionString { get { return getconnectionString(); } }

        static string getconnectionString()
        {
            if (typedatabase == "MSSQL")
            {
                return @"Data Source=" + server_name + ";Initial Catalog=" + db_Name + ";User ID=" + user_Name + ";Password=" + password;
            }
            else if (typedatabase == "MYSQL")
            {
                return @"Server = " + server_name + "; " +
                                            "Port=" + port + ";" +
                                            "Database=" + db_Name + ";" +
                                            "Uid=" + user_Name + ";" +
                                            "Pwd=" + password + ";" +
                                            "Connection Timeout=" + ConnectionTimeOut + ";Pooling=false;charset=utf8;Convert Zero Datetime=True;";

            }
            else
            {
                return "";
            }
        }
    }
}


