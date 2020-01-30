using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommon
{
    public class ResultUsers : Result
    {
       
        // properties
        public List<User> ListOfUsers { get; set; }

        // constructors
        public ResultUsers(List<User> inListOfUsers)
        {
            this.ListOfUsers = inListOfUsers;
        }

        public ResultUsers()
        {
        }
    }
}
