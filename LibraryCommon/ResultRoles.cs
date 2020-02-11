using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommon
{
    public class ResultRoles : Result
    {

        public IEnumerable<Role> ListOfRoles { get; set; }

    }
}
