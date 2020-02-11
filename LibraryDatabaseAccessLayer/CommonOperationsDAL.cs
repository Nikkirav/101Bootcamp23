namespace LibraryDatabaseAccessLayer
{


    using LibraryCommon;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class CommonOperationsDAL
    {

        // fields
        private IDbConnection _connection;
        private Logger _logger;

        // properties
        public IDbConnection Connection { get => _connection; set => _connection = value; }

        // properties

        // constructors
        public CommonOperationsDAL(IDbConnection inConnection)
        {
            // 3.f create a db connection
            this._connection = inConnection;
            this._logger = new Logger(inConnection);
        }


        public ResultRoles GetRolesLookupFromDatabase() 
        {

            ResultRoles _resultRoles = new ResultRoles();
            List<Role> _list = new List<Role>();

            try
            {
                using (IDbCommand _command = this._connection.CreateCommand())
                {

                    // open connection
                    this._connection.Open();

                    // set the command properties
                    _command.CommandText = "sp_get_roles";
                    _command.CommandType = System.Data.CommandType.StoredProcedure;
                    _command.CommandTimeout = 15;

                    using (IDataReader _reader = _command.ExecuteReader())
                    {
                        int _roleIdPosition = _reader.GetOrdinal("RoleID");
                        int _roleNamePosition = _reader.GetOrdinal("RoleName");

                        while (_reader.Read())
                        {
                            Role _current = new Role();
                            _current.RoleID = _reader.GetInt32(_roleIdPosition);
                            _current.RoleName = _reader.GetString(_roleNamePosition);
                            _list.Add(_current);
                        }
                    }
                    _connection.Close();
                    _resultRoles.Type = ResultType.Success;
                    _resultRoles.Message = "Get roles succeeded.";
                    _resultRoles.ListOfRoles = _list;
                }
            }
            catch (Exception ex)
            {
                _connection.Close();
                _resultRoles.Type = ResultType.Failure;
                _resultRoles.Message = "Get roles failed.";
                _logger.LogException(ex);
                throw;
            }

            return _resultRoles;
        }


    }
}
