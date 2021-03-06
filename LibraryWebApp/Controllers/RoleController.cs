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
                _logic.CreateRolePassThru(Mapper.RoleModelToRole(model));
                return RedirectToAction("GetRoles", "Role");
            }
            else 
            {
                // send them back to the view with error messages
                return View();
            }                
        }


        //[HttpGet]
        //public ActionResult UpdateRole(RoleModel model)
        //{
        //    return View();
        //}


        // TODO: finish
        [HttpGet]
        public ActionResult UpdateRole(int id)
        {
            List<Role> _list = _logic.GetRolesPassThru();
            RoleModel model = new RoleModel();
            Role _r = _list.Where(r => r.RoleID == id).FirstOrDefault();
            model = Mapper.RoleToRoleModel(_r);
            return View(model);

        }

        [HttpPost]
        public ActionResult UpdateRole(RoleModel r)
        {

            if (ModelState.IsValid)
            {
               
                _logic.UpdateRolePassThru(Mapper.RoleModelToRole(r));
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
            var list = _logic.GetRolesPassThru();
            RoleListVM vm = new RoleListVM(list);

            return View(vm);

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


    }
}