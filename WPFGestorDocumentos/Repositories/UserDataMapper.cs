using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFGestorDocumentos.Adapters;
using WPFGestorDocumentos.Entities;
using WPFGestorDocumentos.Utility;

namespace WPFGestorDocumentos.Repositories
{
    internal class UserDataMapper
    {
        public static List<User> Users { get; set; }

        public static void AddUserToListOnly(User user)
        {
            if (!Users.Contains(user)) { Users.Add(user); }
        }

        public static void Create(User user)
        {
            using SQLiteConnection? con = SQLiteAdapter.GetConnection();
            using var cmd = new SQLiteCommand(con);
            try
            {
                con.Open();
                cmd.CommandText = "INSERT INTO Users(id, username, password, firstname, lastname, picture) VALUES(@id, @username, @password, @firstname, @lastname, @picture)";

                SQLiteParameter blobParam = new SQLiteParameter("@picture", System.Data.DbType.Binary);
                blobParam.Value = CUtility.imageToByteArray(user.Picture);

                cmd.Parameters.AddWithValue("@id", user.Id);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@firstname", user.FirstName);
                cmd.Parameters.AddWithValue("@lastname", user.LastName);
                cmd.Parameters.Add(blobParam);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            AddUserToListOnly(user);
        }

        public static User Find(long userId)
        {
            using SQLiteConnection? con = SQLiteAdapter.GetConnection();
            using var cmd = new SQLiteCommand(con);
            try
            {
                con.Open();
                cmd.CommandText = "SELECT FROM Users WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", userId);
                cmd.Prepare();

                User user = new User();

                using SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(0))
                    {
                        user.Id = (int)Convert.ToInt64(rdr["id"]);
                        user.Username = (string)rdr["username"];
                        user.Password = (string)rdr["password"];
                        user.FirstName = (string)(rdr["firstname"]);
                        user.LastName = (string)rdr["lastname"];

                        byte[] img_bytes = (byte[])rdr["picture"];
                        user.Picture = CUtility.byteArrayToImage(img_bytes);
                    }
                }
                rdr.Close();

                AddUserToListOnly(user);
                return user;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return null;
        }

        public static void Delete(User user)
        {
            using SQLiteConnection? con = SQLiteAdapter.GetConnection();
            using var cmd = new SQLiteCommand(con);
            try
            {
                con.Open();
                cmd.CommandText = $"DELETE FROM Users WHERE id = {user.Id}";
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            Users.Remove(user);
        }

        public static void Update(User user)
        {
            using SQLiteConnection? con = SQLiteAdapter.GetConnection();
            using var cmd = new SQLiteCommand(con);
            try
            {
                con.Open();
                cmd.CommandText = "UPDATE Users SET " + "id=@id " +
                    "username=@username, password=@password, firstname = @firstname, " +
                    "lastname=@lastname, picture=@picture " +
                    $"WHERE id = {user.Id}";

                SQLiteParameter blobParam = new SQLiteParameter("@picture", System.Data.DbType.Binary);
                blobParam.Value = CUtility.imageToByteArray(user.Picture);

                cmd.Parameters.AddWithValue("@id", user.Id);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@firstname", user.FirstName);
                cmd.Parameters.AddWithValue("@lastname", user.LastName);
                cmd.Parameters.Add(blobParam);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            var old = Users.Find(c => c.Id == user.Id);
            if (old != null)
            {
                old.Username = user.Username;
                old.Password = user.Password;
                old.FirstName = user.FirstName;
                old.LastName = user.LastName;
                old.Picture = user.Picture;
            }
        }

        public static void ReadAll()
        {
            using SQLiteConnection? con = SQLiteAdapter.GetConnection();
            using var cmd = new SQLiteCommand(con);
            try
            {
                con.Open();
                cmd.CommandText = "SELECT * FROM Users";

                using SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    User user = new User();

                    if (!rdr.IsDBNull(0))
                    {
                        user.Id = (int)Convert.ToInt64(rdr["id"]);
                        user.Username = (string)rdr["username"];
                        user.Password = (string)rdr["password"];
                        user.FirstName = (string)(rdr["firstname"]);
                        user.LastName = (string)rdr["lastname"];

                        byte[] img_bytes = (byte[])rdr["picture"];
                        user.Picture = CUtility.byteArrayToImage(img_bytes);
                    }

                    AddUserToListOnly(user);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
        }

        public static List<User> GetAll()
        {
            ReadAll();

            if (Users is null)
            {
                return null;
            }
            else
            {
                return Users;
            }
        }
    }
}
