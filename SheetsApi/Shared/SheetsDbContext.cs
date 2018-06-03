using Microsoft.EntityFrameworkCore;
using SheetsApi.Sheets;

namespace SheetsApi.Shared
{
    public class SheetsDbContext : DbContext
    {
        public DbSet<SheetModel> Sheets { get; set; }
        public DbSet<WeaponModel> Weapons { get; set; }
        public DbSet<WeaponTypeModel> WeaponTypes { get; set; }
        public DbSet<RuleModel> Rules { get; set; }
        public DbSet<SheetsUser> Users { get; set; }

        public SheetsDbContext(DbContextOptions<SheetsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // SheetModel
            modelBuilder.Entity<SheetModel>()
                .HasKey(m => m.Id)
                .HasName("PK_SheetModel_Id");
            modelBuilder.Entity<SheetModel>()
                .Property(m => m.Created)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<SheetModel>()
                .Property(m => m.Modified)
                .HasDefaultValueSql("getdate()");
            // WeaponModel
            modelBuilder.Entity<WeaponModel>()
                .HasKey(m => m.Id)
                .HasName("PK_WeaponModel_Id");
            modelBuilder.Entity<WeaponModel>()
                .Property(m => m.Created)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<WeaponModel>()
                .Property(m => m.Modified)
                .HasDefaultValueSql("getdate()");
            // WeaponTypeModel
            modelBuilder.Entity<WeaponTypeModel>()
                .HasKey(m => m.Id)
                .HasName("PK_WeaponTypeModel_Id");
            modelBuilder.Entity<WeaponTypeModel>()
                .Property(m => m.Created)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<WeaponTypeModel>()
                .Property(m => m.Modified)
                .HasDefaultValueSql("getdate()");
            // RuleModel
            modelBuilder.Entity<RuleModel>()
                .HasKey(m => m.Id)
                .HasName("PK_RuleModel_Id");
            modelBuilder.Entity<RuleModel>()
                .Property(m => m.Created)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<RuleModel>()
                .Property(m => m.Modified)
                .HasDefaultValueSql("getdate()");
            // SheetsUser
            modelBuilder.Entity<SheetsUser>()
                .HasKey(m => m.Id)
                .HasName("PK_SheetsUser_Id");
        }
    }
}
