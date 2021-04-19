using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient; // Zelf toegevoegd

namespace FrontEnd
{
    public sealed class sqlCommando : sqlVerbinding
    {

        public string GetUser()
        {
            using( var connection = GetConnection())
            {
                using (var command = new SqlCommand())
                {
                    command.ExecuteNonQuery();
                    return null;                    
                }
            }
        }
    }
}
