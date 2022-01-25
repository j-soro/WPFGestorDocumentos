using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFGestorDocumentos.Models;

namespace WPFGestorDocumentos.Repositories
{
    internal class MockUserRepository : IRepository<User>
    {
        public List<User> Users { get; set; }

        public MockUserRepository()
        {
            Users = GetAll();
        }
        public void Create(User entity)
        {
            Users.Add(entity);
        }

        public void Delete(User entity)
        {
            Users.Remove(entity);
        }

        public List<User> GetAll()
        {
            User user = new User();


            Users.Add(user);

            return Users;
        }

        public User Read(long id)
        {
            return Users.Find(x => x.Id == id);
        }

        public void Update(User user)
        {
            var old = Users.Find(c => c.Id == user.Id);
            if (old != null)
            {
                old.Username = user.Username;
                old.Password = user.Password;
                old.Firstname = user.Firstname;
                old.Lastname = user.Lastname;
                old.Picture = user.Picture;
            }
        }
    }
}
