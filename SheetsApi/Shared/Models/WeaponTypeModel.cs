using System;
using Microsoft.AspNetCore.Identity;

namespace SheetsApi.Shared
{
    public class WeaponTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IdentityUser<int> AddedByUser { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public IdentityUser<int> ModifiedByUser { get; set; }
        public RuleType Type { get; set; }
        public string Attacks { get; set; }

        public enum RuleType
        {
            Assault,
            Heavy,
            RapidFire,
            Melee
        }
    }
}
