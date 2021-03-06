using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryWebApp.Controllers
{
    public class BaseController : Controller
    {
        // fields
        private IDbConnection _connection;
        private string _dbConnection;

        // properties
        public IDbConnection Connection { get => _connection; }

        // constuctors
        public BaseController()
        {
            string _conn = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            // this in only dependency on Sql Server specific classes
            this._connection = new SqlConnection(_conn);

        }

       
    }
}