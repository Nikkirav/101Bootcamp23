using LibraryBusinessLogicLayer;
using LibraryCommon;
using LibraryWebApp.Common;
using LibraryCommon.DataEntity;
using LibraryWebApp.Filters;
using LibraryWebApp.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LibraryWebApp.Controllers
{

    public class HomeController : BaseController
    {

        // data
        private readonly string _dbConn;

        // constuctors
        public HomeController() : base() 
        {
            _dbConn = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        }

        //[HttpGet]
        //public ActionResult Index()
        //{
        //    //return View();
        //    return RedirectToAction("Login", "Home");
        //}



        public ActionResult Index()
        {
            var _v = View();
            return _v;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpGet]
        public ActionResult Books()
        {

            return View();

        }



        //[HttpGet]
        //public ActionResult Login()
        //{
        //    LoginModel model = new LoginModel();
        //    // 1. collect the information the the user
        //    ViewBag.Message = "Login page.";
        //    return View(model);

        //}

        //[HttpPost]
        //public ActionResult Login(LoginModel inModel)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        // 3. send the input down to the database and check for username/password

        //        // 3.a create new bll object
        //        UserOperationsBLL _userOperationsBLL = new UserOperationsBLL(base.Connection);

        //        // 3.b need to convert LoginModel object to User object
        //        User _user = Mapper.LoginModelToUser(inModel);

        //        // 3.c pass the user object down to bll layer
        //        ResultUsers _result = _userOperationsBLL.LoginUser(_user);

        //        if (_result.Type == ResultType.Success)
        //        {
        //            UserModel _userModel = Mapper.UserToUserModel(_result.ListOfUsers[0]);


        //            // store the userModel in Global session
        //            Session["UserSession"] = _userModel;

        //            // Advanced Auth LMS
        //            Session["AUTHUsername"] = _userModel.Username;
        //            Session["AUTHRoles"] = _userModel.RoleName;

        //            return RedirectToAction("Main", "Home");
        //        }
        //        else
        //        {
        //            inModel.DialogMessage = _result.Message;
        //            inModel.DialogMessageType = _result.Type.ToString();
        //            return View(inModel);
        //        }
        //    }
        //    // validation failed, have the user redo the form
        //    else
        //    {
        //        return View(inModel);
        //    }

        //}


        //[HttpGet]
        //[MustBeLoggedIn]
        //public ActionResult Logout()
        //{
        //    // logout code
        //    // TODO: FormsAuthentication.SignOut();
        //    Session.Abandon(); // it will clear the session at the end of request
        //    return RedirectToAction("Index", "Home");

        //}


        //[HttpGet]
        //public ActionResult GenresAuthors()
        //{


        //    return View();
        //}


        //// Register GET
        //[HttpGet]

        //[MustBeLoggedIn]
        //public ActionResult Main()
        //{

        //    BooksModel model = new BooksModel();
        //    ViewBag.Message = "Main page";
        //    ResultBooks _listOfBooks;

        //    // create bll object
        //    BookOperationsBLL _bll = new BookOperationsBLL(base.Connection);


        //    if ((Session["AUTHRoles"].ToString() == RoleType.Administrator.ToString()) ||
        //        (Session["AUTHRoles"].ToString() == RoleType.Librarian.ToString()))
        //    {

        //        // stored procedure will return everything
        //        int _userId = 0;

        //        // get the books for the database based on userid
        //        _listOfBooks = _bll.GetBooksPassThru(_userId);

        //    }
        //    else
        //    {   // Patron

        //        // stored procedure will return everything
        //        UserModel _user = (UserModel)Session["UserSession"];

        //        // get the books for the database based on userid
        //        _listOfBooks = _bll.GetBooksPassThru(_user.UserId);

        //    }




        //    // Map ResultBooks to BooksModel
        //    model = Mapper.ResultsBooksToBooksModel(_listOfBooks);
        //    return View(model);

        //}


        //// Register GET
        //[HttpGet]
        //public ActionResult Register()
        //{
        //    // this will create the empty form

        //    UserModel model = new UserModel();

        //    // 1. collect the information the the user
        //    ViewBag.Message = "Register page.";
        //    return View(model);

        //}

        //[HttpPost]
        //public ActionResult Register(UserModel inModel)
        //{

        //    // 2. valididate the fields have the correct data otherwise (if) send error to user and have
        //    // them redo the input 
        //    // data annotations for validation in MVC

        //    // valid state, validation passed
        //    if (ModelState.IsValid)
        //    {
        //        // 3. send the input down to the database and check for duplicate username

        //        // 3.a create new bll object
        //        UserOperationsBLL _userOperationsBLL = new UserOperationsBLL(base.Connection);

        //        // 3.b need to convert UserModel object to User object
        //        User _user = Mapper.UserModelToUser(inModel);

        //        // 3.c pass the user object down to bll layer
        //        Result _result = _userOperationsBLL.RegisterUser(_user);

        //        inModel.DialogMessage = _result.Message;
        //        inModel.DialogMessageType = _result.Type.ToString();

        //        return View(inModel);
        //    }
        //    // validation failed, have the user redo the form
        //    else
        //    {

        //        return View(inModel);

        //    }

        //}


        //[HttpGet]
        //[MustBeInRole(Roles = "Administrator")]
        //public ActionResult Users()
        //{
        //    // create variables
        //    ResultUsers _resultUsers = new ResultUsers();
        //    UsersModel model = new UsersModel();

        //    // create bll object - constructor that takes a connection
        //    UserOperationsBLL _userOperationsBLL = new UserOperationsBLL(base.Connection);


        //    // call the method 
        //    // pass zero to get all users
        //    _resultUsers = _userOperationsBLL.GetUsersAndTheirRolesPassThru(0);


        //    // Map it
        //    model = Mapper.ResultUsersToUsersModel(_resultUsers);

        //    return View(model);

        //}


        //[HttpPost]
        //[MustBeInRole(Roles = "Administrator")]
        //public ActionResult UserDelete(int id)
        //{

        //    // TODO: need to do the delete

        //    return RedirectToAction("Users");
        //}


        ////[HttpGet]
        ////public ActionResult UserEdit(int id, string firstname, string lastname, string username, string password, int roleid, string rolename)
        ////{

        ////    return View();
        ////}


        //[HttpGet]
        //[MustBeInRole(Roles = "Administrator")]
        //public ActionResult UserEdit(int id)
        //{
        //    // pass this out to the view
        //    UserModel model = new UserModel();

        //    // need to go fetch this user
        //    UserOperationsBLL _userOperationsBLL = new UserOperationsBLL(base.Connection);
            
        //    // need to pass the id
        //    ResultUsers _onlyOne = _userOperationsBLL.GetUsersAndTheirRolesPassThru(id);

        //    // map it
        //    model = Mapper.UserToUserModel(_onlyOne.ListOfUsers[0]); // BIG assumption that index is valid

        //    return View(model);
        //}


        //[HttpPost]
        //[MustBeInRole(Roles = "Administrator")]
        //public ActionResult UserEdit(UserModel model)
        //{

        //    // need to create bll object

        //    // map model to common object
            
        //    // need to call method on bll object and mapped object
        //    // this will be edit CRUD operation

        //    // redirect them to the users view or have back button to return to users view

        //    // need a success message and allow them to go back

        //    return View();
        //}
    }
}