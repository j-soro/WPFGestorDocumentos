using System;
using System.Drawing;
namespace WPFGestorDocumentos.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public Image Cover { get; set; }

        public int Rating { get; set; }

        public int Pages { get; set; }

    }
}