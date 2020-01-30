using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommon
{
    public class Logger
    {

        public void LogException(Exception inException) 
        {
            try
            {
                this.LogExceptionToFile(inException);
                this.LogExceptionToDatabase(inException);
            }
            catch (Exception)
            {

                throw;
            }                 
        }

        private void LogExceptionToFile(Exception inException)
        {
            string _exceptionValue = "Date: " + DateTime.Now.ToString() +
                ", Message: " + inException.Message.ToString() + ", StackTrace: " + inException.StackTrace.ToString() +
                ", Source: " + inException.Source.ToString() + ", TargetSite: " + inException.TargetSite.ToString();

            using (StreamWriter _streamwriter = File.AppendText(@"D:\error_log.log"))
            {
                _streamwriter.WriteLine(_exceptionValue);
            }
        }

        private void LogExceptionToDatabase(Exception inException) 
        { 
        
                // TODO: implement this.
        
        }

    }
}
