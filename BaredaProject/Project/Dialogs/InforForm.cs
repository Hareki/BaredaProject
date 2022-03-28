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
    public partial class InformationForm : Form
    {
        public enum FormType
        {
            Error, Infor, Warning
        }
        public InformationForm()
        {
            InitializeComponent();
        }
        public InformationForm(string title, string message, FormType type)
        {
            InitializeComponent();
            switch (type)
            {
                case FormType.Error:
                    pictureBox.Image = BaredaProject.Properties.Resources.cancel_red_480px;
                    break;
                case FormType.Warning:
                    pictureBox.Image = BaredaProject.Properties.Resources.warning_shield_480px;
                    break;
                case FormType.Infor:
                    pictureBox.Image = BaredaProject.Properties.Resources.info_480px;
                    break;
            }
            this.Text = title;
            this.message.Text = message;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
