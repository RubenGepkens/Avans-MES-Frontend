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
                        connection.Open();                        
                        command.ExecuteScalar();
                        blnReturnValue = true; // Declare connection successful
                    } 
                    catch (SqlException ex) // This will catch all SQL exceptions
                    {
                        Console.WriteLine("Exception E101");
                        MessageBox.Show("SqlException: " + ex.Message, "Connection issue: E101", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine("Exception E102");
                        MessageBox.Show("InvalidOperationException: " + ex.Message, "Connection issue: E102", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex) // This will catch every Exception
                    {
                        Console.WriteLine("Exception E103");
                        MessageBox.Show("Generic exception: " + ex.Message, "Connection issue: E103", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return blnReturnValue;
                }
            }
        }

        /// <summary>
        /// Initialze the list information in the SqlClass.
        /// To be used as filters and customer names.
        /// </summary>
        public void InitializeGlobalData()
        {
            lstRecipes          = GetRecipes();
            lstOrdernames        = GetOrdernames();
            lstProductionlines  = GetProductionlines();
            lstOrderstatusses   = GetOrderStatusses();
        }

        /// <summary>
        /// Function to retrieve recipes.
        /// </summary>
        /// <returns>List containing all recipes</returns>
        public List<string> GetRecipes()
        {
            List<string> lstRecipes = new List<string> { }; ;

            try
            {
                using (var connection = GetConnection())
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("EXECUTE spGetRecipe", connection))
                    {
                        using (DataTable dataTable = new DataTable())
                        {
                            sqlDataAdapter.Fill(dataTable);

                            foreach (DataRow row in dataTable.Rows)
                            {
                                lstRecipes.Add(row[0].ToString());
                            }
                            return lstRecipes;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Generic exception: " + ex.Message);
                MessageBox.Show("Exception message: " + ex.Message, "Generic SQL exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Function to retrieve order names.
        /// </summary>
        /// <returns>List containing all order types</returns>
        public List<string> GetOrdernames()
        {
            List<string> lstCustomers = new List<string> { };

            try
            {
                using (var connection = GetConnection())
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("EXECUTE spGetCustomers", connection))
                    {
                        using (DataTable dataTable = new DataTable())
                        {
                            sqlDataAdapter.Fill(dataTable);

                            foreach (DataRow row in dataTable.Rows)
                            {
                                lstCustomers.Add(row[0].ToString());
                            }
                            return lstCustomers;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Generic exception: " + ex.Message);
                MessageBox.Show("Exception message: " + ex.Message, "Generic SQL exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Retrieves all the names of the available produciton lines.
        /// </summary>
        /// <returns>List containing strings</returns>
        public List<string> GetProductionlines()
        {
            List<string> lstProductionlines = new List<string> { };

            try
            {
                using (var connection = GetConnection())
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("EXECUTE spGetProductionlines", connection))
                    {
                        using (DataTable dataTable = new DataTable())
                        {
                            sqlDataAdapter.Fill(dataTable);
                            
                            foreach ( DataRow row in dataTable.Rows)
                            {
                                lstProductionlines.Add( row[0].ToString() );
                            }
                            return lstProductionlines;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Generic exception: " + ex.Message);
                MessageBox.Show("Exception message: " + ex.Message, "Generic SQL exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Retrieves all the available order statusses.
        /// </summary>
        /// <returns>List containing strings</returns>
        public List<string> GetOrderStatusses()
        {
            List<string> lstOrderStatusses = new List<string> { };
            
            try
            {
                using (var connection = GetConnection())
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("EXECUTE spGetOrderStatusses", connection))
                    {
                        using (DataTable dataTable = new DataTable())
                        {
                            sqlDataAdapter.Fill(dataTable);

                            foreach (DataRow row in dataTable.Rows)
                            {
                                lstOrderStatusses.Add(row[0].ToString());
                            }
                            return lstOrderStatusses;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Generic exception: " + ex.Message);
                MessageBox.Show("Exception message: " + ex.Message, "Generic SQL exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Retrieve production orders and allow for filtering based on production line and order status.
        /// </summary>
        public void GetOrders(DataGridView dataGridView, string strOrdernumber, string strProductionline, string strOrderstatus)
        {
            string strQuery = "EXECUTE spGetOrder @Productielijn= '" + strProductionline + "', @Ordernummer= '" + strOrdernumber + "', @Orderstatus= '" + strOrderstatus + "'";

            try
            {
                using (var connection = GetConnection())
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(strQuery, connection))
                    {                       
                        using (DataTable dataTable = new DataTable())
                        {
                            sqlDataAdapter.Fill(dataTable);
                            dataGridView.DataSource = dataTable;
                            dataGridView.RowHeadersVisible = false;
                            dataGridView.AutoResizeColumns();
                            dataGridView.Sort( dataGridView.Columns["Ordernummer"], System.ComponentModel.ListSortDirection.Ascending );
                        }
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Generic exception: " + ex.Message);
                MessageBox.Show("Exception message: " + ex.Message, "Generic SQL exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        /// <summary>
        /// Excecutes a stored procedure to insert an order into the database.
        /// </summary>
        /// <param name="strOrdername"></param>
        /// <param name="strOrdernumber"></param>
        /// <param name="strDescription"></param>
        /// <param name="dtOrderStartDate"></param>
        /// <param name="dtOrderEndtDate"></param>
        /// <param name="strProductionline"></param>
        /// <param name="strRecipe"></param>
        /// <param name="intOrdersize"></param>
        public void InsertOrder(
            string strOrdername,
            string strOrdernumber,
            string strDescription,
            DateTime dtOrderStartDate,
            DateTime dtOrderEndtDate,
            string strProductionline,
            string strRecipe,
            int intOrdersize,
            int intAmountWhite,
            int intAmountBrown)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    using (var command = new SqlCommand("spInsertOrder", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@strOrderName", SqlDbType.VarChar).Value = strOrdername;
                        command.Parameters.Add("@strBatchNumber", SqlDbType.VarChar).Value = strOrdernumber;
                        command.Parameters.Add("@strDescription", SqlDbType.VarChar).Value = strDescription;
                        command.Parameters.Add("@dtStartTime", SqlDbType.DateTime).Value = dtOrderStartDate;
                        command.Parameters.Add("@dtEndTime", SqlDbType.DateTime).Value = dtOrderEndtDate;
                        command.Parameters.Add("@strHierarchy", SqlDbType.VarChar).Value = "EnterPrise";
                        command.Parameters.Add("@intAmountWhite", SqlDbType.Int).Value = intAmountWhite;
                        command.Parameters.Add("@intAmountBrown", SqlDbType.Int).Value = intAmountBrown;
                        command.Parameters.Add("@strProductieLijn", SqlDbType.VarChar).Value = strProductionline;

                        connection.Open();
                        command.ExecuteNonQuery();                       
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Generic exception: " + ex.Message);
                MessageBox.Show("Exception message: " + ex.Message, "Generic SQL exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Excecutes a stored procedure to insert an order into the database.
        /// </summary>
        /// <param name="strOrdername"></param>
        /// <param name="strOrdernumber"></param>
        /// <param name="strDescription"></param>
        /// <param name="dtOrderStartDate"></param>
        /// <param name="dtOrderEndtDate"></param>
        /// <param name="strProductionline"></param>
        /// <param name="strRecipe"></param>
        /// <param name="intOrdersize"></param>
        public void OrderEdit(
            string strOrdername,
            string strOrdernumber,
            string strDescription,
            DateTime dtOrderStartDate,
            DateTime dtOrderEndtDate,
            string strProductionline,
            string strRecipe,
            int intOrdersize)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    using (var command = new SqlCommand("", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@strOrderName", SqlDbType.VarChar).Value = strOrdername;
                        command.Parameters.Add("@strBatchNumber", SqlDbType.VarChar).Value = strOrdernumber;
                        command.Parameters.Add("@strDescription", SqlDbType.VarChar).Value = strDescription;
                        command.Parameters.Add("@dtStartTime", SqlDbType.DateTime).Value = dtOrderStartDate;
                        command.Parameters.Add("@dtEndTime", SqlDbType.DateTime).Value = dtOrderEndtDate;
                        command.Parameters.Add("@strHierarchy", SqlDbType.VarChar).Value = "EnterPrise";
                        command.Parameters.Add("@intAmountWhite", SqlDbType.Int).Value = intOrdersize;
                        command.Parameters.Add("@intAmountBrown", SqlDbType.Int).Value = intOrdersize;
                        command.Parameters.Add("@strProductieLijn", SqlDbType.VarChar).Value = strProductionline;

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Generic exception: " + ex.Message);
                MessageBox.Show("Exception message: " + ex.Message, "Generic SQL exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Execute a stored procedure to remove an order from the database.
        /// </summary>
        /// <returns>true if command was excecuted successfully and false if an error occured.</returns>
        public bool RemoveOrder(string strGUID)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    using (var command = new SqlCommand("", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        
                        command.Parameters.Add("@strGUID", SqlDbType.VarChar).Value = strGUID;                        

                        connection.Open();
                        command.ExecuteNonQuery();
                        
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Generic exception: " + ex.Message);
                MessageBox.Show("Exception message: " + ex.Message, "Generic SQL exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}