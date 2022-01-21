using System;
using System.ComponentModel;
using System.Drawing;
using WPFGestorDocumentos.Entities;

namespace WPFGestorDocumentos.Entities
{
    public class Book : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

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

        public string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        public string _author;
        public string Author
        {
            get { return _author; }
            set
            {
                if (value != _author)
                {
                    _author = value;
                    NotifyPropertyChanged("Author");
                }
            }
        }

        public int _year;
        public int Year
        {
            get { return _year; }
            set
            {
                if (value != _year)
                {
                    _year = value;
                    NotifyPropertyChanged("Year");
                }
            }
        }
        public string _genre;
        public string Genre
        {
            get { return _genre; }
            set
            {
                if (value != _genre)
                {
                    _genre = value;
                    NotifyPropertyChanged("Genre");
                }
            }
        }

        public Image _cover;
        public Image Cover
        {
            get { return _cover; }
            set
            {
                if (value != _cover)
                {
                    _cover = value;
                    NotifyPropertyChanged("Cover");
                }
            }
        }
        public int _rating;
        public int Rating
        {
            get { return _rating; }
            set
            {
                if (value != _rating)
                {
                    _rating = value;
                    NotifyPropertyChanged("Rating");
                }
            }
        }
        public int _pages;
        public int Pages
        {
            get { return _pages; }
            set
            {
                if (value != _pages)
                {
                    _pages = value;
                    NotifyPropertyChanged("Pages");
                }
            }
        }

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}