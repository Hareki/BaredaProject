
namespace BaredaProject
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textServerName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textUser = new Guna.UI2.WinForms.Guna2TextBox();
            this.textPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.userEP = new System.Windows.Forms.ErrorProvider(this.components);
            this.passwordEP = new System.Windows.Forms.ErrorProvider(this.components);
            this.serverNameEP = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userEP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordEP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverNameEP)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.textServerName);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.textUser);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textPassword);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(58, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 547);
            this.panel1.TabIndex = 20;
            // 
            // textServerName
            // 
            this.textServerName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textServerName.BorderThickness = 2;
            this.textServerName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textServerName.DefaultText = "";
            this.textServerName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textServerName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textServerName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textServerName.DisabledState.Parent = this.textServerName;
            this.textServerName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textServerName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textServerName.FocusedState.Parent = this.textServerName;
            this.textServerName.Font = new System.Drawing.Font("Baloo 2", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textServerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(70)))), ((int)(((byte)(68)))));
            this.textServerName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.textServerName.HoverState.Parent = this.textServerName;
            this.textServerName.IconLeftOffset = new System.Drawing.Point(0, -5);
            this.textServerName.IconLeftSize = new System.Drawing.Size(35, 35);
            this.textServerName.IconRightOffset = new System.Drawing.Point(0, -3);
            this.textServerName.IconRightSize = new System.Drawing.Size(35, 35);
            this.textServerName.Location = new System.Drawing.Point(49, 198);
            this.textServerName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.textServerName.Name = "textServerName";
            this.textServerName.PasswordChar = '\0';
            this.textServerName.PlaceholderText = "";
            this.textServerName.SelectedText = "";
            this.textServerName.ShadowDecoration.Parent = this.textServerName;
            this.textServerName.Size = new System.Drawing.Size(391, 49);
            this.textServerName.TabIndex = 43;
            this.textServerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextEnter_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("Baloo 2", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.label3.Location = new System.Drawing.Point(161, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 91);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sao lưu - Phục hồi cơ sở dữ liệu";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Baloo 2", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(44, 159);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 10, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tên server";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.Font = new System.Drawing.Font("Baloo 2 Medium", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(70)))), ((int)(((byte)(68)))));
            this.btnClose.Image = global::BaredaProject.Properties.Resources.cancel_30px;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(49, 454);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(182, 55);
            this.btnClose.TabIndex = 45;
            this.btnClose.Text = "Thoát";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnLogin.Font = new System.Drawing.Font("Baloo 2 Medium", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(70)))), ((int)(((byte)(68)))));
            this.btnLogin.Image = global::BaredaProject.Properties.Resources.enter_30px;
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogin.Location = new System.Drawing.Point(258, 454);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(182, 55);
            this.btnLogin.TabIndex = 44;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::BaredaProject.Properties.Resources.database_administrator_480px;
            this.pictureBox1.Location = new System.Drawing.Point(81, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(74, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // textUser
            // 
            this.textUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textUser.BorderThickness = 2;
            this.textUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textUser.DefaultText = "";
            this.textUser.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textUser.DisabledState.Parent = this.textUser;
            this.textUser.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textUser.FocusedState.Parent = this.textUser;
            this.textUser.Font = new System.Drawing.Font("Baloo 2", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(70)))), ((int)(((byte)(68)))));
            this.textUser.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.textUser.HoverState.Parent = this.textUser;
            this.textUser.IconLeft = global::BaredaProject.Properties.Resources.user_480px1;
            this.textUser.IconLeftOffset = new System.Drawing.Point(0, -5);
            this.textUser.IconLeftSize = new System.Drawing.Size(35, 35);
            this.textUser.IconRightOffset = new System.Drawing.Point(0, -3);
            this.textUser.IconRightSize = new System.Drawing.Size(35, 35);
            this.textUser.Location = new System.Drawing.Point(49, 277);
            this.textUser.Margin = new System.Windows.Forms.Padding(0, 30, 0, 10);
            this.textUser.Name = "textUser";
            this.textUser.PasswordChar = '\0';
            this.textUser.PlaceholderText = "Tài khoản";
            this.textUser.SelectedText = "";
            this.textUser.ShadowDecoration.Parent = this.textUser;
            this.textUser.Size = new System.Drawing.Size(391, 57);
            this.textUser.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.textUser.TabIndex = 13;
            this.textUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextEnter_KeyDown);
            // 
            // textPassword
            // 
            this.textPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textPassword.BorderThickness = 2;
            this.textPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textPassword.DefaultText = "";
            this.textPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textPassword.DisabledState.Parent = this.textPassword;
            this.textPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textPassword.FocusedState.Parent = this.textPassword;
            this.textPassword.Font = new System.Drawing.Font("Baloo 2", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(70)))), ((int)(((byte)(68)))));
            this.textPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.textPassword.HoverState.Parent = this.textPassword;
            this.textPassword.IconLeft = global::BaredaProject.Properties.Resources.lock_500px;
            this.textPassword.IconLeftOffset = new System.Drawing.Point(0, -5);
            this.textPassword.IconLeftSize = new System.Drawing.Size(35, 35);
            this.textPassword.IconRight = global::BaredaProject.Properties.Resources.invisible_512px;
            this.textPassword.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.textPassword.IconRightOffset = new System.Drawing.Point(0, -3);
            this.textPassword.IconRightSize = new System.Drawing.Size(35, 35);
            this.textPassword.Location = new System.Drawing.Point(49, 354);
            this.textPassword.Margin = new System.Windows.Forms.Padding(4, 10, 4, 40);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '\0';
            this.textPassword.PlaceholderText = "Mật khẩu";
            this.textPassword.SelectedText = "";
            this.textPassword.ShadowDecoration.Parent = this.textPassword;
            this.textPassword.Size = new System.Drawing.Size(391, 57);
            this.textPassword.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.textPassword.TabIndex = 13;
            this.textPassword.UseSystemPasswordChar = true;
            this.textPassword.IconRightClick += new System.EventHandler(this.TextPassword_IconRightClick);
            this.textPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextEnter_KeyDown);
            // 
            // userEP
            // 
            this.userEP.ContainerControl = this;
            this.userEP.Icon = ((System.Drawing.Icon)(resources.GetObject("userEP.Icon")));
            // 
            // passwordEP
            // 
            this.passwordEP.ContainerControl = this;
            this.passwordEP.Icon = ((System.Drawing.Icon)(resources.GetObject("passwordEP.Icon")));
            // 
            // serverNameEP
            // 
            this.serverNameEP.ContainerControl = this;
            this.serverNameEP.Icon = ((System.Drawing.Icon)(resources.GetObject("serverNameEP.Icon")));
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 638);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.Text = "Bareda Project";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userEP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordEP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverNameEP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnLogin;
        private Guna.UI2.WinForms.Guna2TextBox textServerName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2TextBox textUser;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox textPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider userEP;
        private System.Windows.Forms.ErrorProvider passwordEP;
        private System.Windows.Forms.ErrorProvider serverNameEP;
    }
}