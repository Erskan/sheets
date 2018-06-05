using System;
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
        DbSet<SheetsUser> Users { get; set; }
        DbSet<ForceModel> Forces { get; set; }
        DbSet<GameModel> Games { get; set; }

        int SaveChanges();
    }
}