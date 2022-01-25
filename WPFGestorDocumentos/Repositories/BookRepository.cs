using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFGestorDocumentos.Models;

namespace WPFGestorDocumentos.Repositories
{
    internal class BookRepository : IRepository<Book>
    {
        public List<Book> Books { get; set; }

        public BookRepository()
        {
            Books = GetAll();
        }

        public List<Book>? GetAll()
        {
            return BookDataMapper.GetAll();
        }

        public void Create(Book book)
        {
            BookDataMapper.Create(book);
        }
        public Book? Read(long bookId)
        {
            return BookDataMapper.Find(bookId);
        }
        public void Update(Book book)
        {
            BookDataMapper.Update(book);
        }
        public void Delete(Book book)
        {
            BookDataMapper.Delete(book);
        }
    }
}
