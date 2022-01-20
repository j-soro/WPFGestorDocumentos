using System.Data.SQLite;

namespace WPFGestorDocumentos.Services
{
    internal interface IDatabaseConnectionService
    {
        SQLiteConnection GetConnection();
    }
}