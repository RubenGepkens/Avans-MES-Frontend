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
			Console.WriteLine("frmMain_Shown(object sender, EventArgs e)");
			/*
			// Debug info
			Console.WriteLine("connectionString: {0}", Properties.Settings.Default.connectionString);
			Console.WriteLine("lastUsername: {0}", Properties.Settings.Default.lastUsername);
			Console.WriteLine("lastPassword: {0}", Properties.Settings.Default.lastPassword);
			Console.WriteLine("lastServerAddress: {0}", Properties.Settings.Default.lastServerAddress);
			Console.WriteLine("lastServerPort: {0}", Properties.Settings.Default.lastServerPort);
			*/

			// Check if the application has connection information set and if not, open the dialog.
			establishConnection();
		}

		/// <summary>
		/// Check if the application has connection information set and then attempt to make a connection.
		/// If no connection information has been entered, open a dialog and let the user enter it.
		/// </summary>
		private bool establishConnection()
        {
			Console.WriteLine("frmMain - establishConnection()");

			if (String.IsNullOrWhiteSpace(Properties.Settings.Default.connectionString) |
				String.IsNullOrWhiteSpace(Properties.Settings.Default.lastUsername) |
				String.IsNullOrWhiteSpace(Properties.Settings.Default.lastPassword) |
				String.IsNullOrWhiteSpace(Properties.Settings.Default.lastServerAddress) |
				String.IsNullOrWhiteSpace(Properties.Settings.Default.lastServerPort)
			)
			{
				// No prior (successfull) database connection established, let the user input the connection settings.
				Console.WriteLine("establishConnection() ; IsNullOrWhiteSpace");
				enterConnectionSettings();
				checkConnectionSettings();
			} else
            {
				checkConnectionSettings();
			}
			return false;
        }

		/// <summary>
		/// Dialog for allowing user to enter the database connection settings suchs as address, port, username etc..
		/// </summary>
		private void enterConnectionSettings()
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
					Properties.Settings.Default.Save();
				}
			}
		}

		/// <summary>
		/// Check if a database connection can be established.
		/// </summary>
		/// <returns>True if connection succeeded and False if not.</returns>
		private bool checkConnectionSettings()
        {
			Console.WriteLine("frmMain - checkConnectionSettings()");

			string strLblStatus = lblStatus.Text;
			lblStatus.Text = "Verbinding maken, even geduld..";
			UseWaitCursor = true;

			bool blnCheckConnection = sqlData.checkConnection();

			if ( blnCheckConnection )
            {
				databaseConnectionEstablished();
            } else
            {
				databaseConnectionLost();
            }

			UseWaitCursor = false;
			//lblStatus.Text = strLblStatus;
			return blnCheckConnection;
		}

		/// <summary>
		/// Unlock the toolbarbuttons and updates the statusstrip.
		/// </summary>
		private void databaseConnectionEstablished()
		{
			// Initialize the list information in SqlClass.
			sqlData.initializeGlobalData();

			// Update statuslabel in the frmMain UI.
			lblStatus.Text = "Verbonden";
			lblStatus.Image = FrontEnd.Properties.Resources.Gnome_network_idle_svg;
			sqlData.blnConnectionStatus = true;

			// Unlock the UI controls that require SQL queries.
			btnTest.Enabled = true;
			btnConnect.Enabled = false;
			btnMnuConnect.Enabled = false;

			txtOrdernumber.Enabled = true;
			btnClearOrderFilter.Enabled = true;
			cbxProductionLine.Enabled = true;
			cbxProductionLine.SelectedIndex = 0;
			cbxOrderStatus.Enabled = true;
			cbxOrderStatus.SelectedIndex = 0;
			btnReleaseOrder.Enabled = true;
			btnOrderStart.Enabled = true;
			btnOrderPause.Enabled = true;
			btnOrderStop.Enabled = true;
			btnOrderAdd.Enabled = true;
			btnOrderEdit.Enabled = true;
			btnOrderRemove.Enabled = true;

			// Set up the data filters
			initializeFilters();
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
			btnConnect.Enabled = true;
			btnMnuConnect.Enabled = true;

			txtOrdernumber.Enabled = false;
			btnClearOrderFilter.Enabled = false;
			cbxProductionLine.Enabled = false;
			cbxProductionLine.SelectedIndex = 0;
			cbxOrderStatus.Enabled = false;
			cbxOrderStatus.SelectedIndex = 0;
			btnReleaseOrder.Enabled = false;
			btnOrderStart.Enabled = false;
			btnOrderPause.Enabled = false;
			btnOrderStop.Enabled = false;
			btnOrderAdd.Enabled = false;
			btnOrderEdit.Enabled = false;
			btnOrderRemove.Enabled = false;
		}

		/// <summary>
		/// Reset application settings.
		/// </summary>
		void resetSettings()
		{
			var msgBxResult = MessageBox.Show("Weet je zeker dat je de gebruikersinstellingen wilt resetten?", "Gebruikersinstellingen resetten?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if ( msgBxResult == DialogResult.Yes )
			{
				Properties.Settings.Default.Reset();
			}
		}

		/// <summary>
		/// Example function showing how to use the sqlData class for excecuting SQL queries.
		/// </summary>
		void getExampleData()
        {
			sqlData.exampleFunction(dgvTab1);
		}

		/// <summary>
		/// Retrieve production orders and allow for filtering based on production line and order status.
		/// </summary>
		void getOrderData()
        {
			sqlData.getOrders(dgvTab1, txtOrdernumber.Text, cbxProductionLine.Text, cbxOrderStatus.Text);			
        }

		/// <summary>
		/// Prepares all filters for use. Retrieves available filter options from the database and sets the comboboxes.
		/// </summary>
		void initializeFilters()
        {
			// Retrieve all production lines and order statusses.
			//sqlData.lstProductionlines = sqlData.getProductionlines();
			//sqlData.lstOrderstatusses = sqlData.getOrderStatusses();

			// Clear the comboboxes
			cbxProductionLine.Items.Clear();
			cbxOrderStatus.Items.Clear();

			// Add an empty item to use as an empty filter.
			cbxProductionLine.Items.Add("");
			cbxOrderStatus.Items.Add("");

			// Add each item from the list to the combobox control.
			foreach (string strListItem in sqlData.lstProductionlines)
            {
				cbxProductionLine.Items.Add(strListItem);
            }

			// Add each item from the list to the combobox control.
			foreach (string strListItem in sqlData.lstOrderstatusses)
            {
				cbxOrderStatus.Items.Add(strListItem);
            }
		}


		// =========================================================================================================================================================================================


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

		private void btnApplicationInfo_Click(object sender, EventArgs e)
        {
			Form frmAboutbox = new frmAboutBox();
			frmAboutbox.Show();			
		}

        private void afsluitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Close();			
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
			establishConnection();
		}

		private void btnMnuConnect_Click(object sender, EventArgs e)
		{
			establishConnection();
		}

		private void btnSettings_Click(object sender, EventArgs e)
		{
			// Allow user to modify the connectionsettings.
			enterConnectionSettings();
		}

		private void btnMnuSettings_Click(object sender, EventArgs e)
		{
			// Allow user to modify the connectionsettings.
			enterConnectionSettings();
		}

		private void btnTest_Click(object sender, EventArgs e) // Example function used to demonstrate how a DataGridView can be filled.
		{
			foreach ( string ding in sqlData.lstCustomers)
            {
				lstbxCustomers.Items.Add(ding);
            }

			foreach ( string ding in sqlData.lstRecipes)
            {
				lstbxRecipes.Items.Add(ding);
            }

			foreach ( string ding in sqlData.lstProductionlines)
            {
				lstbxProductionlines.Items.Add(ding);
            }

			foreach ( string ding in sqlData.lstOrderstatusses)
            {
				lstbxOrderstatusses.Items.Add(ding);
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
			string strOrdernumber;
			string strCustomerName;
			string strOrderDate;
			string strSelectedRecipe;

			// Retrieve the highest order number and add 1
			string T_strOrdernumber = dgvTab1.Rows[0].Cells[0].Value.ToString();			// retrieve the highest order number from datagridview
			T_strOrdernumber = T_strOrdernumber.Substring(2, T_strOrdernumber.Length-2);	// slice off the 'OS' at the start of the string
			int T_intOrdernumber;
			int.TryParse(T_strOrdernumber, out T_intOrdernumber);                           // Parse the string to convert the number part to int.
			strOrdernumber = "SO" + (T_intOrdernumber + 1).ToString();						// Add 'SO' to the start of the ordernumber string
			

			using ( frmModifyOrder frmModifyOrder = new frmModifyOrder() )
			{
				// Preload variables before the form is shown to the user.
				frmModifyOrder.strOrdernumber		= strOrdernumber;
				frmModifyOrder.lstRecipes			= sqlData.lstRecipes;
				frmModifyOrder.lstCustomers			= sqlData.lstCustomers;
				frmModifyOrder.lstProductionlines	= sqlData.lstProductionlines;
				frmModifyOrder.strFormTitle			= "Order toevoegen..";

				if (frmModifyOrder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					strOrdernumber		= frmModifyOrder.strOrdernumber;
					strCustomerName		= "";
					strOrderDate		= frmModifyOrder.dtOrderDate.ToString("yyyy-MM-dd");
					strSelectedRecipe	= frmModifyOrder.strSelectedRecipe;

					Console.WriteLine("OK!\t {0}\t {1}\t", strOrdernumber, strCustomerName, strOrderDate);					
				}
			}
        }

		/// <summary>
		/// Edit the currently selected order.
		/// </summary>
		private void btnOrderEdit_Click(object sender, EventArgs e)
        {
			string strOrdernumber;
			string strCustomerName;
			string strOrderDate;
			string strSelectedRecipe;

			using (frmModifyOrder frmModifyOrder = new frmModifyOrder())
			{
				// Preload variables before the form is shown to the user.
				frmModifyOrder.lstRecipes			= sqlData.lstRecipes;
				frmModifyOrder.strFormTitle			= "Order bewerken..";

				// Preload the order data before the form is shown.
				frmModifyOrder.strOrdernumber		= "1000";					// PLACEHOLDER - TODO
				frmModifyOrder.strSelectedCustomer	= "Jumbo b.v.";         // PLACEHOLDER - TODO
				frmModifyOrder.dtOrderDate			= DateTime.Now;         // PLACEHOLDER - TODO
				frmModifyOrder.strSelectedRecipe	= "Witbrood";           // PLACEHOLDER - TODO

				// Display form and if dialog is accepted (when ShowDialog() == DialogResult.OK), retrieve the modified data for further processing.
				if (frmModifyOrder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					strOrdernumber					= frmModifyOrder.strOrdernumber;
					strCustomerName					= frmModifyOrder.strSelectedCustomer;
					strOrderDate					= frmModifyOrder.dtOrderDate.ToString("yyyy-MM-dd");
					strSelectedRecipe				= frmModifyOrder.strSelectedRecipe;

					Console.WriteLine("OK!\t {0}\t {1}\t", strOrdernumber, strCustomerName, strOrderDate);
				}
			}
		}

        private void btnOrderRemove_Click(object sender, EventArgs e)
        {

        }

        private void btnResetUserSettings_Click(object sender, EventArgs e)
        {
			resetSettings();
		}

        private void btnMnuResetUserSettings_Click(object sender, EventArgs e)
        {
			resetSettings();
		}

        private void btnClearOrderFilter_Click(object sender, EventArgs e)
        {
			txtOrdernumber.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
			getOrderData();
		}

        private void txtOrdernumber_TextChanged(object sender, EventArgs e)
        {
			getOrderData();
		}

        private void cbxProductionLine_SelectedIndexChanged(object sender, EventArgs e)
        {
			getOrderData();
		}

        private void cbxOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
			getOrderData();
		}

        private void tESTToolStripMenuItem_Click(object sender, EventArgs e)
        {
			OPC opc = new OPC();			
        }
    }
}