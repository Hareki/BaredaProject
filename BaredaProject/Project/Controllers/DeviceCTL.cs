using System;
using System.Collections.Generic;

namespace BaredaProject.Project.Controller
{
    class DeviceCTL : MainCTL
    {
        internal static new bool CreateDevice(string dbName, string defaultPath)
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
        internal static bool BackupDB(string dbName, bool init, string description)
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
        internal static bool DeleteDevice(string defaultPath, string dbName, int pos)
        {
            //Do không thể xóa 1 phần dữ liệu của device.
            return true;
        }
        internal static bool DeleteDeviceInfo(string dbName, int pos)
        {
            string command = "DECLARE @database_name NVARCHAR(100),@Pos INT " +
                                "SET @Pos = " + pos + " SET @database_name = '" + dbName + "'  " +
                                "DECLARE @backup_set_id INT DECLARE @media_set_id INT DECLARE @restore_history_id TABLE (restore_history_id INT) SELECT @backup_set_id = MAX(backup_set_id) FROM msdb.dbo.backupset WHERE position = @Pos AND database_name = @database_name AND name = 'Device_' +  @database_name SELECT @media_set_id = media_set_id FROM msdb.dbo.backupset WHERE backup_set_id = @backup_set_id  INSERT INTO @restore_history_id (restore_history_id)  SELECT DISTINCT restore_history_id FROM msdb.dbo.restorehistory WHERE backup_set_id = @backup_set_id  SET XACT_ABORT ON  BEGIN TRANSACTION BEGIN TRY DELETE FROM msdb.dbo.backupfile WHERE backup_set_id = @backup_set_id DELETE FROM msdb.dbo.backupfilegroup WHERE backup_set_id = @backup_set_id DELETE FROM msdb.dbo.restorefile WHERE restore_history_id IN (SELECT restore_history_id FROM @restore_history_id) DELETE FROM msdb.dbo.restorefilegroup WHERE restore_history_id IN (SELECT restore_history_id FROM @restore_history_id) DELETE FROM msdb.dbo.restorehistory WHERE restore_history_id IN (SELECT restore_history_id FROM @restore_history_id) DELETE FROM msdb.dbo.backupset WHERE backup_set_id = @backup_set_id COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK DECLARE @ErrMess VARCHAR(1000) SELECT @ErrMess = 'Error: ' + ERROR_MESSAGE() RAISERROR(@ErrMess, 16, 1) END CATCH";
            List<Para> paraList = new List<Para>();// ghi cho đủ tham số chứ chỗ này ko cần
            return ExecSqlNonQuery(command, ConnectionString, paraList);
        }
        internal static bool RestoreDB(string dbName, int pos)
        {
            string deviceName = $"Device_{dbName}";

            string command = $"ALTER DATABASE {dbName}"
              + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;"
              + $" USE tempdb; RESTORE DATABASE {dbName}"
              + $" {GetFullRestoreLocationCommand(dbName, pos, false)}"
              + $" ALTER DATABASE {dbName} SET MULTI_USER";
            return ExecSqlNonQuery(command, ConnectionString, new List<Para>());
        }
        internal static bool RestoreDB_Time(string dbName, Dictionary<int, DateTime> fullBackupDates, List<DateTime> logDates, DateTime timeInput)
        {
            string deviceName = $"Device_{dbName}";
            object[] coreParameters = MainCTL.GetCoreParametes(fullBackupDates, timeInput, logDates);
            int pos = (int)coreParameters[0];
            bool needTailLog = (bool)coreParameters[1];
            List<DateTime> neededLogDates = (List<DateTime>)coreParameters[2];
            string command = GetRestoreCommand(dbName, timeInput, pos, needTailLog, neededLogDates, true, deviceName);
            return ExecSqlNonQuery(command, ConnectionString, new List<Para>());
        }

    }
}
