/*
 * MOMS2 Frontend - SqlClass
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

namespace FrontEnd
{
    public class SqlClass
    {
        private readonly string strConnectionString;
        public bool blnConnectionStatus { get; set; }

        public SqlClass()
        {
            strConnectionString = Properties.Settings.Default.connectionString;
            blnConnectionStatus = false;
            Console.WriteLine("sqlVerbinding: " + strConnectionString);
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(strConnectionString);
        }
    }
}