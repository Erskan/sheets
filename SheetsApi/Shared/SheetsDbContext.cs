using Microsoft.EntityFrameworkCore;
using SheetsApi.Sheets;
using SheetsApi.Shared;

namespace SheetsApi.Shared
{
    public class SheetsDbContext : DbContext
    {
        public SheetsDbContext(DbContextOptions<SheetsDbContext> options) : base(options)
        {
        }

        public DbSet<SheetModel> Sheets { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<WeaponType> WeaponTypes { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<SheetsUser> Users { get; set; }
    }
}
