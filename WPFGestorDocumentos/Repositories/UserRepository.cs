using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFGestorDocumentos.Entities;

namespace WPFGestorDocumentos.Repositories
{
    internal class UserRepository : IRepository<User>
    {
        public List<User> Users { get; set; }

        public UserRepository()
        {
            Users = GetAll();
        }
        public List<User> GetAll()
        {
            return UserDataMapper.GetAll();
        }

        public void Create(User user)
        {
            UserDataMapper.Create(user);
        }

        public User Read(long userId)
        {
            return UserDataMapper.Find(userId);
        }

        public void Update(User user)
        {
            UserDataMapper.Update(user);
        }

        public void Delete(User user)
        {
            UserDataMapper.Delete(user);
        }
    }
}
