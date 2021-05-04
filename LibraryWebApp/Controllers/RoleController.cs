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
        private RoleBusinessLogic _logic;

        // constuctors
        public RoleController() : base()
        {
            _dbConn = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            _logic = new RoleBusinessLogic(_dbConn);
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
            RoleListVM model;

            try
            {               
                List<Role> list = _logic.GetRolesPassThru();
                model = new RoleListVM(list);
            }
            catch (Exception)
            {
                // TODO: log error if no is thrown
                throw;
            }         
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateRole()
        {

            return View();

        }

        [HttpPost]
        public ActionResult CreateRole(RoleModel model) 
        {

            if (ModelState.IsValid)
            {
                // TODO: process and add the role to db
                return RedirectToAction("GetRoles", "Role");
            }
            else 
            {
                // send them back to the view with error messages
                return View();
            }                
        }



        [HttpGet]
        public ActionResult ExampleView()
        {

            return View();

        }

        [HttpPost]
        public ActionResult DeleteRole(int id)
        {

            try
            {
                _logic.DeleteRolePassThru(id);
            }
            catch (Exception ex)
            {

                throw;
            }

            //return View();
            return RedirectToAction("GetRoles", "Role");
        }


        // TODO: finish
        [HttpPost]
        public ActionResult UpdateRole(int id)
        {


            return View();

        }
    }
}