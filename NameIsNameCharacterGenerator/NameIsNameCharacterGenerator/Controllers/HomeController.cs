using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NameIsNameCharacterGenerator.Models;
using NameIsNameCharacterGenerator.Services;

namespace NameIsNameCharacterGenerator.Controllers
{
    public class HomeController : Controller
    {
        ICharacterService service = new EFCharacterService();
        public ActionResult Index()
        {
            //CharacterSheet sheet = new CharacterSheet();

            return View();
        }

        public ActionResult NewCharacter()
        {
            ViewBag.Message = "New Random Character";

            var service = new EFCharacterService();
            var models = service.GetAllCharacters();
            return View(models);
        }

        public ActionResult AllCharacters()
        {
            //ViewBag.Message = "All of the characters made by the program!";
            CharacterList model = service.GetAllCharacters();

            return View(model);
        }

        public ActionResult Character(int id)
        {
            Character model = service.GetCharacterById(id);
            return View(model);
        }


        public ActionResult CreateNewCharacter()
        {
            CharacterSheet model = new CharacterSheet();
            service.AddNewCharacter(model);
			//RedirectToAction("AllCharacters");
			return View("Index");
			//return View("Character", model);
		}

        public ActionResult DeleteCharacter(int id)
        {
            service.DeleteCharacterById(id);
            return RedirectToAction("AllCharacters");
        }

        public ActionResult EditCharacter(int id)
        {
            Character model = service.GetCharacterById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditCharacter(Character character)
        {
            //service.

            CharacterList model = service.GetAllCharacters();

            return View("AllCharacters", model);
        }
    }
}
