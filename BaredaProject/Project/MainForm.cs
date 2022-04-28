using BaredaProject.Project;
using BaredaProject.Project.Dialogs;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public static bool USE_DEVICE_MODE = true;
        public static readonly string CONFIG_PATH = GetGeneralLogPath() + "config";
        public static readonly string LOG_START_TIME = "LogStartTime";
        public static readonly string LOG_END_TIME = "LogEndTime";

        private static void CheckFileExists()
        {
            if (!File.Exists(CONFIG_PATH))
            {
                File.Create(CONFIG_PATH);
            }
        }
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
            string result = GetGeneralLogPath() + dbName + @"\" + $"{dbName}_log.trn";
            return result;
        }


        /*----VIEW----*/
        private void CustomCellPadding()
        {
            RepositoryItemTextEdit edit = new RepositoryItemTextEdit();
            edit.Padding = new Padding(5, 2, 2, 2);
            gvDBList.Columns[1].ColumnEdit =
            gvBackups.Columns[1].ColumnEdit =
            gvBackups.Columns[2].ColumnEdit =
            gvBackups.Columns[3].ColumnEdit = edit;
        }
        private void ReloadDBList()
        {
            this.adapterDBList.Connection.ConnectionString = MainCTL.ConnectionString;
            this.adapterDBList.Fill(this.myDataSet.databases_list);
        }
        private void LoadBackups(string dbName)
        {
            adapterBackupList.Connection.ConnectionString = MainCTL.ConnectionString;
            if (USE_DEVICE_MODE)
                adapterBackupList.Fill(this.myDataSet.database_backups, dbName);
            else
                adapterBackupList.FileFill(this.myDataSet.database_backups, dbName);
        }
        private void SetBackupsViewCaption(string dbName)
        {
            gvBackups.ViewCaption = $"Danh sách bản sao lưu của {dbName}";
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

        }
        private void ReloadGvBackups(string dbName)
        {
            RefreshDeviceAndBackupState(dbName);
            LoadBackups(dbName);
            SetBackupsViewCaption(dbName);
        }


        /*----PRE-PROCESS----*/
        private bool IsValidRowBds(BindingSource bds)
        {
            return bds.Position != -1 && bds.Count != 0 || bds.DataSource != null;
        }
        private int GetSelectedBackupPos()
        {
            string text = Utils.GetCellStringBds(bdsBackupList, colposition, -1);
            return int.Parse(text);
        }
        private string GetSelectedDBName()
        {
            return Utils.GetCellStringBds(bdsDBList, colname, -1);
        }
        private void BackupDB(bool init)
        {
            string dbName = GetSelectedDBName();
            if (init)
                if (!Utils.ShowConfirmMessage("Xác nhận", $"Bạn có chắc muốn xóa toàn bộ các bản sao lưu cũ của {dbName} và ghi bản mới?"))
                    return;



            DescriptionInput input = new DescriptionInput();
            input.ShowDialog();
            if (input.Continue)
            {
                string description = input.Description;
                if (MainCTL.BackupDB(dbName, description, init, GetDBFullBackupPath(dbName)))
                {
                    Utils.ShowInfoMessage("Thông báo", "Tạo bản sao lưu thành công", InformationForm.FormType.Infor);
                }
                ReloadGvBackups(dbName);
            }
        }
        private DateTime GetMaxBackupTime()
        {
            object maxDate = Utils.GetCellValueBds(bdsBackupList, colbackup_start_date, bdsBackupList.Count - 1);
            if (maxDate != null)
                return ((DateTime)maxDate).AddMilliseconds(-1000);
            else return DateTime.MaxValue;

        }
        private bool IsValidTimeInput(DateTime timeInput, string dbName)
        {
            double minutesLeft = DateTime.Now.Subtract(timeInput).TotalMinutes;
            DateTime timeLimit = DateTime.Parse(ReadConfig(dbName, "LogEndTime"));
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
        private void BarBtnDefaultBackup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BackupDB(false);
        }
        private void BarBtnInitBackup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BackupDB(true);

        }
        private void BarBtnDefaultRestore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string dbName = GetSelectedDBName();
            int pos = GetSelectedBackupPos();
            if (Utils.ShowConfirmMessage("Xác nhận", $"Bạn có chắc muốn phục hồi {dbName} về bản sao lưu thứ {pos}?"))
            {
                Cursor.Current = Cursors.WaitCursor;
                if (MainCTL.RestoreDB(dbName, pos))
                {
                    Cursor.Current = Cursors.Default;
                    Utils.ShowInfoMessage("Thông báo", $"Phục hồi {dbName} về bản sao lưu thứ {pos} hoàn tất", InformationForm.FormType.Infor);
                }
            }
        }

        private int GetLatestPos()
        {
            object latestPos = Utils.GetCellValueBds(bdsBackupList, colposition, bdsBackupList.Count - 1);
            if (latestPos != null)
                return (int)latestPos;
            else return -1;
        }

        private void InitConfig(string dbName)
        {
            if (!ConfigHasKey(dbName, LOG_START_TIME))
            {
                DateTime initTime = GetMaxBackupTime();
                WriteConfig(dbName, LOG_START_TIME, initTime.ToString(Utils.SQL_DATE_FORMAT));
                WriteConfig(dbName, LOG_END_TIME, initTime.ToString(Utils.SQL_DATE_FORMAT));
            }
        }

        public static void ClearConfig(string dbName, string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(CONFIG_PATH);
            config.AppSettings.Settings.Remove(GenerateKey(dbName, key));
            config.Save(ConfigurationSaveMode.Minimal);
        }

        private void BarBtnTimeRestore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TimeInput input = new TimeInput();
            input.ShowDialog();
            if (input.Continue)
            {
                string dbName = GetSelectedDBName();
                InitConfig(dbName);
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





                if (Utils.ShowConfirmMessage(title, message))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    int latestPos = GetLatestPos();
                    if (MainCTL.RestoreDB_Time(dbName, timeInput, latestPos, needNewLog))
                    {
                        Cursor.Current = Cursors.Default;
                        Utils.ShowInfoMessage("Thông báo", $"Phục hồi {dbName} về thời điểm {timeInput.ToString(Utils.SQL_DATE_FORMAT)} hoàn tất", InformationForm.FormType.Infor);
                    }
                }
            }

        }
        private static string GenerateKey(string dbName, string key)
        {

            return $"{dbName}_{key}";
        }
        public static void WriteConfig(string dbName, string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(CONFIG_PATH);
            string realKey = GenerateKey(dbName, key);
            config.AppSettings.Settings.Remove(realKey);
            config.AppSettings.Settings.Add(realKey, value);
            config.Save(ConfigurationSaveMode.Minimal);
        }

        public static bool ConfigHasKey(string dbName, string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(CONFIG_PATH);
            string realKey = GenerateKey(dbName, key);
            foreach (string element in config.AppSettings.Settings.AllKeys)
            {
                if (element.Equals(realKey)) return true;
            }
            return false;
        }

        public static string ReadConfig(string dbName, string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(CONFIG_PATH);
            string realKey = GenerateKey(dbName, key);
            string[] keys = config.AppSettings.Settings.AllKeys;
            foreach (string element in keys)
            {
                if (element == realKey)
                    return config.AppSettings.Settings[realKey].Value;
            }
            return null;
        }

        private void BtnCreateDevice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string dbName = GetSelectedDBName();

            if (MainCTL.CreateDevice(dbName, GetDBFullBackupPath(dbName)))
            {
                Utils.ShowInfoMessage("Thông báo", "Tạo device thành công", InformationForm.FormType.Infor);
                ReloadGvBackups(GetSelectedDBName());
            }

        }

        private void Main_Load(object sender, EventArgs e)
        {
            CustomCellPadding();
            ReloadDBList();
            CheckFileExists();
            //  MainCTL.AddBackupLogJob(GetGeneralLogPath());
        }
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BarBtnDeleteSelected_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string dbName = GetSelectedDBName();
            int pos = GetSelectedBackupPos();
            if (Utils.ShowConfirmMessage("Xác nhận", $"Bạn có chắc muốn xóa bản sao lưu thứ {pos} của {dbName}?"))
            {
                if (MainCTL.DeleteBackupInstance(dbName, pos, GetDBFullBackupPath(dbName)))
                {
                    Utils.ShowInfoMessage("Thông báo", "Đã xóa bản sao lưu được chọn", InformationForm.FormType.Infor);
                    ReloadGvBackups(GetSelectedDBName());
                }
            }
        }


        private void BarBtnDeleteAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string dbName = GetSelectedDBName();
            if (Utils.ShowConfirmMessage("Xác nhận", $"Bạn có chắc muốn xóa toàn bộ bản sao lưu của {dbName}?"))
                if (MainCTL.DeleteAllDBBackupInstances(dbName))
                {
                    Utils.ShowInfoMessage("Thông báo", $"Xóa toàn bộ bản sao lưu của {dbName} hoàn tất", InformationForm.FormType.Infor);
                    ReloadDBList();
                }
        }
        private void BtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReloadDBList();
        }
    }
}
