namespace SheetsApi.Shared
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public WeaponType Type { get; set; }
        public int Strength { get; set; }
        public int ArmorPenetration { get; set; }
        public int Damage { get; set; }
        public int Points { get; set; }
        public int Range { get; set; }
    }
}