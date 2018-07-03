using SheetsApi.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SheetsApi.Sheets
{
    public class SheetModel
    {
        public int SheetId { get; set; }
        public string Name { get; set; }
        public IdentityUser<int> AddedByUser { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public IdentityUser<int> ModifiedByUser { get; set; }
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
        public IEnumerable<WeaponModel> Weapons { get; set; }
        public IEnumerable<RuleModel> Rules { get; set; }

        public SheetModel()
        {
            Weapons = new List<WeaponModel>();
            Rules = new List<RuleModel>();
        }
    }
}
