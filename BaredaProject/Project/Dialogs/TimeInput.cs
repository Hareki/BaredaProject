using System;
using System.Windows.Forms;

namespace BaredaProject
{
    public partial class TimeInput : Form
    {
        public bool Continue = false;

        public TimeInput()
        {
            InitializeComponent();
            dateEdit1.EditValue = DateTime.Now;
        }
        public DateTime GetTimeInput()
        {
            return dateEdit1.DateTime;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Continue = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Continue = false;
            this.Close();
        }
    }
}
