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

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDataSet.backup_devices' table. You can move, or remove it, as needed.
            this.backup_devicesTableAdapter.Fill(this.myDataSet.backup_devices);
            // TODO: This line of code loads data into the 'myDataSet.databases_list' table. You can move, or remove it, as needed.
            this.databases_listTableAdapter.Fill(this.myDataSet.databases_list);

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.database_backupsTableAdapter.Fill(this.myDataSet.database_backups, dBNAMEToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
