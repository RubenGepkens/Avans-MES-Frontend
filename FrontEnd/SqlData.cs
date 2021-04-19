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
    public sealed class SqlData : SqlClass
    {
        public bool checkConnection()
        {
            bool blnReturnValue = false;

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

        public void exampleFunction(DataGridView dataGridView)
        {
            using (var connection = GetConnection())
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM dbo.Equipment", connection))
                {
                    using (DataTable dataTable = new DataTable())
                    {
                        sqlDataAdapter.Fill(dataTable);
                        dataGridView.DataSource = dataTable;
                        dataGridView.AutoResizeColumns();

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
    }
}
