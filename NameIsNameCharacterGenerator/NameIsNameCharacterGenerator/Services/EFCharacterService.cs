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
            throw new NotImplementedException();
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

        public List<Character> GetAllCharacters()
        {
            List<Character> list = new List<Character>();
            using (var context = new CharacterEntities())
            {
                var query = context.Characters.Select(c => c);
                list = query.ToList();
            }

            return list;
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