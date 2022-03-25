using BaredaProject.Project;
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

        public static bool ConnectToServer(string serverName, string userName, string password)
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

        public static bool BackupDB(string dbName, string description, bool init)
        {
            string command = $"BACKUP DATABASE {dbName} TO Device_{dbName} WITH DESCRIPTION = N'{description}'";
            if (init) command += ", INIT";
            return ExecSqlNonQuery(command, ConnectionString);

        }

        public static bool CreateDevice(string deviceName, string fullPath)
        {
            string command = $"EXEC master.dbo.sp_addumpdevice @devtype = N'disk', @logicalname = N'{deviceName}', @physicalname = N'{fullPath}'";
            return ExecSqlNonQuery(command, ConnectionString);
        }

        private static bool ExecSqlNonQuery(String command, String connectionString)
        {
            SqlConnection connection;
            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(command, connection);
            sqlCmd.CommandType = CommandType.Text;
            if (connection.State == ConnectionState.Closed) connection.Open();
            try
            {
                sqlCmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                connection.Close();
                Utils.ShowInfoMessage("Lỗi thực thi", ex.Message, Utils.MessageType.Error);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }
    }
}
