using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFGestorDocumentos.Adapters;

namespace WPFGestorDocumentos.Services
{
    internal class DatabaseConnectionService : IDatabaseConnectionService
    {
        public SQLiteConnection GetConnection()
        {
            return DbAdapter.GetConnection();
        }
    }
}
