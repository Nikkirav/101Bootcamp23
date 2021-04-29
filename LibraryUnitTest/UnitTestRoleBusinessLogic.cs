using System;
using System.Collections.Generic;
using LibraryBusinessLogicLayer;
using LibraryCommon.DataEntity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryUnitTest
{
    [TestClass]
    public class UnitTestRoleBusinessLogic
    {

        // THIS SHOULD BE YOUR LibraryUnitTest DB
        // private readonly string _conn = @"Server=LAPTOP-1RTOL5OV\SQLEXPRESS01;Database=LibraryUnitTest;Trusted_Connection=True;"; 
        public string _conn = "Data Source=LAPTOP-401;Initial Catalog=LibraryUnitTest;Integrated Security=True";
        private RoleBusinessLogic _businesslogic;

        // constructor 
        public UnitTestRoleBusinessLogic()
        {
            _businesslogic = new RoleBusinessLogic(_conn);
        }

        [TestMethod]
        public void Get_Roles_Thru_Business_Logic()
        {
            // arrange

            // act
            List<Role> _callOne = _businesslogic.GetRolesPassThru();
            List<Role> _callTwo = _businesslogic.GetRolesPassThru();

            // assert
            Assert.AreEqual(_callOne.Count, _callTwo.Count);
        }

        public void Add_Role_Thru_Business_Logic() 
        { 
        
        
        
        }
    }
}
