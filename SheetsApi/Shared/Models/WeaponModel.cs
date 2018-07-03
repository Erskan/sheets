using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SheetsApi.Shared
{
    public class WeaponModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IdentityUser<int> AddedByUser { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public IdentityUser<int> ModifiedByUser { get; set; }
        public int Range { get; set; }
        public WeaponTypeModel Type { get; set; }
        public int Strength { get; set; }
        public int ArmorPenetration { get; set; }
        public int Damage { get; set; }
        public int Points { get; set; }
        public IEnumerable<RuleModel> Rules { get; set; }

        public WeaponModel()
        {
            Rules = new List<RuleModel>();
        }
    }
}
