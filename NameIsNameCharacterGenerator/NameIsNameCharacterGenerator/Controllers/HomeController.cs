using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NameIsNameCharacterGenerator.Models;

namespace NameIsNameCharacterGenerator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CharacterSheet sheet = new CharacterSheet(Race.Dragonborn, CharacterClass.Barbarian, Background.Acolyte);

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