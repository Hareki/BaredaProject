using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaredaProject.Project
{
    class LongCommands
    {
        public static string GetAddBackupJobCommand(string defaultPath, string jobName)
        {
            string result = @"USE [msdb]

DECLARE @TestId binary(16)
SELECT @TestId = job_id FROM msdb.dbo.sysjobs WHERE (name = N'" + jobName + @"')
IF (@TestId IS NULL)
BEGIN
DECLARE @jobId BINARY(16)
EXEC  msdb.dbo.sp_add_job @job_name=N'BackupLogDaily', 
		@enabled=1, 
		@notify_level_eventlog=0, 
		@notify_level_email=2, 
		@notify_level_page=2, 
		@delete_level=0, 
		@category_name=N'[Uncategorized (Local)]', 
		@owner_login_name=N'sa', @job_id = @jobId OUTPUT
select @jobId

EXEC msdb.dbo.sp_add_jobserver @job_name=N'BackupLogDaily', @server_name = N'MSI\SERVER0'

USE [msdb]

EXEC msdb.dbo.sp_add_jobstep @job_name=N'BackupLogDaily', @step_name=N'Backup_Existing_DBs_Log', 
		@step_id=1, 
		@cmdexec_success_code=0, 
		@on_success_action=1, 
		@on_fail_action=2, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'SELECT distinct(database_name) into #BackupList
FROM      msdb.dbo.backupset set1
WHERE name LIKE ''Device_%''

DECLARE @DBName nvarchar(50);
DECLARE @DefaultPath nvarchar(200) = ''" + defaultPath + @"'';
DECLARE @FileName nvarchar(50);
DECLARE @Final nvarchar(250);
While Exists (SELECT * FROM #BackupList)
BEGIN
	SELECT TOP 1 @DBName = database_name From #BackupList
	SET	@FileName = @DBName + ''_Log_'' + CAST(DATEDIFF_BIG(ms, ''1970-01-01 00:00:00'', GETUTCDATE()) as nvarchar)
	SET @Final = @DefaultPath + @FileName

	BACKUP LOG @DBName TO DISK = @Final WITH INIT
	DELETE #BackupList Where database_name = @DBName
END
DROP TABLE #BackupList', 
		@database_name=N'tempdb', 
		@flags=0

USE [msdb]

EXEC msdb.dbo.sp_update_job @job_name=N'BackupLogDaily', 
		@enabled=1, 
		@start_step_id=1, 
		@notify_level_eventlog=0, 
		@notify_level_email=2, 
		@notify_level_page=2, 
		@delete_level=0, 
		@description=N'', 
		@category_name=N'[Uncategorized (Local)]', 
		@owner_login_name=N'sa', 
		@notify_email_operator_name=N'', 
		@notify_page_operator_name=N''

USE [msdb]

DECLARE @schedule_id int
EXEC msdb.dbo.sp_add_jobschedule @job_name=N'BackupLogDaily', @name=N'EveryWeek', 
		@enabled=1, 
		@freq_type=4, 
		@freq_interval=1, 
		@freq_subday_type=4, 
		@freq_subday_interval=5, 
		@freq_relative_interval=0, 
		@freq_recurrence_factor=1, 
		@active_start_date=20220331, 
		@active_end_date=99991231, 
		@active_start_time=0, 
		@active_end_time=235959, @schedule_id = @schedule_id OUTPUT
select @schedule_id
END
";
            return result;
        }
    }
}
