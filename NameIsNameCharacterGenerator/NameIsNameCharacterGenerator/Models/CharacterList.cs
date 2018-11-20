using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NameIsNameCharacterGenerator.Services;

namespace NameIsNameCharacterGenerator.Models
{
    public class CharacterList
    {
        public List<Character> Characters { get; set; }
        public CharacterList()
        {
            Characters = new List<Character>();
        }
    }
}