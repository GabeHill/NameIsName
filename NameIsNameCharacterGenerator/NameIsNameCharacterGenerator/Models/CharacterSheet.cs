using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NameIsNameCharacterGenerator.Models {
    public enum Race {
        Dwarf,Elf,Halfling,Human,Dragonborn,Gnome,HalfElf,HalfOrc,Tiefling
    }

    public enum CharacterClass {
        Barbarian,Bard,Cleric,Fighter,Monk,Paladin,Ranger,Rouge,Sorcerer,Warlock,Wizard
    }

    public enum Background {
        Acolyte,Charlatan,Criminal,Entertainer,FolkHero,GuildArtisan,Hermit,Noble,Outlander,Sage,Sailor,Soldier,Urchin
    }


    public class CharacterSheet {

        public string name { get; set; }

        public Race race { get; set; }

        public CharacterClass characterClass { get; set; }

        public Background background { get; set; }

        public int Str { get; set; }
        public int Dex { get; set; }
        public int Con { get; set; }
        public int Int { get; set; }
        public int Wis { get; set; }
        public int Cha { get; set; }

        public CharacterSheet(Race r, CharacterClass c, Background b) {
            race = r;
            characterClass = c;
            background = b;

            Str = SetAbilityScore();
            Dex = SetAbilityScore();
            Con = SetAbilityScore();
            Int = SetAbilityScore();
            Wis = SetAbilityScore();
            Cha = SetAbilityScore();
        }

        private int SetAbilityScore()
        {
            int total = 0;
            total += RollD6();
            total += RollD6();
            total += RollD6();
            return total;
        }

        private int RollD6()
        {
            Random r = new Random();
            return r.Next(1, 7);
        }
    }
}