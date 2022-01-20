using System;
using System.Drawing;
namespace WPFGestorDocumentos.Models
{
    public class Book
    {
        private int id { get; set; }

        private string title { get; set; }

        private string author { get; set; }

        private int year { get; set; }

        private int genre { get; set; }

        private Image cover { get; set; }

        private float rating { get; set; }

        private bool isfav { get; set; }

        private int pages { get; set; }

    }
}