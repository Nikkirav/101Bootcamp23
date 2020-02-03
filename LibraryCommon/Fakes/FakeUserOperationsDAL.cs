using LibraryCommon.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommon.Fakes
{
    public class FakeUserOperationsDAL : IUserOperationsDAL
    {
        public IDbConnection Connection { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ResultUsers LoginUserToDatabase(User inUser)
        {
            throw new NotImplementedException();
        }

        public Result RegisterUserToDatabase(User inUser)
        {
            return new Result() { Message = "User registered.", Type = ResultType.Success };
        }
    }
}
