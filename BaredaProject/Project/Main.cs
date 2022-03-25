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

        private string GetDefaultPath()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
            var directory = new DirectoryInfo(documentsPath);
            return directory.Parent.FullName + @"\Deivces";
        }

        private void CustomCellPadding()
        {
            RepositoryItemTextEdit edit = new RepositoryItemTextEdit();
            edit.Padding = new Padding(5, 2, 2, 2);
            gvDBList.Columns[1].ColumnEdit =
            gvBackups.Columns[1].ColumnEdit =
            gvBackups.Columns[2].ColumnEdit =
            gvBackups.Columns[3].ColumnEdit = edit;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            CustomCellPadding();
            ReloadDBList();

        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private bool IsValidRowBds(BindingSource bds)
        {
            return bds.Position != -1 && bds.Count != 0 || bds.DataSource != null;
        }

        private void ReloadDBList()
        {
            this.adapterDBList.Connection.ConnectionString = MyConnection.ConnectionString;
            this.adapterDBList.Fill(this.myDataSet.databases_list);
        }

        private void RefreshDeviceBackupState(string dbName)
        {
            String deviceName = $"Device_{dbName}";
            adapterDeviceList.Connection.ConnectionString = MyConnection.ConnectionString;
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

        private void LoadBackups(string dbName)
        {
            adapterBackupList.Connection.ConnectionString = MyConnection.ConnectionString;
            adapterBackupList.Fill(this.myDataSet.database_backups, dbName);
        }
        private void SetBackupsViewCaption(string dbName)
        {
            gvBackups.ViewCaption = $"Danh sách bản sao lưu của {dbName}";
        }
        private void ReloadGvBackups(string dbName)
        {
            RefreshDeviceBackupState(dbName);
            LoadBackups(dbName);
            SetBackupsViewCaption(dbName);
        }
        private void GvDBList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            String dbName;
            try
            {
                if (!IsValidRowBds(bdsDBList)) return;
                else dbName = Utils.GetCellStringGridView(gvDBList, colname, -1);
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

        private string getSelectedDBName()
        {
            return Utils.GetCellStringGridView(gvDBList, colname, -1);
        }

        private void BackupDB(bool init)
        {
            if (init)
            {
                if (!Utils.ShowConfirmMessage("Xác nhận", "Bạn có chắc muốn xóa toàn bộ các bản sao lưu cũ và ghi bản mới?"))
                {
                    return;
                }
            }

            string dbName = getSelectedDBName();
            DescriptionInput input = new DescriptionInput();
            input.ShowDialog();
            if (input.Continue)
            {
                string description = input.Description;
                if (MyConnection.BackupDB(dbName, description, false))
                {
                    Utils.ShowInfoMessage("Thông báo", "Tạo bản sao lưu thành công", Utils.MessageType.Information);
                }
                ReloadGvBackups(dbName);
            }
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

        }

        private void BarBtnTimeRestore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TimeInput input = new TimeInput();
            input.ShowDialog();
        }

        private void BtnCreateDevice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string deviceName = $"Device_{getSelectedDBName()}";
            string fullPath = $"{GetDefaultPath()}\\{deviceName}.bak";
            Directory.CreateDirectory(GetDefaultPath());
            if (MyConnection.CreateDevice(deviceName, fullPath))
            {
                Utils.ShowInfoMessage("Thông báo", "Tạo device thành công", Utils.MessageType.Information);
                ReloadGvBackups(getSelectedDBName());
            }

        }
    }
}
