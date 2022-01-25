using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFGestorDocumentos.Adapters;
using WPFGestorDocumentos.Models;
using WPFGestorDocumentos.Utility;

namespace WPFGestorDocumentos.Repositories
{
    internal class BookDataMapper
    {
        public static List<Book>? Books { get; set; }
        public static void AddBookToListOnly(Book book)
        {
            if (!Books.Contains(book)) { Books.Add(book); }
        }
        public static void Create(Book book)
        {
            using SQLiteConnection? con = SQLiteAdapter.GetConnection();
            using var cmd = new SQLiteCommand(con);
            try
            {
                con.Open();
                cmd.CommandText = "INSERT INTO Books(id, title, author, year, genre, cover, rating, pages) VALUES(@title, @author, @year, @genre, @cover, @rating, @pages)";

                SQLiteParameter blobParam = new SQLiteParameter("@cover", System.Data.DbType.Binary);
                blobParam.Value = CUtility.imageToByteArray(book.Cover);

                cmd.Parameters.AddWithValue("@id", book.Id);
                cmd.Parameters.AddWithValue("@title", book.Title);
                cmd.Parameters.AddWithValue("@author", book.Author);
                cmd.Parameters.AddWithValue("@year", book.Year);
                cmd.Parameters.AddWithValue("@genre", book.Genre);
                cmd.Parameters.Add(blobParam);
                cmd.Parameters.AddWithValue("@rating", book.Rating);
                cmd.Parameters.AddWithValue("@pages", book.Pages);

                cmd.ExecuteNonQuery();

            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
            AddBookToListOnly(book);
        }
        public static Book? Find(long bookId)
        {
            using SQLiteConnection? con = SQLiteAdapter.GetConnection();
            using var cmd = new SQLiteCommand(con);
            try
            {
                con.Open();
                cmd.CommandText = "SELECT FROM Books WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", bookId);
                cmd.Prepare();

                Book book = new Book();

                using SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(0))
                    {
                        book.Id = (int) Convert.ToInt64(rdr["id"]);
                        book.Title = (string)rdr["title"];
                        book.Author = (string)rdr["author"];
                        book.Year = (string) (rdr["year"]);
                        book.Genre = (string)rdr["genre"];

                        byte[] img_bytes = (byte[])rdr["cover"];
                        book.Cover = CUtility.byteArrayToImage(img_bytes);

                        book.Rating = (int) Convert.ToInt64(rdr["rating"]);
                        book.Pages = (int) Convert.ToInt64(rdr["pages"]);
                    }
                }
                rdr.Close();

                AddBookToListOnly(book);
                return book;
            }
            catch
            {
                
            }
            finally
            {
                con.Close();
            }
            return null;
        }
        public static void Update(Book book) 
        {
            using SQLiteConnection? con = SQLiteAdapter.GetConnection();
            using var cmd = new SQLiteCommand(con);
            try
            {
                con.Open();
                cmd.CommandText = "UPDATE Books SET "+ "id=@id "+
                    "title=@title, author=@author, year = @year, "+
                    "genre=@genre, cover=@cover, rating=@rating, "+
                    "pages=@pages "+
                    $"WHERE id = {book.Id}";

                SQLiteParameter blobParam = new SQLiteParameter("@cover", System.Data.DbType.Binary);
                blobParam.Value = CUtility.imageToByteArray(book.Cover);

                cmd.Parameters.AddWithValue("@id", book.Id);
                cmd.Parameters.AddWithValue("@title", book.Title);
                cmd.Parameters.AddWithValue("@author", book.Author);
                cmd.Parameters.AddWithValue("@year", book.Year);
                cmd.Parameters.AddWithValue("@genre", book.Genre);
                cmd.Parameters.Add(blobParam);
                cmd.Parameters.AddWithValue("@rating", book.Rating);
                cmd.Parameters.AddWithValue("@pages", book.Pages);

                cmd.ExecuteNonQuery();

            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
            var old = Books.Find(c => c.Id == book.Id);
            if (old != null)
            {
                old.Title = book.Title;
                old.Author = book.Author;
                old.Year = book.Year;
                old.Genre = book.Genre;
                old.Rating = book.Rating;
                old.Pages = book.Pages;
            }  
        }
        public static void Delete(Book book)
        {
            using SQLiteConnection? con = SQLiteAdapter.GetConnection();
            using var cmd = new SQLiteCommand(con);
            try
            {
                con.Open();
                cmd.CommandText = $"DELETE FROM Books WHERE id = {book.Id}";
                cmd.ExecuteNonQuery();

            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
            Books.Remove(book);
        }
        public static void ReadAll()
        {
            using SQLiteConnection? con = SQLiteAdapter.GetConnection();
            using var cmd = new SQLiteCommand(con);
            try
            {
                con.Open();
                cmd.CommandText = "SELECT * FROM Books";

                using SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Book book = new Book();

                    if (!rdr.IsDBNull(0))
                    {
                        book.Id = (int)Convert.ToInt64(rdr["id"]);
                        book.Title = (string)rdr["title"];
                        book.Author = (string)rdr["author"];
                        book.Year = (string)(rdr["year"]);
                        book.Genre = (string)rdr["genre"];

                        byte[] img_bytes = (byte[])rdr["cover"];
                        book.Cover = CUtility.byteArrayToImage(img_bytes);

                        book.Rating = (int)Convert.ToInt64(rdr["rating"]);
                        book.Pages = (int)Convert.ToInt64(rdr["pages"]);
                    }

                    AddBookToListOnly(book);
                }
                rdr.Close();
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }

        public static List<Book>? GetAll()
        {
            ReadAll();

            if (Books is null)
            {
                return null;
            }
            else
            {
                return Books;
            }
        }
    }
}
