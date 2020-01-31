using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommon
{
    public class Logger
    {

        // fields
        private IDbConnection _connection;

        // constuctors
        public Logger(IDbConnection inConnection) 
        {
            this._connection = inConnection;        
        }

        public void LogException(Exception inException) 
        {
            try
            {
                this.LogExceptionToFile(inException);
                this.LogExceptionToDatabase(inException);
            }
            catch (Exception ex)
            {
                throw;
            }                 
        }

        private void LogExceptionToFile(Exception inException)
        {
         
            string _exceptionValue = "Date: " + DateTime.Now.ToString() +
                ", Message: " + inException.Message.ToString() + ", StackTrace: " + inException.StackTrace.ToString() +
                ", Source: " + inException.Source.ToString() + ", TargetSite: " + inException.TargetSite.ToString();

            using (StreamWriter _streamwriter = File.AppendText(@"D:\library_web_app_error_log.log"))
            {
                _streamwriter.WriteLine(_exceptionValue);
            }
        }

        private void LogExceptionToDatabase(Exception inException) 
        {
          
            using (IDbCommand _command = this._connection.CreateCommand())
            {
                // set the command properties
                _command.CommandText = "sp_LogException";
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandTimeout = 15;

                //@parmExceptionStackTrace varchar(max),
                //@parmExceptionMessage varchar(max),
                //@parmExceptionSource varchar(max),
                //@parmExceptionURL varchar(max),
                //@parmLogdate datetime

                IDbDataParameter _parameterStackTrace = _command.CreateParameter();
                _parameterStackTrace.DbType = DbType.String;
                _parameterStackTrace.ParameterName = "@parmExceptionStackTrace";
                _parameterStackTrace.Value = inException.StackTrace;
                _command.Parameters.Add(_parameterStackTrace);

                IDbDataParameter _parameterMessage = _command.CreateParameter();
                _parameterMessage.DbType = DbType.String;
                _parameterMessage.ParameterName = "@parmExceptionMessage";
                _parameterMessage.Value = inException.Message;
                _command.Parameters.Add(_parameterMessage);

                IDbDataParameter _parameterSource = _command.CreateParameter();
                _parameterSource.DbType = DbType.String;
                _parameterSource.ParameterName = "@parmExceptionSource";
                _parameterSource.Value = inException.Source;
                _command.Parameters.Add(_parameterSource);

                IDbDataParameter _parmURL = _command.CreateParameter();
                _parmURL.DbType = DbType.String;
                _parmURL.ParameterName = "@parmExceptionURL";
                _parmURL.Value = inException.TargetSite.Name;
                _command.Parameters.Add(_parmURL);

                IDbDataParameter _parmLogdate = _command.CreateParameter();
                _parmLogdate.DbType = DbType.String;
                _parmLogdate.ParameterName = "@parmLogdate";
                _parmLogdate.Value = DateTime.Now.ToString();
                _command.Parameters.Add(_parmLogdate);

                // run the insert
                this._connection.Open();
                _command.ExecuteNonQuery();
                this._connection.Close();


            }
        }

    }
}
