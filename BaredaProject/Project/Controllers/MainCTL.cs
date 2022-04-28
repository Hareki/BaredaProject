using BaredaProject.Project;
using BaredaProject.Project.Controller;
using BaredaProject.Project.Dialogs;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

    class MainCTL
    {
        private static string _serverName;
        private static string _userName;
        private static string _password;
        public static string ConnectionString;
        public static SqlConnection ServerConnection = new SqlConnection();
        private static readonly string FILE_DELETED_MESSAGE = "xp_delete_file() returned error 2, 'The system cannot find the file specified.'";



        /*----COMMONS----*/
        public static bool ConnectToServer(string serverName, string userName, string password)
        {
            MainCTL._serverName = serverName;
            MainCTL._userName = userName;
            MainCTL._password = password;

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
        protected static bool ClearBackupHistory(string dbName)
        {
            //DateTime now = DateTime.Now;
            //now.ToString("yyyy-MM-dd HH:mm:ss")
            string command = "EXEC msdb.dbo.sp_delete_database_backuphistory @DBName";
            List<Para> paraList = new List<Para>
            {
                new Para("@DBName", dbName)
            };
            return ExecSqlNonQuery(command, ConnectionString, paraList);

        }
        private static bool DeleteLogFile(string dbName)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
            var directory = new DirectoryInfo(documentsPath);
            string folderPath = directory.Parent.FullName + $"\\Backup\\File\\{dbName}";
            string command = "EXECUTE master.dbo.xp_delete_file 0, @FolderPath";
            List<Para> paraList = new List<Para>
            {
                new Para("@FolderPath", folderPath)
            };
            return ExecSqlNonQuery(command, ConnectionString, paraList);
        }

        public static bool DropDevice(string deviceName)
        {
            string command = $"EXEC sp_dropdevice '{deviceName}', 'delfile'";
            return ExecSqlNonQuery(command, ConnectionString, new List<Para>());
        }

        protected static bool DeleteSpecifiedFile(string fileFullPath)
        {
            string command = $"EXECUTE master.dbo.xp_delete_file 0, @FileFullPath";
            List<Para> paraList = new List<Para>
            {
                new Para("@FileFullPath", fileFullPath)
            };
            return ExecSqlNonQuery(command, ConnectionString, paraList);
        }
        protected static string GetFullRestoreCommand(string dbName, string deviceNameOrFilePath, int pos, bool noRecovery)
        {
            //Path = [Device Name] or [Full File Path]
            string command = noRecovery ? ", NORECOVERY" : ", RECOVERY";
            if (Main.USE_DEVICE_MODE)
                return $" RESTORE DATABASE {dbName} FROM {deviceNameOrFilePath} WITH FILE = {pos}, REPLACE{command}; ";
            else
                return $" RESTORE DATABASE {dbName} FROM DISK = {deviceNameOrFilePath} WITH REPLACE{command}; ";
        }

        protected static void ClearConfig(string dbName)
        {
            Main.ClearConfig(dbName, Main.LOG_START_TIME);
            Main.ClearConfig(dbName, Main.LOG_END_TIME);
        }
        /*----CALLERS AND COMMON PROCESSES----*/
        public static bool BackupDB(string dbName, string description, bool init, string defaultPath)
        {
            if (init)
            {
                ClearBackupHistory(dbName);
                ClearConfig(dbName);
            }
            if (Main.USE_DEVICE_MODE)
                return DeviceCTL.BackupDB(dbName, init, description);
            else
                return FileCTL.BackupDB(dbName, defaultPath, description, init);
        }
        private static bool DeleteBackup(string defaultPath, string dbName, int pos)
        {
            if (Main.USE_DEVICE_MODE)
                return DeviceCTL.DeleteDevice(defaultPath, dbName, pos);
            else
                return FileCTL.DeleteFile(defaultPath, dbName, pos);
        }
        private static bool DeleteBackupInfo(string dbName, int pos)
        {
            if (Main.USE_DEVICE_MODE)
                return DeviceCTL.DeleteDeviceInfo(dbName, pos);
            else
                return FileCTL.DeleteFileInfo(dbName, pos);
        }
        public static bool DeleteBackupInstance(string dbName, int pos, string defaultPath)
        {
            return DeleteBackup(defaultPath, dbName, pos) && DeleteBackupInfo(dbName, pos);
        }
        public static bool RestoreDB(string dbName, int pos)
        {
            if (Main.USE_DEVICE_MODE)
                return DeviceCTL.RestoreDB(dbName, pos);
            else
                return FileCTL.RestoreDB(dbName, pos);
        }
        public static bool RestoreDB_Time(string dbName, DateTime timeInput, int latestPos, bool needNewLog)
        {
            if (Main.USE_DEVICE_MODE)
                return DeviceCTL.RestoreDB_Time(dbName, timeInput, latestPos, needNewLog);
            else
                return FileCTL.RestoreDB_Time(dbName, timeInput, latestPos, needNewLog);
        }
        public static bool CreateDevice(string dbName, string defaultPath)
        {
            return DeviceCTL.CreateDevice(dbName, defaultPath);
        }
        public static bool DeleteAllDBBackupInstances(string dbName)
        {
            //  Main.ClearKV(dbName);
            bool test1 = ClearBackupHistory(dbName);
            bool test2 = DropDevice($"Device_{dbName}");
            ClearConfig(dbName);
            DeleteLogFile(dbName);
            return test1 && test2;//ko test số 3 vì có thể bị fail, do ko có directory file (không có log file)
        }

        /*----EXECUTE COMMANDS----*/
        protected static bool ExecSqlNonQuery(string command, string connectionString, List<Para> paraList)
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
                if (!ex.Message.Equals(FILE_DELETED_MESSAGE))
                {
                    Utils.ShowInfoMessage("Lỗi thực thi", ex.Message, InformationForm.FormType.Error);
                    Console.WriteLine("Command:\n " + command);
                }
                return false;
            }
        }

        protected static SqlDataReader ExecuteSqlDataReader(string command, string connectionString, List<Para> paraList)
        {
            SqlDataReader result;
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

            if (connection.State == ConnectionState.Closed)
                connection.Open();
            try
            {
                result = sqlCmd.ExecuteReader();
                return result;
            }
            catch (SqlException ex)
            {
                connection.Close();
                Utils.ShowInfoMessage("Lỗi thực thi", ex.Message, InformationForm.FormType.Error);
                connection.Close();
                Console.WriteLine("Command:\n " + command);
                return null;
            }
        }
    }
}
