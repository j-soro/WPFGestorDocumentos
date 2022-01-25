using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFGestorDocumentos.Exceptions;
using WPFGestorDocumentos.Models;

namespace WPFGestorDocumentos.Models
{
    public class BookCollection
    {
        public List<Book> Books { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Image Picture { get; set; }

        public int Count { get; }

        public BookCollection(List<Book> books, string username, string password, string name, string description)
        {
            Books = books;
            Username = username;
            Password = password;
            Name = name;
            Description = description;
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }
        public void RemoveBook(Book book)
        {
            Books.Remove(book);
        }

        public void UpdateBook(Book book)
        {
            Book? Updated = Books.Find(b => b.Id == book.Id);
            if (Updated != null)
            {
                Updated.Title = book.Title;
                Updated.Author = book.Author;
                Updated.Year = book.Year;
                Updated.Genre = book.Genre;
                Updated.Rating = book.Rating;
                Updated.Pages = book.Pages;
                Updated.PagesRead = book.PagesRead;
            }
        }

        public Book FindBookById(int BookId)
        {
            Book? FoundBook = Books.Find(b => BookId == b.Id);

            if (FoundBook is null)
            {
                throw new BookIdNotFoundException(BookId);
            }
            else return FoundBook;
        }

        public override bool Equals(object obj)
        {
            return obj is BookCollection bookCol &&
                Books == bookCol.Books &&
                Username == bookCol.Username &&
                Name == bookCol.Name;
        }

        public bool Conflicts(BookCollection newBookCollection)
        {
            if (newBookCollection.Equals(this))
            {
                return true;
            }
            return false;            
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Books, Username, Password, Name);
        }
    }
}
