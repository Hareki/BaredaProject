﻿using BaredaProject.Project;
using BaredaProject.Project.Dialogs;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
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

        private static readonly string MOST_RECENT_PATH = GetGeneralLogPath() + "data.propterties";
        private static void CheckFileExists()
        {
            if (!File.Exists(MOST_RECENT_PATH))
            {
                using (File.Create(MOST_RECENT_PATH)) ;
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
            string result = GetGeneralLogPath() + dbName + @"\";
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
        private DateTime GetMinBackupTime()
        {
            return ((DateTime)Utils.GetCellValueBds(bdsBackupList, colbackup_start_date, 0)).AddMilliseconds(-1000);
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
                if (MainCTL.RestoreDB(dbName, pos, null))
                {
                    Cursor.Current = Cursors.Default;
                    Utils.ShowInfoMessage("Thông báo", $"Phục hồi {dbName} về bản sao lưu thứ {pos} hoàn tất", InformationForm.FormType.Infor);
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
                while (input.Continue &&(!IsValidTimeInput(timeInput)))
                {
                    input.ShowDialog();
                    timeInput = input.GetTimeInput();
                }
                if (input.Continue == false) return;

                string dbName = GetSelectedDBName();
                string message = $"Bạn có chắc muốn phục hồi {dbName} về thời điểm {timeInput}?";
                string temp = File.ReadAllText(MOST_RECENT_PATH);
                if (!string.IsNullOrEmpty(temp))
                {
                    DateTime mostRecentBackup = DateTime.Parse(temp);
                    if (timeInput < mostRecentBackup)
                    {
                        message = $"Bạn vừa nhập vào thời điểm muốn phục hồi nhỏ hơn lần phục hồi gần nhất trước đó là" +
                             $" {mostRecentBackup.ToString(Utils.SQL_DATE_FORMAT)}. Mọi thao tác trên CSDL kể từ thời điểm vừa nêu đến thời điểm hiện tại " +
                             $"sẽ bị XÓA VĨNH VIỄN, KHÔNG THỂ PHỤC HỒI.\n\nBạn có chắc muốn phục hồi {dbName} về thời điểm {timeInput}?";
                    }
                }

                if (Utils.ShowConfirmMessage("Xác nhận", message))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (MainCTL.RestoreDB_Time(dbName, bdsBackupList, colbackup_start_date, colposition, timeInput, GetDBFullBackupPath(dbName)))
                    {
                        Cursor.Current = Cursors.Default;
                        Utils.ShowInfoMessage("Thông báo", $"Phục hồi {dbName} về thời điểm {timeInput.ToString(Utils.SQL_DATE_FORMAT)} hoàn tất", InformationForm.FormType.Infor);
                        File.WriteAllText(MOST_RECENT_PATH, timeInput.ToString(Utils.SQL_DATE_FORMAT));
                    }
                }
            }

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
            MainCTL.AddBackupLogJob(GetGeneralLogPath());
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
                if (!MainCTL.DeleteBackupLogs_Time(dbName, GetMinBackupTime()))
                {
                    Utils.ShowInfoMessage("Thông báo", "Xảy ra lỗi khi cố gắng xóa các file nhật ký vô chủ", InformationForm.FormType.Infor);
                    Debug.Assert(false);
                }
            }
        }

        private DateTime GetMinBackupTime2(string dbName) // tương đương GetMinBackupTime, nhưng hướng xử lý khác, chậm nhưng chắc
        {
            List<DateTime> dates = new List<DateTime>();
            int count = bdsBackupList.Count;
            for (int i = 0; i < count; i++)
            {
                DateTime date = ((DateTime)Utils.GetCellValueBds(bdsBackupList, colbackup_start_date, i));
                dates.Add(date);
            }
            DateTime minDate = dates.Min(date => date);
            return minDate;
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