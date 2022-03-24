
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnBackup = new DevExpress.XtraBars.BarButtonItem();
            this.backupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barBtnDeB = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnRB = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelBackup = new DevExpress.XtraBars.BarButtonItem();
            this.btnRestore = new DevExpress.XtraBars.BarButtonItem();
            this.restoreMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barBtnDR = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSR = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.btnDevice = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
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
            this.databases_listBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.databases_listTableAdapter = new BaredaProject.MyDataSetTableAdapters.databases_listTableAdapter();
            this.tableAdapterManager = new BaredaProject.MyDataSetTableAdapters.TableAdapterManager();
            this.database_backupsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.database_backupsTableAdapter = new BaredaProject.MyDataSetTableAdapters.database_backupsTableAdapter();
            this.backup_devicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.backup_devicesTableAdapter = new BaredaProject.MyDataSetTableAdapters.backup_devicesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restoreMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databases_listBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database_backupsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backup_devicesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(231);
            this.gridControl1.Location = new System.Drawing.Point(881, 5492);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(231);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(27731, 13856);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 20000;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
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
            this.btnDevice,
            this.barStaticItem1,
            this.barStaticItem2,
            this.barStaticItem3,
            this.barButtonItem8,
            this.barCheckItem1,
            this.btnDelBackup,
            this.barCheckItem2,
            this.barBtnSR,
            this.barBtnDR,
            this.barBtnDeB,
            this.barBtnRB,
            this.barButtonItem3});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 21;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemDateEdit1});
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnBackup, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelBackup, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRestore, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem3, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDevice, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnBackup
            // 
            this.btnBackup.ActAsDropDown = true;
            this.btnBackup.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnBackup.Caption = " Sao lưu  ";
            this.btnBackup.DropDownControl = this.backupMenu;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnDeB),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnRB)});
            this.backupMenu.Manager = this.barManager1;
            this.backupMenu.Name = "backupMenu";
            // 
            // barBtnDeB
            // 
            this.barBtnDeB.Caption = "Sao lưu thông thường";
            this.barBtnDeB.Id = 18;
            this.barBtnDeB.ImageOptions.Image = global::BaredaProject.Properties.Resources.save_as_20px;
            this.barBtnDeB.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2", 10.2F);
            this.barBtnDeB.ItemAppearance.Normal.Options.UseFont = true;
            this.barBtnDeB.Name = "barBtnDeB";
            // 
            // barBtnRB
            // 
            this.barBtnRB.Caption = "Xóa tất cả bản sao lưu cũ rồi tiến hành sao lưu";
            this.barBtnRB.Id = 19;
            this.barBtnRB.ImageOptions.Image = global::BaredaProject.Properties.Resources.minus_20px;
            this.barBtnRB.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2", 10.2F);
            this.barBtnRB.ItemAppearance.Normal.Options.UseFont = true;
            this.barBtnRB.Name = "barBtnRB";
            // 
            // btnDelBackup
            // 
            this.btnDelBackup.Caption = "  Xóa bản sao lưu ";
            this.btnDelBackup.Hint = "Xóa bản sao lưu đã chọn trên danh sách";
            this.btnDelBackup.Id = 14;
            this.btnDelBackup.ImageOptions.Image = global::BaredaProject.Properties.Resources.remove_from_cart;
            this.btnDelBackup.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2 Medium", 14F, System.Drawing.FontStyle.Bold);
            this.btnDelBackup.ItemAppearance.Normal.Options.UseFont = true;
            this.btnDelBackup.Name = "btnDelBackup";
            // 
            // btnRestore
            // 
            this.btnRestore.ActAsDropDown = true;
            this.btnRestore.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnRestore.Caption = " Phục hồi ";
            this.btnRestore.DropDownControl = this.restoreMenu;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnDR),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnSR)});
            this.restoreMenu.Manager = this.barManager1;
            this.restoreMenu.Name = "restoreMenu";
            // 
            // barBtnDR
            // 
            this.barBtnDR.Caption = "Phục hồi theo bản sao lưu đã chọn";
            this.barBtnDR.Id = 17;
            this.barBtnDR.ImageOptions.Image = global::BaredaProject.Properties.Resources.restart_20px;
            this.barBtnDR.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2", 10.2F);
            this.barBtnDR.ItemAppearance.Normal.Options.UseFont = true;
            this.barBtnDR.Name = "barBtnDR";
            // 
            // barBtnSR
            // 
            this.barBtnSR.Caption = "Phục hồi về một thời điểm cụ thể";
            this.barBtnSR.Id = 16;
            this.barBtnSR.ImageOptions.Image = global::BaredaProject.Properties.Resources.clock_20px;
            this.barBtnSR.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barBtnSR.ItemAppearance.Normal.Options.UseFont = true;
            this.barBtnSR.Name = "barBtnSR";
            this.barBtnSR.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSR_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "  Làm mới ";
            this.barButtonItem3.Id = 20;
            this.barButtonItem3.ImageOptions.Image = global::BaredaProject.Properties.Resources.refresh_1_;
            this.barButtonItem3.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2 Medium", 14F, System.Drawing.FontStyle.Bold);
            this.barButtonItem3.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // btnDevice
            // 
            this.btnDevice.Caption = "  Tạo device  ";
            this.btnDevice.Id = 8;
            this.btnDevice.ImageOptions.Image = global::BaredaProject.Properties.Resources.data_warehouse;
            this.btnDevice.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2 Medium", 14F, System.Drawing.FontStyle.Bold);
            this.btnDevice.ItemAppearance.Normal.Options.UseFont = true;
            this.btnDevice.Name = "btnDevice";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem3)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = " Nguyễn Ngọc Minh Tú ";
            this.barStaticItem1.Id = 9;
            this.barStaticItem1.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barStaticItem1.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = " N18DCCN192 ";
            this.barStaticItem2.Id = 10;
            this.barStaticItem2.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barStaticItem2.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItem2.Name = "barStaticItem2";
            // 
            // barStaticItem3
            // 
            this.barStaticItem3.Caption = " Đồ án sao lưu - phục hồi cơ sở dữ liệu trong SQL Server ";
            this.barStaticItem3.Id = 11;
            this.barStaticItem3.ItemAppearance.Normal.Font = new System.Drawing.Font("Baloo 2", 10.2F);
            this.barStaticItem3.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItem3.Name = "barStaticItem3";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(28612, 63);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 19348);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(28612, 37);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 63);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 19285);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(28612, 63);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 19285);
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
            this.repositoryItemDateEdit1.MaskSettings.Set("mask", "dd/MM/yyyy | h:mm:ss tt");
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
            // databases_listBindingSource
            // 
            this.databases_listBindingSource.DataMember = "databases_list";
            this.databases_listBindingSource.DataSource = this.myDataSet;
            // 
            // databases_listTableAdapter
            // 
            this.databases_listTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = BaredaProject.MyDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // database_backupsBindingSource
            // 
            this.database_backupsBindingSource.DataMember = "database_backups";
            this.database_backupsBindingSource.DataSource = this.myDataSet;
            // 
            // database_backupsTableAdapter
            // 
            this.database_backupsTableAdapter.ClearBeforeFill = true;
            // 
            // backup_devicesBindingSource
            // 
            this.backup_devicesBindingSource.DataMember = "backup_devices";
            this.backup_devicesBindingSource.DataSource = this.myDataSet;
            // 
            // backup_devicesTableAdapter
            // 
            this.backup_devicesTableAdapter.ClearBeforeFill = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Bareda Project";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restoreMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databases_listBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database_backupsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backup_devicesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarEditItem textTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarButtonItem btnBackup;
        private DevExpress.XtraBars.BarButtonItem btnRestore;
        private DevExpress.XtraBars.Bar bar3;
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
        private DevExpress.XtraBars.BarButtonItem btnDevice;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem btnDelBackup;
        private DevExpress.XtraBars.BarCheckItem barCheckItem2;
        private DevExpress.XtraBars.PopupMenu restoreMenu;
        private DevExpress.XtraBars.BarButtonItem barBtnSR;
        private DevExpress.XtraBars.BarButtonItem barBtnDR;
        private DevExpress.XtraBars.PopupMenu backupMenu;
        private DevExpress.XtraBars.BarButtonItem barBtnDeB;
        private DevExpress.XtraBars.BarButtonItem barBtnRB;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private System.Windows.Forms.BindingSource databases_listBindingSource;
        private MyDataSet myDataSet;
        private MyDataSetTableAdapters.databases_listTableAdapter databases_listTableAdapter;
        private MyDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource database_backupsBindingSource;
        private MyDataSetTableAdapters.database_backupsTableAdapter database_backupsTableAdapter;
        private System.Windows.Forms.BindingSource backup_devicesBindingSource;
        private MyDataSetTableAdapters.backup_devicesTableAdapter backup_devicesTableAdapter;
    }
}

