using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFGestorDocumentos.Adapters;
using WPFGestorDocumentos.Models;
using WPFGestorDocumentos.Services;

namespace WPFGestorDocumentos
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Image img = Image.FromFile(@"C:\Users\joaquin\source\repos\WPFGestorDocumentos\WPFGestorDocumentos\placeholder.png");
            User s = new User(1, "jsoro", "1234", "Joaquín", "Soro", img);
            Session session = new Session("Sesión principal", s);

            Book book = new Book(1, "El señor de las moscas", "William Golding", "1951", "Novela", 8, 240, 0);
            List<Book> books = new List<Book>();
            books.Add(book);

            BookCollection bookCol1 = new BookCollection(books,
                "jsoro",
                "1234",
                "Mi colección",
                "Una colección de prueba");

            session.AddBookCollection(bookCol1);
            base.OnStartup(e);
        }

    }
}
