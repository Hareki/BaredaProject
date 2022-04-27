using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace BaredaProject.Project.Controller
{
    class FileCTL : MainCTL
    {
        private static int GetCurrentPosition(string dbName)
        {
            string command = "SELECT Count(*) FROM msdb.dbo.backupset AS backupset WHERE database_name = @DBName AND type = 'D' AND NAME LIKE '%File_' + @DBName + '%' ";
            List<Para> paraList = new List<Para>
            {
                new Para("@DBName", dbName)
            };
            using (SqlDataReader myReader = ExecuteSqlDataReader(command, MainCTL.ConnectionString, paraList))
            {
                if (myReader == null) return -1;

                myReader.Read();
                return int.Parse(myReader.GetValue(0).ToString());
            }
        }
        internal static bool BackupDB(string dbName, string defaultPath, string description, bool init)
        {
            int oldPos = GetCurrentPosition(dbName);
            if (init) MainCTL.ClearBackupHistory(dbName);
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
                        Console.WriteLine($"File Skipped During Delete: {dbName}_Pos{i}");
                    }

                }

            }
            else pos = oldPos + 1;

            string fileFullPath = $"{defaultPath}\\{dbName}_Pos{pos}.bak";
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
        internal static bool DeleteFile(string defaultPath, string dbName, int pos)
        {
            //File chứ không phải device, vì device không thể xóa 1 phần dữ liệu (?), chỉ có lưu trữ
            //trên các file riêng mới có thể
            string fileFullPath;
            if (pos <= 0) fileFullPath = $"{defaultPath}\\{dbName}_Pos{pos} - Dummy.bak";
            else fileFullPath = $"{defaultPath}\\{dbName}_Pos{pos}.bak";
            string command = "EXECUTE master.dbo.xp_delete_file 0, @FileFullPath";
            List<Para> paraList = new List<Para>
            {
                new Para("@FileFullPath", fileFullPath)
            };
            return ExecSqlNonQuery(command, ConnectionString, paraList);
        }
        internal static bool DeleteFileInfo(string dbName, int pos)
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
        internal static new bool RestoreDB(string dbName, int pos, string backupFilePath)
        {
            string fullFilePath = GetFullFilePath(dbName, pos);

            string command = $"ALTER DATABASE {dbName}"
              + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE; "
              + $" USE tempdb; RESTORE DATABASE {dbName} "
              + $" {GetFullRestoreCommand(dbName,fullFilePath, pos, false)}"
              + $" ALTER DATABASE {dbName} SET MULTI_USER";
            return ExecSqlNonQuery(command, ConnectionString, new List<Para>());
        }
        internal static bool RestoreDB_Time(string dbName, string logFilePath, DateTime timeInput)
        {
            return false;
        }
        internal static string GetFullFilePath(string dbName, int pos)
        {
            string result = $"{Main.GetDBFullBackupPath(dbName)}\\{dbName}_Pos{pos}.bak";
            return result;
        }
        internal static bool AddDummyBackupRecord(string dbName, string defaultPath)
        {
            //Không dùng được, do pos trên db ko tăng nếu khác file hoặc device, nghĩa là phải cùng media (file hoặc device như nhau)
            //Cũng như việc BackupFile và GetCurrentDBPos đã dc tinh chỉnh nhiều so với ban đầu
            string fileFullPath = $"{defaultPath}\\{dbName} - Pos0 - Dummy.bak";
            return BackupDB(dbName, fileFullPath, "Dummy backup file", false) && DeleteFile(defaultPath, dbName, 0);
        }
    }
}
