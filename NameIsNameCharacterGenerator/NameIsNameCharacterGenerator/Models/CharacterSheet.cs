using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace NameIsNameCharacterGenerator.Models
{
    public enum Race
    {
        Dwarf, Elf, Halfling, Human, Dragonborn, Gnome, HalfElf, HalfOrc, Tiefling
    }

    public enum CharacterClass
    {
        Barbarian, Bard, Cleric, Fighter, Monk, Paladin, Ranger, Rouge, Sorcerer, Warlock, Wizard
    }

    public enum Background
    {
        Acolyte, Charlatan, Criminal, Entertainer, FolkHero, GuildArtisan, Hermit, Noble, Outlander, Sage, Sailor, Soldier, Urchin
    }


    public class CharacterSheet
    {

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

        public string Bond { get; set; }
        public string Flaw { get; set; }
        public string Ideal { get; set; }
        public string PersonalityTrait { get; set; }

        public CharacterSheet(Race r, CharacterClass c, Background b)
        {
            SetBackground(b);

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

        private void SetBackground(Background b)
        {
			//HttpContext.Current.Server.MapPath(HttpContext.Current.Server.MapPath("~/CSVs/bond.csv"));
			//You need to change to file paths based on your personal computers
			Bond = SetBackgroundTrait(ReadFile(HttpContext.Current.Server.MapPath("~/CSVs/bond.csv"), b), 6);
            Flaw = SetBackgroundTrait(ReadFile(HttpContext.Current.Server.MapPath("~/CSVs/bond.csv"), b), 6);
            Ideal = SetBackgroundTrait(ReadFile(HttpContext.Current.Server.MapPath("~/CSVs/bond.csv"), b), 6);
            PersonalityTrait = SetBackgroundTrait(ReadFile(HttpContext.Current.Server.MapPath("~/CSVs/bond.csv"), b), 8);
        }

        private List<string> ReadFile(string filename, Background b)
        {
            List<string> list = new List<string>();
            using (var reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (line.StartsWith(b.ToString()))
                    {
                        list.Add(line);
                    }
                }
            }

            return list;
        }

        private string SetBackgroundTrait(List<string> list, int upperLimit)
        {
            Random r = new Random();
            string trait = "";

            trait = list[r.Next(0, upperLimit)];

            return trait;
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