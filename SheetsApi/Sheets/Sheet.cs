﻿using SheetsApi.Shared;
using System.Collections.Generic;

namespace SheetsApi.Sheets
{
    public class Sheet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Movement { get; set; }
        public int WeaponSkill { get; set; }
        public int BallisticSkill { get; set; }
        public int Strength { get; set; }
        public int Toughness { get; set; }
        public int Wounds { get; set; }
        public int Attacks { get; set; }
        public int Leadership { get; set; }
        public int Save { get; set; }
        public int InvulnerableSave { get; set; }
        public int Points { get; set; }
        public int Max { get; set; }
        public IEnumerable<Weapon> Weapons { get; set; }
        public IEnumerable<Rule> Rules { get; set; }

        public Sheet()
        {
            Weapons = new List<Weapon>();
            Rules = new List<Rule>();
        }
    }
}
