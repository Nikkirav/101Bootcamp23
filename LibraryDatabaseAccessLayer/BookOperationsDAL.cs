using LibraryCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabaseAccessLayer
{
    public class BookOperationsDAL
    {

        // fields
        private IDbConnection _connection;
        private Logger _logger;

        // properties
        public IDbConnection Connection { get => _connection; set => _connection = value; }

        // properties

        // constructors
        public BookOperationsDAL(IDbConnection inConnection)
        {
            // 3.f create a db connection
            this._connection = inConnection;
            this._logger = new Logger(inConnection);
        }

        public ResultBooks GetBooksFromDatabase(int inUserId)
        {

            // declare variables
            List<Book> _listOfBooks = new List<Book>();
            ResultBooks _resultBooks = new ResultBooks();

            try
            {
              
                // 3.g create a db commmnd
                using (IDbCommand _command = this._connection.CreateCommand())
                {

                    // open connection
                    this._connection.Open();

                    // set the command properties
                    _command.CommandText = "sp_get_books_main";
                    _command.CommandType = System.Data.CommandType.StoredProcedure;
                    _command.CommandTimeout = 15;

                    // parameter
                    // @parm_userid int= 0,
                    // @parm_username varchar(255) = '',
                    // @parm_password varchar(255) = ''                  

                    IDbDataParameter _parameterUserId = _command.CreateParameter();
                    _parameterUserId.DbType = DbType.Int32;
                    _parameterUserId.ParameterName = "@parm_userid";
                    _parameterUserId.Value = inUserId;
                    _command.Parameters.Add(_parameterUserId);

                    // loop to read rows
                    // 3.h run the command
                    using (IDataReader _reader = _command.ExecuteReader())
                    {

                      //  [BookID]
                      //,[Title]
                      //,[Author]
                      //,[Genre]
                      //,[UserID]
                      //,[Borrower]
                      //,[CheckOutDate]
                      //,[DueDateBack]
                      //,[ReturnedDate]
                      //,[BookStatus]


                        int _bookIDPosition = _reader.GetOrdinal("BookID");
                        int _titlePosition = _reader.GetOrdinal("Title");
                        int _authorPosition = _reader.GetOrdinal("Author");
                        int _genrePosition = _reader.GetOrdinal("Genre");
                        int _userIdPosition = _reader.GetOrdinal("UserID");
                        int _borrowerPosition = _reader.GetOrdinal("Borrower");
                        int _checkOutDatePosition = _reader.GetOrdinal("CheckOutDate");
                        int _dueDateBackPosition = _reader.GetOrdinal("DueDateBack");
                        int _returnedDatePosition = _reader.GetOrdinal("ReturnedDate");
                        int _bookStatusPositiion = _reader.GetOrdinal("BookStatus");

                        while (_reader.Read())
                        {
                            Book _currentBook = new Book();
                            _currentBook.BookID = _reader.GetInt32(_bookIDPosition);
                            _currentBook.Title = _reader.GetString(_titlePosition);
                            _currentBook.Author = _reader.GetString(_authorPosition);
                            _currentBook.Genre = _reader.GetString(_genrePosition);
                            if (_reader.IsDBNull(_userIdPosition)) 
                            {
                                _currentBook.UserID = 0;
                            } 
                            else 
                            {
                                _currentBook.UserID = _reader.GetInt32(_userIdPosition);
                            }
                            if (_reader.IsDBNull(_borrowerPosition))
                            {
                                _currentBook.Borrower = null;
                            }
                            else
                            {
                                _currentBook.Borrower = _reader.GetString(_borrowerPosition);
                            }
                            if (_reader.IsDBNull(_checkOutDatePosition))
                            {
                                _currentBook.CheckOutDate = DateTime.MinValue;
                            }
                            else
                            {
                                _currentBook.CheckOutDate = _reader.GetDateTime(_checkOutDatePosition);
                            }
                            if (_reader.IsDBNull(_dueDateBackPosition))
                            {
                                _currentBook.DueDateBack = DateTime.MinValue;
                            }
                            else
                            {
                                _currentBook.DueDateBack = _reader.GetDateTime(_dueDateBackPosition);
                            }
                            if (_reader.IsDBNull(_returnedDatePosition))
                            {
                                _currentBook.ReturnedDate = DateTime.MinValue;
                            }
                            else
                            {
                                _currentBook.ReturnedDate = _reader.GetDateTime(_returnedDatePosition);
                            }
                            _currentBook.BookStatus = _reader.GetString(_bookStatusPositiion);

                            // add to list
                            _listOfBooks.Add(_currentBook);
                        }

                        _resultBooks.Type = ResultType.Success;
                        _resultBooks.Message = "Get status of books succeeded.";
                        _resultBooks.ListOfBooks = _listOfBooks;
                    }
                }
            }
            catch (Exception ex)
            {
                _connection.Close();
                _resultBooks.Type = ResultType.Failure;
                _resultBooks.Message = "Get status of books failed.";
                _logger.LogException(ex);
                throw;
            }

            return _resultBooks;
        }
    }
}
