using LibraryCommon;
using LibraryCommon.DataEntity;
using LibraryDatabaseAccessLayer;
using System;
using System.Collections.Generic;


namespace LibraryBusinessLogicLayer
{
    public class UserBusinessLogic
    {
        // data
        private UserDataAccess _data;

        // constructor
        public UserBusinessLogic()
        {
            _data = new UserDataAccess();
        }

        public UserBusinessLogic(string conn)
        {
            _data = new UserDataAccess(conn);
        }

        public ResultUsers LoginUser(LibraryCommon.DataEntity.User user)
        {
            throw new NotImplementedException();
        }

        public Result RegisterUser(LibraryCommon.DataEntity.User user)
        {
            throw new NotImplementedException();
        }
    }

}
