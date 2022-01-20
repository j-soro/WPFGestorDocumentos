using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFGestorDocumentos.Adapters;
using WPFGestorDocumentos.Services;

namespace WPFGestorDocumentos
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            CustomDependencyService.Register<LoginService>();
            CustomDependencyService.Register<DatabaseConnectionService>();





        }
    }
}
