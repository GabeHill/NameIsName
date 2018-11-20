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
                    //Alignment
                    Str = model.Str,
                    Dex = model.Dex,
                    Con = model.Con,
                    Int = model.Int,
                    Wis = model.Wis,
                    Cha = model.Cha,
                    //Prof = model.
                    //Acrobatics = model.
                    //AniamlHandling
                    //Arcana
                    //Athletics
                    //Deception
                    //History
                    //Insight
                    //Intimidation
                    //Investigation
                    //Medicine
                    //Nature
                    //Perception
                    //Performance
                    //Persuasion
                    //Religion
                    //SlightOfHand
                    //Stealth
                    //Survival
                    AC = model.AC,
                    //Speed = model
                    HP = model.HP,
                    //HitDice = model
                    
                };

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