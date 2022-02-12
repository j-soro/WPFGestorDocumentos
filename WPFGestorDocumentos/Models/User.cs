using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFGestorDocumentos.Models
{
    public class User : INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                if (value != this._id)
                {
                    this._id = value;
                    NotifyPropertyChanged(nameof(Id));
                }
            }
        }

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                if (value != this._username)
                {
                    this._username = value;
                    NotifyPropertyChanged(nameof(Username));
                }
            }
        }
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                NotifyPropertyChanged(nameof(Password));
            }
        }

        private string _firstname;
        public string Firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
                NotifyPropertyChanged(nameof(Firstname));
            }
        }

        private string _lastname;
        public string Lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
                NotifyPropertyChanged(nameof(Lastname));
            }
        }

        private Image _picture;
        public Image Picture
        {
            get
            {
                return _picture;
            }
            set
            {
                _picture = value;
                NotifyPropertyChanged(nameof(Picture));
            }
        }

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

        public User(int id, string username, string password, string firstname, string lastname)
        {
            Id = id;
            Username = username;
            Password = password;
            Firstname = firstname;
            Lastname = lastname;
            Picture = Image.FromFile(@"C:\Users\joaquin\source\repos\WPFGestorDocumentos\WPFGestorDocumentos\Resources\placeholder.png");
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        internal void UpdateUserInfo(User newUserInfo)
        {
            Id = newUserInfo.Id;
            Username = newUserInfo.Username;
            Password = newUserInfo.Password;
            Firstname = newUserInfo.Firstname;
            Lastname = newUserInfo.Lastname;
            Picture = newUserInfo.Picture;
        }

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
