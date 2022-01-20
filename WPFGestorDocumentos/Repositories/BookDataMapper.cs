using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFGestorDocumentos.Models;

namespace WPFGestorDocumentos.Repositories
{
    internal class BookDataMapper
    {
        public BookDataMapper(DbAdapter adapter)
        {
            // Assign DbAdapter object to the adapter class member.
            using var con = new SQLiteConnection("Data Source =:memory: ");
        }

        public void select(long bookId)
        {
            // 1. Fetch book record from db by bookId and using the injected db adapter.
            // 2. Map fetched db record to a Book object using mapBook().
            // 3. Add Book object to books using addBook().
        }
        public void insert(Book book)
        {
            // 1. Read the class members of object book.
            // 2. Inject the values in an INSERT SQL statement as parameters.
            // 3. Run the INSERT query and return last insert id.
            // 4. Assign the last insert id to book's ID class member. 
            // 4. Return book.
        }
        public void update(Book book) { ... }
        public void delete(Book book) { ... }

        public void mapBook(List<Book> bookRecord)
        {
            // 1. Create a plain Book object.
            // 2. Read bookRecord array and map each field to the corresponding 
            //    class member of the Book object.
            // 3. Return mapped Book object.
        }

        public void addBook(Book book)
        {
            // Add book to books collection.
        }

    }
}
