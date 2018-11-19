﻿using System;
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
        private Race dragonborn;
        private CharacterClass barbarian;
        private Background acolyte;

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

        public int HP { get; set; }
        public int AC { get; set; }


        public CharacterSheet()
        {
            Array values = Enum.GetValues(typeof(Race));
            Random random = new Random();
            Race r = (Race)values.GetValue(random.Next(values.Length));

            Array values2 = Enum.GetValues(typeof(CharacterClass));
            Random random2 = new Random();
            CharacterClass c = (CharacterClass)values2.GetValue(random2.Next(values2.Length));

            Array values3 = Enum.GetValues(typeof(Background));
            Random random3 = new Random();
            Background b = (Background)values3.GetValue(random3.Next(values3.Length));

            SetBFIP(b);

            race = r;
            characterClass = c;
            background = b;

            Str = SetAbilityScore();
            Dex = SetAbilityScore();
            Con = SetAbilityScore();
            Int = SetAbilityScore();
            Wis = SetAbilityScore();
            Cha = SetAbilityScore();

            switch (r)
            {
                case Race.Dwarf:
                    Str += 2;
                    Wis += 1;
                    break;
                case Race.Elf:
                    Dex += 2;
                    Int += 1;
                    break;
                case Race.Halfling:
                    Cha += 1;
                    Dex += 2;
                    break;
                case Race.Human:
                    Str += 1;
                    Dex += 1;
                    Con += 1;
                    Int += 1;
                    Wis += 1;
                    Cha += 1;
                    break;
                case Race.Dragonborn:
                    Str += 2;
                    Cha += 1;
                    break;
                case Race.Gnome:
                    Int += 2;
                    break;
                case Race.HalfElf:
                    Cha += 2;
                    break;
                case Race.HalfOrc:
                    Str += 2;
                    Con += 1;
                    break;
                case Race.Tiefling:
                    Int += 1;
                    Cha += 2;
                    break;
                default:
                    break;
            }
            int StrMod = DetermineMod(Str);
            int DexMod = DetermineMod(Dex);
            int ConMod = DetermineMod(Con);
            int IntMod = DetermineMod(Int);
            int WisMod = DetermineMod(Wis);
            int ChaMod = DetermineMod(Cha);

            Acrobatics = DexMod;
            AnimalHandling = WisMod;
            Arcana = IntMod;
            Athletics = StrMod;
            Deception = ChaMod;
            History = IntMod;
            Insight = WisMod;
            Intimidation = ChaMod;
            Investigation = IntMod;
            Medicine = WisMod;
            Nature = IntMod;
            Perception = ChaMod;
            Performance = ChaMod;
            Persuasion = ChaMod;
            Religion = IntMod;
            SlightOfHand = DexMod;
            Stealth = DexMod;
            Survival = WisMod;

           HP = DetermineHp(ConMod);
           AC = 10 + DexMod; 
        }

        

        private int DetermineHp(int ConMod) {
            int hp = 0;
            switch (characterClass)
            {
                case CharacterClass.Barbarian:
                    hp = 12 + ConMod;
                    break;
                case CharacterClass.Bard:
                    hp = 8 + ConMod;
                    break;
                case CharacterClass.Cleric:
                    hp = 8 + ConMod;
                    break;
                case CharacterClass.Fighter:
                    hp = 10 + ConMod;
                    break;
                case CharacterClass.Monk:
                    hp = 8 + ConMod;
                    break;
                case CharacterClass.Paladin:
                    hp = 10 + ConMod;
                    break;
                case CharacterClass.Ranger:
                    hp = 10 + ConMod;
                    break;
                case CharacterClass.Rouge:
                    hp = 8 + ConMod;
                    break;
                case CharacterClass.Sorcerer:
                    hp = 6 + ConMod;
                    break;
                case CharacterClass.Warlock:
                    hp = 8 + ConMod;
                    break;
                case CharacterClass.Wizard:
                    hp = 6 + ConMod;
                    break;
                default:
                    break;
            }
            return hp;
        }


        private int DetermineMod(int stat)
        {
            if (stat < 4)
            {
                return -4;
            }
            else if (stat >= 4 && stat < 6)
            {
                return -3;
            }
            else if (stat >= 6 && stat < 8)
            {
                return -2;
            }
            else if (stat >= 8 && stat < 10)
            {
                return -1;
            }
            else if (stat >= 10 && stat < 12)
            {
                return 0;
            }
            else if (stat >= 12 && stat < 14)
            {
                return 1;
            }
            else if (stat >= 14 && stat < 16)
            {
                return 2;
            }
            else if (stat >= 16 && stat < 18)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }

        public CharacterSheet(Race dragonborn, CharacterClass barbarian, Background acolyte)
        {
            this.dragonborn = dragonborn;
            this.barbarian = barbarian;
            this.acolyte = acolyte;
        }

        private void SetBFIP(Background b)
        {
            //You need to change to file paths based on your personal computers
            Bond = SetBackgroundTrait(ReadFile(@"\CSVs\Bond.csv", b), 6);
            Flaw = SetBackgroundTrait(ReadFile(@"\CSVs\Flaws.csv", b), 6);
            Ideal = SetBackgroundTrait(ReadFile(@"\CSVs\Ideals.csv", b), 6);
            PersonalityTrait = SetBackgroundTrait(ReadFile(@"\CSVs\PersonalityTrait.csv", b), 8);
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