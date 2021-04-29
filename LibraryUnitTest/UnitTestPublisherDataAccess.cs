using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LibraryCommon.DataEntity;
using LibraryDatabaseAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryUnitTest
{
    [TestClass]
    public class UnitTestPublisherDataAccess
    {
        // THIS SHOULD BE YOUR LibraryUnitTest DB
        // private readonly string _conn = @"Server=LAPTOP-1RTOL5OV\SQLEXPRESS01;Database=LibraryUnitTest;Trusted_Connection=True;"; 
        public string _conn = "Data Source=LAPTOP-401;Initial Catalog=LibraryUnitTest;Integrated Security=True";
        private PublisherDataAccess _data;

        // constructor 
        public UnitTestPublisherDataAccess()
        {
            _data = new PublisherDataAccess(_conn);
        }


        [TestMethod]
        public void Add_One_Publisher()
        {

            // get count of current list, add one publisher, get the list a second time 
            // and this next time there should be an extra publisher
            // arrange
            List<Publisher> list = new List<Publisher>();
            list = _data.GetPublishers();
            int _countBeforeAdding = list.Count;

            // act
            Publisher p = new Publisher
            {
                PublisherID = 0,
                Address = "1109 Wonderplace Lane",
                City = "Venus",
                Name = "Best Publisher",
                State = "MO",
                Zip = 65203
            };

            _data.CreatePublisher(p);
            list = _data.GetPublishers();
            int _countAfterAdding = list.Count;

            // assert
            Assert.AreEqual(_countBeforeAdding + 1, _countAfterAdding);
        }
    }
}
