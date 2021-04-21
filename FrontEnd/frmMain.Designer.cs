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
            this.afsluitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnApplicationInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.btnConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTest = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvTab1 = new System.Windows.Forms.DataGridView();
            this.toolStripTab1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cbxProductionLine = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOrderStart = new System.Windows.Forms.ToolStripButton();
            this.btnOrderPause = new System.Windows.Forms.ToolStripButton();
            this.btnOrderStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOrderEdit = new System.Windows.Forms.ToolStripButton();
            this.btnOrderRemove = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.dgvTab1_2 = new System.Windows.Forms.DataGridView();
            this.btnOrderAdd = new System.Windows.Forms.ToolStripButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.menuStripMain.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTab1)).BeginInit();
            this.toolStripTab1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTab1_2)).BeginInit();
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
            this.afsluitenToolStripMenuItem});
            this.bestandToolStripMenuItem.Image = global::FrontEnd.Properties.Resources.Gnome_folder_svg;
            this.bestandToolStripMenuItem.Name = "bestandToolStripMenuItem";
            this.bestandToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.bestandToolStripMenuItem.Text = "&Bestand";
            // 
            // afsluitenToolStripMenuItem
            // 
            this.afsluitenToolStripMenuItem.Image = global::FrontEnd.Properties.Resources._240px_Gnome_application_exit_svg;
            this.afsluitenToolStripMenuItem.Name = "afsluitenToolStripMenuItem";
            this.afsluitenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.afsluitenToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.afsluitenToolStripMenuItem.Text = "&Afsluiten";
            this.afsluitenToolStripMenuItem.Click += new System.EventHandler(this.afsluitenToolStripMenuItem_Click);
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
            this.toolStripSeparator2,
            this.btnTest,
            this.toolStripSeparator3,
            this.toolStripButton2,
            this.toolStripButton4,
            this.toolStripButton3,
            this.toolStripSeparator1});
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 49);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::FrontEnd.Properties.Resources.Gnome_x_office_presentation_svg;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(46, 46);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::FrontEnd.Properties.Resources.Gnome_document_open_recent_svg;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(46, 46);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::FrontEnd.Properties.Resources.Gnome_applications_system_svg;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(46, 46);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 49);
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
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1176, 555);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Afgehandelde orders";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.splitContainer1.SplitterDistance = 344;
            this.splitContainer1.TabIndex = 6;
            // 
            // dgvTab1
            // 
            this.dgvTab1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTab1.Location = new System.Drawing.Point(0, 0);
            this.dgvTab1.Name = "dgvTab1";
            this.dgvTab1.ReadOnly = true;
            this.dgvTab1.Size = new System.Drawing.Size(1170, 344);
            this.dgvTab1.TabIndex = 6;
            this.dgvTab1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvTab1_DataError);
            // 
            // toolStripTab1
            // 
            this.toolStripTab1.ImageScalingSize = new System.Drawing.Size(42, 42);
            this.toolStripTab1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cbxProductionLine,
            this.toolStripSeparator5,
            this.btnOrderStart,
            this.btnOrderPause,
            this.btnOrderStop,
            this.toolStripSeparator4,
            this.btnOrderAdd,
            this.btnOrderEdit,
            this.btnOrderRemove});
            this.toolStripTab1.Location = new System.Drawing.Point(3, 3);
            this.toolStripTab1.Name = "toolStripTab1";
            this.toolStripTab1.Size = new System.Drawing.Size(1170, 49);
            this.toolStripTab1.TabIndex = 4;
            this.toolStripTab1.Text = "toolStrip2";
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
            "Lijn 1",
            "Lijn 2"});
            this.cbxProductionLine.Name = "cbxProductionLine";
            this.cbxProductionLine.Size = new System.Drawing.Size(75, 49);
            this.cbxProductionLine.ToolTipText = "Selecteer een productielijn om de orders op te halen.";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 49);
            // 
            // btnOrderStart
            // 
            this.btnOrderStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOrderStart.Image = global::FrontEnd.Properties.Resources._240px_Oxygen480_actions_go_next_view_page_svg;
            this.btnOrderStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOrderStart.Name = "btnOrderStart";
            this.btnOrderStart.Size = new System.Drawing.Size(46, 46);
            this.btnOrderStart.Text = "toolStripButton1";
            // 
            // btnOrderPause
            // 
            this.btnOrderPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOrderPause.Image = global::FrontEnd.Properties.Resources._240px_Gnome_media_playback_pause_svg;
            this.btnOrderPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOrderPause.Name = "btnOrderPause";
            this.btnOrderPause.Size = new System.Drawing.Size(46, 46);
            this.btnOrderPause.Text = "toolStripButton5";
            // 
            // btnOrderStop
            // 
            this.btnOrderStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOrderStop.Image = global::FrontEnd.Properties.Resources.Gnome_media_playback_stop_svg;
            this.btnOrderStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOrderStop.Name = "btnOrderStop";
            this.btnOrderStop.Size = new System.Drawing.Size(46, 46);
            this.btnOrderStop.Text = "toolStripButton6";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 49);
            // 
            // btnOrderEdit
            // 
            this.btnOrderEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOrderEdit.Image = global::FrontEnd.Properties.Resources._240px_Gnome_accessories_text_editor_svg;
            this.btnOrderEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOrderEdit.Name = "btnOrderEdit";
            this.btnOrderEdit.Size = new System.Drawing.Size(46, 46);
            this.btnOrderEdit.Text = "toolStripButton1";
            // 
            // btnOrderRemove
            // 
            this.btnOrderRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOrderRemove.Image = global::FrontEnd.Properties.Resources.Gnome_user_trash_full_svg;
            this.btnOrderRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOrderRemove.Name = "btnOrderRemove";
            this.btnOrderRemove.Size = new System.Drawing.Size(46, 46);
            this.btnOrderRemove.Text = "toolStripButton7";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.ItemSize = new System.Drawing.Size(58, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 80);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1184, 593);
            this.tabControl1.TabIndex = 3;
            // 
            // dgvTab1_2
            // 
            this.dgvTab1_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTab1_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTab1_2.Location = new System.Drawing.Point(0, 0);
            this.dgvTab1_2.Name = "dgvTab1_2";
            this.dgvTab1_2.ReadOnly = true;
            this.dgvTab1_2.Size = new System.Drawing.Size(1170, 152);
            this.dgvTab1_2.TabIndex = 0;
            // 
            // btnOrderAdd
            // 
            this.btnOrderAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOrderAdd.Image = global::FrontEnd.Properties.Resources.Gnome_window_new_svg;
            this.btnOrderAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOrderAdd.Name = "btnOrderAdd";
            this.btnOrderAdd.Size = new System.Drawing.Size(46, 46);
            this.btnOrderAdd.Text = "toolStripButton1";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1176, 555);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Realtime data";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            this.toolStripTab1.ResumeLayout(false);
            this.toolStripTab1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTab1_2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton btnTest;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem bestandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afsluitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnApplicationInfo;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.TabPage tabPage2;
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
    }
}

