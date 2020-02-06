using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommon
{
    public class Book
    {
        public int BookID { get; set; }

        public int UserID { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public string Borrower { get; set; }

        public DateTime CheckOutDate { get; set; }

        public DateTime DueDateBack { get; set; }

        public DateTime ReturnedDate { get; set; }

        public string BookStatus { get; set; }

    }
}
