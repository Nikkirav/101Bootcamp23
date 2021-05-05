using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommon
{
    public class Result
    {
        // properties
        public string Message { get; set; }
        public ResultType Type { get; set; }

        public Exception Exception { get; set; }

    }
}
