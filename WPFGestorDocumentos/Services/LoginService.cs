using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFGestorDocumentos.Models;

namespace WPFGestorDocumentos.Services
{
    // servicio: lógica de negocio que va al tercero
    public class LoginService : ILoginService
    {
        public UserData DoLogin(string username, string password)
        {
            return new UserData();
        }
    }
}
