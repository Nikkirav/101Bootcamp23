using LibraryBusinessLogicLayer;
using LibraryCommon.DataEntity;
using LibraryWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryWebApp.Controllers
{

    public class UserController : Controller
    {
        private readonly string _dbConn;
        private UserBusinessLogic _logicUser;
        private RoleBusinessLogic _logicRole;

        public UserController() : base()
        {
            _dbConn = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            _logicUser = new UserBusinessLogic(_dbConn);
            _logicRole = new RoleBusinessLogic(_dbConn);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            List<LibraryCommon.DataEntity.User> _list = _logicUser.GetUsersPassThru();
            UserListVM model = new UserListVM(_list);
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            RoleListVM list = new RoleListVM(_logicRole.GetRolesPassThru());
            ViewBag.Roles = new SelectList(list.ListOfRoleModel, "RoleId", "RoleName");
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(UserModel model)
        {
            if (ModelState.IsValid)
            {

                User toAdd = new User();

                toAdd.FirstName = model.FirstName;
                toAdd.LastName = model.LastName;
                toAdd.UserName = model.Username;
                toAdd.Password = model.Password;
                toAdd.RoleID_FK = model.RoleId;

                _logicUser.CreateUserPassThru(toAdd);

                return RedirectToAction("GetUsers", "User");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult UpdateUser(UserModel model, int id, int roleID)
        {

            RoleListVM list = new RoleListVM(_logicRole.GetRolesPassThru());
            ViewBag.Roles = new SelectList(list.ListOfRoleModel, "RoleId", "RoleName");

            model.UserId = id;
            model.RoleId = roleID;
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateUser(UserModel model)
        {
            User toUpdate = new User();

            toUpdate.UserID = model.UserId;
            toUpdate.FirstName = model.FirstName;
            toUpdate.LastName = model.LastName;
            toUpdate.UserName = model.Username;
            toUpdate.Password = model.Password;
            toUpdate.RoleID_FK = model.RoleId;

            _logicUser.UpdateUserPassThru(toUpdate);

            return RedirectToAction("GetUsers", "User");
        }

        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            User toDelete = new User();
            toDelete.UserID = id;
            _logicUser.DeleteUserPassThru(toDelete);

            return RedirectToAction("GetUsers", "User");
        }

    }
}