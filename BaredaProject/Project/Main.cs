using BaredaProject.Project;
using BaredaProject.Project.Dialogs;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        /*----GET PATHS----*/
        public static string GetDefaultPath()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
            var directory = new DirectoryInfo(documentsPath);
            string result;
            if (USE_DEVICE_MODE)
                result = directory.Parent.FullName + @"\Backup\Device";
            else
                result = directory.Parent.FullName + @"\Backup\File";

            Directory.CreateDirectory(result);
            return result;

        }
        public static string GetDefaultLogPath()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
            var directory = new DirectoryInfo(documentsPath);
            string result = directory.Parent.FullName + @"\Backup\Log\";
            Directory.CreateDirectory(result);
            return result;
        }
        public static string GetSpecifiedDefaultLogPath(string dbName)
        {
            string result = GetDefaultLogPath() + dbName + @"\";
            Directory.CreateDirectory(result);
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
            this.adapterDBList.Connection.ConnectionString = ConnectionController.ConnectionString;
            this.adapterDBList.Fill(this.myDataSet.databases_list);
        }
        private void LoadBackups(string dbName)
        {
            adapterBackupList.Connection.ConnectionString = ConnectionController.ConnectionString;
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
                adapterDeviceList.Connection.ConnectionString = ConnectionController.ConnectionString;
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
            if (init)
                if (!Utils.ShowConfirmMessage("Xác nhận", "Bạn có chắc muốn xóa toàn bộ các bản sao lưu cũ và ghi bản mới?"))
                    return;


            string dbName = GetSelectedDBName();
            DescriptionInput input = new DescriptionInput();
            input.ShowDialog();
            if (input.Continue)
            {
                string description = input.Description;
                if (ConnectionController.BackupDB(dbName, description, init, GetDefaultPath()))
                {
                    Utils.ShowInfoMessage("Thông báo", "Tạo bản sao lưu thành công", InformationForm.FormType.Infor);
                }
                ReloadGvBackups(dbName);
            }
        }
        private DateTime GetMinBackupTime()
        {
            return (DateTime)Utils.GetCellValueBds(bdsBackupList, colbackup_start_date, 0);
        }
        private int GetLatestDBPos(string dbName)
        {
            return int.Parse(Utils.GetCellStringBds(bdsBackupList, colposition, gvBackups.RowCount - 1));
        }
        private bool IsValidTimeInput(DateTime timeInput)
        {
            DateTime minBackupTime = GetMinBackupTime();
            Double minutesLeft = DateTime.Now.Subtract(timeInput).TotalMinutes;
            if (minutesLeft < 1)
            {
                Utils.ShowInfoMessage("Lỗi phục hồi", "Thời điểm phục hồi phải nhỏ hơn hiện tại ít nhất 1 phút", InformationForm.FormType.Error);
                return false;
            }

            if (timeInput < minBackupTime)
            {
                Utils.ShowInfoMessage("Lỗi phục hồi", "Thời điểm phục hồi nằm trong khoảng có các bản sao lưu", InformationForm.FormType.Error);
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
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "", MessageBoxButtons.OK);
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
            if (Utils.ShowConfirmMessage("Xác nhận", $"Xác nhận phục hồi {dbName} về bản sao lưu thứ {pos}?"))
            {
                if (ConnectionController.RestoreDB(dbName, pos, null))
                {
                    Utils.ShowInfoMessage("Thông báo", "Phục hồi hoàn tất", InformationForm.FormType.Infor);
                }

            }
        }
        private void BarBtnTimeRestore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TimeInput input = new TimeInput();
            input.ShowDialog();
            if (input.Continue)
            {
                DateTime timeInput = input.GetTimeInput();
                while ((!IsValidTimeInput(timeInput)) && input.Continue)
                {
                    input.ShowDialog();
                    timeInput = input.GetTimeInput();
                }

                string dbName = GetSelectedDBName();
                int pos = GetSelectedBackupPos();
                if (Utils.ShowConfirmMessage("Xác nhận", $"Xác nhận phục hồi {dbName} về thời điểm {timeInput}?"))
                {
                    if (ConnectionController.RestoreDB_Time(dbName, bdsBackupList, colbackup_start_date, colposition, timeInput, GetDefaultPath()))
                        Utils.ShowInfoMessage("Thông báo", "Phục hồi hoàn tất", InformationForm.FormType.Infor);
                }
            }

        }
        private void BtnCreateDevice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string dbName = GetSelectedDBName();

            if (ConnectionController.CreateDevice(dbName, GetDefaultPath()))
            {
                Utils.ShowInfoMessage("Thông báo", "Tạo device thành công", InformationForm.FormType.Infor);
                ReloadGvBackups(GetSelectedDBName());
            }

        }
        private void BtnDelBackup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Utils.ShowConfirmMessage("Xác nhận", "Xóa bản sao lưu đã chọn?"))
            {
                string dbName = GetSelectedDBName();
                int pos = GetSelectedBackupPos();
                if (ConnectionController.DeleteBackupInstance(dbName, pos, GetDefaultPath()))
                {
                    Utils.ShowInfoMessage("Thông báo", "Đã xóa bản sao lưu được chọn", InformationForm.FormType.Infor);
                    ReloadGvBackups(GetSelectedDBName());
                }
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {
            CustomCellPadding();
            ReloadDBList();
            ConnectionController.AddBackupLogJob(GetDefaultLogPath());
        }
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
