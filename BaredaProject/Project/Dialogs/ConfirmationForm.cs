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
    public partial class ConfirmationForm : Form
    {
        public bool Continue = false;
        public ConfirmationForm()
        {
            InitializeComponent();
        }
        public ConfirmationForm(string title, string message)
        {
            InitializeComponent();
            this.message.Text = message;
            this.title.Text = title;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Continue = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Continue = false;
            this.Close();
        }
    }
}
