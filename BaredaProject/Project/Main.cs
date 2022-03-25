using BaredaProject.Project;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void barBtnSR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TimeInput input = new TimeInput();
            input.ShowDialog();
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

        private void RefreshDeviceState(string dbName)
        {
            String deviceName = $"Device_{dbName}";
            adapterDeviceList.Connection.ConnectionString = MyConnection.ConnectionString;
            adapterDeviceList.FillBy(this.myDataSet.backup_devices, deviceName);

            if (bdsDeviceList.Count > 0)
            {
                btnCreateDevice.Enabled = false;
            }
            else
            {
                btnCreateDevice.Enabled = true;
            }
        }

        private void LoadBackups(string dbName)
        {
            adapterBackupList.Connection.ConnectionString = MyConnection.ConnectionString;
            adapterBackupList.Fill(this.myDataSet.database_backups, dbName);
            //if(!btnCreateDevice.Enabled || bdsBackupList.Count <= 0)
            //{
            //    btnBackup.Enabled = btnRestore.Enabled = false;
            //}
        }
        private void SetBackupsViewCaption(string dbName)
        {
            gvBackups.ViewCaption = $"Danh sách bản sao lưu của {dbName}";
        }
        private void gvDBList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            String dbName;
            try
            {
                if (!IsValidRowBds(bdsDBList)) return;
                else dbName = Utils.GetCellStringGridView(gvDBList, colname, -1);
                RefreshDeviceState(dbName);
                LoadBackups(dbName);
                SetBackupsViewCaption(dbName);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "", MessageBoxButtons.OK);
            }
        }
    }
}
