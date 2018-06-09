using System;
using System.Collections.Generic;
using System.Linq;
using SheetsApi.Shared;
using SheetsApi.Sheets;

namespace SheetsApi.Settings
{
    public static class InitializeDatabase
    {
        public static void Init(SheetsDbContext context)
        {
            if (context.Sheets.Any() || context.Users.Any())
            {
                // Don't seed if data exists in the DB.
                return;
            }

            var defaultUser = new SheetsUser
            {
                Id = 1,
                Name = "Default User"
            };
            context.Users.Add(defaultUser);

            var defaultSheet = new SheetModel
            {
                SheetId = 1,
                Attacks = 2,
                BallisticSkill = 4,
                InvulnerableSave = 0,
                Leadership = 6,
                Movement = 6,
                Name = "Test Sheet One",
                Rules = new List<RuleModel>(),
                Save = 4,
                Strength = 3,
                Toughness = 4,
                WeaponSkill = 5,
                Weapons = new List<WeaponModel>(),
                Wounds = 1,
                AddedByUser = defaultUser,
                ModifiedByUser = defaultUser,
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow
            };
            context.Sheets.Add(defaultSheet);
        }
    }
}
