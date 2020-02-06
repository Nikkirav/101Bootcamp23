using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryWebApp.Models
{
    public class BooksModel : BaseModel
    {

        public IEnumerable<BookModel> ListOfBookModel { get; set; }


    }
}