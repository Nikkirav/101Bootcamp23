using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LibraryDatabaseAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryCommon.DataEntity;
using System.Linq;

namespace LibraryUnitTest
{

    [TestClass]
    public class UnitTestRoleDataAccess
    {

        // THIS SHOULD BE YOUR LibraryUnitTest DB
        // private readonly string _conn = @"Server=LAPTOP-1RTOL5OV\SQLEXPRESS01;Database=LibraryUnitTest;Trusted_Connection=True;"; 
        public  string _conn =  "Data Source=LAPTOP-401;Initial Catalog=LibraryUnitTest;Integrated Security=True";
        private RoleDataAccess _data;

        // constructor 
        public UnitTestRoleDataAccess() 
        {
            _data = new RoleDataAccess(_conn);
        }

        [TestMethod]
        public void Connect_To_DataBase_Open_Closed()
        {
            // arrange
            SqlConnection _sqlConnection = new SqlConnection(_conn);
            string o, c;

            // act
            _sqlConnection.Open();
            Console.WriteLine("Connection is " + _sqlConnection.State.ToString());
            o = _sqlConnection.State.ToString().ToUpper();

            _sqlConnection.Close();
            Console.WriteLine("Connection is " + _sqlConnection.State.ToString());
            c = _sqlConnection.State.ToString().ToUpper();

            // assert
            Assert.AreEqual(o, "OPEN");
            Assert.AreEqual(c, "CLOSED");
        }


        [TestMethod]
        public void Add_One_Role()
        {
            // arrange
            List<Role> list = new List<Role>();

            // act
            list = _data.GetRoles();
            int _countBeforeAdd = list.Count;

            Role r = new Role { RoleID = 0, RoleName = "Testing Role Another" };

            // assert
            int key = _data.CreateRole(r); // should add a new row of data to db
            list = _data.GetRoles();
            int _countAfterAdd = list.Count;

            Assert.IsTrue(_countBeforeAdd + 1 == _countAfterAdd);

        }

        [TestMethod]
        public void Add_Role_Then_Delete_Role() 
        {

            // arrange
            List<Role> list = new List<Role>();

            // act
            Guid id = Guid.NewGuid();
            string roleName = "Testing Role - guid: " + id.ToString();
            Role r = new Role { RoleID = 0, RoleName = roleName };

            // assert
            int key = _data.CreateRole(r); // need to delete this one
            list = _data.GetRoles();
            Role findIt = list.Where(f => f.RoleName == roleName).FirstOrDefault();
            Assert.IsNotNull(findIt);
            _data.DeleteRole(new Role { RoleID = key }); // cleanup
            list = _data.GetRoles();
            findIt = list.Where(f => f.RoleName == roleName).FirstOrDefault();
            Assert.IsNull(findIt);
        }

        [TestMethod]
        public void Add_Role_Update_RoleName_Then_Delete()
        {

            // arrange
            Role r = new Role { RoleName = "Mock Role" };
            _data.CreateRole(r);

            // act



            // assert

            
        }

        [TestMethod]
        public void Get_Roles_Count_Add_Role_And_Recount()
        {

            throw new NotImplementedException();
            // arrange

            // act

            // assert

        }

    }


}
