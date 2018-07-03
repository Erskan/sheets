using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SheetsApi.Forces;
using SheetsApi.Games;
using SheetsApi.Shared.Interfaces;
using SheetsApi.Sheets;

namespace SheetsApi.Shared
{
    public class SheetsDbContext : DbContext, ISheetsDbContext
    {
        public DbSet<SheetModel> Sheets { get; set; }
        public DbSet<WeaponModel> Weapons { get; set; }
        public DbSet<WeaponTypeModel> WeaponTypes { get; set; }
        public DbSet<RuleModel> Rules { get; set; }
        public DbSet<IdentityUser<int>> Users { get; set; }
        public DbSet<IdentityUserRole<int>> UserRoles { get; set; }
        public DbSet<IdentityRole<int>> Roles { get; set; }
        public DbSet<IdentityUserClaim<int>> Claims { get; set; }
        public DbSet<ForceModel> Forces { get; set; }
        public DbSet<GameModel> Games { get; set; }

        public SheetsDbContext(DbContextOptions<SheetsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // SheetModel
            modelBuilder.Entity<SheetModel>()
                .HasKey(m => m.SheetId)
                .HasName("PK_SheetModel_Id");
            modelBuilder.Entity<SheetModel>()
                .Property(m => m.Created)
                .HasDefaultValueSql("date('now')");
            modelBuilder.Entity<SheetModel>()
                .Property(m => m.Modified)
                .HasDefaultValueSql("date('now')");
            // WeaponModel
            modelBuilder.Entity<WeaponModel>()
                .HasKey(m => m.Id)
                .HasName("PK_WeaponModel_Id");
            modelBuilder.Entity<WeaponModel>()
                .Property(m => m.Created)
                .HasDefaultValueSql("date('now')");
            modelBuilder.Entity<WeaponModel>()
                .Property(m => m.Modified)
                .HasDefaultValueSql("date('now')");
            // WeaponTypeModel
            modelBuilder.Entity<WeaponTypeModel>()
                .HasKey(m => m.Id)
                .HasName("PK_WeaponTypeModel_Id");
            modelBuilder.Entity<WeaponTypeModel>()
                .Property(m => m.Created)
                .HasDefaultValueSql("date('now')");
            modelBuilder.Entity<WeaponTypeModel>()
                .Property(m => m.Modified)
                .HasDefaultValueSql("date('now')");
            // RuleModel
            modelBuilder.Entity<RuleModel>()
                .HasKey(m => m.Id)
                .HasName("PK_RuleModel_Id");
            modelBuilder.Entity<RuleModel>()
                .Property(m => m.Created)
                .HasDefaultValueSql("date('now')");
            modelBuilder.Entity<RuleModel>()
                .Property(m => m.Modified)
                .HasDefaultValueSql("date('now')");
            // ForceModel
            modelBuilder.Entity<ForceModel>()
                .HasKey(m => m.ForceId)
                .HasName("PK_ForceModel_Id");
            modelBuilder.Entity<ForceModel>()
                .Property(m => m.Created)
                .HasDefaultValueSql("date('now')");
            modelBuilder.Entity<ForceModel>()
                .Property(m => m.Modified)
                .HasDefaultValueSql("date('now')");
            // GameModel
            modelBuilder.Entity<GameModel>()
                .HasKey(m => m.GameId)
                .HasName("PK_GameModel_Id");
            modelBuilder.Entity<GameModel>()
                .Property(m => m.Created)
                .HasDefaultValueSql("date('now')");
            modelBuilder.Entity<GameModel>()
                .Property(m => m.Modified)
                .HasDefaultValueSql("date('now')");
            // User
            modelBuilder.Entity<IdentityUser<int>>()
                .HasKey(m => m.Id)
                .HasName("PK_SheetsUser_Id");
            // Role
            modelBuilder.Entity<IdentityRole<int>>()
                .HasKey(m => m.Id)
                .HasName("PK_SheetsRole_Id");
            // Claim
            modelBuilder.Entity<IdentityUserClaim<int>>()
                .HasKey(m => m.Id)
                .HasName("PK_SheetsClaim_Id");
            // UserRoles
            modelBuilder.Entity<IdentityUserRole<int>>()
                .HasKey(m => m.UserId)
                .HasName("PK_SheetsUserRoles_Id");

            // Mapping tables
            modelBuilder.Entity<GameForceMap>()
                .HasKey(gfm => new { gfm.ForceId, gfm.GameId});
            modelBuilder.Entity<GameForceMap>()
                .HasOne(gfm => gfm.Game)
                .WithMany(g => g.GameForceMap)
                .HasForeignKey(gfm => gfm.GameId);
            modelBuilder.Entity<GameForceMap>()
                .HasOne(gfm => gfm.Force)
                .WithMany(f => f.GameForceMaps)
                .HasForeignKey(gfm => gfm.ForceId);
        }
    }

    public class GameForceMap
    {
        public GameModel Game { get; set; }
        public ForceModel Force { get; set; }
        public int GameId { get; set; }
        public int ForceId { get; set; }
    }
}
