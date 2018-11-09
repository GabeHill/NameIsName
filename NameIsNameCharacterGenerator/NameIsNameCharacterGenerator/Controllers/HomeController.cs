using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NameIsNameCharacterGenerator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewCharacter()
        {
            ViewBag.Message = "New Random Character";

            return View();
        }

        public ActionResult AllCharacters()
        {
            ViewBag.Message = "All of the characters made by the program!";

            return View();
        }

        //public ActionResult CreateNewCharacter()
        //{
        //    // TODO: adding a random characer to the database
        //}
    }
}