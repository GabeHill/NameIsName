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
        public ActionResult Index()
        {
            CharacterSheet sheet = new CharacterSheet(Race.Dragonborn, CharacterClass.Barbarian, Background.Acolyte);

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

			CharacterList CL = new CharacterList();
			EFCharacterService ef = new EFCharacterService();
			CL.AllCharacters = ef.GetAllCharacters();

            return View(CL);
        }
		public ActionResult Character( int charID)
		{

			EFCharacterService ef = new EFCharacterService();
			Character character = ef.GetCharacterById(charID);

			return View(character);
		}

	}
}