using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SheetsApi.Forces;
using SheetsApi.Shared;
using SheetsApi.Sheets;

namespace SheetsApi.Settings
{
    public static class InitializeDatabase
    {
        public static async System.Threading.Tasks.Task InitAsync(SheetsDbContext context, UserManager<IdentityUser<int>> userManager)
        {
            if (await context.Sheets.AnyAsync() || await context.Users.AnyAsync())
            {
                // Don't seed if data exists in the DB.
                return;
            }

            var userCreationResult = await userManager.CreateAsync(new IdentityUser<int>("admin")
            {
                Email = "admin@whark.net"
            }, "secret");

            var user = await context.Users.OrderBy(u => u.Id).FirstAsync();

            var defaultSheet = new SheetModel
            {
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
                Max = 10,
                AddedByUser = user,
                ModifiedByUser = user,
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow
            };
            var defaultForce = new ForceModel
            {
                Name = "Test Force One",
                AddedByUser = user,
                ModifiedByUser = user,
                Sheets = new List<SheetModel> {defaultSheet}
            };
            try
            {
                await context.Sheets.AddAsync(defaultSheet);
                await context.Forces.AddAsync(defaultForce);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
        }
    }
}
