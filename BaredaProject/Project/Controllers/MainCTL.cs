using BaredaProject.Project;
using BaredaProject.Project.Controller;
using BaredaProject.Project.Dialogs;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private static bool DeleteAllFiles(string dbName)
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
        private static bool DeleteAllLogs(string dbName)
        {
            string folderPath = Main.GetDBLogPath(dbName);
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
        protected static bool BackupLogExists(string dbName, DateTime timeInput)
        {
            string command = $"USE {dbName} SELECT [Begin Time] FROM fn_dblog(null,null) WHERE [Begin Time] < {timeInput}";
            using (SqlDataReader myReader = ExecuteSqlDataReader(command, ConnectionString, new List<Para>()))
            {
                if (myReader is null) return false;
                return myReader.HasRows;
            }
        }
        protected static string GetDBFullTailLogPath(string dbName)
        {
            string currentMilis = Utils.ConvertDateTimeToMilisString(DateTime.Now);
            return $"{Main.GetDBLogPath(dbName)}{dbName}_tailLog_{currentMilis}.trn";
        }
        protected static string GetBackupTailLogCommand(bool needTailLog, string dbName, string tailLogFullPath)
        {
            if (!needTailLog) return string.Empty;
            return $"BACKUP LOG {dbName} TO DISK = '{tailLogFullPath}' WITH INIT ";

        }
        protected static string GetRestoreTailLogCommand(bool needTailLog, string dbName, string tailLogFullPath, DateTime timeInput)
        {
            if (!needTailLog) return string.Empty;
            return $"RESTORE LOG {dbName} FROM DISK = '{tailLogFullPath}' WITH NORECOVERY, STOPAT = '{timeInput.ToString(Utils.SQL_DATE_FORMAT)}'";
        }
        protected static List<String> GetFileNames(string parentPath)
        {
            List<String> result = new List<string>();
            DirectoryInfo d = new DirectoryInfo(parentPath); //Assuming Test is your Folder
            try
            {
                FileInfo[] Files = d.GetFiles("*.*"); //Getting Text files

                foreach (FileInfo file in Files)
                {
                    result.Add(file.Name);
                }
            }
            catch (DirectoryNotFoundException) { }
            return result;

        }
        protected static List<DateTime> GetDatesFromLogs(string dbName)
        {
            List<string> fileNames = GetFileNames(Main.GetDBLogPath(dbName));
            List<DateTime> result = new List<DateTime>();
            foreach (string fileName in fileNames)
            {
                int startIndex = fileName.LastIndexOf("_") + 1;
                int length = fileName.LastIndexOf(".") - startIndex;
                string milis = fileName.Substring(startIndex, length);
                DateTime date = Utils.ConvertMilisStringToDateTime(milis);
                result.Add(date);
            }
            return result;
        }
        protected static Dictionary<int, DateTime> GetDatesFromBDS(BindingSource bds, GridColumn colDate, GridColumn colPos)
        {
            Dictionary<int, DateTime> result = new Dictionary<int, DateTime>();
            for (int i = 0; i < bds.Count; i++)
            {
                DateTime date = ((DateTime)Utils.GetCellValueBds(bds, colDate, i));
                int pos = ((int)Utils.GetCellValueBds(bds, colPos, i));
                result.Add(pos, date);
            }
            return result;
        }
        protected static bool BackupTailog(bool needTailog, string dbName, string dbTailLogFullPath)
        {
            if (!needTailog) return true;
            string command = $"BACKUP LOG {dbName} TO DISK = '{dbTailLogFullPath}' WITH INIT";
            return ExecSqlNonQuery(command, ConnectionString, new List<Para>());
        }
        protected static string RenameTailLog(bool needTailog, string dbName, string dbTailLogFullPath)
        {
            if (!needTailog) return dbTailLogFullPath;
            string command = "DECLARE @first_lsn numeric(25,0) \n"
            + "SELECT @first_lsn = first_lsn FROM msdb.dbo.backupset as set1, msdb.dbo.backupmediafamily as set2 WHERE set2.physical_device_name = '" + dbTailLogFullPath + "' AND set1.media_set_id = set2.media_set_id \n"
            + "IF(EXISTS (SELECT * FROM msdb.dbo.backupset WHERE first_lsn < @first_lsn and database_name = '" + dbName + "')) SELECT 0 ELSE SELECT 1";
            // 0 = không cần reset, 1 = cần reset
            using (SqlDataReader myReader = ExecuteSqlDataReader(command, ConnectionString, new List<Para>()))
            {
                if (myReader == null) return dbTailLogFullPath;

                myReader.Read();
                int result = int.Parse(myReader.GetValue(0).ToString());
                if (result == 0)
                {
                    return dbTailLogFullPath;
                }
                else
                {
                    string newName = dbTailLogFullPath.Replace("_tailLog_", "_tailLog_reset_");
                    File.Move(dbTailLogFullPath, newName);
                    return newName;
                }
            }

        }
        protected static string GetLogFullPathByDate(string DBParentLogPath, string dbName, DateTime date)
        {
            string[] names = { "_log_", "_tailLog_", "_log_reset_", "_tailLog_reset_" };
            string path = string.Empty;
            for (int i = 0; i < names.Length; i++)
            {
                path = $"{DBParentLogPath}{dbName}{names[i]}{Utils.ConvertDateTimeToMilisString(date)}.trn";
                if (File.Exists(path)) break;
            }
            return path;
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
        protected static string GetFullRestoreLocationCommand(string path, int pos, bool noRecovery)
        {
            //Path = [Device Name] or [Full File Path]
            string command = noRecovery ? ", NORECOVERY" : string.Empty;
            if (Main.USE_DEVICE_MODE)
                return $" FROM {path} WITH FILE = {pos}, REPLACE{command}; ";
            else
                return $" FROM DISK = {path} WITH REPLACE{command}; ";
        }
        protected static object[] GetCoreParametes(Dictionary<int, DateTime> fullBackupDates, DateTime timeInput, List<DateTime> logDates)
        {
            bool needTailLog = false;
            KeyValuePair<int, DateTime> kvp = fullBackupDates.Where(element => element.Value <= timeInput).Max(element => element);
            DateTime lowerBound = kvp.Value;
            int pos = kvp.Key;
            //DateTime upperBound = logDates.Where(date => date >= timeInput).Min(date => date);
            List<DateTime> test = logDates.Where(date => date >= timeInput).ToList();
            DateTime upperBound;
            if (test.Count == 0)
            {
                needTailLog = true;
                upperBound = DateTime.Now;
            }
            else
            {
                needTailLog = false;
                upperBound = test.Min(date => date);
            }
            List<DateTime> neededLogDates = logDates.Where(date => date >= lowerBound && date <= upperBound).ToList()
                .OrderBy(date => date).ToList();
            return new object[] { pos, needTailLog, neededLogDates };
        }
        protected static string GetRestoreCommand(string dbName, DateTime timeInput, int pos, bool needTailLog, List<DateTime> neededLogDates, bool noRecovery, string path)
        {

            string dbTailLogFullPath = GetDBFullTailLogPath(dbName);
            BackupTailog(needTailLog, dbName, dbTailLogFullPath);
            dbTailLogFullPath = RenameTailLog(needTailLog, dbName, dbTailLogFullPath);
            string preCommand = $"ALTER DATABASE {dbName} SET SINGLE_USER WITH ROLLBACK IMMEDIATE; "
                             + "USE master "
                             + $" RESTORE DATABASE {dbName} {GetFullRestoreLocationCommand(path, pos, noRecovery)} ";
            StringBuilder buider = new StringBuilder(preCommand);
            string DBParentLogPath = Main.GetDBLogPath(dbName);
            foreach (DateTime date in neededLogDates)
            {
                string disk = GetLogFullPathByDate(DBParentLogPath, dbName, date);
                if (disk.Contains("_reset_")) buider = new StringBuilder(preCommand); // lặp 1
                buider.AppendLine($"RESTORE LOG {dbName} FROM DISK = '{disk}' WITH STOPAT = '{timeInput.ToString(Utils.SQL_DATE_FORMAT)}', NORECOVERY ");
            }
            if (dbTailLogFullPath.Contains("_reset_") && needTailLog == true) buider = new StringBuilder(preCommand); //lặp 2
            buider.AppendLine(GetRestoreTailLogCommand(needTailLog, dbName, dbTailLogFullPath, timeInput));
            buider.AppendLine($"RESTORE DATABASE {dbName} ");
            buider.AppendLine($"ALTER DATABASE {dbName} SET MULTI_USER ");
            string command = buider.ToString();
            return command;
        }


        /*----CALLERS AND COMMON PROCESSES----*/
        public static bool BackupDB(string dbName, string description, bool init, string defaultPath)
        {
            if (init)
            {
                ClearBackupHistory(dbName);
                DeleteAllLogs(dbName);
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
        public static bool RestoreDB(string dbName, int pos, string backupFilePath)
        {
            if (Main.USE_DEVICE_MODE)
                return DeviceCTL.RestoreDB(dbName, pos);
            else
                return FileCTL.RestoreDB(dbName, pos, backupFilePath);
        }
        public static bool RestoreDB_Time(string dbName, BindingSource bds, GridColumn colDate, GridColumn colPos, DateTime timeInput, string defaultPath)
        {
            List<DateTime> logDates = GetDatesFromLogs(dbName);
            Dictionary<int, DateTime> fullBackupDates = GetDatesFromBDS(bds, colDate, colPos);


            if (Main.USE_DEVICE_MODE)
                return DeviceCTL.RestoreDB_Time(dbName, fullBackupDates, logDates, timeInput);
            else
                return FileCTL.RestoreDB_Time(dbName, fullBackupDates, logDates, timeInput, defaultPath);

        }
        public static bool CreateDevice(string dbName, string defaultPath)
        {
            return DeviceCTL.CreateDevice(dbName, defaultPath);
        }
        public static bool DeleteAllDBBackupInstances(string dbName)
        {
            bool test2 = ClearBackupHistory(dbName);
            bool test1 = DropDevice($"Device_{dbName}");
            bool test4 = DeleteAllFiles(dbName);
            bool test3 = DeleteAllLogs(dbName);
            return test1 && test2 && test3 && test4;
        }
        public static bool DeleteBackupLogs_Time(string dbName, DateTime cutOffDate)
        {
            string folderPath = Main.GetDBLogPath(dbName);
            string command = $"EXECUTE master.dbo.xp_delete_file 0, '{folderPath}', 'trn', '{cutOffDate.ToString(Utils.SQL_DATE_FORMAT)}', 1";
            return ExecSqlNonQuery(command, ConnectionString, new List<Para>());
        }


        /*----OTHERS----*/
        public static bool AddBackupLogJob(string defaultPath)
        {
            string command = LongCommands.GetAddBackupJobCommand(defaultPath, "BackupLogDaily");
            return ExecSqlNonQuery(command, ConnectionString, new List<Para>());
        }


        /*----EXECUTE COMMANDS----*/
        protected static bool ExecSqlNonQuery(String command, String connectionString, List<Para> paraList)
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
        protected static SqlDataReader ExecuteSqlDataReader(string command, String connectionString, List<Para> paraList)
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
