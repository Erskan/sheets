using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using SheetsApi.Shared;
using SheetsApi.Sheets;

namespace SheetsApi.Settings
{
    public static class InitializeDatabase
    {
        public static async System.Threading.Tasks.Task InitAsync(SheetsDbContext context, UserManager<IdentityUser<int>> userManager)
        {
            if (context.Sheets.Any() || context.Users.Any())
            {
                // Don't seed if data exists in the DB.
                return;
            }

            var userCreationResult = await userManager.CreateAsync(new IdentityUser<int>("admin")
            {
                Email = "admin@whark.net"
            }, "secret");
            context.SaveChanges();

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
                Points = 100,
                AddedByUser = context.Users.First(),
                ModifiedByUser = context.Users.First(),
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow
            };
            context.Sheets.Add(defaultSheet);
        }
    }
}
