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
        //Get
        List<CharacterSheet> GetAllCharacters();
        CharacterSheet GetCharacterById(int id);
        //Update
        //Delete
    }
}
