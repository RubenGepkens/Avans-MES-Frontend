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
 * Wes Verhagen			2135682
 * Maurits Duel			2142917
 * Leon van Elteren		2136163
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
	 * 
	 * Walkthrough: Handling Errors that Occur During Data Entry in the Windows Forms DataGridView Control
	 * https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/handling-errors-that-occur-during-data-entry-in-the-datagrid?view=netframeworkdesktop-4.8
	 * 
	 * SQL Encryption
	 * https://stackoverflow.com/questions/3674160/using-encrypt-yes-in-a-sql-server-connection-string-provider-ssl-provider
	 * 
	 * Connection Strings and Configuration Files
	 * https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/connection-strings-and-configuration-files?redirectedfrom=MSDN
	 */

	public partial class frmMain : Form
	{
		// Manier om sql te herbruiken.
		private SqlData sqlData = new SqlData();

		public frmMain()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{			
			// Locks all buttons and controls before the form is presented to the user.
			databaseConnectionLost();
		}

		private void frmMain_Shown(object sender, EventArgs e)
		{
			// Check if the application has connection information set and if not, open the dialog.
			establishConnection();
		}

		/// <summary>
		/// Check if the application has connection information set and then attempt to make a connection.
		/// If no connection information has been entered, open a dialog and let the user enter it.
		/// </summary>
		private bool establishConnection()
        {
			if (String.IsNullOrWhiteSpace(Properties.Settings.Default.connectionString) |
				String.IsNullOrWhiteSpace(Properties.Settings.Default.lastUsername) |
				String.IsNullOrWhiteSpace(Properties.Settings.Default.lastPassword) |
				String.IsNullOrWhiteSpace(Properties.Settings.Default.lastServerAddress) |
				String.IsNullOrWhiteSpace(Properties.Settings.Default.lastServerPort)
			)
			{
				// No prior (successfull) database connection established, let the user input the connection settings.
				connectionSettings();
			} else
            {
				// Attempt connection
				if (sqlData.checkConnection())
				{
					databaseConnectionEstablished();
				}
				else
				{
					databaseConnectionLost();
				}
			}
			return false;
        }

		private void connectionSettings()
        {
			using (frmLogin frmLogin = new frmLogin())
			{
				DialogResult result = frmLogin.ShowDialog();

				if (result == System.Windows.Forms.DialogResult.OK)
				{
					// Form SQL connection string.
					string strConnection = "Server=" + frmLogin.serverAdres + "," + frmLogin.serverPoort + "; Database=Avans_ISA95; User Id=" + frmLogin.gebruikersnaam + "; Password=" + frmLogin.wachtwoord
						+ "; Encrypt=True; TrustServerCertificate=True";
					// Save connectionstring
					Properties.Settings.Default.connectionString = strConnection;

					if (sqlData.checkConnection())
					{
						databaseConnectionEstablished();
					}
					else
					{
						databaseConnectionLost();
					}

				}
			}
		}

		/// <summary>
		/// Unlock the tolbarbuttons and updates the statusstrip.
		/// </summary>
		private void databaseConnectionEstablished()
		{
			lblStatus.Text = "Verbonden";
			lblStatus.Image = FrontEnd.Properties.Resources.Gnome_network_idle_svg;
			sqlData.blnConnectionStatus = true;

			// Unlock controls that require SQL queries
			btnTest.Enabled = true;

			cbxProductionLine.Enabled = true;
			cbxProductionLine.SelectedIndex = 0;
			btnOrderStart.Enabled = true;
			btnOrderPause.Enabled = true;
			btnOrderStop.Enabled = true;
			btnOrderAdd.Enabled = true;
			btnOrderEdit.Enabled = true;
			btnOrderRemove.Enabled = true;
		}

		/// <summary>
		/// Locks the toolbarbuttons and updates the statusstrip.
		/// </summary>
		private void databaseConnectionLost()
		{
			lblStatus.Text = "Geen verbinding";
			lblStatus.Image = FrontEnd.Properties.Resources.Gnome_network_offline_svg;
			sqlData.blnConnectionStatus = false;

			// Lock controls that require SQL queries, preventing queries to be fired when database connectivity has not been checked.
			btnTest.Enabled = false;

			cbxProductionLine.Enabled = false;
			cbxProductionLine.Text = "Geen selectie";
			btnOrderStart.Enabled = false;
			btnOrderPause.Enabled = false;
			btnOrderStop.Enabled = false;
			btnOrderAdd.Enabled = false;
			btnOrderEdit.Enabled = false;
			btnOrderRemove.Enabled = false;
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
					string strConnection = "Server=" + frmLogin.serverAdres + "," + frmLogin.serverPoort + "; Database=Avans_ISA95; User Id=" + frmLogin.gebruikersnaam + "; Password=" + frmLogin.wachtwoord
						+ "; Encrypt=True; TrustServerCertificate=True";
					// Save connectionstring
					Properties.Settings.Default.connectionString = strConnection;
					
					//SqlData SqlData = new SqlData();					
					if (sqlData.checkConnection())
                    {
						databaseConnectionEstablished();
                    } else
                    {
						databaseConnectionLost();
                    }
				}	
			}
		}

        private void btnTest_Click(object sender, EventArgs e) // Example function used to demonstrate how a DataGridView can be filled.
		{
			SqlData SqlData = new SqlData();
			SqlData.exampleFunction(dgvTab1);			
		}

		/// <summary>
		/// Without this exceptionhandler the DataGridView will crash the application.
		/// Handle the exception and show a dialog if it occurs.
		/// </summary>
		private void dgvTab1_DataError(object sender, DataGridViewDataErrorEventArgs e) // Exception handler for DataGridView
		{			
			if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
			{				
				MessageBox.Show("Exception message: " + e.Exception.Message, "E200", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void btnOrderStart_Click(object sender, EventArgs e)
        {

        }

        private void btnOrderPause_Click(object sender, EventArgs e)
        {

        }

        private void btnOrderStop_Click(object sender, EventArgs e)
        {

        }

		/// <summary>
		/// Open the new order dialog and process results, i.e. send the new order to the database.
		/// </summary>
		private void btnOrderAdd_Click(object sender, EventArgs e)
        {
			int intBatchNumber;
			string strCustomerName;
			string strOrderDate;
			//List<string> lstRecipes = new List<string>{ "Witbrood", "Bruinbrood", "Herman Brood" };  // TODO: storedprocedure/functie voor 'getRecipes'
			List<string> lstRecipes = sqlData.getRecipes();
			string strSelectedRecipe;

			using ( frmModifyOrder frmModifyOrder = new frmModifyOrder() )
			{
				// Preload variables before the form is shown to the user.
				frmModifyOrder.lstRecipes		= lstRecipes;
				frmModifyOrder.strFormTitle		= "Order toevoegen..";

				if (frmModifyOrder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					intBatchNumber		= frmModifyOrder.intBatchNumber;
					strCustomerName		= frmModifyOrder.strCustomerName;
					strOrderDate		= frmModifyOrder.dtOrderDate.ToString("yyyy-MM-dd");
					strSelectedRecipe	= frmModifyOrder.strSelectedRecipe;

					Console.WriteLine("OK!\t {0}\t {1}\t", intBatchNumber, strCustomerName, strOrderDate);					
				}
			}
        }

		/// <summary>
		/// Edit the currently selected order.
		/// </summary>
		private void btnOrderEdit_Click(object sender, EventArgs e)
        {
			int intBatchNumber;
			string strCustomerName;
			string strOrderDate;
			List<string> lstRecipes = sqlData.getRecipes();
			string strSelectedRecipe;

			using (frmModifyOrder frmModifyOrder = new frmModifyOrder())
			{
				// Preload variables before the form is shown to the user.
				frmModifyOrder.lstRecipes			= lstRecipes;
				frmModifyOrder.strFormTitle			= "Order bewerken..";

				// Preload the order data before the form is shown.
				frmModifyOrder.intBatchNumber		= 1000;					// PLACEHOLDER - TODO
				frmModifyOrder.strCustomerName		= "Jumbo b.v.";         // PLACEHOLDER - TODO
				frmModifyOrder.dtOrderDate			= DateTime.Now;         // PLACEHOLDER - TODO
				frmModifyOrder.strSelectedRecipe	= "Witbrood";           // PLACEHOLDER - TODO

				// Display form and if dialog is accepted (when ShowDialog() == DialogResult.OK), retrieve the modified data for further processing.
				if (frmModifyOrder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					intBatchNumber					= frmModifyOrder.intBatchNumber;
					strCustomerName					= frmModifyOrder.strCustomerName;
					strOrderDate					= frmModifyOrder.dtOrderDate.ToString("yyyy-MM-dd");
					strSelectedRecipe				= frmModifyOrder.strSelectedRecipe;

					Console.WriteLine("OK!\t {0}\t {1}\t", intBatchNumber, strCustomerName, strOrderDate);
				}
			}
		}

        private void btnOrderRemove_Click(object sender, EventArgs e)
        {

        }
    }
}
