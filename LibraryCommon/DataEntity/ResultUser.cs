using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommon.DataEntity
{
    public class ResultUser : Result
    {
        public User User { get; set; }

        public ResultUser()
        {
            User = new User();
        }
    }
}
