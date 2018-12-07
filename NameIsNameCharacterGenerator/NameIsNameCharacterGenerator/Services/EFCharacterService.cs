using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using NameIsNameCharacterGenerator.Models;

namespace NameIsNameCharacterGenerator.Services
{
    public class EFCharacterService : ICharacterService
    {
        public void AddNewCharacter(CharacterSheet model)
        {
            using (var context = new NewCharacterEntity())
            {
				Character c = CharacterConverter(model);
                context.Characters.Add(c);
                // Create the Character
                context.SaveChanges();
            }
        }

        public void AddIdealByCharacter(Character c, string ideal)
        {
            using (var context = new NewCharacterEntity())
            {
                context.Characters.Attach(c);
                Ideal tempIdeal = new Ideal();
                tempIdeal.CharacterID = c.CharcterID;
                tempIdeal.Character = c;
                tempIdeal.Ideals = ideal;
                context.Ideals.Add(tempIdeal);

                context.SaveChanges();
            }
        }
        public void DeleteCharacterById(int id)
        {
            using (var context = new NewCharacterEntity())
            {
                //Depending on foreign keys this may require reworking
                var query = context.Characters.SingleOrDefault(i => i.CharcterID == id);

                var bonds = query.Bonds.ToList();
                bonds.ForEach(b =>
                {
                    query.Bonds.Remove(b);
                    context.Bonds.Remove(b);
                });

                var equipment = query.Equipments.ToList();
                equipment.ForEach(e =>
                {
                    query.Equipments.Remove(e);
                    context.Equipments.Remove(e);
                });

                var features = query.Features_Traits.ToList();
                features.ForEach(f =>
                {
                    query.Features_Traits.Remove(f);
                    context.Features_Traits.Remove(f);
                });

                var flaws = query.Flaws.ToList();
                flaws.ForEach(f =>
                {
                    query.Flaws.Remove(f);
                    context.Flaws.Remove(f);
                });

                var ideals = query.Ideals.ToList();
                ideals.ForEach(i =>
                {
                    query.Ideals.Remove(i);
                    context.Ideals.Remove(i);
                });

                var personality = query.PersonalityTraits.ToList();
                personality.ForEach(p =>
                {
                    query.PersonalityTraits.Remove(p);
                    context.PersonalityTraits.Remove(p);
                });

                var lang = query.Prof_Lang.ToList();
                lang.ForEach(l =>
                {
                    query.Prof_Lang.Remove(l);
                    context.Prof_Lang.Remove(l);
                });

                context.Characters.Remove(query);
                context.SaveChanges();
            }
        }

        public CharacterList GetAllCharacters()
        {
            CharacterList results = new CharacterList();
            using (var context = new NewCharacterEntity())
            {
                var query = context.Characters.Select(c => c);
                List<Character> list = new List<Character>();
                list = query.ToList();
                results.Characters = list;
            }

            return results;
        }

        public Character GetCharacterById(int id)
        {
            Character result;
            using (var context = new NewCharacterEntity())
            {
                var query = context.Characters.Single(i => i.CharcterID == id);
                result = query;
            }
            return result;
        }


		public Character CharacterConverter(CharacterSheet model)
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

			c.Ideals.Add(new Ideal() { Character = c, CharacterID = c.CharcterID, Ideals = model.Ideal });
			foreach (string profLang in model.Prof_Lang)
			{
				c.Prof_Lang.Add(new Prof_Lang { CharcterID = c.CharcterID, Character = c, Prof_Lang1 = profLang });
			}

			c.Bonds.Add(new Bond() { Character = c, CharcterID = c.CharcterID, Bond1 = model.Bond });
			c.Flaws.Add(new Flaw() { Character = c, CharacterID = c.CharcterID, Flaws = model.Flaw });

			string[] allStuff = model.ClassEquipment[0].Split('|');
			Random rand = new Random();
			string thisOnesStuff = allStuff[rand.Next(allStuff.Count())];
			string[] allOfStuff = thisOnesStuff.Split(',');
			foreach (string item in allOfStuff)
			{
				if (item != c.Class)
				{
					c.Equipments.Add(new Equipment() { Character = c, CharcterID = c.CharcterID, Equipment1 = item });
				}
			}

			foreach (string feature in model.ClassFeatures)
			{
				c.Features_Traits.Add(new Features_Traits() { Character = c, CharcterID = c.CharcterID, Features_Trait = feature });
			}
			c.PersonalityTraits.Add(new PersonalityTrait() { Character = c, CharacterID = c.CharcterID, PersonalityTraits = model.PersonalityTrait });
			return c;
		}
    }
}