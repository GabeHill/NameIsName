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
		public ActionResult Character(CharacterSheet CharSh)
		{
			Character model = CharSheetToChar(CharSh);
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


		private Character CharSheetToChar(CharacterSheet model)
		{
			Character c = new Character()
			{
				Name = model.name,
				Class = model.characterClass.ToString(),
				Race = model.race.ToString(),
				Alignment = model.Alignment,
				Str = model.Str,
				Dex = model.Dex,
				Con = model.Con,
				Int = model.Int,
				Wis = model.Wis,
				Cha = model.Cha,
				//Prof = model.Pro
				Acrobatics = model.Acrobatics,
				AniamlHandling = model.AnimalHandling,
				Arcana = model.Arcana,
				Athletics = model.Athletics,
				Deception = model.Deception,
				History = model.History,
				Insight = model.Insight,
				Intimidation = model.Intimidation,
				Investigation = model.Investigation,
				Medicine = model.Medicine,
				Nature = model.Nature,
				Perception = model.Perception,
				Performance = model.Performance,
				Persuasion = model.Persuasion,
				Religion = model.Religion,
				SlightOfHand = model.SlightOfHand,
				Stealth = model.Stealth,
				Survival = model.Survival,
				AC = model.AC,
				//Speed = model
				HP = model.HP,
				HitDice = model.HitDice
			};
			return c;
		}

	}
}
