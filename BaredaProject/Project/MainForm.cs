using BaredaProject.Project;
using BaredaProject.Project.Dialogs;
using BaredaProject.Project.Others;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BaredaProject
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        public static bool USE_DEVICE_MODE = false;

        /*----GET PATHS----*/
        public static string GetDBFullBackupPath(string dbName)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
            var directory = new DirectoryInfo(documentsPath);
            string result;
            if (USE_DEVICE_MODE)
                result = directory.Parent.FullName + $"\\Backup\\Device\\{dbName}";
            else
                result = directory.Parent.FullName + $"\\Backup\\File\\{dbName}";

            Directory.CreateDirectory(result);
            return result;

        }
        public static string GetGeneralLogPath()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
            var directory = new DirectoryInfo(documentsPath);
            string result;
            if (USE_DEVICE_MODE)
                result = directory.Parent.FullName + @"\Backup\Log\Device\";
            else result = directory.Parent.FullName + @"\Backup\Log\File\";
            Directory.CreateDirectory(result);
            return result;
        }
        public static string GetDBLogPath(string dbName)
        {
            string parent = GetGeneralLogPath() + dbName + @"\";
            Directory.CreateDirectory(parent);

            string result = parent + $"{dbName}_log.trn";
            return result;
        }

        /*----VIEW----*/
        private void CustomCellPadding()
        {
            RepositoryItemTextEdit edit = new RepositoryItemTextEdit();
            edit.Padding = new Padding(5, 2, 2, 2);
            gvDBList.Columns[1].ColumnEdit =
            //gvDBList.Columns[2].ColumnEdit =
            gvBackups.Columns[1].ColumnEdit =
            gvBackups.Columns[2].ColumnEdit =
            gvBackups.Columns[3].ColumnEdit = edit;
        }
        private void SetBackupsViewCaption(string dbName)
        {
            gvBackups.ViewCaption = $"Danh sách bản sao lưu của {dbName}";
        }
        private void FillTimeLimitCells()
        {
            for (int i = 0; i < bdsDBList.Count; i++)
            {
                string dbName = Utils.GetCellStringBds(bdsDBList, colname, i);
                if (TimeConfig.ConfigHasKey(dbName, TimeConfig.LOG_START_TIME))
                {
                    string cofigText = TimeConfig.ReadConfig(dbName, TimeConfig.LOG_START_TIME);
                    string dateText = string.Empty;
                    bool success = DateTime.TryParse(cofigText, out DateTime date);
                    if (success) dateText = date.ToString(Utils.VN_DATE_FORMAT);
                    (bdsDBList[i] as DataRowView)["time_limit"] = string.IsNullOrEmpty(dateText) ? cofigText : dateText;
                }
            }
            gvDBList.RefreshData();
        }
        private void ConfigTimeLimitColumn()
        {
            myDataSet.databases_list.Columns[2].ReadOnly = false;
            myDataSet.databases_list.Columns[2].MaxLength = 30;
        }
        private void ReloadDBList(int index = -1)
        {
            this.adapterDBList.Connection.ConnectionString = MainCTL.ConnectionString;
            this.adapterDBList.Fill(this.myDataSet.databases_list);
            FillTimeLimitCells();
            if (index >= 0)
            {
                bdsDBList.Position = index;
                gvDBList.FocusedRowHandle = index;
            }

        }
        private void LoadBackups(string dbName)
        {
            adapterBackupList.Connection.ConnectionString = MainCTL.ConnectionString;
            if (USE_DEVICE_MODE)
                adapterBackupList.Fill(this.myDataSet.database_backups, dbName);
            else
                adapterBackupList.FileFill(this.myDataSet.database_backups, dbName);
        }
        private void RefreshDeviceAndBackupState(string dbName)
        {
            if (USE_DEVICE_MODE)
            {
                String deviceName = $"Device_{dbName}";
                adapterDeviceList.Connection.ConnectionString = MainCTL.ConnectionString;
                adapterDeviceList.FillBy(this.myDataSet.backup_devices, deviceName);

                if (bdsDeviceList.Count > 0)
                {
                    btnCreateDevice.Enabled = false;
                    btnBackup.Enabled = true;
                }
                else
                {
                    btnCreateDevice.Enabled = true;
                    btnBackup.Enabled = false;
                }
            }
            else
            {
                btnBackup.Enabled = true;
                btnCreateDevice.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            barBtnTimeRestore.Enabled = TimeConfig.IsConfigRestoreEnable(dbName);

        }
        private void ReloadGvBackups(string dbName)
        {
            RefreshDeviceAndBackupState(dbName);
            LoadBackups(dbName);
            SetBackupsViewCaption(dbName);
        }
        public void InitConfig(string dbName)
        {
            if (!TimeConfig.ConfigHasKey(dbName, TimeConfig.LOG_START_TIME))
            {
                TimeConfig.WriteConfig(dbName, TimeConfig.LOG_START_TIME, "Lần full backup mới nhất (2)");
                TimeConfig.WriteConfig(dbName, TimeConfig.LOG_END_TIME, "Lần full backup mới nhất (2)");
            }
        }


        /*----VALIDATE----*/
        private bool IsValidTimeInput(DateTime timeInput, string dbName)
        {
            double minutesLeft = DateTime.Now.Subtract(timeInput).TotalMinutes;
            bool result = DateTime.TryParse(TimeConfig.ReadConfig(dbName, TimeConfig.LOG_START_TIME), out DateTime logStart);
            DateTime timeLimit = result ? logStart : GetMaxBackupTime();
            if (minutesLeft < 1)
            {
                Utils.ShowInfoMessage("Lỗi phục hồi", "Thời điểm nhập vào phải nhỏ hơn hiện tại ít nhất 1 phút", InformationForm.FormType.Error);
                return false;
            }

            if (timeInput < timeLimit)
            {
                Utils.ShowInfoMessage("Lỗi phục hồi", "Thời điểm nhập vào phải lớn hơn giới hạn phục hồi", InformationForm.FormType.Error);
                return false;
            }
            return true;
        }
        private bool IsValidRowBds(BindingSource bds)
        {
            return bds.Position != -1 && bds.Count != 0 || bds.DataSource != null;
        }

        /*----GETTERS----*/
        private int GetSelectedBackupPos()
        {
            string text = Utils.GetCellStringBds(bdsBackupList, colposition, -1);
            return int.Parse(text);
        }
        private string GetSelectedDBName()
        {
            return Utils.GetCellStringBds(bdsDBList, colname, -1);
        }
        public DateTime GetMaxBackupTime()
        {
            object maxDate = Utils.GetCellValueBds(bdsBackupList, colbackup_start_date, bdsBackupList.Count - 1);
            if (maxDate != null)
                return ((DateTime)maxDate).AddMilliseconds(-1000);
            else return DateTime.MaxValue;
        }
        private int GetMaxPosition()
        {
            object position = Utils.GetCellValueBds(bdsBackupList, colposition, bdsBackupList.Count - 1);
            if (position != null)
                return ((int)position);
            else return Int32.MaxValue;
        }
        private int GetLatestPos()
        {
            object latestPos = Utils.GetCellValueBds(bdsBackupList, colposition, bdsBackupList.Count - 1);
            if (latestPos != null)
                return (int)latestPos;
            else return -1;
        }

        /*----BACKUP----*/
        private void BackupDB(bool init)
        {
            string dbName = GetSelectedDBName();
            if (init)
            {
                if (!Utils.ShowConfirmMessage("Xác nhận", $"Bạn có chắc muốn xóa toàn bộ các bản sao lưu cũ của {dbName} và ghi bản mới?"))
                    return;
                
            }
            TimeConfig.EnableConfig(dbName);
            MainCTL.ClearLog(dbName);
            DescriptionInput input = new DescriptionInput();
            input.ShowDialog();
            if (input.Continue)
            {
                string description = input.Description;
                if (MainCTL.BackupDB(dbName, description, init))
                {
                    Utils.ShowInfoMessage("Thông báo", "Tạo bản sao lưu thành công", InformationForm.FormType.Infor);
                }
                TimeConfig.ClearConfig(dbName);
                ReloadDBList(bdsDBList.Position);
                ReloadGvBackups(dbName);
            }
        }
        /*----EVENTS----*/
        private void GvDBList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            String dbName;
            try
            {
                if (!IsValidRowBds(bdsDBList)) return;
                else dbName = Utils.GetCellStringBds(bdsDBList, colname, -1);
                ReloadGvBackups(dbName);
            }
            catch (Exception)
            {
                //     MessageBox.Show("Error: " + ex.Message, "", MessageBoxButtons.OK);
            }
        }
        private void GvBackups_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Console.WriteLine("focused: " + gvBackups.FocusedRowHandle);
            btnDelBackup.Enabled = btnRestore.Enabled = !(gvBackups.FocusedRowHandle < 0);
        }

        /*-----*/

        //Default Backup
        private void BarBtnDefaultBackup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BackupDB(false);
        }
        //Init Backup
        private void BarBtnInitBackup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BackupDB(true);

        }
        //Default Restore
        private void BarBtnDefaultRestore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int pos = GetSelectedBackupPos();
            string dbName = GetSelectedDBName();
            string message = $"Bạn có chắc muốn phục hồi {dbName} về bản sao lưu thứ {pos}?";
            string title = "Xác nhận";
            bool warning = false;
            if (pos != GetMaxPosition())
            {
                warning = true;
                title = "Cảnh báo";
                message = $"Bạn đang sao lưu về một bản cũ hơn, điều này sẽ dẫn đến việc chức năng " +
                    $"phục hồi theo thời gian không thể hoạt động cho đến khi có một bản sao lưu mới.\n\nTiến hành sao lưu?";
            }
            if (Utils.ShowConfirmMessage(title, message, warning))
            {
                if (warning)
                {
                    TimeConfig.DisableConfig(dbName);
                    MainCTL.ClearLog(dbName);
                }

                Cursor.Current = Cursors.WaitCursor;
                if (MainCTL.RestoreDB(dbName, pos))
                {
                    Cursor.Current = Cursors.Default;
                    Utils.ShowInfoMessage("Thông báo", $"Phục hồi {dbName} về bản sao lưu thứ {pos} hoàn tất", InformationForm.FormType.Infor);
                }
            }
        }
        //Time Restore
        private void BarBtnTimeRestore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TimeInput input = new TimeInput();
            input.ShowDialog();
            if (input.Continue)
            {
                string dbName = GetSelectedDBName();
                DateTime timeInput = input.GetTimeInput();
                while (input.Continue && (!IsValidTimeInput(timeInput, dbName)))
                {
                    input.ShowDialog();
                    timeInput = input.GetTimeInput();
                }
                if (input.Continue == false) return;


                string message = $"Bạn có chắc muốn phục hồi {dbName} về thời điểm {timeInput}?";
                string title = "Xác nhận";
                bool needNewLog = false;
                bool warning = false;

                bool success = DateTime.TryParse(TimeConfig.ReadConfig(dbName, TimeConfig.LOG_END_TIME), out DateTime timeLimit);
                if (success)
                {
                    if (timeInput > timeLimit)
                    {
                        message = $"Hành động này sẽ xóa file log cũ, khiến khoảng thời gian {timeLimit.ToString(Utils.SQL_DATE_FORMAT)} trở về trước không còn có thể phục hồi.\nBạn có muốn tiếp tục?";
                        title = "Cảnh báo";
                        warning = needNewLog = true;
                    }
                }
                else
                    needNewLog = true;

                if (Utils.ShowConfirmMessage(title, message, warning))
                {
                    InitConfig(dbName);
                    Cursor.Current = Cursors.WaitCursor;
                    int latestPos = GetLatestPos();
                    if (MainCTL.RestoreDB_Time(dbName, timeInput, latestPos, needNewLog))
                    {
                        Cursor.Current = Cursors.Default;
                        Utils.ShowInfoMessage("Thông báo", $"Phục hồi {dbName} về thời điểm {timeInput.ToString(Utils.SQL_DATE_FORMAT)} hoàn tất", InformationForm.FormType.Infor);
                        ReloadDBList(bdsDBList.Position);
                    }
                }
            }

        }
        //Delete a backup
        private void BarBtnDeleteSelected_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string dbName = GetSelectedDBName();
            int pos = GetSelectedBackupPos();
            string message = $"Bạn có chắc muốn xóa bản sao lưu thứ {pos} của {dbName}?";
            string title = "Xác nhận";
            bool warning = false;

            if (pos == GetMaxPosition())
            {
                warning = true;
                title = "Cảnh báo";
                message = $"Bạn đang tiến hành xóa bản sao lưu mới nhất, điều này sẽ dẫn đến việc chức năng " +
                    $"phục hồi theo thời gian không thể hoạt động cho đến khi có một bản sao lưu mới.\n\nTiến hành xóa?";
            }
            if (Utils.ShowConfirmMessage(title, message, warning))
            {
                if (warning)
                {
                    TimeConfig.DisableConfig(dbName);
                    MainCTL.ClearLog(dbName);
                }
                if (MainCTL.DeleteBackupInstance(dbName, pos, GetDBFullBackupPath(dbName)))
                {
                    Utils.ShowInfoMessage("Thông báo", "Đã xóa bản sao lưu được chọn", InformationForm.FormType.Infor);
                    ReloadDBList(bdsDBList.Position);
                    ReloadGvBackups(GetSelectedDBName());
                }
            }
        }
        //Delete all backups
        private void BarBtnDeleteAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string dbName = GetSelectedDBName();
            if (Utils.ShowConfirmMessage("Xác nhận", $"Bạn có chắc muốn xóa toàn bộ bản sao lưu của {dbName}?"))
                if (MainCTL.DeleteAllDBBackupInstances(dbName))
                {
                    Utils.ShowInfoMessage("Thông báo", $"Xóa toàn bộ bản sao lưu của {dbName} hoàn tất", InformationForm.FormType.Infor);
                    ReloadDBList(bdsBackupList.Position);
                }
        }
        //Refresh
        private void BtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReloadDBList();
        }
        private void BtnCreateDevice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string dbName = GetSelectedDBName();

            if (MainCTL.CreateDevice(dbName, GetDBFullBackupPath(dbName)))
            {
                Utils.ShowInfoMessage("Thông báo", "Tạo device thành công", InformationForm.FormType.Infor);
                ReloadDBList(bdsDBList.Position);
                ReloadGvBackups(GetSelectedDBName());
            }

        }

        /*-----*/
        private void Main_Load(object sender, EventArgs e)
        {
            CustomCellPadding();
            TimeConfig.CheckConfigExists();
            ConfigTimeLimitColumn();
            ReloadDBList();
            //  MainCTL.AddBackupLogJob(GetGeneralLogPath());
        }
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
