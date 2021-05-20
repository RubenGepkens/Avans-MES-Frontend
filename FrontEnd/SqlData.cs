/*
 * MOMS2 Frontend - SqlData
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient; // Zelf toegevoegd
using System.Windows.Forms;
using System.Data;

namespace FrontEnd
{
    /// <summary>
    /// Child class of SqlClass holding the SQL queries to interact with the database.
    /// </summary>
    public sealed class SqlData : SqlClass
    {
        /// <summary>
        /// Method that executes a dummy SQL statement to check the database connection.
        /// Contains various try .. catch statements to caputure connection related exceptions.
        /// </summary>
        /// <returns>True if connection could be established and if not returns False.</returns>
        public bool checkConnection()
        {
            bool blnReturnValue = false;
            initializeConnectionString();

            using (var connection = GetConnection())
            {
                using (var command = new SqlCommand("SELECT 1", connection))
                {
                    try
                    {
                        Console.WriteLine("checkConnection()\t {0}", connection.ConnectionString);
                        connection.Open();                        
                        command.ExecuteScalar();
                        blnReturnValue = true; // Declare connection successful
                    } 
                    catch (SqlException ex) // This will catch all SQL exceptions
                    {
                        Console.WriteLine("Exception E101");
                        MessageBox.Show("Execute exception issue: " + ex.Message, "Connection issue: E101", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine("Exception E102");
                        MessageBox.Show("Connection exception issue: " + ex.Message, "Connection issue: E102", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex) // This will catch every Exception
                    {
                        Console.WriteLine("Exception E103");
                        MessageBox.Show("Exception message: " + ex.Message, "Connection issue: E103", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return blnReturnValue;
                }
            }
        }

        /// <summary>
        /// Function to retrieve recipes.
        /// </summary>
        /// <returns>List containing all recipes</returns>
        public List<string> getRecipes()
        {
            List<string> lstRecipes = new List<string> { "Witbrood", "Bruinbrood", "Herman Brood" }; ;

            return lstRecipes;
        }

        /// <summary>
        /// Example method retrieving nonsense (dummy) data to demonstrate the filling of a DataGridView control.
        /// </summary>
        /// <param name="dataGridView"></param>
        public void exampleFunction(DataGridView dataGridView) // Example function used to demonstrate how a DataGridView can be filled.
        {
            using (var connection = GetConnection()) // Retrieve connectionstring
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM dbo.Equipment", connection)) // Create SqlDataAdapter used to retrieve/manipulate data from a database.
                {
                    using (DataTable dataTable = new DataTable())
                    {
                        try
                        {
                            sqlDataAdapter.Fill(dataTable);
                            dataGridView.DataSource = dataTable;
                            dataGridView.AutoResizeColumns();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Generic SQL exception: " + ex.Message);
                            MessageBox.Show("Exception message: " + ex.Message, "Generic SQL exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }                        
                        /*
                        using (BindingSource bSource = new BindingSource())
                        {                           
                            bSource.DataSource = dataTable;                            
                            dataGridView.DataSource = bSource;                            
                        }
                        */
                    }
                }
            }
        }

        /// <summary>
        /// Retrieve production orders and allow for filtering based on production line and order status.
        /// </summary>
        public void getOrders(DataGridView dataGridView)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("EXECUTE spGetOrder", connection))
                    {
                        using (DataTable dataTable = new DataTable())
                        {
                            sqlDataAdapter.Fill(dataTable);
                            dataGridView.DataSource = dataTable;
                            dataGridView.RowHeadersVisible = false;
                            dataGridView.AutoResizeColumns();
                        }
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Generic exception: " + ex.Message);
                MessageBox.Show("Exception message: " + ex.Message, "Generic SQL exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
    }
}