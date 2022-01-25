using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WPFGestorDocumentos.Exceptions
{
    public class BookIdNotFoundException : Exception
    {
        public int Id { get; }
        public BookIdNotFoundException(int id)
        {
            Id = id;
        }

        public BookIdNotFoundException(string? message, int id) : base(message)
        {
            Id = id;
        }

        public BookIdNotFoundException(string? message, Exception? innerException, int id) : base(message, innerException)
        {
            Id = id;
        }
    }
}
