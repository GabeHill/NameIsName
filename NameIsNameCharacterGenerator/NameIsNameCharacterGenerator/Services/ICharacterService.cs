using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NameIsNameCharacterGenerator.Models;

namespace NameIsNameCharacterGenerator.Services
{
    interface ICharacterService
    {
        //Create
        void AddNewCharacter(CharacterSheet model);
        //Get
        List<Character> GetAllCharacters();
        Character GetCharacterById(int id);
        //Update

        //Delete
        void DeleteCharacterById(int id);
    }
}
