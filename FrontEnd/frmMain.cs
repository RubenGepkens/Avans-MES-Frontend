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
using System.Media;

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
		// SQL database class
		private SqlData sqlData = new SqlData();

		// Object for use with the OPC server
		private OPC objOPC;

		// List containg the update interval of the OPC data. Time in miliseconds.
		private List<int> lstOPCupdateInterval = new List<int> { 10000, 15000, 30000, 60000 };

		public frmMain()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// Locks all buttons and controls before the form is presented to the user.
			databaseConnectionLost();
			OPCConnectionLost();
		}

		private void frmMain_Shown(object sender, EventArgs e)
		{
			// Check if the application has connection information set and if not, open the dialog.
			establishConnection();
		}

		#region Database connection functions

		/// <summary>
		/// Check if the application has connection information set and then attempt to make a connection.
		/// If no connection information has been entered, open a dialog and let the user enter it.
		/// </summary>
		private bool establishConnection()
        {
			// Check if there database connection information stored in the application memory.
			if (String.IsNullOrWhiteSpace(Properties.Settings.Default.connectionString) |
				String.IsNullOrWhiteSpace(Properties.Settings.Default.lastUsername) |
				String.IsNullOrWhiteSpace(Properties.Settings.Default.lastPassword) |
				String.IsNullOrWhiteSpace(Properties.Settings.Default.lastServerAddress) |
				String.IsNullOrWhiteSpace(Properties.Settings.Default.lastServerPort)
			)
			{
				// Application memory contains no or incomplete connection information -> let the user input the connection settings.

				// Show dialog to allow user to enter connection information.
				if ( enterConnectionSettings() )
                {
					// If possible valid information was entered in the dialog, check the connection.
					checkConnectionSettings();
				}				
			} else
            {
				// Application memory *may* contain valid connection information -> validate the information by checking for a successful connection.
				checkConnectionSettings();
			}
			return false;
        }

		/// <summary>
		/// Dialog for allowing user to enter the database connection settings suchs as address, port, username etc..
		/// </summary>
		/// <returns>True if possible valid connection information was entered and False if no information was provided.</returns>
		private bool enterConnectionSettings()
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

					// Dialog was accepted, possible valid connection information was entered.
					return true;
				} else
                {
					// Dialog was not accepted, return false. 
					return false;
                }
			}
		}

		/// <summary>
		/// Check if a database connection can be established.
		/// </summary>
		/// <returns>True if connection succeeded and False if not.</returns>
		private bool checkConnectionSettings()
        {
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
			// Update statuslabel in the frmMain UI.
			lblStatus.Text = "Verbonden met de database";
			lblStatus.Image = FrontEnd.Properties.Resources.Gnome_network_idle_svg;
			sqlData.blnConnectionStatus = true;

			// Unlock the UI controls that require SQL queries.
			btnTest.Enabled = true;
			btnConnect.Enabled = false;
			btnMnuDBConnect.Enabled = false;
			btnMnuHideGUID.Enabled = true;
			btnMnuHideGUID.Checked = true;

			txtOrdernumber.Enabled = true;
			btnClearOrderFilter.Enabled = true;
			cbxProductionLine.Enabled = true;
			cbxProductionLine.SelectedIndex = 0;
			cbxOrderStatus.Enabled = true;
			cbxOrderStatus.SelectedIndex = 0;
			btnReleaseOrder.Enabled = true;
			btnOrderAdd.Enabled = true;
			btnOrderEdit.Enabled = true;
			btnOrderRemove.Enabled = true;
			btnRefresh.Enabled = true;

			// Set up the data filters
			initializeFilters();

			// Fill dgv
			getOrderData();
		}

		/// <summary>
		/// Locks the toolbarbuttons and updates the statusstrip.
		/// </summary>
		private void databaseConnectionLost()
		{
			lblStatus.Text = "Geen verbinding met de database";
			lblStatus.Image = FrontEnd.Properties.Resources.Gnome_network_offline_svg;
			sqlData.blnConnectionStatus = false;

			// Lock controls that require SQL queries, preventing queries to be fired when database connectivity has not been checked.
			btnTest.Enabled = false;
			btnConnect.Enabled = true;
			btnMnuDBConnect.Enabled = true;
			btnMnuHideGUID.Enabled = false;

			txtOrdernumber.Enabled = false;
			btnClearOrderFilter.Enabled = false;
			cbxProductionLine.Enabled = false;
			cbxProductionLine.SelectedIndex = 0;
			cbxOrderStatus.Enabled = false;
			cbxOrderStatus.SelectedIndex = 0;
			btnReleaseOrder.Enabled = false;
			btnOrderAdd.Enabled = false;
			btnOrderEdit.Enabled = false;
			btnOrderRemove.Enabled = false;
			btnRefresh.Enabled = false;
		}
		#endregion

		#region OPC connection functions

		/// <summary>
		/// Dialog for setting the OPC server connection parameters.
		/// </summary>
		/// <returns>True if dialog was accepted and False if dialog input was cancelled.</returns>
		private bool enterOPCConnectionSettings()
        {
			using ( frmOPCSettings frmOPCSettings = new frmOPCSettings())
            {
				frmOPCSettings.strServerAdress	= Properties.Settings.Default.OPCServerAddress;
				frmOPCSettings.intServerPort	= Properties.Settings.Default.OPCServerPort;

				DialogResult result = frmOPCSettings.ShowDialog();

				if ( result == DialogResult.OK)
                {
					Properties.Settings.Default.OPCServerAddress	= frmOPCSettings.strServerAdress;
					Properties.Settings.Default.OPCServerPort		= frmOPCSettings.intServerPort;
					Properties.Settings.Default.Save();
					return true;
                } else
                {
					return false;
                }
            }
        }

		/// <summary>
		/// Attempt connection with the OPC server
		/// </summary>
		private void establishOPCConnection()
        {
			UseWaitCursor = true;

			string strOPCServerAddress = Properties.Settings.Default.OPCServerAddress;
			int intOPCServerPort = Properties.Settings.Default.OPCServerPort;

			OPC tmpObjOPC = new OPC(strOPCServerAddress, intOPCServerPort);
			if (tmpObjOPC.blnConnectionStatus)
			{
				objOPC = tmpObjOPC;
				OPCConnectionEstablished();
			} else
            {
				OPCConnectionLost();
            }						
			UseWaitCursor = false;
		}

		/// <summary>
		/// Function to be executed when connection with the OPC server is made
		/// </summary>
		private void OPCConnectionEstablished()
        {
			txtOPCStatusDetails.Text = "Verbonden met OPC server: " + objOPC.strServerAddress + ":" + objOPC.intServerPort.ToString();
			txtOPCStatusDetails.BackColor = Color.LightGreen;

			lblOPCstatus.Text = "Verbonden met OPC";

			btnMnuOPCupdateInterval.Enabled = true;
			btnMnuOPCenableRealtimeData.Enabled = true;
			btnMnuOPCnotifyOnUpdate.Enabled = true;

			btnUpdateOPCdata.Enabled = true;

			btnOrderStart.Enabled = false;
			btnOrderPause.Enabled = true;
			btnOrderStop.Enabled = true;			

			SystemSounds.Beep.Play();
			tabControl1.SelectedIndex = 1;

			getOrderData();
		}

		/// <summary>
		/// Function to be executed when connection with the OPC server is lost
		/// </summary>
		private void OPCConnectionLost()
        {
			txtOPCStatusDetails.Text = "Niet verbonden";
			txtOPCStatusDetails.BackColor = SystemColors.Control;

			lblOPCstatus.Text = "Geen verbinding met OPC";

			btnMnuOPCupdateInterval.Enabled = false;
			btnMnuOPCenableRealtimeData.Enabled = false;
			cbxMnuOPCupdateInterval.SelectedIndex = 3;
			btnMnuOPCnotifyOnUpdate.Enabled = false;

			btnOrderStart.Enabled = false;
			btnOrderPause.Enabled = false;
			btnOrderStop.Enabled = false;

			txtOPCrealtimeStatus.Text = "Niet geactiveerd";
			btnUpdateOPCdata.Enabled = false;
		}

		#endregion

		#region General application functions

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
		/// Retrieve production orders and allow for filtering based on production line and order status.
		/// </summary>
		void getOrderData()
        {
			if (sqlData.blnConnectionStatus)
            {
				sqlData.GetOrders(dgvTab1, txtOrdernumber.Text, cbxProductionLine.Text, cbxOrderStatus.Text);
			}			
        }

		/// <summary>
		/// Prepares all filters for use. Retrieves available filter options from the database and sets the comboboxes.
		/// </summary>
		void initializeFilters()
        {
			// Initialize the list information in SqlClass.
			sqlData.InitializeGlobalData();

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

		/// <summary>
		/// Retrieves realtime production data from the OPC server.
		/// Data is displayed on the "Realtime data" tab of the tabcontrol.
		/// </summary>
		private void GetRealtimeOPCData()
        {
			if (objOPC != null && objOPC.blnConnectionStatus)
			{
				List<string> lstTemp = objOPC.GetRealtimeData();

				if (btnMnuOPCnotifyOnUpdate.Checked)
				{
					SystemSounds.Beep.Play();
				}

				// PackML Line 1
				txtLine1M1PackML.Text	= lstTemp[0];
				txtLine1M2PackML.Text	= lstTemp[1];
				txtLine1M3PackML.Text	= lstTemp[2];

				// PackML Line 2
				txtLine2M1PackML.Text	= lstTemp[3];
				txtLine2M2PackML.Text	= lstTemp[4];
				txtLine2M3PackML.Text	= lstTemp[5];

				// Productiondata line 1
				txtLine1M1Parts.Text	= lstTemp[6];
				txtLine1M2Baked.Text	= lstTemp[7];
				txtLine1M2Rejected.Text = lstTemp[8];
				txtLine1M3Packed.Text	= lstTemp[9];
				txtLine1M3Rejected.Text = lstTemp[10];

				// Productiondata line 1
				txtLine2M1Parts.Text	= lstTemp[11];
				txtLine2M2Baked.Text	= lstTemp[12];
				txtLine2M2Rejected.Text = lstTemp[13];
				txtLine2M3Packed.Text	= lstTemp[14];
				txtLine2M3Rejected.Text = lstTemp[15];
			}
		}

		/// <summary>
		/// Releases an order in the database.
		/// </summary>
		private void OrderRelease()
        {
			if (sqlData.blnConnectionStatus)
            {
				int intRowIndex			= dgvTab1.CurrentCell.RowIndex;
				int intColumnIndex;

				intColumnIndex			= dgvTab1.Columns["Ordernaam"].Index;
				string strOrdername		= dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value.ToString();

				intColumnIndex			= dgvTab1.Columns["Ordernummer"].Index;
				string strOrdernummer	= dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value.ToString();

				intColumnIndex			= dgvTab1.Columns["Beschrijving"].Index;
				string strDescription	= dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value.ToString();

				var msgBxResult = MessageBox.Show("Wil je de volgende order vrijgeven?\n" +
					"\n" +
					"Ordernaam:\t" + strOrdername + "\n" +
					"Ordernummer:\t" + strOrdernummer + "\n" +
					"Beschrijving:\t" + strDescription + "","Order vrijgeven?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (msgBxResult == DialogResult.Yes)
                {
					intColumnIndex		= dgvTab1.Columns["Schedule UId"].Index;
					string strGUID		= dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value.ToString();

					sqlData.ReleaseOrder(strGUID);

					// Make sure the datagridview and filters are updated.
					initializeFilters();
					getOrderData();
				}
			}
        }

		/// <summary>
		/// Open the new order dialog and process results, i.e. send the new order to the database.
		/// </summary>
		private void OrderAdd()
        {
			if (sqlData.blnConnectionStatus)
			{
				string strOrdername;
				string strOrdernumber;
				string strDescription;
				DateTime dtOrderStartDate;
				DateTime dtOrderEndDate;
				string strProductionlineWhite;
				string strProductionlineBrown;
				string strRecipe;
				int intOrdersize;
				int intAmountWhite;
				int intAmountBrown;				

				using (frmModifyOrder frmModifyOrder = new frmModifyOrder())
				{
					// Preload variables before the form is shown to the user.
					frmModifyOrder.strFormTitle				= "Nieuwe order aanmaken..";

					frmModifyOrder.lstRecipes				= sqlData.lstRecipes;
					frmModifyOrder.lstOrdername				= sqlData.lstOrdernames;
					frmModifyOrder.lstProductionlines		= sqlData.lstProductionlines;

					// Display form and if dialog is accepted (when ShowDialog() == DialogResult.OK), retrieve the modified data for further processing.
					if (frmModifyOrder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						strOrdername						= frmModifyOrder.strOrdername;
						strOrdernumber						= frmModifyOrder.strOrdernumber;
						strDescription						= frmModifyOrder.strDescription;
						dtOrderStartDate					= frmModifyOrder.dtOrderStartDate;
						dtOrderEndDate						= frmModifyOrder.dtOrderEndDate;
						strProductionlineWhite				= frmModifyOrder.strProductionlineWhite;
						strProductionlineBrown				= frmModifyOrder.strProductionlineBrown;
						strRecipe							= frmModifyOrder.strSelectedRecipe;
						intOrdersize						= frmModifyOrder.intOrderSize;
						intAmountWhite						= frmModifyOrder.intAmountWhite;
						intAmountBrown						= frmModifyOrder.intAmountBrown;						

						sqlData.InsertOrder(
							strOrdername,
							strOrdernumber,
							strDescription,
							dtOrderStartDate,
							dtOrderEndDate,
							strProductionlineWhite,
							strProductionlineBrown,
							strRecipe,
							intOrdersize,
							intAmountWhite,
							intAmountBrown);

						// Make sure the datagridview and filters are updated.
						initializeFilters();
						getOrderData();
					}
				}
			}
		}

		/// <summary>
		/// Edit the currently selected order.
		/// </summary>
		private void OrderEdit()
        {
			if (sqlData.blnConnectionStatus) { 
				string strOrdername;
				string strOrdernumber;
				string strDescription;
				DateTime dtOrderStartDate;
				DateTime dtOrderEndDate;
				string strProductionline;
				string strRecipe;
				int intOrdersize;
				int intAmountWhite;
				int intAmountBrown;
				string strScheduleUId;
				string strRequestUId;

				using (frmModifyOrder frmModifyOrder = new frmModifyOrder())
				{
					// Variable that contains the current selected row of the main datagridview.
					int intRowIndex							= dgvTab1.CurrentCell.RowIndex;
					int intColumnIndex;

					// Temp for date conversions.
					DateTime dateStartTime;
					DateTime dateEndTime;
					bool blConvertResult;

					// Preload variables before the form is shown to the user.
					frmModifyOrder.strFormTitle				= "Order bewerken..";

					// Retrieve the name of the order.
					intColumnIndex							= dgvTab1.Columns["Ordernaam"].Index;
					frmModifyOrder.strOrdername				= dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value.ToString();

					// Retrieve the ordernumber.
					intColumnIndex							= dgvTab1.Columns["Ordernummer"].Index;
					frmModifyOrder.strOrdernumber			= dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value.ToString();

					// Retrieve the order size.
					intColumnIndex							= dgvTab1.Columns["Aantal"].Index;
					frmModifyOrder.intOrderSize				= System.Convert.ToInt32(dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value);

					// Retrieve the datetime. We have to parse the string to DateTime format!
					intColumnIndex							= dgvTab1.Columns["Starttijd"].Index;
					blConvertResult							= DateTime.TryParse(dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value.ToString(), out dateStartTime);

					// If the parsing of the date string failed, set todays date instead. We can continue just fine.
					if (blConvertResult == false)
					{
						dateStartTime = DateTime.Now;
					}

					// Retrieve the datetime. We have to parse the string to DateTime format!
					intColumnIndex							= dgvTab1.Columns["Eindtijd"].Index;
					blConvertResult							= DateTime.TryParse(dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value.ToString(), out dateEndTime);

					// If the parsing of the date string failed, set todays date instead. We can continue just fine.
					if (blConvertResult == false)
					{
						dateEndTime = DateTime.Now;
					}

					frmModifyOrder.dtOrderStartDate			= dateStartTime;
					frmModifyOrder.dtOrderEndDate			= dateEndTime;

					// 
					intColumnIndex = dgvTab1.Columns["Schedule UId"].Index;
					strScheduleUId = dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value.ToString();

					// 
					intColumnIndex = dgvTab1.Columns["Request UId"].Index;
					strRequestUId = dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value.ToString();

					// Setup properties of frmModifyOrder
					frmModifyOrder.lstRecipes				= sqlData.lstRecipes;
					frmModifyOrder.lstOrdername				= sqlData.lstOrdernames;
					frmModifyOrder.lstProductionlines		= sqlData.lstProductionlines;

					intColumnIndex							= dgvTab1.Columns["Recept"].Index;
					frmModifyOrder.strSelectedRecipe		= dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value.ToString();

					intColumnIndex							= dgvTab1.Columns["Beschrijving"].Index;
					frmModifyOrder.strDescription			= dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value.ToString();

					intColumnIndex							= dgvTab1.Columns["Productielijn"].Index;
					frmModifyOrder.strSelectedProducionline = dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value.ToString();

					// Display form and if dialog is accepted (when ShowDialog() == DialogResult.OK), retrieve the modified data for further processing.
					if (frmModifyOrder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						strOrdername			= frmModifyOrder.strOrdername;
						strOrdernumber			= frmModifyOrder.strOrdernumber;
						strDescription			= frmModifyOrder.strDescription;
						dtOrderStartDate		= frmModifyOrder.dtOrderStartDate;
						dtOrderEndDate			= frmModifyOrder.dtOrderEndDate;
						strProductionline		= frmModifyOrder.strSelectedProducionline;
						strRecipe				= frmModifyOrder.strSelectedRecipe;
						intOrdersize			= frmModifyOrder.intOrderSize;
						intAmountWhite			= frmModifyOrder.intAmountWhite;
						intAmountBrown			= frmModifyOrder.intAmountBrown;					

						sqlData.OrderEdit(strOrdername,
							strOrdernumber,
							strDescription,
							dtOrderStartDate,
							dtOrderEndDate,
							strProductionline,
							strRecipe,
							intOrdersize,
							intAmountWhite,
							intAmountBrown,
							strScheduleUId,
							strRequestUId);
					}
				}
			}
		}

		/// <summary>
		/// Command the OPC server to start the selected order.
		/// </summary>
		private void OrderStart()
        {
			int intRowIndex			= dgvTab1.CurrentCell.RowIndex;
			int intColumnIndex		= dgvTab1.Columns["Ordernaam"].Index;
			string strOrdername		= dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value.ToString();

			var msgBxResult = MessageBox.Show("Weet je zeker dat je de order '" + strOrdername + "' wilt starten? Hierbij worden alle onderliggende orders ook gestart.","Order starten?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (msgBxResult == DialogResult.Yes)
            {
				intRowIndex			= dgvTab1.CurrentCell.RowIndex;
				intColumnIndex		= dgvTab1.Columns["Schedule UId"].Index;
				string strGUID		= dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value.ToString();

				// Check if objOPC exists and that there is a connection with the OPC.
				if (objOPC != null && objOPC.blnConnectionStatus)
				{
					if (objOPC.StartOrder(strGUID))
					{
						MessageBox.Show("Order is gestart", "Order starten", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show("Er is een probleem opgetreden en de order kon niet worden gestart. Is er verbinding met de OPC server?", "Order starten", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
			}		
		}

		/// <summary>
		/// Command the OPC server to pauze the selected order.
		/// </summary>
		private void OrderPause()
        {
			// TODO
        }

		/// <summary>
		/// Command the OPC server to stop the selected order.
		/// </summary>
		private void OrderStop()
        {
			// TODO			
		}

		/// <summary>
		/// Remove the selected order from the database.
		/// </summary>
		private void OrderRemove()
        {
			// Check if there is a database connection.
			if (sqlData.blnConnectionStatus)
			{
				// Variable that contains the current selected row of the main datagridview.
				int intRowIndex				= dgvTab1.CurrentCell.RowIndex;
				int intColumnIndex;

				intColumnIndex				= dgvTab1.Columns["Ordernaam"].Index;
				string strOrdername			= dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value.ToString();

				intColumnIndex				= dgvTab1.Columns["Ordernummer"].Index;
				string strOrdernummer		= dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value.ToString();

				intColumnIndex				= dgvTab1.Columns["Beschrijving"].Index;
				string strDescription		= dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value.ToString();

				intColumnIndex				= dgvTab1.Columns["Recept"].Index;
				string strRecipe			= dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value.ToString();

				intColumnIndex				= dgvTab1.Columns["Aantal"].Index;
				string strAmount			= dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value.ToString();

				intColumnIndex				= dgvTab1.Columns["Schedule UId"].Index;
				string strGUID				= dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value.ToString();

				// Show confirmation messagebox.
				var msgBxResult = MessageBox.Show(
					"Weet je zeker dat je de volgende order wilt verwijderen?\n" +
					"\n" +
					"Ordernaam:\t" + strOrdername + "\n" +
					"Ordernummer:\t" + strOrdernummer + "\n" +
					"Beschrijving:\t" + strDescription + "\n" +
					"Recept:\t\t" + strRecipe + "\n" +
					"Aantal:\t\t" + strAmount + "\n" +
					"GUID:\t\t" + strGUID, "Order verwijderen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (msgBxResult == DialogResult.Yes)
				{
					// Let the user know if the command was succesful or not.
					if (sqlData.RemoveOrder(strGUID))
					{
						MessageBox.Show("Order is successvol verwijderd", "Order verwijderden", MessageBoxButtons.OK, MessageBoxIcon.Information);

						// Make sure the datagridview and filters are updated.
						initializeFilters();
						getOrderData();
					}
					else
					{
						MessageBox.Show("Er is een fout opgetreden. De geselecteerde order is niet verwijderd.", "Order verwijderden", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
			}
		}

		#endregion

		#region Menustrip items eventhandlers
		private void btnMnuResetUserSettings_Click(object sender, EventArgs e)
		{
			resetSettings();
		}

		private void afsluitenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnMnuDBConnect_Click(object sender, EventArgs e)
		{
			establishConnection();
		}

		private void btnMnuDBSettings_Click(object sender, EventArgs e)
		{
			enterConnectionSettings();
		}

		private void btnMnuHideGUID_CheckStateChanged(object sender, EventArgs e)
		{
			if (btnMnuHideGUID.Checked)
            {
				try
                {
					int intColumnIndex;
					intColumnIndex = dgvTab1.Columns["Schedule UId"].Index;

					if (dgvTab1.Columns[intColumnIndex].Visible)
					{
						dgvTab1.Columns[intColumnIndex].Visible = false;
						dgvTab1.Columns[intColumnIndex + 1].Visible = false;
					}
					else
					{
						dgvTab1.Columns[intColumnIndex].Visible = true;
						dgvTab1.Columns[intColumnIndex + 1].Visible = true;
					}
				} catch (Exception ex)
                {
                    Console.WriteLine("Exception in btnMnuHideGUID_CheckStateChanged");
                }
			}
		}

		private void btnMnuOPCConnect_Click(object sender, EventArgs e)
		{
			establishOPCConnection();
		}

		private void btnMnuOPCSettings_Click(object sender, EventArgs e)
		{
			enterOPCConnectionSettings();
		}

		private void btnMnuEnableRealtimeData_Click(object sender, EventArgs e)
		{
			if ( btnMnuOPCenableRealtimeData.Checked)
            {
				timerRetrieveOPC.Enabled = true;
				txtOPCrealtimeStatus.Text = "Automatisch ophalen";
				txtOPCrealtimeStatus.BackColor = Color.LightGreen;
			} else
            {
				timerRetrieveOPC.Enabled = false;
				txtOPCrealtimeStatus.Text = "Handmatig ophalen";
				txtOPCrealtimeStatus.BackColor = SystemColors.Control;
			}
		}

		private void cbxMnuOPCupdateInterval_SelectedIndexChanged(object sender, EventArgs e)
		{
			int intIndex = cbxMnuOPCupdateInterval.SelectedIndex;
			txtOPCupdateInterval.Text = cbxMnuOPCupdateInterval.SelectedItem.ToString();

			if (intIndex >= 0 && intIndex <= 3)
			{
				timerRetrieveOPC.Interval = lstOPCupdateInterval[intIndex];
			}
		}

		private void btnApplicationInfo_Click(object sender, EventArgs e)
		{
			Form frmAboutbox = new frmAboutBox();
			frmAboutbox.Show();
		}

		#endregion

		#region Toolstrip items eventhandlers
		private void btnConnect_Click(object sender, EventArgs e)
		{
			establishConnection();
		}

		private void btnSettings_Click(object sender, EventArgs e)
		{
			// Allow user to modify the connectionsettings.
			enterConnectionSettings();
		}

		private void btnTest_Click(object sender, EventArgs e) // Example function used to demonstrate how a DataGridView can be filled.
		{
			int intRowIndex = dgvTab1.CurrentCell.RowIndex;
			int intColumnIndex;

			intColumnIndex = dgvTab1.Columns["Schedule UId"].Index;
			string strGUID = dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value.ToString();

			MessageBox.Show("Rij: " + intRowIndex + " kolom: " + intColumnIndex + " waarde: " + strGUID);			
		}	

		private void btnResetUserSettings_Click(object sender, EventArgs e)
		{
			resetSettings();
		}
		#endregion

		#region Tabcontrol : "Overzicht orders"
		
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

		/// <summary>
		/// Function called when the datagridview selection changes. It is used to enable or disable the btnOrderRemove to allow deletion of an order only when the order status allow it.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgvTab1_SelectionChanged(object sender, EventArgs e)
		{
            try
            {
				if (sqlData.blnConnectionStatus && dgvTab1.SelectedCells.Count > 0)
				{
					int intRowIndex			= dgvTab1.CurrentCell.RowIndex;
					int intColumnIndex		= dgvTab1.Columns["Orderstatus"].Index;
					string strOrderstatus	= dgvTab1.Rows[intRowIndex].Cells[intColumnIndex].Value.ToString();

					if (strOrderstatus == "FORECAST")
					{
						btnReleaseOrder.Enabled		= true;
						btnOrderRemove.Enabled		= true;
						btnOrderEdit.Enabled		= true;
						btnOrderStart.Enabled		= false;

					} else if (strOrderstatus == "RELEASED")
                    {
						btnReleaseOrder.Enabled		= false;
						btnOrderRemove.Enabled		= false;
						btnOrderEdit.Enabled		= false;

						if ((objOPC != null && objOPC.blnConnectionStatus))
						{
							btnOrderStart.Enabled	= true;
						}
					}
					else
					{
						btnReleaseOrder.Enabled		= false;
						btnOrderRemove.Enabled		= false;
						btnOrderEdit.Enabled		= false;
						btnOrderStart.Enabled		= false;
					}
				}
			}	catch (Exception ex)
            {
                Console.WriteLine("Error occured in dgvTab1_SelectionChanged. Exception message: {0}", ex);
            }							
		}

		private void txtOrdernumber_TextChanged(object sender, EventArgs e)
		{
			getOrderData();
		}

		private void btnClearOrderFilter_Click(object sender, EventArgs e)
		{
			txtOrdernumber.Clear();
		}

		private void cbxProductionLine_SelectedIndexChanged(object sender, EventArgs e)
		{
			getOrderData();
		}

		private void cbxOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
		{
			getOrderData();
		}

		private void btnReleaseOrder_Click(object sender, EventArgs e)
		{
			OrderRelease();
		}

		private void btnOrderStart_Click(object sender, EventArgs e)
        {
			OrderStart();
        }

        private void btnOrderPause_Click(object sender, EventArgs e)
        {
			OrderPause();
        }

        private void btnOrderStop_Click(object sender, EventArgs e)
        {
			OrderStop();
        }

		private void btnOrderAdd_Click(object sender, EventArgs e)
        {
			OrderAdd();
		}

		private void btnOrderEdit_Click(object sender, EventArgs e)
        {
			OrderEdit();
		}

        private void btnOrderRemove_Click(object sender, EventArgs e)
        {
			OrderRemove();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
			sqlData.InitializeGlobalData();
			getOrderData();
		}

		#endregion

		#region Tabcontrol : "Realtime data"

		private void timerRetrieveOPC_Tick(object sender, EventArgs e)
        {
			GetRealtimeOPCData();
		}

        private void btnUpdateOPCdata_Click(object sender, EventArgs e)
        {
			GetRealtimeOPCData();
		}

		#endregion

		#region Tabcontrol : "Database"
		private void btnGetDatabaseItems_Click(object sender, EventArgs e)
        {
			lstbxCustomers.Items.Clear();
			lstbxRecipes.Items.Clear();
			lstbxProductionlines.Items.Clear();
			lstbxOrderstatusses.Items.Clear();

			foreach (string ding in sqlData.lstOrdernames)
			{
				lstbxCustomers.Items.Add(ding);
			}

			foreach (string ding in sqlData.lstRecipes)
			{
				lstbxRecipes.Items.Add(ding);
			}

			foreach (string ding in sqlData.lstProductionlines)
			{
				lstbxProductionlines.Items.Add(ding);
			}

			foreach (string ding in sqlData.lstOrderstatusses)
			{
				lstbxOrderstatusses.Items.Add(ding);
			}
		}
        #endregion
    }
}