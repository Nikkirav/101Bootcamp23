using LibraryCommon.DataEntity;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LibraryDatabaseAccessLayer
{
    public class BookDataAccess 
    {
        private readonly string _conn;

        public BookDataAccess(string conn) 
        { 
            _conn = conn;
        }

        public List<Book> GetBooks()
        {

            // TESTing - just mock the list right now
            // MockBooks _mockBooks = new MockBooks();
            // return _mockBooks.Books;

            // implement this with ado.net  
            List<Book> _list = new List<Book>();
            using (SqlConnection con = new SqlConnection(_conn))
            {
                using (SqlCommand _sqlCommand = new SqlCommand("spGetBook", con))
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    _sqlCommand.CommandTimeout = 30;

                    con.Open();
                    Book _book;
                    using (SqlDataReader reader = _sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _book = new Book
                            {
                                BookID = reader.GetInt32(reader.GetOrdinal("BookID")),
                                Title = (string)reader["Title"],
                                Description = (string)reader["Description"],
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                IsPaperback = reader.GetBoolean(reader.GetOrdinal("IsPaperBack")),
                                PublishDate = reader.GetDateTime(reader.GetOrdinal("PublishDate")),
                                AuthorID_FK = reader.GetInt32(reader.GetOrdinal("AuthorID_FK")),
                                GenreID_FK = reader.GetInt32(reader.GetOrdinal("GenreID_FK")),
                                PublisherID_FK = reader.GetInt32(reader.GetOrdinal("PublisherID_FK"))
                            };
                            _list.Add(_book);
                        }
                    }
                    con.Close();
                }
            }
            return _list;
        }

        public int CreateBook(Book b)
        {
            using (SqlConnection con = new SqlConnection(_conn))
            {
                using (SqlCommand _sqlCommand = new SqlCommand("spCreateBook", con))
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    _sqlCommand.CommandTimeout = 30;

                    SqlParameter _paramTitle = _sqlCommand.CreateParameter();
                    _paramTitle.DbType = DbType.String;
                    _paramTitle.ParameterName = "@ParamTitle";
                    _paramTitle.Value = b.Title;
                    _sqlCommand.Parameters.Add(_paramTitle);

                    SqlParameter _paramDescription = _sqlCommand.CreateParameter();
                    _paramDescription.DbType = DbType.String;
                    _paramDescription.ParameterName = "@ParamDescription";
                    _paramDescription.Value = b.Description;
                    _sqlCommand.Parameters.Add(_paramDescription);

                    SqlParameter _paramPrice = _sqlCommand.CreateParameter();
                    _paramPrice.DbType = DbType.Decimal;
                    _paramPrice.ParameterName = "@ParamPrice";
                    _paramPrice.Value = b.Price;
                    _sqlCommand.Parameters.Add(_paramPrice);

                    SqlParameter _paramIsPaperBack = _sqlCommand.CreateParameter();
                    _paramIsPaperBack.DbType = DbType.Boolean;
                    _paramIsPaperBack.ParameterName = "@ParamIsPaperBack";
                    _paramIsPaperBack.Value = b.IsPaperback;
                    _sqlCommand.Parameters.Add(_paramIsPaperBack);

                    SqlParameter _paramPublishDate = _sqlCommand.CreateParameter();
                    _paramPublishDate.DbType = DbType.DateTime;
                    _paramPublishDate.ParameterName = "@ParamPublishDate";
                    _paramPublishDate.Value = b.PublishDate;
                    _sqlCommand.Parameters.Add(_paramPublishDate);

                    SqlParameter _paramGenreIDFK = _sqlCommand.CreateParameter();
                    _paramGenreIDFK.DbType = DbType.Int32;
                    _paramGenreIDFK.ParameterName = "@ParamGenreID_FK";
                    _paramGenreIDFK.Value = b.GenreID_FK;
                    _sqlCommand.Parameters.Add(_paramGenreIDFK);

                    SqlParameter _paramAuthorIDFK = _sqlCommand.CreateParameter();
                    _paramAuthorIDFK.DbType = DbType.Int32;
                    _paramAuthorIDFK.ParameterName = "@ParamAuthorID_FK";
                    _paramAuthorIDFK.Value = b.AuthorID_FK;
                    _sqlCommand.Parameters.Add(_paramAuthorIDFK);

                    SqlParameter _paramPublisherIDFK = _sqlCommand.CreateParameter();
                    _paramPublisherIDFK.DbType = DbType.Int32;
                    _paramPublisherIDFK.ParameterName = "@ParamPublisherID_FK";
                    _paramPublisherIDFK.Value = b.PublisherID_FK;
                    _sqlCommand.Parameters.Add(_paramPublisherIDFK);

                    SqlParameter _paramBookIDReturn = _sqlCommand.CreateParameter();
                    _paramBookIDReturn.DbType = DbType.Int32;
                    _paramBookIDReturn.ParameterName = "@ParamOutBookID";
                    _sqlCommand.Parameters.Add(_paramBookIDReturn);
                    _paramBookIDReturn.Direction = ParameterDirection.Output;

                    con.Open();
                    _sqlCommand.ExecuteNonQuery();   // calls the sp                                                      
                    var result = _paramBookIDReturn.Value;
                    con.Close();
                    return (int)result;
                }

            }
        }

        public void UpdateBook(Book b)
        {
            using (SqlConnection con = new SqlConnection(_conn))
            {
                using (SqlCommand _sqlCommand = new SqlCommand("spUpdateBook", con))
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    _sqlCommand.CommandTimeout = 30;

                    SqlParameter _paramBookID = _sqlCommand.CreateParameter();
                    _paramBookID.DbType = DbType.Int32;
                    _paramBookID.ParameterName = "@ParamBookID";
                    _paramBookID.Value = b.BookID;
                    _sqlCommand.Parameters.Add(_paramBookID);

                    SqlParameter _paramTitle = _sqlCommand.CreateParameter();
                    _paramTitle.DbType = DbType.String;
                    _paramTitle.ParameterName = "@ParamTitle";
                    _paramTitle.Value = b.Title;
                    _sqlCommand.Parameters.Add(_paramTitle);

                    SqlParameter _paramDescription = _sqlCommand.CreateParameter();
                    _paramDescription.DbType = DbType.String;
                    _paramDescription.ParameterName = "@ParamDescription";
                    _paramDescription.Value = b.Description;
                    _sqlCommand.Parameters.Add(_paramDescription);

                    SqlParameter _paramPrice = _sqlCommand.CreateParameter();
                    _paramPrice.DbType = DbType.Decimal;
                    _paramPrice.ParameterName = "@ParamPrice";
                    _paramPrice.Value = b.Price;
                    _sqlCommand.Parameters.Add(_paramPrice);

                    SqlParameter _paramIsPaperBack = _sqlCommand.CreateParameter();
                    _paramIsPaperBack.DbType = DbType.Boolean;
                    _paramIsPaperBack.ParameterName = "@ParamIsPaperBack";
                    _paramIsPaperBack.Value = b.IsPaperback;
                    _sqlCommand.Parameters.Add(_paramIsPaperBack);

                    SqlParameter _paramPublishDate = _sqlCommand.CreateParameter();
                    _paramPublishDate.DbType = DbType.DateTime;
                    _paramPublishDate.ParameterName = "@ParamPublishDate";
                    _paramPublishDate.Value = b.PublishDate;
                    _sqlCommand.Parameters.Add(_paramPublishDate);

                    SqlParameter _paramGenreIDFK = _sqlCommand.CreateParameter();
                    _paramGenreIDFK.DbType = DbType.Int32;
                    _paramGenreIDFK.ParameterName = "@ParamGenreID_FK";
                    _paramGenreIDFK.Value = b.GenreID_FK;
                    _sqlCommand.Parameters.Add(_paramGenreIDFK);

                    SqlParameter _paramAuthorIDFK = _sqlCommand.CreateParameter();
                    _paramAuthorIDFK.DbType = DbType.Int32;
                    _paramAuthorIDFK.ParameterName = "@ParamAuthorID_FK";
                    _paramAuthorIDFK.Value = b.AuthorID_FK;
                    _sqlCommand.Parameters.Add(_paramAuthorIDFK);

                    SqlParameter _paramPublisherIDFK = _sqlCommand.CreateParameter();
                    _paramPublisherIDFK.DbType = DbType.Int32;
                    _paramPublisherIDFK.ParameterName = "@ParamPublisherID_FK";
                    _paramPublisherIDFK.Value = b.PublisherID_FK;
                    _sqlCommand.Parameters.Add(_paramPublisherIDFK);

                    con.Open();
                    _sqlCommand.ExecuteNonQuery();   // calls the sp                                                      
                    con.Close();

                }
            }
        }

        public void DeleteBook(Book b)
        {
            using (SqlConnection con = new SqlConnection(_conn))
            {
                using (SqlCommand _sqlCommand = new SqlCommand("spDeleteBook", con))
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    _sqlCommand.CommandTimeout = 30;

                    SqlParameter _parameter = _sqlCommand.CreateParameter();
                    _parameter.DbType = DbType.Int32;
                    _parameter.ParameterName = "@ParamBookID";
                    _parameter.Value = b.BookID;
                    _sqlCommand.Parameters.Add(_parameter);

                    con.Open();
                    _sqlCommand.ExecuteNonQuery();   // calls the sp                 
                    con.Close();
                }
            }
        }

    }
}
