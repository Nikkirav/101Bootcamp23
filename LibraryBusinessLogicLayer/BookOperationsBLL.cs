namespace LibraryBusinessLogicLayer
{

    using LibraryCommon;
    using LibraryDatabaseAccessLayer;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BookOperationsBLL
    {

        // fields
        private IDbConnection _connection;

        // constructors
        public BookOperationsBLL(IDbConnection inIDbConnection)
        {
            this._connection = inIDbConnection;
        }



        // methods
        public ResultBooks GetBooksPassThru(int inUserId)
        {
      
            BookOperationsDAL _bookOperationsDAL = new BookOperationsDAL(this._connection);
            return _bookOperationsDAL.GetBooksFromDatabase(inUserId);
        }



    }
}
