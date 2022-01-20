using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFGestorDocumentos.Models;

namespace WPFGestorDocumentos.Services
{
    public interface ILoginService
    {
        UserData DoLogin(string username, string password);

    }
}
