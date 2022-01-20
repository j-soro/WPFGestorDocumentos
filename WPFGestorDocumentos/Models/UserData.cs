using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGestorDocumentos.Models
{
    public class UserData
    {
        public string id { get; set; }
        public string name { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public List<Book> books { get; set; }


    }
}
