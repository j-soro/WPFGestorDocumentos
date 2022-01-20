using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGestorDocumentos.Models
{
    public class User
    {
        private int id { get; set; }

        private int userName { get; set; }

        private int password { get; set; }

        private string firstName { get; set; }

        private int lastName { get; set; }

        private Image image { get; set; }

        private List<Book> userBooks { get; set; }
    }
}
