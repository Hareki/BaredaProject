using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaredaProject.Project.Dialogs
{
    public partial class DescriptionInput : Form
    {
        public string Description;
        public bool Continue = false;
        public DescriptionInput()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Continue = false;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.Description = txtDes.Text;
            this.Continue = true;
            this.Close();
        }
    }
}
