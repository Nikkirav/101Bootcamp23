using LibraryCommon;
using LibraryDatabaseAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessLogicLayer
{
    public class UserOperationsBLL
    {
        // fields
        private IDbConnection _connection;

        // constructors
        public UserOperationsBLL(IDbConnection inIDbConnection)         
        {
            this._connection = inIDbConnection;
        }

        // methods
        public Result RegisterUser(User inUser) 
        {
            // 3. send the input down to the database and check for duplicate username

            // 3.d  create a user operations dal object
            UserOperationsDAL _userOperationsDAL = new UserOperationsDAL(this._connection);

            // 3.e need a method that takes a User object and return a Result object
            Result _result = _userOperationsDAL.RegisterUserToDatabase(inUser);

            // 3.f return the Result
            return _result;
        }



    }
}
