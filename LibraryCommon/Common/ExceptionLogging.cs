using System;
using System.Data;
using System.Data.SqlClient;


namespace LibraryCommon.Common
{
    public class ExceptionLogging
    {
        // data
        private readonly string _conn;

        // constuctors
        public ExceptionLogging() { }
        
        
        public ExceptionLogging(string inConn)
        {
            this._conn = inConn;
        }

        public void LogException(Exception inException)
        {
            try
            {
                // TODO: this.LogExceptionToFile(inException);
                this.LogExceptionToDatabase(inException);
                this.LogExceptionToLogFile(inException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // TODO: logs to a file
        private void LogExceptionToLogFile(Exception inException)
        {
            throw new NotImplementedException();
        }

        private void LogExceptionToDatabase(Exception inException)
        {
            try
            {
                using (SqlConnection _con = new SqlConnection(_conn))
                {
                    using (SqlCommand _command = new SqlCommand("spCreateLogException", _con))
                    {
                        // set the command properties
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.CommandTimeout = 30;

                        SqlParameter _parameterStackTrace = _command.CreateParameter();
                        _parameterStackTrace.DbType = DbType.String;
                        _parameterStackTrace.ParameterName = "@parmStackTrace";
                        _parameterStackTrace.Value = inException.StackTrace == null ? "" : inException.StackTrace;
                        _command.Parameters.Add(_parameterStackTrace);

                        SqlParameter _parameterMessage = _command.CreateParameter();
                        _parameterMessage.DbType = DbType.String;
                        _parameterMessage.ParameterName = "@parmMessage";
                        _parameterMessage.Value = inException.Message == null ? "" : inException.Message;
                        _command.Parameters.Add(_parameterMessage);

                        SqlParameter _parameterSource = _command.CreateParameter();
                        _parameterSource.DbType = DbType.String;
                        _parameterSource.ParameterName = "@parmSource";
                        _parameterSource.Value = inException.Source == null ? "" : inException.Source;
                        _command.Parameters.Add(_parameterSource);

                        SqlParameter _parmURL = _command.CreateParameter();
                        _parmURL.DbType = DbType.String;
                        _parmURL.ParameterName = "@parmURL";
                    
                        if (inException.TargetSite == null)
                        {
                            _parmURL.Value = "";
                        }
                        else if (inException.TargetSite.Name == null) 
                        {
                            _parmURL.Value = "";
                        } 
                        else 
                        {
                            _parmURL.Value = inException.TargetSite.Name; 
                        }
                      
                        _command.Parameters.Add(_parmURL);

                        SqlParameter _parmLogdate = _command.CreateParameter();
                        _parmLogdate.DbType = DbType.String;
                        _parmLogdate.ParameterName = "@parmLogdate";
                        _parmLogdate.Value = DateTime.Now.ToString();
                        _command.Parameters.Add(_parmLogdate);

                        // run the insert
                        _con.Open();
                        _command.ExecuteNonQuery();
                        _con.Close();
                    }
                }                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
