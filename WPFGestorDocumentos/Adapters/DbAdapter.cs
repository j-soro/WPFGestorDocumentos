using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGestorDocumentos.Adapters
{
    public class DbAdapter
    {
        private static SQLiteConnection? connection = null;
        public static SQLiteConnection? GetConnection() 
        {
            if (connection == null)
            {
                using var con = new SQLiteConnection(LoadConnectionString());
            }
            return connection;
        }

        private static string LoadConnectionString(string id = "DefaultConnection")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
