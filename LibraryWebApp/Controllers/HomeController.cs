using LibraryWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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


        // Register GET
        [HttpGet]
        public ActionResult Register()
        {

            UserModel model = new UserModel();

            ViewBag.Message = "Register page.";
            return View(model);

        }

        [HttpPost]
        public ActionResult Register(UserModel inModel)
        {
            // TODO: need to check if the username exists
            // either return failure message or add useer and log them in

            if (ModelState.IsValid)
            {

                // pass it down the stack to the db
                return View(inModel);
            }
            else
            {
                
                return View(inModel);

            }
          
        }


    }
}