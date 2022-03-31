using BaredaProject.Project;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BaredaProject.Project.Dialogs.InformationForm;

namespace BaredaProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            AutoFill();
        }
        private void AutoFill()
        {
            textPassword.Text = "123456";
            textUser.Text = "sa";
            textServerName.Text = @"MSI\SERVER0";
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            RequestLogin();
        }


        private void TextEnter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                RequestLogin();
            }
        }

        private bool IsInputValid()
        {
            bool test1 = IsLoginInfoValid(textPassword, passwordEP);
            bool test2 = IsLoginInfoValid(textUser, userEP);
            bool test3 = IsServerNameValid();

            if (!(test1 && test2 && test3))
            {
                Utils.ShowInfoMessage("Lỗi đăng nhập", "Vui lòng điền đầy đủ thông tin", Project.Dialogs.InformationForm.FormType.Error);
                return false;
            }
            return true;
        }
        private void RequestLogin()
        {
            if (!IsInputValid()) return;

            String serverName = textServerName.Text.Trim();
            String userName = textUser.Text.Trim();
            String password = textPassword.Text.Trim();

            if (!MyConnection.ConnectToServer(serverName, userName, password))
            {
                Utils.ShowInfoMessage("Lỗi đăng nhập", "Tài khoản, mật khẩu hoặc tên server không chính xácaaaaaaaaaaaaaaaaaaarrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrraaaaaa", FormType.Error);
                return;
            }

            ShowMainForm(userName);
        }

        private void ShowMainForm(String userName)
        {
            Program.MainInstance = new Main();
            Program.MainInstance.stripUserName.Text = "Tài khoản: " + userName;
            string mode = Main.USE_DEVICE_MODE ? "Device" : "File";
            Program.MainInstance.stripBackupMode.Text = "Backup mode: " + mode;
            this.Hide();
            Program.MainInstance.Show();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TextPassword_IconRightClick(object sender, EventArgs e)
        {
            if (textPassword.UseSystemPasswordChar == true)
            {
                textPassword.IconRight = global::BaredaProject.Properties.Resources.eye_512px;
                textPassword.UseSystemPasswordChar = false;
            }
            else
            {
                textPassword.IconRight = global::BaredaProject.Properties.Resources.invisible_512px;
                textPassword.UseSystemPasswordChar = true;
            }
        }

        private bool IsLoginInfoValid(Guna2TextBox textBox, ErrorProvider loginEP)
        {
            if (string.IsNullOrEmpty(textBox.Text.Trim()))
            {
                loginEP.SetError(textBox, "Vui lòng không bỏ trống thông tin đăng nhập");
                SetBorderState(textBox, true);
                return false;
            }
            else
            {
                loginEP.SetError(textBox, null);
                SetBorderState(textBox, false);
                return true;
            }

        }

        private bool IsServerNameValid()
        {
            if (string.IsNullOrEmpty(textServerName.Text.Trim()))
            {
                serverNameEP.SetError(textServerName, "Vui lòng không bỏ trống tên server");
                textServerName.BorderColor = Color.FromArgb(236, 65, 52);
                return false;
            }
            else
            {
                serverNameEP.SetError(textServerName, null);
                textServerName.BorderColor = Color.FromArgb(204, 208, 213);
                return true;
            }
        }

        private void SetBorderState(Guna2TextBox textBox, bool error)
        {
            if (error)
            {
                textBox.BorderColor = textBox.HoverState.BorderColor =
                   textBox.FocusedState.BorderColor = Color.FromArgb(236, 65, 52);


            }
            else
            {
                textBox.FocusedState.BorderColor = Color.FromArgb(16, 110, 190);
                textBox.HoverState.BorderColor = Color.FromArgb(104, 168, 255);
                textBox.BorderColor = Color.Silver;
            }
        }
    }
}
