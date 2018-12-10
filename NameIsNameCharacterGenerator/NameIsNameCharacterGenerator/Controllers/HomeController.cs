using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NameIsNameCharacterGenerator.Models;
using NameIsNameCharacterGenerator.Services;
using WebSupergoo.ABCpdf11;
using WebSupergoo.ABCpdf11.Objects;
using WebSupergoo.ABCpdf11.Atoms;
using WebSupergoo.ABCpdf11.Operations;

namespace NameIsNameCharacterGenerator.Controllers
{
	public class HomeController : Controller
	{
		ICharacterService service = new EFCharacterService();
		EFCharacterService EFservice = new EFCharacterService();


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
            CharacterSheet model = service.GetCharacterById(id);
			ViewBag.id = id;
			return View(model);
		}


		public FileResult CreateNewCharacter()
		{
			CharacterSheet model = new CharacterSheet();
			service.AddNewCharacter(model);
			Character character = EFservice.CharacterConverter(model);
			Doc pdf = GetPDF(character);
			return File(pdf.GetStream(), "application/pdf");
		}

		public ActionResult DeleteCharacter(int id)
		{
			service.DeleteCharacterById(id);
			return RedirectToAction("AllCharacters");
		}

		[HttpPost]
		public ActionResult EditCharacter(Character character)
		{
			//service.

			CharacterList model = service.GetAllCharacters();

			return View("AllCharacters", model);
		}

		public FileResult ViewPDF(int id)
		{
			
			CharacterSheet model = service.GetCharacterById(id);
			Character character = EFservice.CharacterConverter(model);
			Doc pdf = GetPDF(character);
			return File(pdf.GetStream(), "application/pdf");
		}


		public Doc GetPDF(Character character)
		{
			Doc theDoc = new Doc();
			theDoc.Read(Server.MapPath("../../PDFs/blankSheet.pdf"));

			//Top of sheet
			(theDoc.Form["CharacterName"]).Value = character.Name;
			(theDoc.Form["ClassLevel"]).Value = character.Class;
			//background
			//Player name
			(theDoc.Form["Race "]).Value = character.Race;
			(theDoc.Form["Alignment"]).Value = character.Alignment;
			//XP
			

			//stats
			(theDoc.Form["STR"]).Value = character.Str.ToString();
			(theDoc.Form["DEX"]).Value = character.Dex.ToString();
			(theDoc.Form["CON"]).Value = character.Con.ToString();
			(theDoc.Form["INT"]).Value = character.Int.ToString();
			(theDoc.Form["WIS"]).Value = character.Wis.ToString();
			(theDoc.Form["CHA"]).Value = character.Cha.ToString();
			
			//inspiration
			//ProBonus

			//saving throws

			//skills
			(theDoc.Form["Acrobatics"]).Value = character.Acrobatics.ToString();
			(theDoc.Form["Animal"]).Value = character.AniamlHandling.ToString();
			(theDoc.Form["Arcana"]).Value = character.Arcana.ToString();
			(theDoc.Form["Athletics"]).Value = character.Athletics.ToString();
			(theDoc.Form["Deception "]).Value = character.Deception.ToString();
			(theDoc.Form["History "]).Value = character.History.ToString();
			(theDoc.Form["Insight"]).Value = character.Insight.ToString();
			(theDoc.Form["Intimidation"]).Value = character.Intimidation.ToString();
			(theDoc.Form["Investigation "]).Value = character.Investigation.ToString(); ;
			(theDoc.Form["Medicine"]).Value = character.Medicine.ToString();
			(theDoc.Form["Nature"]).Value = character.Nature.ToString();
			(theDoc.Form["Perception "]).Value = character.Perception.ToString();
			(theDoc.Form["Persuasion"]).Value = character.Persuasion.ToString();
			(theDoc.Form["Religion"]).Value = character.Religion.ToString();
			(theDoc.Form["SleightofHand"]).Value = character.SlightOfHand.ToString();
			(theDoc.Form["Stealth "]).Value = character.Stealth.ToString();
			(theDoc.Form["Survival"]).Value = character.Survival.ToString();

			//Pasive Wisdom

			//ProfLang
			string proflang = "";
			foreach (var item in character.Prof_Lang)
			{
				proflang += item.Prof_Lang1 + "\n";	
			}
			(theDoc.Form["ProficienciesLang"]).Value = proflang;

			(theDoc.Form["AC"]).Value = character.AC.ToString();
			//Initiative
			(theDoc.Form["Speed"]).Value = character.Speed.ToString();
			(theDoc.Form["HPMax"]).Value = character.HP.ToString();
			(theDoc.Form["HPCurrent"]).Value = character.HP.ToString();
			//HPTemp
			(theDoc.Form["HD"]).Value = character.HitDice.ToString();

			//Attacks & Spellcasting

			//Equipment
			string equip = "";
			foreach (var item in character.Equipments)
			{
				equip += item.Equipment1 + "\n";
			}
			(theDoc.Form["Equipment"]).Value = equip;

			//Personality Traits
			string persTraits = "";
			foreach (var item in character.PersonalityTraits)
			{
				persTraits += item.PersonalityTraits + "\n";
			}
			(theDoc.Form["PersonalityTraits "]).Value = persTraits;
			//Ideals
			string ideals = "";
			foreach (var item in character.Ideals)
			{
				ideals += item.Ideals + "\n";
			}
			(theDoc.Form["Ideals"]).Value = ideals;
			//Bonds
			string bonds = "";
			foreach (var item in character.Bonds)
			{
				bonds += item.Bond1 + "\n";
			}
			(theDoc.Form["Bonds"]).Value = bonds;
			//Flaws
			string flaws = "";
			foreach (var item in character.Flaws)
			{
				flaws += item.Flaws + "\n";
			}
			(theDoc.Form["Flaws"]).Value = flaws;

			//Features & Traits
			string feattrait = "";
			foreach (var item in character.Features_Traits)
			{
				feattrait += item.Features_Trait + "\n";
			}
			feattrait = feattrait.Replace(", ", "\n");
			(theDoc.Form["Features and Traits"]).Value = feattrait;

			return theDoc;
		}

	}
}
