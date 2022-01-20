using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFGestorDocumentos.Models;

namespace WPFGestorDocumentos.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
    }

    internal class UserRepository : IUserRepository
    {
        public List<User> GetAllUsers()
        {
            // Aquí accederíamos a la DB
            return new List<User>();
        }
    }
}
