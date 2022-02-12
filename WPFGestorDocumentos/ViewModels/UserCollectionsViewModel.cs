using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFGestorDocumentos.Models;
using WPFGestorDocumentos.ViewModels.Base;

namespace WPFGestorDocumentos.ViewModels
{
    public class UserCollectionsViewModel : ViewModelBase
    {
        public static BindingList<User> superColeccion { get; set; }
        public static BindingList<BookCollection> bc { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }

        public UserCollectionsViewModel()
        {
            superColeccion = new BindingList<User> { new User(1, "pacorro", "1234", "Paco", "Gómez"), new User(2, "javichu24", "4321", "Javier", "García"), new User(2, "jsoro23", "1423", "Joaquín", "Soro") };


            List<Book> books = new List<Book>();
            Book book = new Book(1, "El señor de las moscas", "William Golding", "1951", "Novela", 8, 240, 0);
            books.Add(book);
            bc = new BindingList<BookCollection> { new BookCollection(books, "jsoro", "1234", "Colección de prueba", "Unos libros que pertenecen a esta colección y este texto es la descripción.") };


        }

    }
}
