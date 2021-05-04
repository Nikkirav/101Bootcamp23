using System;
using System.Data.SqlClient;
using LibraryCommon.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryUnitTest
{
    [TestClass]
    public class UnitTestExceptionLogging
    {

        public string _connBad = "Data Source=LAPTOP-401;Initial Catalog=LibraryPhatPhinger;Integrated Security=True";
        public string _conn = "Data Source=LAPTOP-401;Initial Catalog=LibraryUnitTest;Integrated Security=True";
        public ExceptionLogging _logIt;

        // constructor 
        public UnitTestExceptionLogging()
        {
            _logIt = new ExceptionLogging(_conn);
        }


        [TestMethod]
        public void Throw_Not_Implemented_Exception()
        {

            // arrange
            Exception ex = new NotImplementedException();

            // act
            _logIt.LogException(ex);

            // assert 
            Assert.IsNotNull(ex);
        }
        
      
        [TestMethod]
        public void Throw_Database_Connection_Error()
        {
            // arrange
            SqlConnection _sqlConnectionBad = new SqlConnection(_connBad);
            SqlConnection _sqlConnection = new SqlConnection(_conn);

            // act
            try
            {
                _sqlConnectionBad.Open(); // should fail

            }
            catch (Exception ex)
            {
                _sqlConnection.Open();
                _logIt.LogException(ex);
                Assert.IsNotNull(ex);
            }
            finally 
            {
                
                _sqlConnectionBad.Close();
                _sqlConnection.Close();

            }

        }
          
        
    }
}
