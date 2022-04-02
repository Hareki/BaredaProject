using BaredaProject.Project;
using BaredaProject.Project.Dialogs;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
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

    class ConnectionController
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
            ConnectionController._serverName = serverName;
            ConnectionController._userName = userName;
            ConnectionController._password = password;

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
            List<Para> paraList = new List<Para>
            {
                new Para("@DBName", dbName)
            };
            return ExecSqlNonQuery(command, ConnectionString, paraList);

        }
        private static bool BackupLogExists(string dbName, DateTime timeInput)
        {
            string command = $"USE {dbName} SELECT [Begin Time] FROM fn_dblog(null,null) WHERE [Begin Time] < {timeInput}";
            using (SqlDataReader myReader = ExecuteSqlDataReader(command, ConnectionString, new List<Para>()))
            {
                if (myReader is null) return false;
                return myReader.HasRows;
            }
        }
        private static string GetDBTailLogFullPath(string dbName)
        {
            string currentMilis = Utils.ConvertDateTimeToMilisString(DateTime.Now);
            return $"{Main.GetDBParentLogPath(dbName)}{dbName}_tailLog_{currentMilis}.trn";
        }
        private static string GetBackupTailLogCommand(bool needTailLog, string dbName, string tailLogFullPath)
        {
            if (!needTailLog) return string.Empty;
            return $"BACKUP LOG {dbName} TO DISK = '{tailLogFullPath}' WITH INIT ";

        }
        private static string GetRestoreTailLogCommand(bool needTailLog, string dbName, string tailLogFullPath, DateTime timeInput)
        {
            if (!needTailLog) return string.Empty;
            return $"RESTORE LOG {dbName} FROM DISK = '{tailLogFullPath}' WITH NORECOVERY, STOPAT = '{timeInput.ToString(Utils.SQL_DATE_FORMAT)}'";
        }
        private static List<String> GetFileNames(string parentPath)
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
        private static List<DateTime> GetDatesFromLogs(string dbName)
        {
            List<string> fileNames = GetFileNames(Main.GetDBParentLogPath(dbName));
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
        private static Dictionary<int, DateTime> GetDatesFromBDS(BindingSource bds, GridColumn colDate, GridColumn colPos)
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

        /*----BACKUP DEVICE METHODS----*/
        public static bool CreateDevice(string dbName, string defaultPath)
        {
            string deviceName = $"Device_{dbName}";
            string fullPath = $"{defaultPath}\\{deviceName}.bak";
            string command = "EXEC master.dbo.sp_addumpdevice @devtype = N'disk', @logicalname = @DeviceName, @physicalname = @FullPath";
            List<Para> paraList = new List<Para>
            {
                new Para("@DeviceName", deviceName),
                new Para("@FullPath", fullPath)
            };
            //AddDummyBackupRecord(dbName, defaultPath);// chạy trước tạo device dc, vì ko liên quan tới device.
            return ExecSqlNonQuery(command, ConnectionString, paraList);
        }
        private static bool BackupDevice(string dbName, bool init, string description)
        {
            if (init) ClearBackupHistory(dbName);
            string command = "BACKUP DATABASE @DBName TO @DeviceName WITH DESCRIPTION = @Description, NAME = @DeviceName";
            if (init)
            {
                command += ", INIT";
            }

            List<Para> paraList = new List<Para>
            {
                new Para("@DBName", dbName),
                new Para("@DeviceName", "Device_" + dbName),
                new Para("@Description", description),
            };

            return ExecSqlNonQuery(command, ConnectionString, paraList);
        }
        private static bool DeleteDevice(string defaultPath, string dbName, int pos)
        {
            //Do không thể xóa 1 phần dữ liệu của device.
            return true;
        }
        private static bool DeleteDeviceInfo(string dbName, int pos)
        {
            string command = "DECLARE @database_name NVARCHAR(100),@Pos INT " +
                                "SET @Pos = " + pos + " SET @database_name = '" + dbName + "'  " +
                                "DECLARE @backup_set_id INT DECLARE @media_set_id INT DECLARE @restore_history_id TABLE (restore_history_id INT) SELECT @backup_set_id = MAX(backup_set_id) FROM msdb.dbo.backupset WHERE position = @Pos AND database_name = @database_name AND name = 'Device_' +  @database_name SELECT @media_set_id = media_set_id FROM msdb.dbo.backupset WHERE backup_set_id = @backup_set_id  INSERT INTO @restore_history_id (restore_history_id)  SELECT DISTINCT restore_history_id FROM msdb.dbo.restorehistory WHERE backup_set_id = @backup_set_id  SET XACT_ABORT ON  BEGIN TRANSACTION BEGIN TRY DELETE FROM msdb.dbo.backupfile WHERE backup_set_id = @backup_set_id DELETE FROM msdb.dbo.backupfilegroup WHERE backup_set_id = @backup_set_id DELETE FROM msdb.dbo.restorefile WHERE restore_history_id IN (SELECT restore_history_id FROM @restore_history_id) DELETE FROM msdb.dbo.restorefilegroup WHERE restore_history_id IN (SELECT restore_history_id FROM @restore_history_id) DELETE FROM msdb.dbo.restorehistory WHERE restore_history_id IN (SELECT restore_history_id FROM @restore_history_id) DELETE FROM msdb.dbo.backupset WHERE backup_set_id = @backup_set_id COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK DECLARE @ErrMess VARCHAR(1000) SELECT @ErrMess = 'Error: ' + ERROR_MESSAGE() RAISERROR(@ErrMess, 16, 1) END CATCH";
            List<Para> paraList = new List<Para>();// ghi cho đủ tham số chứ chỗ này ko cần
            return ExecSqlNonQuery(command, ConnectionString, paraList);
        }
        private static bool RestoreDBFromDevice(string dbName, int pos)
        {
            string deviceName = $"Device_{dbName}";

            string command = $"ALTER DATABASE {dbName}"
              + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;"
              + $" USE tempdb; RESTORE DATABASE {dbName}"
              + $" FROM {deviceName} WITH FILE = {pos}, REPLACE; "
              + $" ALTER DATABASE {dbName} SET MULTI_USER";
            return ExecSqlNonQuery(command, ConnectionString, new List<Para>());
        }
        private static bool RestoreDBFromDevice_Time(string dbName, Dictionary<int, DateTime> fullBackupDates, List<DateTime> logDates, DateTime timeInput, string defaultPath)
        {
            string deviceName = $"Device_{dbName}";

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

            string command = GetDeviceRestoreCommand(dbName, timeInput, defaultPath, deviceName, pos, needTailLog, neededLogDates);
            return ExecSqlNonQuery(command, ConnectionString, new List<Para>());


        }


        private static string GetDeviceRestoreCommand(string dbName, DateTime timeInput, string defaultPath, string deviceName, int pos, bool needTailLog, List<DateTime> neededLogDates)
        {

            string dbTailLogFullPath = GetDBTailLogFullPath(dbName);
            BackupTailog(needTailLog, dbName, dbTailLogFullPath);
            dbTailLogFullPath = RenameTailLog(needTailLog, dbName, dbTailLogFullPath);
            string preCommand = $"ALTER DATABASE {dbName} SET SINGLE_USER WITH ROLLBACK IMMEDIATE; "
                             + "USE master "
                             + $" RESTORE DATABASE {dbName} FROM {deviceName} WITH FILE = {pos}, NORECOVERY, REPLACE; ";
            StringBuilder buider = new StringBuilder(preCommand);
            string DBParentLogPath = Main.GetDBParentLogPath(dbName);
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

        private static string RenameTailLog(bool needTailog, string dbName, string dbTailLogFullPath)
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

        private static string GetLogFullPathByDate(string DBParentLogPath, string dbName, DateTime date)
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

        private static bool BackupTailog(bool needTailog, string dbName, string dbTailLogFullPath)
        {
            if (!needTailog) return true;
            string command = $"BACKUP LOG BankManagement TO DISK = '{dbTailLogFullPath}' WITH INIT";
            return ExecSqlNonQuery(command, ConnectionString, new List<Para>());
        }

        /*----BACKUP FILE METHODS----*/
        private static int GetCurrentPosition(string dbName)
        {
            string command = "SELECT Count(*) FROM msdb.dbo.backupset AS backupset WHERE database_name = @DBName AND type = 'D' AND NAME LIKE '%File_' + @DBName + '%' ";
            List<Para> paraList = new List<Para>
            {
                new Para("@DBName", dbName)
            };
            using (SqlDataReader myReader = ExecuteSqlDataReader(command, ConnectionString, paraList))
            {
                if (myReader == null) return -1;

                myReader.Read();
                return int.Parse(myReader.GetValue(0).ToString());
            }
        }
        private static bool BackupFile(string dbName, string defaultPath, string description, bool init)
        {
            int oldPos = GetCurrentPosition(dbName);
            if (init) ClearBackupHistory(dbName);
            int pos;
            if (init)
            {
                pos = 1;
                for (int i = 1; i <= oldPos; i++)
                {
                    try
                    {
                        if (!DeleteFile(defaultPath, dbName, i))
                            throw new Exception();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"File Skipped During Delete: {dbName} - Pos{i}");
                    }

                }

            }
            else pos = oldPos + 1;

            string fileFullPath = $"{defaultPath}\\{dbName} - Pos{pos}.bak";
            string command = "BACKUP DATABASE @DBName TO DISK = @FileFullPath WITH DESCRIPTION = @Des, NAME = @Name";
            List<Para> paraList = new List<Para>
            {
                new Para("@DBName", dbName),
                new Para("@FileFullPath", fileFullPath),
                new Para("@Des", description),
                new Para("@Name", $"File_{dbName}_Pos{pos}")
        };
            return ExecSqlNonQuery(command, ConnectionString, paraList);
        }
        private static bool DeleteFile(string defaultPath, string dbName, int pos)
        {
            //File chứ không phải device, vì device không thể xóa 1 phần dữ liệu (?), chỉ có lưu trữ
            //trên các file riêng mới có thể
            string fileFullPath;
            if (pos <= 0) fileFullPath = $"{defaultPath}\\{dbName} - Pos{pos} - Dummy.bak";
            else fileFullPath = $"{defaultPath}\\{dbName} - Pos{pos}.bak";
            string command = "EXECUTE master.dbo.xp_delete_file 0, @FileFullPath";
            List<Para> paraList = new List<Para>
            {
                new Para("@FileFullPath", fileFullPath)
            };
            return ExecSqlNonQuery(command, ConnectionString, paraList);
        }
        private static bool DeleteFile(string fileFullPath)
        {
            string command = "EXECUTE master.dbo.xp_delete_file 0, @FileFullPath";
            List<Para> paraList = new List<Para>
            {
                new Para("@FileFullPath", fileFullPath)
            };
            return ExecSqlNonQuery(command, ConnectionString, paraList);
        }
        private static bool DeleteFileInfo(string dbName, int pos)
        {
            //Thực chất method này chỉ set dấu hiệu cho biết là đã delete,
            //ko hiện lên UI nữa chứ ko xóa trong history, vì liên quan đến COUNT trong hàm GetCurrentPosition

            //command cũ dùng để xóa record
            // string command = "DECLARE @database_name NVARCHAR(100),@Pos INT " +
            //                      "SET @Pos = " + pos + " SET @database_name = '" + dbName + "'  " +
            //                    "DECLARE @backup_set_id INT DECLARE @media_set_id INT DECLARE @restore_history_id TABLE (restore_history_id INT); WITH Records AS (SELECT top(@pos) row_number() over(order by backup_set_id) as 'row', backup_set_id FROM msdb.dbo.backupset WHERE database_name = @database_name AND name = 'File_' + database_name) SELECT @backup_set_id = backup_set_id FROM Records WHERE row = @pos SELECT @media_set_id = media_set_id FROM msdb.dbo.backupset WHERE backup_set_id = @backup_set_id INSERT INTO @restore_history_id (restore_history_id) SELECT DISTINCT restore_history_id FROM msdb.dbo.restorehistory WHERE backup_set_id = @backup_set_id SET XACT_ABORT ON BEGIN TRANSACTION BEGIN TRY DELETE FROM msdb.dbo.backupfile WHERE backup_set_id = @backup_set_id DELETE FROM msdb.dbo.backupfilegroup WHERE backup_set_id = @backup_set_id DELETE FROM msdb.dbo.restorefile WHERE restore_history_id IN (SELECT restore_history_id FROM @restore_history_id) DELETE FROM msdb.dbo.restorefilegroup WHERE restore_history_id IN (SELECT restore_history_id FROM @restore_history_id) DELETE FROM msdb.dbo.restorehistory WHERE restore_history_id IN (SELECT restore_history_id FROM @restore_history_id) DELETE FROM msdb.dbo.backupset WHERE backup_set_id = @backup_set_id COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK DECLARE @ErrMess VARCHAR(1000) SELECT @ErrMess = 'Error: ' + ERROR_MESSAGE() RAISERROR(@ErrMess, 16, 1) END CATCH";

            string command = "Declare @pos int Declare @database_name nvarchar(50) Declare @backup_set_id int " +
                "Set @pos = " + pos + " Set @database_name = '" + dbName + "'; WITH Records AS (SELECT top(@pos) row_number() over(order by backup_set_id) as 'row', backup_set_id FROM msdb.dbo.backupset WHERE database_name = @database_name AND name LIKE '%File_' + database_name + '%') SELECT @backup_set_id = backup_set_id from Records where row = @pos UPDATE msdb.dbo.backupset SET name = 'Deleted_' + name WHERE backup_set_id = @backup_set_id";

            List<Para> paraList = new List<Para>();
            return ExecSqlNonQuery(command, ConnectionString, paraList);
        }
        private static bool RestoreDBFromFile(string dbName, int pos, string backupFilePath)
        {
            return true;
        }
        private static bool RestoreDBFromFile_Time(string dbName, Dictionary<int, DateTime> fullBackupDates, List<DateTime> logDates, DateTime timeInput, string defaultPath)
        {
            return true;
        }
        /*----BACKUP FILE OTHER METHODS----*/
        private static bool AddDummyBackupRecord(string dbName, string defaultPath)
        {
            //Không dùng được, do pos trên db ko tăng nếu khác file hoặc device, nghĩa là phải cùng media (file hoặc device như nhau)
            //Cũng như việc BackupFile và GetCurrentDBPos đã dc tinh chỉnh nhiều so với ban đầu
            string fileFullPath = $"{defaultPath}\\{dbName} - Pos0 - Dummy.bak";
            return BackupFile(dbName, fileFullPath, "Dummy backup file", false) && DeleteFile(defaultPath, dbName, 0);
        }



        /*----CALLERS----
         Backup = Device or File */
        public static bool BackupDB(string dbName, string description, bool init, string defaultPath)
        {
            if (Main.USE_DEVICE_MODE)
                return BackupDevice(dbName, init, description);
            else
                return BackupFile(dbName, defaultPath, description, init);
        }
        private static bool DeleteBackup(string defaultPath, string dbName, int pos)
        {
            if (Main.USE_DEVICE_MODE)
                return DeleteDevice(defaultPath, dbName, pos);
            else
                return DeleteFile(defaultPath, dbName, pos);
        }
        private static bool DeleteBackupInfo(string dbName, int pos)
        {
            if (Main.USE_DEVICE_MODE)
                return DeleteDeviceInfo(dbName, pos);
            else
                return DeleteFileInfo(dbName, pos);
        }
        public static bool DeleteBackupInstance(string dbName, int pos, string defaultPath)
        {
            return DeleteBackup(defaultPath, dbName, pos) && DeleteBackupInfo(dbName, pos);
        }
        public static bool RestoreDB(string dbName, int pos, string backupFilePath)
        {
            if (Main.USE_DEVICE_MODE)
                return RestoreDBFromDevice(dbName, pos);
            else
                return RestoreDBFromFile(dbName, pos, backupFilePath);
        }
        public static bool RestoreDB_Time(string dbName, BindingSource bds, GridColumn colDate, GridColumn colPos, DateTime timeInput, string defaultPath)
        {
            List<DateTime> logDates = GetDatesFromLogs(dbName);
            Dictionary<int, DateTime> fullBackupDates = GetDatesFromBDS(bds, colDate, colPos);
            if (Main.USE_DEVICE_MODE)
                return RestoreDBFromDevice_Time(dbName, fullBackupDates, logDates, timeInput, defaultPath);
            else
                return RestoreDBFromFile_Time(dbName, fullBackupDates, logDates, timeInput, defaultPath);
        }


        /*----OTHERS----*/
        public static bool AddBackupLogJob(string defaultPath)
        {
            string command = LongCommands.GetAddBackupJobCommand(defaultPath, "BackupLogDaily");
            return ExecSqlNonQuery(command, ConnectionString, new List<Para>());
        }

        /*----EXECUTE COMMANDS----*/
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
                if (!ex.Message.Equals(FILE_DELETED_MESSAGE))
                {
                    Utils.ShowInfoMessage("Lỗi thực thi", ex.Message, InformationForm.FormType.Error);
                    Console.WriteLine("Command:\n " + command);
                }
                return false;
            }
        }
        public static SqlDataReader ExecuteSqlDataReader(string command, String connectionString, List<Para> paraList)
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
