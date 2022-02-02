using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFGestorDocumentos.Models;
using WPFGestorDocumentos.ViewModels.Base;

namespace WPFGestorDocumentos.ViewModels
{
    public class UserCollectionsViewModel : ViewModelBase
    {
        public ObservableCollection<User> superColeccion { get; set; }

        UserCollectionsViewModel()
        {
            superColeccion = new ObservableCollection<User>();
            superColeccion.Add(new User(1, "pacorro", "1234", "Paco", "Gómez"));
        }

    }
}
