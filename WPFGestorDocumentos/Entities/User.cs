using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFGestorDocumentos.Entities;

namespace WPFGestorDocumentos.Entities
{
    public class User : INotifyPropertyChanged
    {
        public int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }

        public string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                if (value != _username)
                {
                    _username = value;
                    NotifyPropertyChanged("Username");
                }
            }
        }

        public string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    NotifyPropertyChanged("Password");
                }
            }
        }

        public string _firstname;
        public string FirstName
        {
            get { return _firstname; }
            set
            {
                if (value != _firstname)
                {
                    _firstname = value;
                    NotifyPropertyChanged("FirstName");
                }
            }
        }

        public string _lastname;
        public string LastName
        {
            get { return _lastname; }
            set
            {
                if (value != _lastname)
                {
                    _lastname = value;
                    NotifyPropertyChanged("LastName");
                }
            }
        }

        public Image _picture;
        public Image Picture
        {
            get { return _picture; }
            set
            {
                if (value != _picture)
                {
                    _picture = value;
                    NotifyPropertyChanged("Picture");
                }
            }
        }

        public List<Book> _userbooks;
        public List<Book> UserBooks
        {
            get { return _userbooks; }
            set
            {
                if (value != _userbooks)
                {
                    _userbooks = value;
                    NotifyPropertyChanged("UserBooks");
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
