using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaredaProject
{

    class MyConnection
    {
        private static string _serverName;
        private static string _userName;
        private static string _password;
        public static string ConnectionString;

        public static SqlConnection ServerConnection = new SqlConnection();

        public static bool connect(string serverName, string userName, string password)
        {
            MyConnection._serverName = serverName;
            MyConnection._userName = userName;
            MyConnection._password = password;

            ConnectionString = "Data source=" + _serverName
                + ";User Id = " + _userName + "; Password = " + _password;

            if (ServerConnection != null && ServerConnection.State == ConnectionState.Open)
            {
                ServerConnection.Close();
            }
            try
            {
                ServerConnection.ConnectionString = ConnectionString;
                ServerConnection.Open();
                Console.WriteLine("Connection String: " + ConnectionString);
                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

        }
    }
}
