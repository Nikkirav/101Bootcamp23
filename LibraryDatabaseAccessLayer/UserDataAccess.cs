using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryCommon.DataEntity;

namespace LibraryDatabaseAccessLayer
{
    public class UserDataAccess
    {

        private readonly string _conn;

        public UserDataAccess(string conn)
        {
            _conn = conn;
        }
     
        public List<User> GetUsers()
        {
            List<User> _list = new List<User>();
            using (SqlConnection con = new SqlConnection(_conn))
            {
                using (SqlCommand _sqlCommand = new SqlCommand("spGetUser", con))
                {
                    _sqlCommand.CommandType = CommandType.Text;
                    _sqlCommand.CommandTimeout = 35;


                    con.Open();
                    User _user;


                    using (SqlDataReader reader = _sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _user = new User
                            {
                                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                LastName = (string)reader["LastName"],
                                FirstName = (string)reader["FirstName"],
                                UserName = (string)reader["UserName"],
                                Password = (string)reader["Password"],
                                RoleID_FK = reader.GetInt32(reader.GetOrdinal("RoleID_FK"))
                            };
                            _list.Add(_user);
                        }
                    }
                    con.Close();
                }
            }
            return _list;
        }

        public void CreateUser(User u)
        {
            using (SqlConnection con = new SqlConnection(_conn))
            {
                using (SqlCommand _sqlCommand = new SqlCommand("spCreateUser", con))
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    _sqlCommand.CommandTimeout = 30;

                    SqlParameter _paramFirstName = _sqlCommand.CreateParameter();
                    _paramFirstName.DbType = DbType.String;
                    _paramFirstName.ParameterName = "@ParamFirstName";
                    _paramFirstName.Value = u.FirstName;
                    _sqlCommand.Parameters.Add(_paramFirstName);

                    SqlParameter _paramLastName = _sqlCommand.CreateParameter();
                    _paramLastName.DbType = DbType.String;
                    _paramLastName.ParameterName = "@ParamLastName";
                    _paramLastName.Value = u.LastName;
                    _sqlCommand.Parameters.Add(_paramLastName);

                    SqlParameter _paramUserName = _sqlCommand.CreateParameter();
                    _paramUserName.DbType = DbType.String;
                    _paramUserName.ParameterName = "@ParamUserName";
                    _paramUserName.Value = u.UserName;
                    _sqlCommand.Parameters.Add(_paramUserName);

                    SqlParameter _paramPassword = _sqlCommand.CreateParameter();
                    _paramPassword.DbType = DbType.String;
                    _paramPassword.ParameterName = "@ParamPassword";
                    _paramPassword.Value = u.Password;
                    _sqlCommand.Parameters.Add(_paramPassword);

                    SqlParameter _paramRoleIdFK = _sqlCommand.CreateParameter();
                    _paramRoleIdFK.DbType = DbType.Int32;
                    _paramRoleIdFK.ParameterName = "@ParamRoleID";
                    _paramRoleIdFK.Value = u.RoleID_FK;
                    _sqlCommand.Parameters.Add(_paramRoleIdFK);

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

        public void DeleteUser(User u)
        {
            using (SqlConnection con = new SqlConnection(_conn))
            {
                using (SqlCommand _sqlCommand = new SqlCommand("spDeleteUser", con))
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    _sqlCommand.CommandTimeout = 30;


                    SqlParameter _parameter = _sqlCommand.CreateParameter();
                    _parameter.DbType = DbType.Int32;
                    _parameter.ParameterName = "@ParamUserID";
                    _parameter.Value = u.UserID;
                    _sqlCommand.Parameters.Add(_parameter);


                    con.Open();
                    _sqlCommand.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void UpdateUser(User u)
        {
            using (SqlConnection con = new SqlConnection(_conn))
            {
                using (SqlCommand _sqlCommand = new SqlCommand("spUpdateUser", con))
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    _sqlCommand.CommandTimeout = 30;


                    SqlParameter _paramUserID = _sqlCommand.CreateParameter();
                    _paramUserID.DbType = DbType.Int32;
                    _paramUserID.ParameterName = "@ParamUserID";
                    _paramUserID.Value = u.UserID;
                    _sqlCommand.Parameters.Add(_paramUserID);


                    SqlParameter _paramFirstName = _sqlCommand.CreateParameter();
                    _paramFirstName.DbType = DbType.String;
                    _paramFirstName.ParameterName = "@ParamFirstName";
                    _paramFirstName.Value = u.FirstName;
                    _sqlCommand.Parameters.Add(_paramFirstName);


                    SqlParameter _paramLastName = _sqlCommand.CreateParameter();
                    _paramLastName.DbType = DbType.String;
                    _paramLastName.ParameterName = "@ParamLastName";
                    _paramLastName.Value = u.LastName;
                    _sqlCommand.Parameters.Add(_paramLastName);


                    SqlParameter _paramUserName = _sqlCommand.CreateParameter();
                    _paramUserName.DbType = DbType.String;
                    _paramUserName.ParameterName = "@ParamUserName";
                    _paramUserName.Value = u.UserName;
                    _sqlCommand.Parameters.Add(_paramUserName);


                    SqlParameter _paramPassword = _sqlCommand.CreateParameter();
                    _paramPassword.DbType = DbType.String;
                    _paramPassword.ParameterName = "@ParamPassword";
                    _paramPassword.Value = u.Password;
                    _sqlCommand.Parameters.Add(_paramPassword);


                    SqlParameter _paramRoleID = _sqlCommand.CreateParameter();
                    _paramRoleID.DbType = DbType.Int32;
                    _paramRoleID.ParameterName = "@ParamRoleID";
                    _paramRoleID.Value = u.RoleID_FK;
                    _sqlCommand.Parameters.Add(_paramRoleID);


                    con.Open();
                    _sqlCommand.ExecuteNonQuery();
                    con.Close();
                }
            }
        }



    }
}
