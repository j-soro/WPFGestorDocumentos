using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFGestorDocumentos.Models;

namespace WPFGestorDocumentos.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
    }

    internal class BookRepository : IBookRepository
    {
        //private readonly BookDataMapper BookDataMapper;
        public List<Book> GetAllBooks()
        {
            return BookDataMapper.GetAllBooks();
        }
        public static Book FindBook(long bookId)
        {
            return BookDataMapper.Read(bookId);
        }
        public static void StoreBook(Book book)
        {
            BookDataMapper.Create(book);
        }
        public static void UpdateBook(Book book)
        {
            BookDataMapper.Update(book);
        }
        public static void RemoveBook(Book book)
        {
            BookDataMapper.Delete(book);
        }
    }
}
