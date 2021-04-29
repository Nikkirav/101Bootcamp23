using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommon
{
    public enum ResultType
    {
        Not_Set = -1,
        Failure = 0,
        Success = 1
    }


    public enum RoleType
    { 
        Anonymous = 0,
        Administrator = 1,
        Librarian = 2,
        Patron = 3 
    }

}
