using LibraryBusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryWebApp.Models;
using ConsoleLibrary.DataEntity;

namespace LibraryWebApp.Controllers
{
    public class GenreController : Controller
    {

        // data
        private readonly string _dbConn;
        private GenreBusinessLogic _logic;

        public object Mapper { get; private set; }

        // constuctors
        public GenreController() : base()
        {
            _dbConn = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            _logic = new GenreBusinessLogic(_dbConn);
        }

        // GET: Genre
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetGenres()
        {
            GenreListVM model;

            try
            {

                List<Genre> list = _logic.GetGenrePassThru();
                model = new GenreListVM(list);
            }
            catch (Exception)
            {
                // TODO: log error if no is thrown
                throw;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateGenre()
        {

            return View();

        }

        [HttpPost]
        public ActionResult CreateGenre(GenreModel model)
        {

            if (ModelState.IsValid)
            {
                // TODO: process and add the role to db
                return RedirectToAction("GetGenre", "Genre");
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
            List<Genre> _list = _logic.GetGenrePassThru();
            GenreModel model = new GenreModel();
            Genre _g = _list.Where(g => g.GenreID == id).FirstOrDefault();
            return View(model);

        }
    }
}