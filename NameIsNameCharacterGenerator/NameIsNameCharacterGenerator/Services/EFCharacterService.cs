using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NameIsNameCharacterGenerator.Models;

namespace NameIsNameCharacterGenerator.Services
{
    public class EFCharacterService : ICharacterService
    {
        public List<CharacterSheet> GetAllCharacters()
        {
            List<CharacterSheet> list = new List<CharacterSheet>();
            using (var context = new CharacterEntities())
            {
                var query = context.Characters.Select(c => c);
                List<Character> results = query.ToList();

                results.ForEach(c =>
                {
                    list.Add(EFConverter(c));
                });
            }

            return list;
        }

        public CharacterSheet GetCharacterById(int id)
        {
            throw new NotImplementedException();
        }

        private CharacterSheet EFConverter(Character c)
        {
            CharacterSheet sheet = new CharacterSheet()
            {
                name = c.Name,
                //Figure out how to convert enums between database and models
                //race = c.Race,
                //characterClass = c.Class,
                //background = c.
                Str = (int)c.Str,
                Dex = (int)c.Dex,
                Con = (int)c.Con,
                Int = (int)c.Int,
                Wis = (int)c.Wis,
                Cha = (int)c.Cha,
                //Bond = c.
            };

            return sheet;
        }
    }
}