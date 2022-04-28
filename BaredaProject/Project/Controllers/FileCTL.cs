using BaredaProject.Project.Others;
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
        internal static new bool BackupDB(string dbName, string description, bool init)
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
                        if (!DeleteFile(dbName, i))
                            throw new Exception();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"File Skipped During Delete: {dbName}_Pos{i}");
                    }

                }

            }
            else pos = oldPos + 1;

            string fileFullPath = GetFullFilePath(dbName, pos);
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
        internal static bool DeleteFile(string dbName, int pos)
        {
            string fullFilePath = GetFullFilePath(dbName, pos);
            string command = "EXECUTE master.dbo.xp_delete_file 0, @FileFullPath";
            List<Para> paraList = new List<Para>
            {
                new Para("@FileFullPath", fullFilePath)
            };
            return ExecSqlNonQuery(command, ConnectionString, paraList);
        }
        internal static bool DeleteFileInfo(string dbName, int pos)
        {
            string command = "Declare @pos int Declare @database_name nvarchar(50) Declare @backup_set_id int " +
                "Set @pos = " + pos + " Set @database_name = '" + dbName + "'; WITH Records AS (SELECT top(@pos) row_number() over(order by backup_set_id) as 'row', backup_set_id FROM msdb.dbo.backupset WHERE database_name = @database_name AND name LIKE '%File_' + database_name + '%') SELECT @backup_set_id = backup_set_id from Records where row = @pos UPDATE msdb.dbo.backupset SET name = 'Deleted_' + name WHERE backup_set_id = @backup_set_id";

            List<Para> paraList = new List<Para>();
            return ExecSqlNonQuery(command, ConnectionString, paraList);
        }
        internal static new bool RestoreDB(string dbName, int pos)
        {
            string fullFilePath = GetFullFilePath(dbName, pos);

            string command = $"ALTER DATABASE {dbName}"
              + "SET SINGLE_USER WITH ROLLBACK IMMEDIATE;\n"
              + $"USE tempdb; RESTORE DATABASE {dbName}\n"
              + $"{GetFullRestoreCommand(dbName, fullFilePath, pos, false)}\n"
              + $"ALTER DATABASE {dbName} SET MULTI_USER";
            return ExecSqlNonQuery(command, ConnectionString, new List<Para>());
        }
        internal static new bool RestoreDB_Time(string dbName, DateTime timeInput, int latestPos, bool needNewLog)
        {
            string fullFilePath = GetFullFilePath(dbName, latestPos);
            string backupLogCommand;
            if (needNewLog)
            {
                backupLogCommand = $"BACKUP LOG {dbName} TO DISK = '{Main.GetDBLogPath(dbName)}' WITH INIT, NORECOVERY\n";
                TimeConfig.WriteConfig(dbName, TimeConfig.LOG_START_TIME, TimeConfig.ReadConfig(dbName, TimeConfig.LOG_END_TIME));
                TimeConfig.WriteConfig(dbName, TimeConfig.LOG_END_TIME, DateTime.Now.ToString(Utils.SQL_DATE_FORMAT));
            }
            else
            {
                backupLogCommand = string.Empty;
            }
            string restoreLogCommand = $"RESTORE LOG {dbName} FROM DISK  = '{Main.GetDBLogPath(dbName)}' WITH  STOPAT = '{timeInput.ToString(Utils.SQL_DATE_FORMAT)}', NORECOVERY\n";
            string command = $"ALTER DATABASE {dbName}\n"
                + "SET SINGLE_USER WITH ROLLBACK IMMEDIATE;\n"
                + $"USE tempdb;\n"
                + backupLogCommand
                + $"{GetFullRestoreCommand(dbName, fullFilePath, latestPos, true)}\n"
                + restoreLogCommand
                + $"RESTORE DATABASE {dbName} WITH RECOVERY;\n"
                + $"ALTER DATABASE {dbName} SET MULTI_USER";
            return ExecSqlNonQuery(command, ConnectionString, new List<Para>());
        }
        internal static string GetFullFilePath(string dbName, int pos)
        {
            return $"{Main.GetDBFullBackupPath(dbName)}\\{dbName}_Pos{pos}.bak";
        }
    }
}
