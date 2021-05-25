namespace FrontEnd
{
	partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.bestandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMnuConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMnuResetUserSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnApplicationInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.btnConnect = new System.Windows.Forms.ToolStripButton();
            this.btnSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTest = new System.Windows.Forms.ToolStripButton();
            this.btnResetUserSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvTab1 = new System.Windows.Forms.DataGridView();
            this.dgvTab1_2 = new System.Windows.Forms.DataGridView();
            this.toolStripTab1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.txtOrdernumber = new System.Windows.Forms.ToolStripTextBox();
            this.btnClearOrderFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cbxProductionLine = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cbxOrderStatus = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReleaseOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOrderStart = new System.Windows.Forms.ToolStripButton();
            this.btnOrderPause = new System.Windows.Forms.ToolStripButton();
            this.btnOrderStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOrderAdd = new System.Windows.Forms.ToolStripButton();
            this.btnOrderEdit = new System.Windows.Forms.ToolStripButton();
            this.btnOrderRemove = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lstbxCustomers = new System.Windows.Forms.ListBox();
            this.lstbxRecipes = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstbxProductionlines = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lstbxOrderstatusses = new System.Windows.Forms.ListBox();
            this.menuStripMain.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTab1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTab1_2)).BeginInit();
            this.toolStripTab1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bestandToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStripMain.Size = new System.Drawing.Size(1184, 28);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // bestandToolStripMenuItem
            // 
            this.bestandToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMnuConnect,
            this.btnMnuSettings,
            this.btnMnuResetUserSettings,
            this.btnMnuClose});
            this.bestandToolStripMenuItem.Name = "bestandToolStripMenuItem";
            this.bestandToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.bestandToolStripMenuItem.Text = "&Programma";
            // 
            // btnMnuConnect
            // 
            this.btnMnuConnect.Image = global::FrontEnd.Properties.Resources.Gnome_network_wired_svg;
            this.btnMnuConnect.Name = "btnMnuConnect";
            this.btnMnuConnect.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.btnMnuConnect.Size = new System.Drawing.Size(239, 22);
            this.btnMnuConnect.Text = "Verbinding &maken";
            this.btnMnuConnect.Click += new System.EventHandler(this.btnMnuConnect_Click);
            // 
            // btnMnuSettings
            // 
            this.btnMnuSettings.Image = global::FrontEnd.Properties.Resources.Gnome_applications_system_svg;
            this.btnMnuSettings.Name = "btnMnuSettings";
            this.btnMnuSettings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.btnMnuSettings.Size = new System.Drawing.Size(239, 22);
            this.btnMnuSettings.Text = "Verbinding &instellen";
            this.btnMnuSettings.Click += new System.EventHandler(this.btnMnuSettings_Click);
            // 
            // btnMnuResetUserSettings
            // 
            this.btnMnuResetUserSettings.Image = global::FrontEnd.Properties.Resources.Gnome_document_open_recent_svg;
            this.btnMnuResetUserSettings.Name = "btnMnuResetUserSettings";
            this.btnMnuResetUserSettings.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.btnMnuResetUserSettings.Size = new System.Drawing.Size(239, 22);
            this.btnMnuResetUserSettings.Text = "&Reset instellingen";
            this.btnMnuResetUserSettings.ToolTipText = "Reset alle instellingen";
            this.btnMnuResetUserSettings.Click += new System.EventHandler(this.btnMnuResetUserSettings_Click);
            // 
            // btnMnuClose
            // 
            this.btnMnuClose.Image = global::FrontEnd.Properties.Resources.Gnome_system_log_out_svg;
            this.btnMnuClose.Name = "btnMnuClose";
            this.btnMnuClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.btnMnuClose.Size = new System.Drawing.Size(239, 22);
            this.btnMnuClose.Text = "&Afsluiten";
            this.btnMnuClose.Click += new System.EventHandler(this.afsluitenToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnApplicationInfo});
            this.infoToolStripMenuItem.Image = global::FrontEnd.Properties.Resources._240px_Gnome_dialog_question_svg;
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.infoToolStripMenuItem.Text = "&Info";
            // 
            // btnApplicationInfo
            // 
            this.btnApplicationInfo.Image = global::FrontEnd.Properties.Resources._240px_Gnome_help_faq_svg;
            this.btnApplicationInfo.Name = "btnApplicationInfo";
            this.btnApplicationInfo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.btnApplicationInfo.Size = new System.Drawing.Size(217, 22);
            this.btnApplicationInfo.Text = "Over deze applicatie";
            this.btnApplicationInfo.Click += new System.EventHandler(this.btnApplicationInfo_Click);
            // 
            // toolStripMain
            // 
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(42, 42);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConnect,
            this.btnSettings,
            this.toolStripSeparator2,
            this.btnTest,
            this.btnResetUserSettings,
            this.toolStripSeparator3});
            this.toolStripMain.Location = new System.Drawing.Point(0, 28);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1184, 49);
            this.toolStripMain.TabIndex = 1;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // btnConnect
            // 
            this.btnConnect.Image = global::FrontEnd.Properties.Resources.Gnome_network_wired_svg;
            this.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(149, 46);
            this.btnConnect.Text = "Verbinding maken";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Image = global::FrontEnd.Properties.Resources.Gnome_applications_system_svg;
            this.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(114, 46);
            this.btnSettings.Text = "Instellingen";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 49);
            // 
            // btnTest
            // 
            this.btnTest.Image = global::FrontEnd.Properties.Resources._240px_Gnumeric_svg;
            this.btnTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(100, 46);
            this.btnTest.Text = "Testknop";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnResetUserSettings
            // 
            this.btnResetUserSettings.Image = global::FrontEnd.Properties.Resources.Gnome_document_open_recent_svg;
            this.btnResetUserSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResetUserSettings.Name = "btnResetUserSettings";
            this.btnResetUserSettings.Size = new System.Drawing.Size(145, 46);
            this.btnResetUserSettings.Text = "Reset instellingen";
            this.btnResetUserSettings.ToolTipText = "Reset alle instellingen";
            this.btnResetUserSettings.Click += new System.EventHandler(this.btnResetUserSettings_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 49);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 676);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1184, 35);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Image = global::FrontEnd.Properties.Resources.Gnome_network_offline_svg;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(124, 30);
            this.lblStatus.Text = "Geen verbinding";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Controls.Add(this.toolStripTab1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1176, 555);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Overzicht orders";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 52);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvTab1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvTab1_2);
            this.splitContainer1.Size = new System.Drawing.Size(1170, 500);
            this.splitContainer1.SplitterDistance = 335;
            this.splitContainer1.TabIndex = 6;
            // 
            // dgvTab1
            // 
            this.dgvTab1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTab1.Location = new System.Drawing.Point(0, 0);
            this.dgvTab1.Name = "dgvTab1";
            this.dgvTab1.ReadOnly = true;
            this.dgvTab1.Size = new System.Drawing.Size(1170, 335);
            this.dgvTab1.TabIndex = 6;
            this.dgvTab1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvTab1_DataError);
            // 
            // dgvTab1_2
            // 
            this.dgvTab1_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTab1_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTab1_2.Location = new System.Drawing.Point(0, 0);
            this.dgvTab1_2.Name = "dgvTab1_2";
            this.dgvTab1_2.ReadOnly = true;
            this.dgvTab1_2.Size = new System.Drawing.Size(1170, 161);
            this.dgvTab1_2.TabIndex = 0;
            // 
            // toolStripTab1
            // 
            this.toolStripTab1.ImageScalingSize = new System.Drawing.Size(42, 42);
            this.toolStripTab1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.txtOrdernumber,
            this.btnClearOrderFilter,
            this.toolStripSeparator8,
            this.toolStripLabel1,
            this.cbxProductionLine,
            this.toolStripSeparator5,
            this.toolStripLabel2,
            this.cbxOrderStatus,
            this.toolStripSeparator6,
            this.btnReleaseOrder,
            this.toolStripSeparator7,
            this.btnOrderStart,
            this.btnOrderPause,
            this.btnOrderStop,
            this.toolStripSeparator4,
            this.btnOrderAdd,
            this.btnOrderEdit,
            this.btnOrderRemove,
            this.btnRefresh,
            this.toolStripSeparator1});
            this.toolStripTab1.Location = new System.Drawing.Point(3, 3);
            this.toolStripTab1.Name = "toolStripTab1";
            this.toolStripTab1.Size = new System.Drawing.Size(1170, 49);
            this.toolStripTab1.TabIndex = 4;
            this.toolStripTab1.Text = "toolStrip2";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(86, 46);
            this.toolStripLabel3.Text = "Ordernummer:";
            // 
            // txtOrdernumber
            // 
            this.txtOrdernumber.BackColor = System.Drawing.SystemColors.Control;
            this.txtOrdernumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtOrdernumber.Name = "txtOrdernumber";
            this.txtOrdernumber.Size = new System.Drawing.Size(120, 49);
            this.txtOrdernumber.ToolTipText = "Typ een ordernummer om de gegevens te filteren.";
            this.txtOrdernumber.TextChanged += new System.EventHandler(this.txtOrdernumber_TextChanged);
            // 
            // btnClearOrderFilter
            // 
            this.btnClearOrderFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClearOrderFilter.Image = global::FrontEnd.Properties.Resources._240px_Gnome_window_close_svg;
            this.btnClearOrderFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearOrderFilter.Name = "btnClearOrderFilter";
            this.btnClearOrderFilter.Size = new System.Drawing.Size(46, 46);
            this.btnClearOrderFilter.Text = "toolStripButton1";
            this.btnClearOrderFilter.ToolTipText = "Verwijder het filter voor ordernummers.";
            this.btnClearOrderFilter.Click += new System.EventHandler(this.btnClearOrderFilter_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 49);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(105, 46);
            this.toolStripLabel1.Text = "Geselecteerde Lijn:";
            // 
            // cbxProductionLine
            // 
            this.cbxProductionLine.BackColor = System.Drawing.SystemColors.Control;
            this.cbxProductionLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProductionLine.Items.AddRange(new object[] {
            "",
            "Lijn 1",
            "Lijn 2"});
            this.cbxProductionLine.Name = "cbxProductionLine";
            this.cbxProductionLine.Size = new System.Drawing.Size(120, 49);
            this.cbxProductionLine.ToolTipText = "Selecteer een productielijn om de orders op te halen";
            this.cbxProductionLine.SelectedIndexChanged += new System.EventHandler(this.cbxProductionLine_SelectedIndexChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 49);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(71, 46);
            this.toolStripLabel2.Text = "Orderstatus:";
            // 
            // cbxOrderStatus
            // 
            this.cbxOrderStatus.BackColor = System.Drawing.SystemColors.Control;
            this.cbxOrderStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOrderStatus.Items.AddRange(new object[] {
            "",
            "Aangemaakt",
            "Gepland",
            "In productie",
            "Afgehandeld"});
            this.cbxOrderStatus.Name = "cbxOrderStatus";
            this.cbxOrderStatus.Size = new System.Drawing.Size(120, 49);
            this.cbxOrderStatus.ToolTipText = "Filter de orders op basis van de orderstatus";
            this.cbxOrderStatus.SelectedIndexChanged += new System.EventHandler(this.cbxOrderStatus_SelectedIndexChanged);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 49);
            // 
            // btnReleaseOrder
            // 
            this.btnReleaseOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReleaseOrder.Image = global::FrontEnd.Properties.Resources._240px_Gnome_x_office_document_svg;
            this.btnReleaseOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReleaseOrder.Name = "btnReleaseOrder";
            this.btnReleaseOrder.Size = new System.Drawing.Size(46, 46);
            this.btnReleaseOrder.Text = "toolStripButton1";
            this.btnReleaseOrder.ToolTipText = "Markeer de geselecteerde order als vrijgegeven.";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 49);
            // 
            // btnOrderStart
            // 
            this.btnOrderStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOrderStart.Image = global::FrontEnd.Properties.Resources._240px_Oxygen480_actions_go_next_view_page_svg;
            this.btnOrderStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOrderStart.Name = "btnOrderStart";
            this.btnOrderStart.Size = new System.Drawing.Size(46, 46);
            this.btnOrderStart.Text = "toolStripButton1";
            this.btnOrderStart.ToolTipText = "Start de geselecteerde order";
            this.btnOrderStart.Click += new System.EventHandler(this.btnOrderStart_Click);
            // 
            // btnOrderPause
            // 
            this.btnOrderPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOrderPause.Image = global::FrontEnd.Properties.Resources._240px_Gnome_media_playback_pause_svg;
            this.btnOrderPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOrderPause.Name = "btnOrderPause";
            this.btnOrderPause.Size = new System.Drawing.Size(46, 46);
            this.btnOrderPause.Text = "toolStripButton5";
            this.btnOrderPause.ToolTipText = "Pauzeer de geselecteerde order";
            this.btnOrderPause.Click += new System.EventHandler(this.btnOrderPause_Click);
            // 
            // btnOrderStop
            // 
            this.btnOrderStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOrderStop.Image = global::FrontEnd.Properties.Resources.Gnome_media_playback_stop_svg;
            this.btnOrderStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOrderStop.Name = "btnOrderStop";
            this.btnOrderStop.Size = new System.Drawing.Size(46, 46);
            this.btnOrderStop.Text = "toolStripButton6";
            this.btnOrderStop.ToolTipText = "Stop de geselecteerde order";
            this.btnOrderStop.Click += new System.EventHandler(this.btnOrderStop_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 49);
            // 
            // btnOrderAdd
            // 
            this.btnOrderAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOrderAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnOrderAdd.Image")));
            this.btnOrderAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOrderAdd.Name = "btnOrderAdd";
            this.btnOrderAdd.Size = new System.Drawing.Size(46, 46);
            this.btnOrderAdd.Text = "toolStripButton1";
            this.btnOrderAdd.ToolTipText = "Maak een nieuwe order";
            this.btnOrderAdd.Click += new System.EventHandler(this.btnOrderAdd_Click);
            // 
            // btnOrderEdit
            // 
            this.btnOrderEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOrderEdit.Image = global::FrontEnd.Properties.Resources._240px_Gnome_accessories_text_editor_svg;
            this.btnOrderEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOrderEdit.Name = "btnOrderEdit";
            this.btnOrderEdit.Size = new System.Drawing.Size(46, 46);
            this.btnOrderEdit.Text = "toolStripButton1";
            this.btnOrderEdit.ToolTipText = "Bewerk de geselecteerde order";
            this.btnOrderEdit.Click += new System.EventHandler(this.btnOrderEdit_Click);
            // 
            // btnOrderRemove
            // 
            this.btnOrderRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOrderRemove.Image = global::FrontEnd.Properties.Resources.Gnome_edit_delete_svg;
            this.btnOrderRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOrderRemove.Name = "btnOrderRemove";
            this.btnOrderRemove.Size = new System.Drawing.Size(46, 46);
            this.btnOrderRemove.Text = "toolStripButton7";
            this.btnOrderRemove.ToolTipText = "Verwijder de geselecteerde order";
            this.btnOrderRemove.Click += new System.EventHandler(this.btnOrderRemove_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::FrontEnd.Properties.Resources.Gnome_view_refresh_svg;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(46, 46);
            this.btnRefresh.Text = "toolStripButton1";
            this.btnRefresh.ToolTipText = "Ververs venster";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 49);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.ItemSize = new System.Drawing.Size(58, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 80);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1184, 593);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.lstbxOrderstatusses);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.lstbxProductionlines);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.lstbxRecipes);
            this.tabPage3.Controls.Add(this.lstbxCustomers);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1176, 555);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Realtime data";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lstbxCustomers
            // 
            this.lstbxCustomers.FormattingEnabled = true;
            this.lstbxCustomers.Location = new System.Drawing.Point(115, 112);
            this.lstbxCustomers.Name = "lstbxCustomers";
            this.lstbxCustomers.Size = new System.Drawing.Size(200, 251);
            this.lstbxCustomers.TabIndex = 0;
            // 
            // lstbxRecipes
            // 
            this.lstbxRecipes.FormattingEnabled = true;
            this.lstbxRecipes.Location = new System.Drawing.Point(321, 112);
            this.lstbxRecipes.Name = "lstbxRecipes";
            this.lstbxRecipes.Size = new System.Drawing.Size(200, 251);
            this.lstbxRecipes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Customers:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Recipes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(524, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Productionlines:";
            // 
            // lstbxProductionlines
            // 
            this.lstbxProductionlines.FormattingEnabled = true;
            this.lstbxProductionlines.Location = new System.Drawing.Point(527, 112);
            this.lstbxProductionlines.Name = "lstbxProductionlines";
            this.lstbxProductionlines.Size = new System.Drawing.Size(200, 251);
            this.lstbxProductionlines.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(730, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Order statusses:";
            // 
            // lstbxOrderstatusses
            // 
            this.lstbxOrderstatusses.FormattingEnabled = true;
            this.lstbxOrderstatusses.Location = new System.Drawing.Point(733, 112);
            this.lstbxOrderstatusses.Name = "lstbxOrderstatusses";
            this.lstbxOrderstatusses.Size = new System.Drawing.Size(200, 251);
            this.lstbxOrderstatusses.TabIndex = 6;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 711);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "frmMain";
            this.Text = "Avans MES - Broodbakkerij Zoete Broodjes Corp.";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTab1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTab1_2)).EndInit();
            this.toolStripTab1.ResumeLayout(false);
            this.toolStripTab1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton btnTest;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem bestandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnMnuClose;
        private System.Windows.Forms.ToolStripMenuItem btnApplicationInfo;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripButton btnSettings;
        private System.Windows.Forms.ToolStripButton btnResetUserSettings;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripButton btnConnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStrip toolStripTab1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnOrderStart;
        private System.Windows.Forms.ToolStripButton btnOrderPause;
        private System.Windows.Forms.ToolStripButton btnOrderStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnOrderRemove;
        private System.Windows.Forms.ToolStripComboBox cbxProductionLine;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnOrderEdit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvTab1;
        private System.Windows.Forms.DataGridView dgvTab1_2;
        private System.Windows.Forms.ToolStripButton btnOrderAdd;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cbxOrderStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripMenuItem btnMnuConnect;
        private System.Windows.Forms.ToolStripMenuItem btnMnuSettings;
        private System.Windows.Forms.ToolStripMenuItem btnMnuResetUserSettings;
        private System.Windows.Forms.ToolStripButton btnReleaseOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox txtOrdernumber;
        private System.Windows.Forms.ToolStripButton btnClearOrderFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ListBox lstbxRecipes;
        private System.Windows.Forms.ListBox lstbxCustomers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstbxOrderstatusses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstbxProductionlines;
    }
}

