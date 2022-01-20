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
        private BookDataMapper dataMapper;
        public List<Book> GetAllBooks()
        {
            return new List<Book>();
        }

        public BookRepository(BookDataMapper dataMapper)
        {
            this.dataMapper = dataMapper;
        }

        public void FindBook(long bookId)
        {
            // 1. Use bookMapper to fetch book record from the storage by bookId.
            //    Notice that I said storage, not db: per definition, a repository 
            //    hides the details regarding the storage type. The user (client) 
            //    knows only that the book is placed... somewhere.
            // 2. Return the fetched book object.
        }
        public void StoreBook(Book book)
        {
            // 1. Use bookMapper to store the book.
            // 2. Return the book (with last insert id in it).
        }
        public void UpdateBook(Book book) { ... }
        public void RemoveBook(Book book) { ... }
    }
}
