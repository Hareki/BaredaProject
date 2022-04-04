using System;
using System.Windows.Forms;

namespace BaredaProject.Project.Dialogs
{
    public partial class ConfirmationForm : Form
    {
        public bool Continue = false;
        private bool _wide;
        public ConfirmationForm()
        {
            InitializeComponent();
        }
        public ConfirmationForm(string title, string message, bool wide)
        {
            InitializeComponent();
            this.message.Text = message;
            Text = title;
            _wide = wide;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Continue = true;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Continue = false;
            Close();
        }

        private void ConfirmationForm_Load(object sender, EventArgs e)
        {
            //if (_wide)
            //{
            //    Size = new Size(880, 283);
            //    message.MaximumSize = new Size(panel3.Width - 10, panel3.Height - 10);
            //}
        }
    }
}
