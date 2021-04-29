using System;
using System.Data.SqlClient;
using LibraryCommon;
using LibraryCommon.Interfaces;
using LibraryDatabaseAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace LibraryUnitTest
//{
//    [TestClass]
//    public class UserOperationDALUnitTest
//    {

//        private readonly string _conn = @"Server=LAPTOP-1RTOL5OV\SQLEXPRESS01;Database=LibraryUnitTest;Trusted_Connection=True;"; // THIS SHOULD BE YOUR LibraryUnitTest DB

//        public UserOperationDALUnitTest() 
//        {
           

//        }


//        [TestMethod]
//        public void UserOpertionsDAL_RegisterUser_AddUserSuccess()
//        {

//            // arrange
//            // first attempt - using a fake
//            //IUserOperationsDAL _userOperationsDAL = new FakeUserOperationsDAL(); OLD
//            // NEW
//            IUserOperationsDAL _userOperationsDAL = new UserOperationsDAL();
//            _userOperationsDAL.Connection = new SqlConnection(_conn);
//            User _user = new User()
//            {
//                FirstName = "Tester1234",
//                LastName = "Tester1234",
//                Password = "password123",
//                RoleId = (int)RoleType.Patron,
//                UserId = 0,
//                Username = "tester1234"
//            };


//            // act
//            Result _result = _userOperationsDAL.RegisterUserToDatabase(_user);

//            // assert
//            Assert.AreEqual(ResultType.Success, _result.Type);
//            Assert.AreEqual("User registered successfully. Please login.", _result.Message);


//            // POST TEST TODO: remove user

//        }


//        [TestMethod]
//        public void UserOpertionsDAL_RegisterUser_AddUserDuplicateFailure()
//        {

//            // arrange
//            IUserOperationsDAL _userOperationsDAL = new UserOperationsDAL();
//            _userOperationsDAL.Connection = new SqlConnection(_conn);
//            User _user = new User()
//            {

//                FirstName = "Giancarlo",
//                LastName = "Rhodes",
//                Password = "password123",
//                RoleId = (int)RoleType.Administrator,
//                UserId = 0,
//                Username = "grhodes29"
//            };

//            // act
//            Result _result = _userOperationsDAL.RegisterUserToDatabase(_user);

//            // assert
//            Assert.AreEqual(ResultType.Failure, _result.Type);
//            Assert.AreEqual("Duplicate Username exists. Please change Username and re-submit.", _result.Message);


//        }

//    }
//}
