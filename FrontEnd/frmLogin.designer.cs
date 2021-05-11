namespace FrontEnd
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGebruikersnaam = new System.Windows.Forms.TextBox();
            this.btnAnnuleer = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtWachtwoord = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtServerAdres = new System.Windows.Forms.TextBox();
            this.txtServerPoort = new System.Windows.Forms.TextBox();
            this.cbxWachtwoordOnthouden = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Gebruikersnaam:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Wachtwoord:";
            // 
            // txtGebruikersnaam
            // 
            this.txtGebruikersnaam.Location = new System.Drawing.Point(105, 32);
            this.txtGebruikersnaam.Name = "txtGebruikersnaam";
            this.txtGebruikersnaam.Size = new System.Drawing.Size(156, 20);
            this.txtGebruikersnaam.TabIndex = 1;
            // 
            // btnAnnuleer
            // 
            this.btnAnnuleer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnuleer.Location = new System.Drawing.Point(332, 109);
            this.btnAnnuleer.Name = "btnAnnuleer";
            this.btnAnnuleer.Size = new System.Drawing.Size(75, 23);
            this.btnAnnuleer.TabIndex = 6;
            this.btnAnnuleer.Text = "Annuleer";
            this.btnAnnuleer.UseVisualStyleBackColor = true;
            this.btnAnnuleer.Click += new System.EventHandler(this.btnAnnuleer_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLogin.Location = new System.Drawing.Point(251, 109);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtWachtwoord
            // 
            this.txtWachtwoord.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWachtwoord.Location = new System.Drawing.Point(105, 58);
            this.txtWachtwoord.Name = "txtWachtwoord";
            this.txtWachtwoord.PasswordChar = '●';
            this.txtWachtwoord.Size = new System.Drawing.Size(156, 20);
            this.txtWachtwoord.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Adres:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Poort:";
            // 
            // txtServerAdres
            // 
            this.txtServerAdres.Location = new System.Drawing.Point(105, 6);
            this.txtServerAdres.Name = "txtServerAdres";
            this.txtServerAdres.Size = new System.Drawing.Size(303, 20);
            this.txtServerAdres.TabIndex = 0;
            // 
            // txtServerPoort
            // 
            this.txtServerPoort.Location = new System.Drawing.Point(308, 32);
            this.txtServerPoort.Name = "txtServerPoort";
            this.txtServerPoort.Size = new System.Drawing.Size(100, 20);
            this.txtServerPoort.TabIndex = 2;
            // 
            // cbxWachtwoordOnthouden
            // 
            this.cbxWachtwoordOnthouden.AutoSize = true;
            this.cbxWachtwoordOnthouden.Location = new System.Drawing.Point(105, 84);
            this.cbxWachtwoordOnthouden.Name = "cbxWachtwoordOnthouden";
            this.cbxWachtwoordOnthouden.Size = new System.Drawing.Size(141, 17);
            this.cbxWachtwoordOnthouden.TabIndex = 4;
            this.cbxWachtwoordOnthouden.Text = "Wachtwoord onthouden";
            this.cbxWachtwoordOnthouden.UseVisualStyleBackColor = true;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnuleer;
            this.ClientSize = new System.Drawing.Size(419, 144);
            this.Controls.Add(this.cbxWachtwoordOnthouden);
            this.Controls.Add(this.txtServerPoort);
            this.Controls.Add(this.txtServerAdres);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWachtwoord);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnAnnuleer);
            this.Controls.Add(this.txtGebruikersnaam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(316, 133);
            this.Name = "frmLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Database verbinding instellen..";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGebruikersnaam;
        private System.Windows.Forms.Button btnAnnuleer;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtWachtwoord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtServerAdres;
        private System.Windows.Forms.TextBox txtServerPoort;
        private System.Windows.Forms.CheckBox cbxWachtwoordOnthouden;
    }
}