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
    public struct Para
    {
        public string ValueName;
        public object RealValue;
        public Para(string valueName, object realValue)
        {
            ValueName = valueName;
            RealValue = realValue;
        }
    }
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

        private static bool ClearBackupHistory(string dbName)
        {
            //DateTime now = DateTime.Now;
            //now.ToString("yyyy-MM-dd HH:mm:ss")
            string command = "EXEC msdb.dbo.sp_delete_database_backuphistory @DBName";
            List<Para> paraList = new List<Para>();
            paraList.Add(new Para("@DBName", dbName));
            return ExecSqlNonQuery(command, ConnectionString, paraList);

        }
        public static bool BackupDB(string dbName, string description, bool init)
        {
            string command = "BACKUP DATABASE @DBName TO @DeviceName WITH DESCRIPTION = @Description";
            if (init)
            {
                command += ", INIT";
                ClearBackupHistory(dbName);
            }

            List<Para> paraList = new List<Para>();
            paraList.Add(new Para("@DBName", dbName));
            paraList.Add(new Para("@DeviceName", "Device_" + dbName));
            paraList.Add(new Para("@Description", description));
            return ExecSqlNonQuery(command, ConnectionString, paraList);

        }

        public static bool CreateDevice(string deviceName, string fullPath)
        {
            string command = "EXEC master.dbo.sp_addumpdevice @devtype = N'disk', @logicalname = @DeviceName, @physicalname = @FullPath";
            List<Para> paraList = new List<Para>();
            paraList.Add(new Para("@DeviceName", deviceName));
            paraList.Add(new Para("@FullPath", fullPath));

            return ExecSqlNonQuery(command, ConnectionString, paraList);
        }

        public static bool DeleteBackupInstance(string dbName, int pos)
        {
            string command = "DECLARE @database_name NVARCHAR(100),@Pos INT " +
                                "SET @Pos = " + pos + "SET @database_name = '" + dbName + "'  " +
                                "DECLARE @backup_set_id INT  DECLARE @media_set_id INT  DECLARE @restore_history_id TABLE (restore_history_id INT) SELECT @backup_set_id = MAX(backup_set_id) FROM msdb.dbo.backupset WHERE position = @Pos AND database_name = @database_name SELECT @media_set_id = media_set_id FROM msdb.dbo.backupset WHERE backup_set_id = @backup_set_id  INSERT INTO @restore_history_id (restore_history_id)  SELECT DISTINCT restore_history_id FROM msdb.dbo.restorehistory WHERE backup_set_id = @backup_set_id  SET XACT_ABORT ON  BEGIN TRANSACTION BEGIN TRY DELETE FROM msdb.dbo.backupfile WHERE backup_set_id = @backup_set_id DELETE FROM msdb.dbo.backupfilegroup WHERE backup_set_id = @backup_set_id DELETE FROM msdb.dbo.restorefile WHERE restore_history_id IN (SELECT restore_history_id FROM @restore_history_id) DELETE FROM msdb.dbo.restorefilegroup WHERE restore_history_id IN (SELECT restore_history_id FROM @restore_history_id) DELETE FROM msdb.dbo.restorehistory WHERE restore_history_id IN (SELECT restore_history_id FROM @restore_history_id) DELETE FROM msdb.dbo.backupset WHERE backup_set_id = @backup_set_id COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK DECLARE @ErrMess VARCHAR(1000) SELECT @ErrMess = 'Error: ' + ERROR_MESSAGE() RAISERROR(@ErrMess, 16, 1) END CATCH";
            List<Para> paraList = new List<Para>();
            return ExecSqlNonQuery(command, ConnectionString, paraList);
        }
        private static bool ExecSqlNonQuery(String command, String connectionString, List<Para> paraList)
        {
            SqlConnection connection;
            connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(command, connection);
            sqlCmd.CommandType = CommandType.Text;
            foreach (Para element in paraList)
            {
                if (element.RealValue.GetType().Equals(typeof(string)))
                {
                    sqlCmd.Parameters.Add(element.ValueName, SqlDbType.NVarChar).Value = element.RealValue;
                }
                else
                {
                    sqlCmd.Parameters.Add(new SqlParameter(element.ValueName, element.RealValue));
                }
            }
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
