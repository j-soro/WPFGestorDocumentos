using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WPFGestorDocumentos.Models;

namespace WPFGestorDocumentos.Exceptions
{
    public class BookCollectionConflictException : Exception
    {
        public BookCollection ExistingBookCollection { get; }
        public BookCollection IncomingBookCollection { get; }

        public BookCollectionConflictException(BookCollection existingBookCollecton, BookCollection incomingBookCollecton)
        {
            ExistingBookCollection = existingBookCollecton;
            IncomingBookCollection = incomingBookCollecton;
        }

        public BookCollectionConflictException(string? message, BookCollection existingBookCollecton, BookCollection incomingBookCollecton) : base(message)
        {
            ExistingBookCollection = existingBookCollecton;
            IncomingBookCollection = incomingBookCollecton;
        }

        public BookCollectionConflictException(string? message, Exception? innerException, BookCollection existingBookCollecton, BookCollection incomingBookCollecton) : base(message, innerException)
        {
            ExistingBookCollection = existingBookCollecton;
            IncomingBookCollection = incomingBookCollecton;
        }
    }
}
