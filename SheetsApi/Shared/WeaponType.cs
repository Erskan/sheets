using System;

namespace SheetsApi.Shared
{
    public class WeaponType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SheetsUser AddedByUser { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public SheetsUser ModifiedByUser { get; set; }
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
