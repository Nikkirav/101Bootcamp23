using LibraryCommon.DataEntity;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LibraryDatabaseAccessLayer
{
    public class AuthorDataAccess
    {
        private readonly string _conn;

        public AuthorDataAccess(string conn) 
        {
            _conn = conn;
        }

        public List<Author> GetAuthors()
        {
            List<Author> _listAuth = new List<Author>();

            using (SqlConnection con = new SqlConnection(_conn))
            {
                using (SqlCommand _sqlCommand = new SqlCommand("spGetAuthor", con))
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    _sqlCommand.CommandTimeout = 30;
                    //_sqlCommand.Parameters.AddWithValue("@BookID", inOneParticularBook);

                    con.Open();
                    Author _Author;

                    using (SqlDataReader reader = _sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _Author = new Author
                            {
                                AuthorID = reader.GetInt32(reader.GetOrdinal("AuthorID")),
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                Bio = (string)reader["Bio"],
                                DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                BirthLocation = (string)reader["BirthLocation"]
                            };
                            _listAuth.Add(_Author);
                        }
                    }
                    con.Close();
                }
                return _listAuth;
            }

        }

        public void CreateAuthor(Author a)
        {
            using (SqlConnection con = new SqlConnection(_conn))
            {
                using (SqlCommand _sqlCommand = new SqlCommand("spCreateAuthor", con))
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    _sqlCommand.CommandTimeout = 30;
                    //_sqlCommand.Parameters.AddWithValue("@ParamRoleName", r.RoleName);
                    //_sqlCommand.Parameters.Add("@ParamRoleName", SqlDbType.NVarChar(100)).Value = r.RoleName;
                    SqlParameter _paramFirstName = _sqlCommand.CreateParameter();
                    _paramFirstName.DbType = DbType.String;
                    _paramFirstName.ParameterName = "@ParamFirstName";
                    _paramFirstName.Value = a.FirstName;
                    _sqlCommand.Parameters.Add(_paramFirstName);

                    SqlParameter _paramLastName = _sqlCommand.CreateParameter();
                    _paramLastName.DbType = DbType.String;
                    _paramLastName.ParameterName = "@ParamLastName";
                    _paramLastName.Value = a.LastName;
                    _sqlCommand.Parameters.Add(_paramLastName);

                    SqlParameter _paramBio = _sqlCommand.CreateParameter();
                    _paramBio.DbType = DbType.String;
                    _paramBio.ParameterName = "@ParamBio";
                    _paramBio.Value = a.Bio;
                    _sqlCommand.Parameters.Add(_paramBio);

                    SqlParameter _paramDateOfBirth = _sqlCommand.CreateParameter();
                    _paramDateOfBirth.DbType = DbType.DateTime;
                    _paramDateOfBirth.ParameterName = "@ParamDateOfBirth";
                    _paramDateOfBirth.Value = a.DateOfBirth;
                    _sqlCommand.Parameters.Add(_paramDateOfBirth);

                    SqlParameter _paramBirthLocation = _sqlCommand.CreateParameter();
                    _paramBirthLocation.DbType = DbType.String;
                    _paramBirthLocation.ParameterName = "@ParamBirthLocation";
                    _paramBirthLocation.Value = a.BirthLocation;
                    _sqlCommand.Parameters.Add(_paramBirthLocation);


                    //SqlParameter _paramAuthorIDReturn = _sqlCommand.CreateParameter();
                    //_paramAuthorIDReturn.DbType = DbType.Int32;
                    //_paramAuthorIDReturn.ParameterName = "@ParamOutAuthorID";
                    //var pk = _sqlCommand.Parameters.Add(_paramAuthorIDReturn);
                    //_paramAuthorIDReturn.Direction = ParameterDirection.Output;

                    con.Open();
                    _sqlCommand.ExecuteNonQuery();   // calls the sp 
                                                     //var result = _paramAuthorIDReturn.Value;
                    con.Close();
                    //return (int)result;
                }
            }
        }

        public void UpdateAuthor(Author a)
        {
            using (SqlConnection con = new SqlConnection(_conn))
            {
                using (SqlCommand _sqlCommand = new SqlCommand("spUpdateAuthor", con))
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    _sqlCommand.CommandTimeout = 30;


                    SqlParameter _paramFirstName = _sqlCommand.CreateParameter();
                    _paramFirstName.DbType = DbType.String;
                    _paramFirstName.ParameterName = "@ParamFirstName";
                    _paramFirstName.Value = a.FirstName;
                    _sqlCommand.Parameters.Add(_paramFirstName);

                    SqlParameter _paramLastName = _sqlCommand.CreateParameter();
                    _paramLastName.DbType = DbType.String;
                    _paramLastName.ParameterName = "@ParamLastName";
                    _paramLastName.Value = a.LastName;
                    _sqlCommand.Parameters.Add(_paramLastName);

                    SqlParameter _paramBio = _sqlCommand.CreateParameter();
                    _paramBio.DbType = DbType.String;
                    _paramBio.ParameterName = "@ParamBio";
                    _paramBio.Value = a.Bio;
                    _sqlCommand.Parameters.Add(_paramBio);

                    SqlParameter _paramDateOfBirth = _sqlCommand.CreateParameter();
                    _paramDateOfBirth.DbType = DbType.DateTime;
                    _paramDateOfBirth.ParameterName = "@ParamDateOfBirth";
                    _paramDateOfBirth.Value = a.DateOfBirth;
                    _sqlCommand.Parameters.Add(_paramDateOfBirth);

                    SqlParameter _paramBirthLocation = _sqlCommand.CreateParameter();
                    _paramBirthLocation.DbType = DbType.String;
                    _paramBirthLocation.ParameterName = "@ParamBirthLocation";
                    _paramBirthLocation.Value = a.BirthLocation;
                    _sqlCommand.Parameters.Add(_paramBirthLocation);

                    SqlParameter _paramAuthorID = _sqlCommand.CreateParameter();
                    _paramAuthorID.DbType = DbType.Int32;
                    _paramAuthorID.ParameterName = "@ParamAuthorID";
                    _paramAuthorID.Value = a.AuthorID;
                    _sqlCommand.Parameters.Add(_paramAuthorID);

                    con.Open();
                    _sqlCommand.ExecuteNonQuery();   // calls the sp                 
                    con.Close();
                }
            }
        }

        public void DeleteAuthor(Author a)

        {
            using (SqlConnection con = new SqlConnection(_conn))
            {
                using (SqlCommand _sqlCommand = new SqlCommand("spDeleteAuthor", con))
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    _sqlCommand.CommandTimeout = 30;

                    SqlParameter _parameter = _sqlCommand.CreateParameter();
                    _parameter.DbType = DbType.Int32;
                    _parameter.ParameterName = "@ParamAuthorID";
                    _parameter.Value = a.AuthorID;
                    _sqlCommand.Parameters.Add(_parameter);

                    con.Open();
                    _sqlCommand.ExecuteNonQuery();   // calls the sp                 
                    con.Close();
                }
            }
        }

    }
}
