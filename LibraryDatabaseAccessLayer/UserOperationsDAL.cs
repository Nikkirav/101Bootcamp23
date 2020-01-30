using LibraryCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabaseAccessLayer
{
  
    public class UserOperationsDAL
    {

        // properties
      

        // fields
        private IDbConnection _connection;
        private Logger _logger;
               
        // properties

        // constructors
        public UserOperationsDAL(IDbConnection inConnection) 
        {
            // 3.f create a db connection
            this._connection = inConnection;
            this._logger = new Logger();
        }


        // methods
        public Result RegisterUserToDatabase(User inUser) 
        {
            // declare variables and initialize
            Result _result = new Result();
            _result.Message = "";
            _result.Type = ResultType.Not_Set;

            // 3. send the input down to the database and check for duplicate username
            // need to call one or two stored procedures
            // if dup, only call check for dup, end, return error
            // if no dup, call second sp add user, return succcess message
            
            try
            {
                // sp check for dup

                // declare variables
                List<User> _listOfUsers = new List<User>();

                // 3.g create a db commmnd
                using (IDbCommand _command = this._connection.CreateCommand())
                {

                    // open connection
                    this._connection.Open();

                    // set the command properties
                    _command.CommandText = "sp_get_users";
                    _command.CommandType = System.Data.CommandType.StoredProcedure;
                    _command.CommandTimeout = 15;

                    // parameter
                    // @parm_userid int= 0,
                    // @parm_username varchar(255) = '',
                    // @parm_password varchar(255) = ''
                    IDbDataParameter _parameterUsername = _command.CreateParameter();
                    _parameterUsername.DbType = DbType.String;
                    _parameterUsername.ParameterName = "@parm_username";
                    _parameterUsername.Value = inUser.Username;
                    _command.Parameters.Add(_parameterUsername);

                    IDbDataParameter _parameterPassword = _command.CreateParameter();
                    _parameterPassword.DbType = DbType.String;
                    _parameterPassword.ParameterName = "@parm_password";
                    _parameterPassword.Value = "";
                    _command.Parameters.Add(_parameterPassword);

                    IDbDataParameter _parameterUserId = _command.CreateParameter();
                    _parameterUserId.DbType = DbType.Int32;
                    _parameterUserId.ParameterName = "@parm_userid";
                    _parameterUserId.Value = 0;
                    _command.Parameters.Add(_parameterUserId);

                    // loop to read rows
                    // 3.h run the command
                    using (IDataReader _reader = _command.ExecuteReader())
                    {
                        int _firstNamePosition = _reader.GetOrdinal("FirstName");
                        int _lastNamePosition = _reader.GetOrdinal("LastName");
                        int _usernamePosition = _reader.GetOrdinal("Username");
                        int _passwordPosition = _reader.GetOrdinal("Password");                      
                        int _userIdPosition = _reader.GetOrdinal("UserId");

                        while (_reader.Read()) 
                        {
                            User _currentUser = new User();
                            _currentUser.FirstName = _reader.GetString(_firstNamePosition);
                            _currentUser.LastName = _reader.GetString(_lastNamePosition);
                            _currentUser.Password = _reader.GetString(_passwordPosition);
                            _currentUser.Username = _reader.GetString(_usernamePosition);
                            _currentUser.UserId = _reader.GetInt32(_userIdPosition);

                            // add to list
                            _listOfUsers.Add(_currentUser);                        
                        }
                    }

                    if (_listOfUsers.Count != 0)
                    {

                        // 4. if dup, send message back to user to redo form and pick an alternate username

                        // set our Result object the failure case
                        _result.Type = ResultType.Failure;
                        _result.Message = "Duplicate Username exists. Please change Username and re-submit.";

                    }
                    else
                    {
                        // 5. if no dup, add user and send a success message
                        using (IDbCommand _cmdAdd = this._connection.CreateCommand())
                        {
                            // set the command properties
                            _cmdAdd.CommandText = "sp_register_user";
                            _cmdAdd.CommandType = System.Data.CommandType.StoredProcedure;
                            _cmdAdd.CommandTimeout = 15;

                            // parameter
                            // passing the username
                            // @parm_FirstName varchar(255),
                            // @parm_LastName varchar(255),
                            // @parm_UserName varchar(255),
                            // @parm_Password varchar(255),
                            // @parm_RoleID int
                            IDbDataParameter _parameterFirstName = _command.CreateParameter();
                            _parameterFirstName.DbType = DbType.String;
                            _parameterFirstName.ParameterName = "@parm_FirstName";
                            _parameterFirstName.Value = inUser.FirstName;
                            _cmdAdd.Parameters.Add(_parameterFirstName);

                            IDbDataParameter _parameterLastName = _command.CreateParameter();
                            _parameterLastName.DbType = DbType.String;
                            _parameterLastName.ParameterName = "@parm_LastName";
                            _parameterLastName.Value = inUser.LastName;
                            _cmdAdd.Parameters.Add(_parameterLastName);

                            IDbDataParameter _parameter_Username = _command.CreateParameter();
                            _parameter_Username.DbType = DbType.String;
                            _parameter_Username.ParameterName = "@parm_UserName";
                            _parameter_Username.Value = inUser.Username;
                            _cmdAdd.Parameters.Add(_parameter_Username);

                            IDbDataParameter _parameter_Password = _command.CreateParameter();
                            _parameter_Password.DbType = DbType.String;
                            _parameter_Password.ParameterName = "@parm_Password";
                            _parameter_Password.Value = inUser.Password;
                            _cmdAdd.Parameters.Add(_parameter_Password);

                            IDbDataParameter _parameterRoleId = _command.CreateParameter();
                            _parameterRoleId.DbType = DbType.Int32;
                            _parameterRoleId.ParameterName = "@parm_RoleID";
                            _parameterRoleId.Value = 3; // lowest role - Patron
                            _cmdAdd.Parameters.Add(_parameterRoleId);

                            // run the insert
                            _cmdAdd.ExecuteNonQuery();

                            // set result object
                            _result.Type = ResultType.Success;
                            _result.Message = "User registered successfully. Please login.";
                        }
                    } // end if

                    // close the connection
                    this._connection.Close();
                }
            }
            catch (Exception ex)
            {
                 _logger.LogException(ex);
                 throw;
            }

            return _result;
        }

        public ResultUsers LoginUserToDatabase(User inUser)
        {
            // declare variables
            List<User> _listOfUsers = new List<User>();
            ResultUsers _result = new ResultUsers();

            try
            {

                // 3.g create a db commmnd
                using (IDbCommand _command = this._connection.CreateCommand())
                {

                    // open connection
                    this._connection.Open();

                    // set the command properties
                    _command.CommandText = "sp_get_users";
                    _command.CommandType = System.Data.CommandType.StoredProcedure;
                    _command.CommandTimeout = 15;

                    // parameter
                    // @parm_userid int= 0,
                    // @parm_username varchar(255) = '',
	                // @parm_password varchar(255) = ''
                    IDbDataParameter _parameterUsername = _command.CreateParameter();
                    _parameterUsername.DbType = DbType.String;
                    _parameterUsername.ParameterName = "@parm_username";
                    _parameterUsername.Value = inUser.Username;
                    _command.Parameters.Add(_parameterUsername);

                    IDbDataParameter _parameterPassword = _command.CreateParameter();
                    _parameterPassword.DbType = DbType.String;
                    _parameterPassword.ParameterName = "@parm_password";
                    _parameterPassword.Value = inUser.Password;
                    _command.Parameters.Add(_parameterPassword);

                    IDbDataParameter _parameterUserId = _command.CreateParameter();
                    _parameterUserId.DbType = DbType.Int32;
                    _parameterUserId.ParameterName = "@parm_userid";
                    _parameterUserId.Value = 0;
                    _command.Parameters.Add(_parameterUserId);

                    // loop to read rows
                    // 3.h run the command
                    using (IDataReader _reader = _command.ExecuteReader())
                    {

                        int _firstNamePosition = _reader.GetOrdinal("FirstName");
                        int _lastNamePosition = _reader.GetOrdinal("LastName");
                        int _usernamePosition = _reader.GetOrdinal("Username");
                        int _passwordPosition = _reader.GetOrdinal("Password");
                        int _userIdPosition = _reader.GetOrdinal("UserId");
                        int _roleIdPosition = _reader.GetOrdinal("RoleID_FK");

                        while (_reader.Read())
                        {
                            User _currentUser = new User();
                            _currentUser.FirstName = _reader.GetString(_firstNamePosition);
                            _currentUser.LastName = _reader.GetString(_lastNamePosition);
                            _currentUser.Password = _reader.GetString(_passwordPosition);
                            _currentUser.Username = _reader.GetString(_usernamePosition);
                            _currentUser.UserId = _reader.GetInt32(_userIdPosition);
                            _currentUser.RoleId = _reader.GetInt32(_roleIdPosition);

                            // add to list
                            _listOfUsers.Add(_currentUser);
                            
                        }


                        // if found 
                        if (_listOfUsers.Count > 0)
                        {
                            _result.Message = "Username/password found.";
                            _result.Type = ResultType.Success;

                        }
                        else // out found
                        {
                            _result.Message = "Username/password not found.";
                            _result.Type = ResultType.Failure;

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                _logger.LogException(ex);
                throw;
            }

            _result.ListOfUsers = _listOfUsers;
            return _result;
        }
    }

}
