using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient; // Zelf toegevoegd

namespace FrontEnd
{
    public class sqlVerbinding
    {
        private readonly string connectionString;

        public sqlVerbinding()
        {
            //Properties.Settings.Default.connectionString
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}