using System;
using System.Data.SqlClient;
using LibraryCommon;
using LibraryCommon.Interfaces;
using LibraryDatabaseAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryUnitTest
{
    [TestClass]
    public class UserOperationDALUnitTest
    {

        private readonly User _user;
        private readonly string _conn = ""; // THIS SHOULD BE YOUR LibraryUnitTest DB

        public UserOperationDALUnitTest() 
        {
            User _user = new User()
            {
                FirstName = "Giancarlo",
                LastName = "Rhodes",
                Password = "password123",
                RoleId = (int)RoleType.Administrator,
                UserId = 0,
                Username = ""
            };

        }


        [TestMethod]
        public void UserOpertionsDAL_RegisterUser_AddUserSuccess()
        {

            //// arrange
            //// first attempt - using a fake
            ////IUserOperationsDAL _userOperationsDAL = new FakeUserOperationsDAL(); OLD
            //// NEW
            //IUserOperationsDAL _userOperationsDAL = new UserOperationsDAL();            
            //_userOperationsDAL.Connection = new SqlConnection(_conn);

            //// act
            //Result _result = _userOperationsDAL.RegisterUserToDatabase(_user);

            //// assert
            //Assert.AreEqual(ResultType.Success, _result.Type);
            //Assert.AreEqual("User registered.", _result.Message);

        }


        [TestMethod]
        public void UserOpertionsDAL_RegisterUser_AddUserDuplicateFailure()
        {

            //// arrange
            //string _conn = "";
            //IUserOperationsDAL _userOperationsDAL = new FakeUserOperationsDAL();
            //_userOperationsDAL.Connection = new SqlConnection(_conn);


            //// act
            //Result _result = _userOperationsDAL.RegisterUserToDatabase(_user);

            //// assert
            //Assert.AreEqual(ResultType.Failure, _result.Type);


        }

    }
}
