using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommon
{
    public class ResultBooks : Result
    {

        public IEnumerable<Book> ListOfBooks { get; set; }

    }
}
