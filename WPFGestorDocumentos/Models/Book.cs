using System;
using System.ComponentModel;
using System.Drawing;

namespace WPFGestorDocumentos.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }

        public string Year { get; set; }

        public string Genre { get; set; }

        public int Rating { get; set; }

        public int Pages { get; set; }

        public Image Cover { get; set; }

        public int PagesRead { get; set; }

        public Book()
        {

        }
        public Book(int id, string title, string author, string year, string genre, int rating, int pages, int pagesread)
        {
            Id = id;
            Title = title;
            Author = author;
            Year = year;
            Genre = genre;
            Rating = rating;
            Pages = pages;
            PagesRead = pagesread;
        }
    }
}