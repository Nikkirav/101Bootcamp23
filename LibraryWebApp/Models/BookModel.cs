using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryWebApp.Models
{
    public class BookModel
    {

        public string BookID { get; set; }

        public string UserID { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public string Borrower { get; set;}

        public string CheckOutDate { get; set; }

        public string DueDateBack { get; set; }

        public string ReturnedDate { get; set; }

        public string BookStatus { get; set; }
    }
}