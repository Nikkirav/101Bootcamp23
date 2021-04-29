using LibraryBusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryCommon.DataEntity;
using LibraryWebApp.Models;
using LibraryWebApp.Common;

namespace LibraryWebApp.Controllers
{
    public class RoleController : Controller
    {

        // data
        private readonly string _dbConn;

        // constuctors
        public RoleController() : base()
        {
            _dbConn = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        }

        // GET: Role
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetRoles()
        {
            RoleBusinessLogic logic = new RoleBusinessLogic(_dbConn); 
            List<Role> list = logic.GetRolesPassThru();
            List<RoleModel> rmlist = Mapper.RoleListToRoleModelList(list); // TODO: implement
            RoleListVM model = new RoleListVM(rmlist);
            // TODO: make the view better !!!
            return View(model);
        }
    }
}