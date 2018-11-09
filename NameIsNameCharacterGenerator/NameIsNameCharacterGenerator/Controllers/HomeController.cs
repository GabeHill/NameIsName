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
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult AllCharacters()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult CreateNewCharacter()
        //{
        //    // TODO: adding a random characer to the database
        //}
    }
}