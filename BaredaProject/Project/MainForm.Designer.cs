
namespace BaredaProject
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnCreateDevice = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelBackup = new DevExpress.XtraBars.BarButtonItem();
            this.deleteMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barBtnDeleteSelected = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnDeleteAll = new DevExpress.XtraBars.BarButtonItem();
            this.btnRestore = new DevExpress.XtraBars.BarButtonItem();
            this.restoreMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barBtnDefaultRestore = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnTimeRestore = new DevExpress.XtraBars.BarButtonItem();
            this.btnBackup = new DevExpress.XtraBars.BarButtonItem();
            this.backupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barBtnDefaultBackup = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnInitBackup = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.textTime = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem2 = new DevExpress.XtraBars.BarCheckItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.myDataSet = new BaredaProject.MyDataSet();
            this.bdsDBList = new System.Windows.Forms.BindingSource(this.components);
            this.adapterDBList = new BaredaProject.MyDataSetTableAdapters.databases_listTableAdapter();
            this.tableAdapterManager = new BaredaProject.MyDataSetTableAdapters.TableAdapterManager();
            this.bdsBackupList = new System.Windows.Forms.BindingSource(this.components);
            this.adapterBackupList = new BaredaProject.MyDataSetTableAdapters.database_backupsTableAdapter();
            this.bdsDeviceList = new System.Windows.Forms.BindingSource(this.components);
            this.adapterDeviceList = new BaredaProject.MyDataSetTableAdapters.backup_devicesTableAdapter();
            this.gcDBList = new DevExpress.XtraGrid.GridControl();
            this.gvDBList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltime_limit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldatabase_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBackups = new DevExpress.XtraGrid.GridControl();
            this.gvBackups = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colposition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbackup_start_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coluser_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stripUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.stripBackupMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restoreMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDBList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsBackupList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDeviceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDBList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDBList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBackups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBackups)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barEditItem1,
            this.barEditItem2,
            this.textTime,
            this.btnBackup,
            this.btnRestore,
            this.barButtonItem8,
            this.barCheckItem1,
            this.btnDelBackup,
            this.barCheckItem2,
            this.barBtnTimeRestore,
            this.barBtnDefaultRestore,
            this.barBtnDefaultBackup,
            this.barBtnInitBackup,
            this.btnRefresh,
            this.btnCreateDevice,
            this.barBtnDeleteSelected,
            this.barBtnDeleteAll});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 26;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemDateEdit1});
            // 
            // bar2
            // 
            this.bar2.BarAppearance.Normal.BorderColor = System.Drawing.Color.Black;
            this.bar2.BarAppearance.Normal.Options.UseBorderColor = true;
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCreateDevice, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelBackup, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRestore, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnBackup, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRefresh, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnCreateDevice
            // 
            this.btnCreateDevice.Caption = " Tạo device";
            this.btnCreateDevice.Enabled = false;
            this.btnCreateDevice.Id = 22;
            this.btnCreateDevice.ImageOptions.Image = global::BaredaProject.Properties.Resources.data_warehouse;
            this.btnCreateDevice.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2 Medium", 14F, System.Drawing.FontStyle.Bold);
            this.btnCreateDevice.ItemAppearance.Normal.Options.UseFont = true;
            this.btnCreateDevice.Name = "btnCreateDevice";
            this.btnCreateDevice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnCreateDevice_ItemClick);
            // 
            // btnDelBackup
            // 
            this.btnDelBackup.ActAsDropDown = true;
            this.btnDelBackup.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnDelBackup.Caption = "  Xóa bản sao lưu ";
            this.btnDelBackup.DropDownControl = this.deleteMenu;
            this.btnDelBackup.Enabled = false;
            this.btnDelBackup.Hint = "Xóa bản sao lưu đã chọn trên danh sách";
            this.btnDelBackup.Id = 14;
            this.btnDelBackup.ImageOptions.Image = global::BaredaProject.Properties.Resources.remove_from_cart;
            this.btnDelBackup.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2 Medium", 14F, System.Drawing.FontStyle.Bold);
            this.btnDelBackup.ItemAppearance.Normal.Options.UseFont = true;
            this.btnDelBackup.Name = "btnDelBackup";
            // 
            // deleteMenu
            // 
            this.deleteMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnDeleteSelected),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnDeleteAll)});
            this.deleteMenu.Manager = this.barManager1;
            this.deleteMenu.Name = "deleteMenu";
            // 
            // barBtnDeleteSelected
            // 
            this.barBtnDeleteSelected.Caption = "Xóa bản sao lưu đã chọn";
            this.barBtnDeleteSelected.Id = 23;
            this.barBtnDeleteSelected.ImageOptions.Image = global::BaredaProject.Properties.Resources.minus_20px;
            this.barBtnDeleteSelected.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2", 12F);
            this.barBtnDeleteSelected.ItemAppearance.Normal.Options.UseFont = true;
            this.barBtnDeleteSelected.Name = "barBtnDeleteSelected";
            this.barBtnDeleteSelected.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarBtnDeleteSelected_ItemClick);
            // 
            // barBtnDeleteAll
            // 
            this.barBtnDeleteAll.Caption = "Xóa toàn bộ các bản sao lưu của CSDL này";
            this.barBtnDeleteAll.Id = 24;
            this.barBtnDeleteAll.ImageOptions.Image = global::BaredaProject.Properties.Resources.delete_database_20px;
            this.barBtnDeleteAll.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2", 12F);
            this.barBtnDeleteAll.ItemAppearance.Normal.Options.UseFont = true;
            this.barBtnDeleteAll.Name = "barBtnDeleteAll";
            this.barBtnDeleteAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarBtnDeleteAll_ItemClick);
            // 
            // btnRestore
            // 
            this.btnRestore.ActAsDropDown = true;
            this.btnRestore.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnRestore.Caption = " Phục hồi ";
            this.btnRestore.DropDownControl = this.restoreMenu;
            this.btnRestore.Enabled = false;
            this.btnRestore.Hint = "Phục hồi CSDL về một thời điểm tùy chọn";
            this.btnRestore.Id = 7;
            this.btnRestore.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRestore.ImageOptions.Image")));
            this.btnRestore.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2 Medium", 14F, System.Drawing.FontStyle.Bold);
            this.btnRestore.ItemAppearance.Normal.Options.UseFont = true;
            this.btnRestore.Name = "btnRestore";
            // 
            // restoreMenu
            // 
            this.restoreMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnDefaultRestore),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnTimeRestore)});
            this.restoreMenu.Manager = this.barManager1;
            this.restoreMenu.Name = "restoreMenu";
            // 
            // barBtnDefaultRestore
            // 
            this.barBtnDefaultRestore.Caption = "Phục hồi theo bản sao lưu đã chọn";
            this.barBtnDefaultRestore.Id = 17;
            this.barBtnDefaultRestore.ImageOptions.Image = global::BaredaProject.Properties.Resources.restart_20px;
            this.barBtnDefaultRestore.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barBtnDefaultRestore.ItemAppearance.Normal.Options.UseFont = true;
            this.barBtnDefaultRestore.Name = "barBtnDefaultRestore";
            this.barBtnDefaultRestore.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarBtnDefaultRestore_ItemClick);
            // 
            // barBtnTimeRestore
            // 
            this.barBtnTimeRestore.Caption = "Phục hồi về một thời điểm cụ thể";
            this.barBtnTimeRestore.Id = 16;
            this.barBtnTimeRestore.ImageOptions.Image = global::BaredaProject.Properties.Resources.clock_20px;
            this.barBtnTimeRestore.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2", 12F);
            this.barBtnTimeRestore.ItemAppearance.Normal.Options.UseFont = true;
            this.barBtnTimeRestore.Name = "barBtnTimeRestore";
            this.barBtnTimeRestore.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarBtnTimeRestore_ItemClick);
            // 
            // btnBackup
            // 
            this.btnBackup.ActAsDropDown = true;
            this.btnBackup.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnBackup.Caption = " Sao lưu  ";
            this.btnBackup.DropDownControl = this.backupMenu;
            this.btnBackup.Enabled = false;
            this.btnBackup.Hint = "Sao lưu CSDL ở thời điểm hiện tại";
            this.btnBackup.Id = 6;
            this.btnBackup.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBackup.ImageOptions.Image")));
            this.btnBackup.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2 Medium", 14F, System.Drawing.FontStyle.Bold);
            this.btnBackup.ItemAppearance.Normal.Options.UseFont = true;
            this.btnBackup.Name = "btnBackup";
            // 
            // backupMenu
            // 
            this.backupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnDefaultBackup),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnInitBackup)});
            this.backupMenu.Manager = this.barManager1;
            this.backupMenu.Name = "backupMenu";
            // 
            // barBtnDefaultBackup
            // 
            this.barBtnDefaultBackup.Caption = "Sao lưu thông thường";
            this.barBtnDefaultBackup.Id = 18;
            this.barBtnDefaultBackup.ImageOptions.Image = global::BaredaProject.Properties.Resources.save_as_20px;
            this.barBtnDefaultBackup.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2", 12F);
            this.barBtnDefaultBackup.ItemAppearance.Normal.Options.UseFont = true;
            this.barBtnDefaultBackup.Name = "barBtnDefaultBackup";
            this.barBtnDefaultBackup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarBtnDefaultBackup_ItemClick);
            // 
            // barBtnInitBackup
            // 
            this.barBtnInitBackup.Caption = "Xóa tất cả bản sao lưu cũ rồi tiến hành sao lưu";
            this.barBtnInitBackup.Id = 19;
            this.barBtnInitBackup.ImageOptions.Image = global::BaredaProject.Properties.Resources.delete_database_20px;
            this.barBtnInitBackup.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2", 12F);
            this.barBtnInitBackup.ItemAppearance.Normal.Options.UseFont = true;
            this.barBtnInitBackup.Name = "barBtnInitBackup";
            this.barBtnInitBackup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarBtnInitBackup_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "  Làm mới ";
            this.btnRefresh.Id = 20;
            this.btnRefresh.ImageOptions.Image = global::BaredaProject.Properties.Resources.refresh_1_;
            this.btnRefresh.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2 Medium", 14F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ItemAppearance.Normal.Options.UseFont = true;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnRefresh_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Appearance.BorderColor = System.Drawing.Color.Red;
            this.barDockControlTop.Appearance.Options.UseBorderColor = true;
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1554, 63);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 641);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1554, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 63);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 578);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1554, 63);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 578);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Sao lưu";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2 Medium", 14F, System.Drawing.FontStyle.Bold);
            this.barButtonItem1.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Phục hồi";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2 Medium", 14F, System.Drawing.FontStyle.Bold);
            this.barButtonItem2.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemTextEdit1;
            this.barEditItem1.Id = 2;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // barEditItem2
            // 
            this.barEditItem2.Caption = "barEditItem2";
            this.barEditItem2.Edit = this.repositoryItemTextEdit2;
            this.barEditItem2.Id = 4;
            this.barEditItem2.Name = "barEditItem2";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // textTime
            // 
            this.textTime.Caption = "barEditItem3";
            this.textTime.Edit = this.repositoryItemDateEdit1;
            this.textTime.Id = 5;
            this.textTime.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2 Medium", 14F, System.Drawing.FontStyle.Bold);
            this.textTime.ItemAppearance.Normal.Options.UseFont = true;
            this.textTime.ItemInMenuAppearance.Normal.Font = new System.Drawing.Font("Baloo 2 Medium", 14F, System.Drawing.FontStyle.Bold);
            this.textTime.ItemInMenuAppearance.Normal.Options.UseFont = true;
            this.textTime.Name = "textTime";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.Appearance.Font = new System.Drawing.Font("Baloo 2", 13F);
            this.repositoryItemDateEdit1.Appearance.Options.UseFont = true;
            this.repositoryItemDateEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemDateEdit1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.repositoryItemDateEdit1.DisplayFormat.FormatString = "dd/MM/yyyy | h:mm:ss tt";
            this.repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.EditFormat.FormatString = "dd/MM/yyyy | h:mm:ss tt";
            this.repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "barButtonItem8";
            this.barButtonItem8.Id = 12;
            this.barButtonItem8.Name = "barButtonItem8";
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.Caption = "barCheckItem1";
            this.barCheckItem1.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText;
            this.barCheckItem1.Id = 13;
            this.barCheckItem1.Name = "barCheckItem1";
            // 
            // barCheckItem2
            // 
            this.barCheckItem2.Caption = "a";
            this.barCheckItem2.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.AfterText;
            this.barCheckItem2.Id = 15;
            this.barCheckItem2.Name = "barCheckItem2";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Tạo device";
            this.barButtonItem5.Id = 6;
            this.barButtonItem5.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2 Medium", 14F, System.Drawing.FontStyle.Bold);
            this.barButtonItem5.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Tạo device";
            this.barButtonItem6.Id = 6;
            this.barButtonItem6.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2 Medium", 14F, System.Drawing.FontStyle.Bold);
            this.barButtonItem6.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "MyDataSet";
            this.myDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsDBList
            // 
            this.bdsDBList.DataMember = "databases_list";
            this.bdsDBList.DataSource = this.myDataSet;
            // 
            // adapterDBList
            // 
            this.adapterDBList.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = BaredaProject.MyDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // bdsBackupList
            // 
            this.bdsBackupList.DataMember = "database_backups";
            this.bdsBackupList.DataSource = this.myDataSet;
            // 
            // adapterBackupList
            // 
            this.adapterBackupList.ClearBeforeFill = true;
            // 
            // bdsDeviceList
            // 
            this.bdsDeviceList.DataMember = "backup_devices";
            this.bdsDeviceList.DataSource = this.myDataSet;
            // 
            // adapterDeviceList
            // 
            this.adapterDeviceList.ClearBeforeFill = true;
            // 
            // gcDBList
            // 
            this.gcDBList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gcDBList.DataSource = this.bdsDBList;
            this.gcDBList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(15);
            this.gcDBList.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcDBList.Location = new System.Drawing.Point(59, 133);
            this.gcDBList.MainView = this.gvDBList;
            this.gcDBList.Margin = new System.Windows.Forms.Padding(50, 50, 25, 50);
            this.gcDBList.Name = "gcDBList";
            this.gcDBList.Size = new System.Drawing.Size(582, 418);
            this.gcDBList.TabIndex = 13;
            this.gcDBList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDBList});
            // 
            // gvDBList
            // 
            this.gvDBList.Appearance.EvenRow.BackColor = System.Drawing.Color.White;
            this.gvDBList.Appearance.EvenRow.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gvDBList.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvDBList.Appearance.EvenRow.Options.UseForeColor = true;
            this.gvDBList.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))));
            this.gvDBList.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvDBList.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))));
            this.gvDBList.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvDBList.Appearance.GroupRow.Font = new System.Drawing.Font("Baloo 2", 10.2F);
            this.gvDBList.Appearance.GroupRow.Options.UseFont = true;
            this.gvDBList.Appearance.HeaderPanel.Font = new System.Drawing.Font("Baloo 2", 12F, System.Drawing.FontStyle.Bold);
            this.gvDBList.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvDBList.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))));
            this.gvDBList.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvDBList.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.gvDBList.Appearance.OddRow.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gvDBList.Appearance.OddRow.Options.UseBackColor = true;
            this.gvDBList.Appearance.OddRow.Options.UseForeColor = true;
            this.gvDBList.Appearance.Preview.Font = new System.Drawing.Font("Baloo 2", 10.2F);
            this.gvDBList.Appearance.Preview.Options.UseFont = true;
            this.gvDBList.Appearance.Row.Font = new System.Drawing.Font("Baloo 2", 12F);
            this.gvDBList.Appearance.Row.Options.UseFont = true;
            this.gvDBList.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))));
            this.gvDBList.Appearance.SelectedRow.Font = new System.Drawing.Font("Baloo 2", 12F);
            this.gvDBList.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvDBList.Appearance.SelectedRow.Options.UseFont = true;
            this.gvDBList.Appearance.TopNewRow.Font = new System.Drawing.Font("Baloo 2", 10.2F);
            this.gvDBList.Appearance.TopNewRow.Options.UseFont = true;
            this.gvDBList.Appearance.ViewCaption.Font = new System.Drawing.Font("Baloo 2", 13.8F, System.Drawing.FontStyle.Bold);
            this.gvDBList.Appearance.ViewCaption.Options.UseFont = true;
            this.gvDBList.AppearancePrint.OddRow.BackColor = System.Drawing.Color.DimGray;
            this.gvDBList.AppearancePrint.OddRow.Options.UseBackColor = true;
            this.gvDBList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colname,
            this.coltime_limit,
            this.coldatabase_id});
            this.gvDBList.DetailHeight = 1664;
            this.gvDBList.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvDBList.GridControl = this.gcDBList;
            this.gvDBList.Name = "gvDBList";
            this.gvDBList.OptionsBehavior.Editable = false;
            this.gvDBList.OptionsBehavior.ReadOnly = true;
            this.gvDBList.OptionsCustomization.AllowRowSizing = true;
            this.gvDBList.OptionsDetail.EnableMasterViewMode = false;
            this.gvDBList.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gvDBList.OptionsPrint.EnableAppearanceOddRow = true;
            this.gvDBList.OptionsScrollAnnotations.ShowFocusedRow = DevExpress.Utils.DefaultBoolean.True;
            this.gvDBList.OptionsView.EnableAppearanceEvenRow = true;
            this.gvDBList.OptionsView.EnableAppearanceOddRow = true;
            this.gvDBList.OptionsView.ShowGroupPanel = false;
            this.gvDBList.OptionsView.ShowIndicator = false;
            this.gvDBList.OptionsView.ShowViewCaption = true;
            this.gvDBList.ViewCaption = "Danh sách CSDL";
            this.gvDBList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GvDBList_FocusedRowChanged);
            // 
            // colname
            // 
            this.colname.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(164)))), ((int)(((byte)(236)))));
            this.colname.AppearanceHeader.Options.UseBackColor = true;
            this.colname.Caption = " Tên";
            this.colname.FieldName = "name";
            this.colname.MinWidth = 130;
            this.colname.Name = "colname";
            this.colname.Visible = true;
            this.colname.VisibleIndex = 1;
            this.colname.Width = 330;
            // 
            // coltime_limit
            // 
            this.coltime_limit.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(164)))), ((int)(((byte)(236)))));
            this.coltime_limit.AppearanceHeader.Options.UseBackColor = true;
            this.coltime_limit.Caption = " Giới hạn phục hồi thời gian";
            this.coltime_limit.FieldName = "time_limit";
            this.coltime_limit.MinWidth = 270;
            this.coltime_limit.Name = "coltime_limit";
            this.coltime_limit.ToolTip = "Thời điểm phục hồi theo thời gian không thể nhỏ hơn giới hạn này, vì đây là thời " +
    "điểm sớm nhất mà file log có dữ liệu để phục hồi, thời điểm này phụ thuộc vào lầ" +
    "n phục hồi theo thời gian gần nhất";
            this.coltime_limit.Visible = true;
            this.coltime_limit.VisibleIndex = 2;
            this.coltime_limit.Width = 270;
            // 
            // coldatabase_id
            // 
            this.coldatabase_id.AppearanceCell.Options.UseTextOptions = true;
            this.coldatabase_id.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coldatabase_id.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(164)))), ((int)(((byte)(236)))));
            this.coldatabase_id.AppearanceHeader.Options.UseBackColor = true;
            this.coldatabase_id.AppearanceHeader.Options.UseTextOptions = true;
            this.coldatabase_id.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coldatabase_id.Caption = "Mã";
            this.coldatabase_id.FieldName = "database_id";
            this.coldatabase_id.MaxWidth = 100;
            this.coldatabase_id.MinWidth = 100;
            this.coldatabase_id.Name = "coldatabase_id";
            this.coldatabase_id.OptionsColumn.FixedWidth = true;
            this.coldatabase_id.Visible = true;
            this.coldatabase_id.VisibleIndex = 0;
            this.coldatabase_id.Width = 100;
            // 
            // gcBackups
            // 
            this.gcBackups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcBackups.DataSource = this.bdsBackupList;
            this.gcBackups.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(15);
            this.gcBackups.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcBackups.Location = new System.Drawing.Point(691, 133);
            this.gcBackups.MainView = this.gvBackups;
            this.gcBackups.Margin = new System.Windows.Forms.Padding(25, 50, 50, 50);
            this.gcBackups.Name = "gcBackups";
            this.gcBackups.Size = new System.Drawing.Size(804, 418);
            this.gcBackups.TabIndex = 14;
            this.gcBackups.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBackups});
            // 
            // gvBackups
            // 
            this.gvBackups.Appearance.EvenRow.BackColor = System.Drawing.Color.White;
            this.gvBackups.Appearance.EvenRow.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gvBackups.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvBackups.Appearance.EvenRow.Options.UseForeColor = true;
            this.gvBackups.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(213)))));
            this.gvBackups.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvBackups.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(213)))));
            this.gvBackups.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvBackups.Appearance.GroupRow.Font = new System.Drawing.Font("Baloo 2", 10.2F);
            this.gvBackups.Appearance.GroupRow.Options.UseFont = true;
            this.gvBackups.Appearance.HeaderPanel.Font = new System.Drawing.Font("Baloo 2", 12F, System.Drawing.FontStyle.Bold);
            this.gvBackups.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvBackups.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(213)))));
            this.gvBackups.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvBackups.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.gvBackups.Appearance.OddRow.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gvBackups.Appearance.OddRow.Options.UseBackColor = true;
            this.gvBackups.Appearance.OddRow.Options.UseForeColor = true;
            this.gvBackups.Appearance.Preview.Font = new System.Drawing.Font("Baloo 2", 10.2F);
            this.gvBackups.Appearance.Preview.Options.UseFont = true;
            this.gvBackups.Appearance.Row.Font = new System.Drawing.Font("Baloo 2", 12F);
            this.gvBackups.Appearance.Row.Options.UseFont = true;
            this.gvBackups.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))));
            this.gvBackups.Appearance.SelectedRow.Font = new System.Drawing.Font("Baloo 2", 12F);
            this.gvBackups.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvBackups.Appearance.SelectedRow.Options.UseFont = true;
            this.gvBackups.Appearance.TopNewRow.Font = new System.Drawing.Font("Baloo 2", 10.2F);
            this.gvBackups.Appearance.TopNewRow.Options.UseFont = true;
            this.gvBackups.Appearance.ViewCaption.Font = new System.Drawing.Font("Baloo 2", 13.8F, System.Drawing.FontStyle.Bold);
            this.gvBackups.Appearance.ViewCaption.Options.UseFont = true;
            this.gvBackups.AppearancePrint.OddRow.BackColor = System.Drawing.Color.DimGray;
            this.gvBackups.AppearancePrint.OddRow.Options.UseBackColor = true;
            this.gvBackups.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colposition,
            this.colbackup_start_date,
            this.coluser_name,
            this.coldescription});
            this.gvBackups.DetailHeight = 1664;
            this.gvBackups.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvBackups.GridControl = this.gcBackups;
            this.gvBackups.Name = "gvBackups";
            this.gvBackups.OptionsBehavior.Editable = false;
            this.gvBackups.OptionsBehavior.ReadOnly = true;
            this.gvBackups.OptionsCustomization.AllowRowSizing = true;
            this.gvBackups.OptionsDetail.EnableMasterViewMode = false;
            this.gvBackups.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gvBackups.OptionsPrint.EnableAppearanceOddRow = true;
            this.gvBackups.OptionsScrollAnnotations.ShowFocusedRow = DevExpress.Utils.DefaultBoolean.True;
            this.gvBackups.OptionsView.EnableAppearanceEvenRow = true;
            this.gvBackups.OptionsView.EnableAppearanceOddRow = true;
            this.gvBackups.OptionsView.ShowGroupPanel = false;
            this.gvBackups.OptionsView.ShowIndicator = false;
            this.gvBackups.OptionsView.ShowViewCaption = true;
            this.gvBackups.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colbackup_start_date, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvBackups.ViewCaption = "Danh sách bản sao lưu theo BikeStores";
            this.gvBackups.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GvBackups_FocusedRowChanged);
            // 
            // colposition
            // 
            this.colposition.AppearanceCell.Options.UseTextOptions = true;
            this.colposition.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colposition.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(164)))), ((int)(((byte)(236)))));
            this.colposition.AppearanceHeader.Options.UseBackColor = true;
            this.colposition.AppearanceHeader.Options.UseTextOptions = true;
            this.colposition.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colposition.Caption = "Thứ tự";
            this.colposition.FieldName = "position";
            this.colposition.MaxWidth = 150;
            this.colposition.MinWidth = 150;
            this.colposition.Name = "colposition";
            this.colposition.OptionsColumn.FixedWidth = true;
            this.colposition.Visible = true;
            this.colposition.VisibleIndex = 0;
            this.colposition.Width = 150;
            // 
            // colbackup_start_date
            // 
            this.colbackup_start_date.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(164)))), ((int)(((byte)(236)))));
            this.colbackup_start_date.AppearanceHeader.Options.UseBackColor = true;
            this.colbackup_start_date.Caption = " Ngày sao lưu";
            this.colbackup_start_date.FieldName = "backup_start_date";
            this.colbackup_start_date.MaxWidth = 275;
            this.colbackup_start_date.MinWidth = 275;
            this.colbackup_start_date.Name = "colbackup_start_date";
            this.colbackup_start_date.OptionsColumn.FixedWidth = true;
            this.colbackup_start_date.Visible = true;
            this.colbackup_start_date.VisibleIndex = 2;
            this.colbackup_start_date.Width = 275;
            // 
            // coluser_name
            // 
            this.coluser_name.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(164)))), ((int)(((byte)(236)))));
            this.coluser_name.AppearanceHeader.Options.UseBackColor = true;
            this.coluser_name.Caption = " User sao lưu";
            this.coluser_name.FieldName = "user_name";
            this.coluser_name.MaxWidth = 281;
            this.coluser_name.MinWidth = 281;
            this.coluser_name.Name = "coluser_name";
            this.coluser_name.OptionsColumn.FixedWidth = true;
            this.coluser_name.Visible = true;
            this.coluser_name.VisibleIndex = 3;
            this.coluser_name.Width = 281;
            // 
            // coldescription
            // 
            this.coldescription.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(164)))), ((int)(((byte)(236)))));
            this.coldescription.AppearanceHeader.Options.UseBackColor = true;
            this.coldescription.Caption = " Mô tả";
            this.coldescription.FieldName = "description";
            this.coldescription.MinWidth = 250;
            this.coldescription.Name = "coldescription";
            this.coldescription.Visible = true;
            this.coldescription.VisibleIndex = 1;
            this.coldescription.Width = 461;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripUserName,
            this.stripBackupMode,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 601);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1554, 40);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stripUserName
            // 
            this.stripUserName.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.stripUserName.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.stripUserName.Font = new System.Drawing.Font("Baloo 2 Medium", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stripUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(164)))), ((int)(((byte)(236)))));
            this.stripUserName.Name = "stripUserName";
            this.stripUserName.Size = new System.Drawing.Size(133, 34);
            this.stripUserName.Text = " Tài khoản: sa ";
            // 
            // stripBackupMode
            // 
            this.stripBackupMode.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.stripBackupMode.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.stripBackupMode.Font = new System.Drawing.Font("Baloo 2", 10.8F);
            this.stripBackupMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(70)))), ((int)(((byte)(68)))));
            this.stripBackupMode.Name = "stripBackupMode";
            this.stripBackupMode.Size = new System.Drawing.Size(164, 34);
            this.stripBackupMode.Text = "Backup mode: File";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Baloo 2", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(70)))), ((int)(((byte)(68)))));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(459, 34);
            this.toolStripStatusLabel2.Text = " Đồ án sao lưu - phục hồi cơ sở dữ liệu trong SQL Server";
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.guna2Separator1.Location = new System.Drawing.Point(0, 69);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1554, 11);
            this.guna2Separator1.TabIndex = 29;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1554, 641);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gcBackups);
            this.Controls.Add(this.gcDBList);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bareda Project";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restoreMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDBList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsBackupList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDeviceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDBList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDBList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBackups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBackups)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarEditItem textTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarButtonItem btnBackup;
        private DevExpress.XtraBars.BarButtonItem btnRestore;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem btnDelBackup;
        private DevExpress.XtraBars.BarCheckItem barCheckItem2;
        private DevExpress.XtraBars.PopupMenu restoreMenu;
        private DevExpress.XtraBars.BarButtonItem barBtnTimeRestore;
        private DevExpress.XtraBars.BarButtonItem barBtnDefaultRestore;
        private DevExpress.XtraBars.PopupMenu backupMenu;
        private DevExpress.XtraBars.BarButtonItem barBtnDefaultBackup;
        private DevExpress.XtraBars.BarButtonItem barBtnInitBackup;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private System.Windows.Forms.BindingSource bdsDBList;
        private MyDataSet myDataSet;
        private MyDataSetTableAdapters.databases_listTableAdapter adapterDBList;
        private MyDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource bdsBackupList;
        private MyDataSetTableAdapters.database_backupsTableAdapter adapterBackupList;
        private System.Windows.Forms.BindingSource bdsDeviceList;
        private MyDataSetTableAdapters.backup_devicesTableAdapter adapterDeviceList;
        private DevExpress.XtraGrid.GridControl gcDBList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDBList;
        private DevExpress.XtraGrid.GridControl gcBackups;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBackups;
        private DevExpress.XtraGrid.Columns.GridColumn colname;
        private DevExpress.XtraGrid.Columns.GridColumn coldatabase_id;
        private DevExpress.XtraGrid.Columns.GridColumn colposition;
        private DevExpress.XtraGrid.Columns.GridColumn colbackup_start_date;
        private DevExpress.XtraGrid.Columns.GridColumn coluser_name;
        private DevExpress.XtraGrid.Columns.GridColumn coldescription;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        public System.Windows.Forms.ToolStripStatusLabel stripUserName;
        private DevExpress.XtraBars.BarButtonItem btnCreateDevice;
        public System.Windows.Forms.ToolStripStatusLabel stripBackupMode;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private DevExpress.XtraBars.PopupMenu deleteMenu;
        private DevExpress.XtraBars.BarButtonItem barBtnDeleteSelected;
        private DevExpress.XtraBars.BarButtonItem barBtnDeleteAll;
        private DevExpress.XtraGrid.Columns.GridColumn coltime_limit;
    }
}

