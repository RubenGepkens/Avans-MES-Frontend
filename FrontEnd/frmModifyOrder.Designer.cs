
namespace FrontEnd
{
    partial class frmModifyOrder
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxOrdername = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOrdernumber = new System.Windows.Forms.TextBox();
            this.dtpOrderStartDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxProductionLine = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOrderize = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxRecipe = new System.Windows.Forms.ComboBox();
            this.ckxExtraRecipe = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxRecipeExtra = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOrderizeExtra = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxProductionLineExtra = new System.Windows.Forms.ComboBox();
            this.dtpOrderEndDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderize)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderizeExtra)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(12, 439);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Accepteer";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(226, 439);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Annuleer";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpOrderEndDate);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbxOrdername);
            this.groupBox1.Controls.Add(this.txtOrdernumber);
            this.groupBox1.Controls.Add(this.dtpOrderStartDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 190);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Algemene gegevens";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(105, 94);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 20);
            this.txtDescription.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ordernaam:";
            // 
            // cbxOrdername
            // 
            this.cbxOrdername.FormattingEnabled = true;
            this.cbxOrdername.Location = new System.Drawing.Point(105, 41);
            this.cbxOrdername.Name = "cbxOrdername";
            this.cbxOrdername.Size = new System.Drawing.Size(200, 21);
            this.cbxOrdername.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Productielijn:";
            // 
            // txtOrdernumber
            // 
            this.txtOrdernumber.Location = new System.Drawing.Point(105, 68);
            this.txtOrdernumber.Name = "txtOrdernumber";
            this.txtOrdernumber.Size = new System.Drawing.Size(200, 20);
            this.txtOrdernumber.TabIndex = 1;
            // 
            // dtpOrderStartDate
            // 
            this.dtpOrderStartDate.CustomFormat = "dd-MM-yyyy HH:mm";
            this.dtpOrderStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderStartDate.Location = new System.Drawing.Point(105, 121);
            this.dtpOrderStartDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpOrderStartDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpOrderStartDate.Name = "dtpOrderStartDate";
            this.dtpOrderStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtpOrderStartDate.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Starttijd:";
            // 
            // cbxProductionLine
            // 
            this.cbxProductionLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProductionLine.FormattingEnabled = true;
            this.cbxProductionLine.Location = new System.Drawing.Point(105, 19);
            this.cbxProductionLine.Name = "cbxProductionLine";
            this.cbxProductionLine.Size = new System.Drawing.Size(200, 21);
            this.cbxProductionLine.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Beschrijving:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ordernummer:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Aantal:";
            // 
            // txtOrderize
            // 
            this.txtOrderize.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtOrderize.Location = new System.Drawing.Point(105, 73);
            this.txtOrderize.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtOrderize.Name = "txtOrderize";
            this.txtOrderize.Size = new System.Drawing.Size(200, 20);
            this.txtOrderize.TabIndex = 1;
            this.txtOrderize.ThousandsSeparator = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cbxProductionLineExtra);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cbxRecipeExtra);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtOrderizeExtra);
            this.groupBox2.Controls.Add(this.ckxExtraRecipe);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbxRecipe);
            this.groupBox2.Controls.Add(this.cbxProductionLine);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtOrderize);
            this.groupBox2.Location = new System.Drawing.Point(12, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 225);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ordergegevens";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Recept:";
            // 
            // cbxRecipe
            // 
            this.cbxRecipe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRecipe.FormattingEnabled = true;
            this.cbxRecipe.Location = new System.Drawing.Point(105, 46);
            this.cbxRecipe.Name = "cbxRecipe";
            this.cbxRecipe.Size = new System.Drawing.Size(200, 21);
            this.cbxRecipe.TabIndex = 0;
            // 
            // ckxExtraRecipe
            // 
            this.ckxExtraRecipe.AutoSize = true;
            this.ckxExtraRecipe.Location = new System.Drawing.Point(6, 113);
            this.ckxExtraRecipe.Name = "ckxExtraRecipe";
            this.ckxExtraRecipe.Size = new System.Drawing.Size(254, 17);
            this.ckxExtraRecipe.TabIndex = 8;
            this.ckxExtraRecipe.Text = "Extra recept toevoegen (alleen aanmaken order)";
            this.ckxExtraRecipe.UseVisualStyleBackColor = true;
            this.ckxExtraRecipe.CheckStateChanged += new System.EventHandler(this.ckxExtraRecipe_CheckStateChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Recept:";
            // 
            // cbxRecipeExtra
            // 
            this.cbxRecipeExtra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRecipeExtra.Enabled = false;
            this.cbxRecipeExtra.FormattingEnabled = true;
            this.cbxRecipeExtra.Location = new System.Drawing.Point(105, 163);
            this.cbxRecipeExtra.Name = "cbxRecipeExtra";
            this.cbxRecipeExtra.Size = new System.Drawing.Size(200, 21);
            this.cbxRecipeExtra.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Aantal:";
            // 
            // txtOrderizeExtra
            // 
            this.txtOrderizeExtra.Enabled = false;
            this.txtOrderizeExtra.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtOrderizeExtra.Location = new System.Drawing.Point(105, 190);
            this.txtOrderizeExtra.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtOrderizeExtra.Name = "txtOrderizeExtra";
            this.txtOrderizeExtra.Size = new System.Drawing.Size(200, 20);
            this.txtOrderizeExtra.TabIndex = 10;
            this.txtOrderizeExtra.ThousandsSeparator = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 139);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Productielijn:";
            this.label10.Visible = false;
            // 
            // cbxProductionLineExtra
            // 
            this.cbxProductionLineExtra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProductionLineExtra.Enabled = false;
            this.cbxProductionLineExtra.FormattingEnabled = true;
            this.cbxProductionLineExtra.Location = new System.Drawing.Point(105, 136);
            this.cbxProductionLineExtra.Name = "cbxProductionLineExtra";
            this.cbxProductionLineExtra.Size = new System.Drawing.Size(200, 21);
            this.cbxProductionLineExtra.TabIndex = 13;
            this.cbxProductionLineExtra.Visible = false;
            // 
            // dtpOrderEndDate
            // 
            this.dtpOrderEndDate.CustomFormat = "dd-MM-yyyy HH:mm";
            this.dtpOrderEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderEndDate.Location = new System.Drawing.Point(105, 147);
            this.dtpOrderEndDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpOrderEndDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpOrderEndDate.Name = "dtpOrderEndDate";
            this.dtpOrderEndDate.Size = new System.Drawing.Size(200, 20);
            this.dtpOrderEndDate.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 151);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Eindtijd:";
            // 
            // frmModifyOrder
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(348, 474);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmModifyOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmModifyOrder";
            this.Load += new System.EventHandler(this.frmModifyOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderize)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderizeExtra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpOrderStartDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtOrderize;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxProductionLine;
        private System.Windows.Forms.TextBox txtOrdernumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxRecipe;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox cbxOrdername;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxRecipeExtra;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown txtOrderizeExtra;
        private System.Windows.Forms.CheckBox ckxExtraRecipe;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxProductionLineExtra;
        private System.Windows.Forms.DateTimePicker dtpOrderEndDate;
        private System.Windows.Forms.Label label11;
    }
}