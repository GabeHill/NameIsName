using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NameIsNameCharacterGenerator.Models;

namespace NameIsNameCharacterGenerator.Services
{
    public class EFCharacterService : ICharacterService
    {
        public void AddNewCharacter(CharacterSheet model)
        {
            using (var context = new CharacterEntities())
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

                c.Ideal.Ideals = model.Ideal;
                c.Prof_Lang.Prof_Lang1 = model.Prof_Lang.First();
                //foreach (string lang in model.Prof_Lang)
                //{
                //    c.Prof_Lang.Prof_Lang1 = lang;
                //}
                context.Characters.Add(c);
                context.SaveChanges();
            }
        }

        public void DeleteCharacterById(int id)
        {
            using (var context = new CharacterEntities())
            {
                //Depending on foreign keys this may require reworking
                var query = context.Characters.SingleOrDefault(i => i.CharcterID == id);

                context.Characters.Remove(query);
                context.SaveChanges();
            }
        }

        public CharacterList GetAllCharacters()
        {
            CharacterList results = new CharacterList();
            using (var context = new CharacterEntities())
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
            using (var context = new CharacterEntities())
            {
                var query = context.Characters.Single(i => i.CharcterID == id);
                result = query;
            }
            return result;
        }

    }
}