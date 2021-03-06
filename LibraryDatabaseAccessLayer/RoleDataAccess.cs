using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using LibraryCommon.Common;
using LibraryCommon.DataEntity;

namespace LibraryDatabaseAccessLayer
{
    public class RoleDataAccess
    {
        private readonly string _conn;
        private ExceptionLogging _logger;

        // constructors
        public RoleDataAccess(string conn)
        {
            _conn = conn;
            _logger = new ExceptionLogging(_conn);
        }

        public RoleDataAccess()
        {
            _logger = new ExceptionLogging(_conn);
        }

        // methods
        public List<Role> GetRoles()
        {
            List<Role> _list = new List<Role>();

            try
            {
                using (SqlConnection con = new SqlConnection(_conn))
                {
                    using (SqlCommand _sqlCommand = new SqlCommand("spGetRole", con))
                    {
                        _sqlCommand.CommandType = CommandType.StoredProcedure;
                        _sqlCommand.CommandTimeout = 30;
                        //_sqlCommand.Parameters.AddWithValue("@BookID", inOneParticularBook);

                        con.Open();
                        Role _role;
                        using (SqlDataReader reader = _sqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                _role = new Role
                                {
                                    RoleID = reader.GetInt32(reader.GetOrdinal("RoleID")),
                                    RoleName = (string)reader["RoleName"]
                                    //Description = (string)reader["Book_Description"],
                                    //Price = reader.GetDecimal(reader.GetOrdinal("Book_Price")),
                                    //IsPaperback = (string)reader["Book_IsPaperBack"],
                                    //Author_FK = reader.GetInt32(reader.GetOrdinal("Book_AuthorID_FK")),
                                    //Genre_FK = reader.GetInt32(reader.GetOrdinal("GenreID_FK"))
                                };
                                _list.Add(_role);
                            }
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                throw ex;
            }

            return _list;
        }

        public int CreateRole(Role r)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(_conn))
                {
                    using (SqlCommand _sqlCommand = new SqlCommand("spCreateRole", con))
                    {
                        _sqlCommand.CommandType = CommandType.StoredProcedure;
                        _sqlCommand.CommandTimeout = 30;
                        //_sqlCommand.Parameters.AddWithValue("@ParamRoleName", r.RoleName);
                        //_sqlCommand.Parameters.Add("@ParamRoleName", SqlDbType.NVarChar(100)).Value = r.RoleName;
                        SqlParameter _paramRoleName = _sqlCommand.CreateParameter();
                        _paramRoleName.DbType = DbType.String;
                        _paramRoleName.ParameterName = "@ParamRoleName";
                        _paramRoleName.Value = r.RoleName;
                        _sqlCommand.Parameters.Add(_paramRoleName);

                        SqlParameter _paramRoleIDReturn = _sqlCommand.CreateParameter();
                        _paramRoleIDReturn.DbType = DbType.Int32;
                        _paramRoleIDReturn.ParameterName = "@ParamOutRoleID";
                        var pk = _sqlCommand.Parameters.Add(_paramRoleIDReturn);
                        _paramRoleIDReturn.Direction = ParameterDirection.Output;

                        con.Open();
                        _sqlCommand.ExecuteNonQuery();   // calls the sp 
                        var result = _paramRoleIDReturn.Value;
                        con.Close();
                        return (int)result;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                throw ex;
            }
            finally 
            { 
            
            
            }

           
        }

        public void DeleteRole(Role r)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_conn))
                {
                    using (SqlCommand _sqlCommand = new SqlCommand("spDeleteRole", con))
                    {
                        _sqlCommand.CommandType = CommandType.StoredProcedure;
                        _sqlCommand.CommandTimeout = 30;
                        SqlParameter _parameter = _sqlCommand.CreateParameter();
                        _parameter.DbType = DbType.Int32;
                        _parameter.ParameterName = "@ParamRoleID";
                        _parameter.Value = r.RoleID;
                        _sqlCommand.Parameters.Add(_parameter);

                        con.Open();
                        _sqlCommand.ExecuteNonQuery();   // calls the sp                 
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                throw ex;
            }
            finally
            {


            }

        }

        public void UpdateRole(Role r)
        {

            try
            {

                using (SqlConnection con = new SqlConnection(_conn))
                {
                    using (SqlCommand _sqlCommand = new SqlCommand("spUpdateRole", con))
                    {
                        _sqlCommand.CommandType = CommandType.StoredProcedure;
                        _sqlCommand.CommandTimeout = 30;

                        SqlParameter _paramRoleName = _sqlCommand.CreateParameter();
                        _paramRoleName.DbType = DbType.String;
                        _paramRoleName.ParameterName = "@ParamRoleName";
                        _paramRoleName.Value = r.RoleName;
                        _sqlCommand.Parameters.Add(_paramRoleName);

                        SqlParameter _paramRoleID = _sqlCommand.CreateParameter();
                        _paramRoleID.DbType = DbType.Int32;
                        _paramRoleID.ParameterName = "@ParamRoleID";
                        _paramRoleID.Value = r.RoleID;
                        _sqlCommand.Parameters.Add(_paramRoleID);

                        con.Open();
                        _sqlCommand.ExecuteNonQuery();   // calls the sp                 
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                throw ex;
            }
            finally
            {


            }


        }
    
    }
}
