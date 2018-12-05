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

        static Random rand = new Random();

        public List<string> firstNames => new List<string> { "Eva", "Falyne", "Genaesis", "Genaesys", "Gianna", "Jianna", "Janna", "Graece", "Grassa", "Haenna", "Hanna", "Gael", "Gayl", "Gayel", "Gaeus", "Gavyn", "Gaevyn", "Goshwa", "Joshoe", "Graysus", "Graysen", "Gwann", "Ewan", "Gwyllam", "Gwyllem", "Haddeus", "Hudsyn", "Haesoe", "Haesys" };

        public List<string> languages = new List<string> { "Dwarvish", "Elvish", "Giant", "Gnomish", "Goblin", "Halfling", "Orc", "Abyssal", "Celestial", "Deep Speech", "Draconic", "Infernal", "Primordial", "Sylvan", "Undercommon" };

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


        public string Alignment { get; set; }
        public string Bond { get; set; }
        public string Flaw { get; set; }
        public string Ideal { get; set; }
        public string PersonalityTrait { get; set; }
        public string BackgroundFeature { get; set; }

        public int HP { get; set; }
        public int AC { get; set; }
        public string HitDice { get; set; }

        public List<string> ClassProficiecies { get; set; }
        public List<string> ClassFeatures { get; set; }
        public List<string> ClassEquipment { get; set; }
        public List<string> Equipment { get; set; }
        public List<string> Features_Traits { get; set; }
        public List<string> Prof_Lang { get; set; }

        public int Acrobatics { get; set; }
        public int AnimalHandling { get; set; }
        public int Arcana { get; set; }
        public int Athletics { get; set; }
        public int Deception { get; set; }
        public int History { get; set; }
        public int Insight { get; set; }
        public int Intimidation { get; set; }
        public int Investigation { get; set; }
        public int Medicine { get; set; }
        public int Nature { get; set; }
        public int Perception { get; set; }
        public int Performance { get; set; }
        public int Persuasion { get; set; }
        public int Religion { get; set; }
        public int SlightOfHand { get; set; }
        public int Stealth { get; set; }
        public int Survival { get; set; }

        public CharacterSheet()
        {
            Prof_Lang = new List<string>();
            Equipment = new List<string>();
            Features_Traits = new List<string>();

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
            Prof_Lang.Add("Common");
            switch (r)
            {
                case Race.Dwarf:
                    Str += 2;
                    Wis += 1;
                    List<string> tools = new List<string> { "Brewer's supplies", "Mason's tools", "Smith's tools" };
                    Prof_Lang.Add(tools[rand.Next(0, 4)]);
                    Prof_Lang.Add("Dwarvish");
                    break;
                case Race.Elf:
                    Dex += 2;
                    Int += 1;
                    Perception += 2;
                    Prof_Lang.Add("Elvish");
                    break;
                case Race.Halfling:
                    Cha += 1;
                    Dex += 2;
                    Prof_Lang.Add("Halfling");
                    break;
                case Race.Human:
                    Str += 1;
                    Dex += 1;
                    Con += 1;
                    Int += 1;
                    Wis += 1;
                    Cha += 1;
                    Prof_Lang.Add(languages[rand.Next(0, languages.Count)]);
                    break;
                case Race.Dragonborn:
                    Str += 2;
                    Cha += 1;
                    Prof_Lang.Add("Draconic");
                    break;
                case Race.Gnome:
                    Int += 2;
                    Prof_Lang.Add("Gnomish");
                    break;
                case Race.HalfElf:
                    Cha += 2;
                    Prof_Lang.Add("Elvish");
                    string l;
                    do
                    {
                        l = languages[rand.Next(0, languages.Count)];
                    } while (l.Equals("Elvish"));
                    Prof_Lang.Add(l);
                    break;
                case Race.HalfOrc:
                    Str += 2;
                    Con += 1;
                    Intimidation += 2;
                    Prof_Lang.Add("Orc");
                    break;
                case Race.Tiefling:
                    Int += 1;
                    Cha += 2;
                    Prof_Lang.Add("Infernal");
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

            int count = 0;
            if (IntMod > 0)
            {
                while (count != IntMod)
                {
                    bool isKnown = false;
                    string tempLang = languages[rand.Next(0, languages.Count)];
                    foreach (string lang in Prof_Lang)
                    {
                        if (tempLang == lang)
                        {
                            isKnown = true;
                        }
                    }
                    if (!isKnown)
                    {
                        Prof_Lang.Add(tempLang);
                        count++;
                    }
                }
            }

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

            if (characterClass == CharacterClass.Barbarian)
            {
                AC += ConMod;
            }
            if (characterClass == CharacterClass.Monk)
            {
                AC += WisMod;
            }
            HitDice = $"1D{HP}";

            SetClassFeatures(characterClass);
            name = firstNames[rand.Next(0, firstNames.Count)];
            Alignment = DecideAlignmnet();
        }

        private string DecideAlignmnet()
        {
            List<string> allOfEm = new List<string> { "Lawful Good", "Neutral Good", "Chaotic Good", "Lawful Neutral", "Neutral", "Chaotic Neutral", "Lawful Evil", "Neutral Evil", "Chaotic Evil" };
            Random rand = new Random();
            return allOfEm[rand.Next(0, allOfEm.Count)];
        }

        private int DetermineHp(int ConMod)
        {
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

        private void SetClassFeatures(CharacterClass c)
        {
            ClassProficiecies = ReadFile(HttpContext.Current.Server.MapPath(@"\CSVs\ClassProficiecies.csv"), c.ToString());
            ClassFeatures = ReadFile(HttpContext.Current.Server.MapPath(@"\CSVs\ClassFeatures.csv"), c.ToString());
            ClassEquipment = ReadFile(HttpContext.Current.Server.MapPath(@"\CSVs\ClassEquipment.csv"), c.ToString());
        }

        private void SetBFIP(Background b)
        {
            Bond = SetBackgroundTrait(ReadFile(HttpContext.Current.Server.MapPath(@"\CSVs\Bond.csv"), b.ToString()), 6);
            Flaw = SetBackgroundTrait(ReadFile(HttpContext.Current.Server.MapPath(@"\CSVs\Flaws.csv"), b.ToString()), 6);
            Ideal = SetBackgroundTrait(ReadFile(HttpContext.Current.Server.MapPath(@"\CSVs\Ideals.csv"), b.ToString()), 6);
            PersonalityTrait = SetBackgroundTrait(ReadFile(HttpContext.Current.Server.MapPath(@"\CSVs\PersonalityTrait.csv"), b.ToString()), 8);
            BackgroundFeature = SetBackgroundTrait(ReadFile(HttpContext.Current.Server.MapPath(@"\CSVs\BackgroundFeature.csv"), b.ToString()), 1);
        }

        private List<string> ReadFile(string filename, string b)
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
