using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFGestorDocumentos.Exceptions;
using WPFGestorDocumentos.Models;

namespace WPFGestorDocumentos.Models
{
    public class Session
    {
        private readonly User _user;

        private readonly List<BookCollection> _bookCollections;

        public string Name { get; }

        public Session(string name, User user)
        {
            Name = name;
            _bookCollections = new List<BookCollection>();

            _user = user;
        }
        public IEnumerable<BookCollection> GetCollectionsForUser(string username)
        {
            return _bookCollections.Where(x => x.Username == username);
        }

        public void AddBookCollection(BookCollection NewBookCollection)
        {
            foreach (BookCollection ExistingBookCol in _bookCollections)
            {
                if (ExistingBookCol.Conflicts(NewBookCollection))
                {
                    throw new BookCollectionConflictException(ExistingBookCol, NewBookCollection);
                }
            }
            _bookCollections.Add(NewBookCollection);
        }

        public void RemoveBookCollection(BookCollection RemovedBookCollection)
        {
            _bookCollections.Remove(RemovedBookCollection);
        }

        public void UpdateBookCollection(BookCollection newBookCollection)
        {
            IEnumerable<BookCollection> BookCollections = _bookCollections.Where(b => b.Equals(newBookCollection));
            foreach (BookCollection bookCol in BookCollections)
            {
                bookCol.Books = newBookCollection.Books;
                bookCol.Username = newBookCollection.Username;
                bookCol.Password = newBookCollection.Password;
                bookCol.Name = newBookCollection.Name;
                bookCol.Description = newBookCollection.Description;
            }
        }

        public void EditUserInformation(User newUserInfo)
        {
            _user.UpdateUserInfo(newUserInfo);
        }
    }
}
