using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SheetsApi.Forces;
using SheetsApi.Games;
using SheetsApi.Sheets;

namespace SheetsApi.Shared.Interfaces
{
    public interface ISheetsDbContext : IDisposable
    {
        DbSet<SheetModel> Sheets { get; set; }
        DbSet<WeaponModel> Weapons { get; set; }
        DbSet<WeaponTypeModel> WeaponTypes { get; set; }
        DbSet<RuleModel> Rules { get; set; }
        DbSet<IdentityUser<int>> Users { get; set; }
        DbSet<IdentityUserRole<int>> UserRoles { get; set; }
        DbSet<IdentityRole<int>> Roles { get; set; }
        DbSet<IdentityUserClaim<int>> Claims { get; set; }
        DbSet<ForceModel> Forces { get; set; }
        DbSet<GameModel> Games { get; set; }

        int SaveChanges();
    }
}