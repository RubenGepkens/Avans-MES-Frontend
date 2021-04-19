/*
 * MOMS2 Frontend - frmMain
 * 
 * Avans Hogeschool 's-Hertogenbosch - (c)2021
 * MOMS3 - leerjaar 3 - BLOK 12
 * 
 * Manufacturing execution system (MES) voor het vak MOMS2. Bedrijfproject met Actemium voor 'Broodbakkerij Zoete Broodjes Corp.'.
 * 
 * Door:				Studentnummer:
 * Ruben Gepkens		2137822
 * Tom Schellekens		2135695
 * Wes Verhagen			x
 * Maurits Duel			x
 * Leon van Elteren		x
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; // zelf toegevoegd
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd
{
	/*
	 * Where to put a common database connection for my classes;
	 * https://softwareengineering.stackexchange.com/questions/280333/where-to-put-a-common-database-connection-for-my-classes
	 * 
	 * Connection strings for MS SQL;
	 * https://www.connectionstrings.com/sql-server/
	 * 
	 * How to write in a DataGridView from a different class;
	 * https://stackoverflow.com/questions/40343047/how-to-write-in-a-datagridview-from-a-different-class
	 */

	public partial class frmMain : Form
	{
		private bool dbConnEstablished = false;

		public frmMain()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			databaseConnectionLost();
		}

        private void btnApplicationInfo_Click(object sender, EventArgs e)
        {
			Form frmAboutbox = new frmAboutBox();
			frmAboutbox.Show();			
		}

        private void afsluitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
			this.Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
			using (frmLogin frmLogin = new frmLogin())
            {				
				DialogResult result = frmLogin.ShowDialog();

				if (result == System.Windows.Forms.DialogResult.OK)
                {
					// Form SQL connection string.
					string strConnection = "Server=" + frmLogin.serverAdres + "," + frmLogin.serverPoort + "; Database=Avans_ISA95; User Id=" + frmLogin.gebruikersnaam + "; Password=" + frmLogin.wachtwoord;
					// Save connectionstring
					Properties.Settings.Default.connectionString = strConnection;

					SqlCommand SqlCommand = new SqlCommand();					
					if (SqlCommand.checkConnection())
                    {
						databaseConnectionEstablished();
                    } else
                    {
						databaseConnectionLost();
                    }
				}	
			}
		}

		private void databaseConnectionEstablished()
        {
			lblStatus.Text		= "Verbonden";
			lblStatus.Image		= FrontEnd.Properties.Resources.Gnome_network_idle_svg;
			dbConnEstablished	= true;
		}

		private void databaseConnectionLost()
        {
			lblStatus.Text		= "Geen verbinding";
			lblStatus.Image		= FrontEnd.Properties.Resources.Gnome_network_offline_svg;
			dbConnEstablished	= false;
		}

        private void btnTest_Click(object sender, EventArgs e)
        {

        }
    }
}
