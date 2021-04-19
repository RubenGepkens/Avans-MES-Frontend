using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient; // Zelf toegevoegd

namespace FrontEnd
{
    public class SqlClass
    {
        private readonly string strConnectionString;

        public SqlClass()
        {
            strConnectionString = Properties.Settings.Default.connectionString;
            Console.WriteLine("sqlVerbinding: " + strConnectionString);
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(strConnectionString);
        }
    }
}