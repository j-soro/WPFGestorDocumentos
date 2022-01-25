using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGestorDocumentos.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Image Picture { get; set; }

        public User()
        {

        }

        public User(int id, string username, string password, string firstname, string lastname, Image picture)
        {
            Id = id;
            Username = username;
            Password = password;
            Firstname = firstname;
            Lastname = lastname;
            Picture = picture;
        }

        internal void UpdateUserInfo(User newUserInfo)
        {
            Id = newUserInfo.Id;
            Username = newUserInfo.Username;
            Password = newUserInfo.Password;
            Firstname = newUserInfo.Firstname;
            Lastname = newUserInfo.Lastname;
            Picture = newUserInfo.Picture;
        }
    }
}
