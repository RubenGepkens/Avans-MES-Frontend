/*
 * DAB2_F1_dbViewer - frmLogin
 * 
 * Avans Hogeschool 's-Hertogenbosch - (c)2020
 * Databases 2 - leerjaar 2 - BLOK 7
 * 
 * Door:                Studentnummer:
 * Ruben Gepkens        2137822    
 * Roel Graat           2145328
 * Casper de Bruin      2123618
 * 
 * frmLogin door:   Ruben Gepkens.
 * Datum:           20-3-2020
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Bron:    https://www.youtube.com/watch?v=8aDsXyiBLsI
//          https://stackoverflow.com/questions/453161/how-can-i-save-application-settings-in-a-windows-forms-application
//          https://stackoverflow.com/questions/4051302/which-passwordchar-shows-a-black-dot-in-a-winforms-textbox/7285282#7285282

namespace DAB2_F1_dbViewer
{
    public partial class frmLogin : Form
    {
        public string gebruikersnaam { get; set; }
        public string wachtwoord { get; set; }
        public string serverAdres { get; set; }
        public string serverPoort { get; set; }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //txtGebruikersnaam.Text          = Properties.Settings.Default.laatsteGebruikersnaam;
            //txtServerAdres.Text             = Properties.Settings.Default.laatsteServerAdres;
            //txtServerPoort.Text             = Properties.Settings.Default.laatsteServerPoort;
            //cbxWachtwoordOnthouden.Checked  = Properties.Settings.Default.wachtwoordOnthouden;

            if ( cbxWachtwoordOnthouden.Checked == true)
            {
               // txtWachtwoord.Text          = Properties.Settings.Default.laatsteWachtwoord;
            }
        }

        private void btnAnnuleer_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (cbxWachtwoordOnthouden.Checked == true)
            {
                //Properties.Settings.Default.laatsteWachtwoord = txtWachtwoord.Text;
            }
            else
            {
                //Properties.Settings.Default.laatsteWachtwoord = "";
            }

            //Properties.Settings.Default.laatsteGebruikersnaam = txtGebruikersnaam.Text;
            //Properties.Settings.Default.laatsteServerAdres = txtServerAdres.Text;
            //Properties.Settings.Default.laatsteServerPoort = txtServerPoort.Text;
            //Properties.Settings.Default.wachtwoordOnthouden = cbxWachtwoordOnthouden.Checked;
            //Properties.Settings.Default.Save();

            gebruikersnaam  = txtGebruikersnaam.Text;
            wachtwoord      = txtWachtwoord.Text;
            serverAdres     = txtServerAdres.Text;
            serverPoort     = txtServerPoort.Text;

            Close();
        }
    }
}
