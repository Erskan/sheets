﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SheetsApi.Shared;
using System;

namespace SheetsApi.Migrations
{
    [DbContext(typeof(SheetsDbContext))]
    partial class SheetsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("SheetsApi.Forces.ForceModel", b =>
                {
                    b.Property<int>("ForceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddedByUserId");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("ModifiedByUserId");

                    b.Property<string>("Name");

                    b.HasKey("ForceId")
                        .HasName("PK_ForceModel_Id");

                    b.HasIndex("AddedByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("Forces");
                });

            modelBuilder.Entity("SheetsApi.Games.GameModel", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddedByUserId");

                    b.Property<DateTime?>("Completed");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("LoserForceId");

                    b.Property<int?>("LoserScore");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("ModifiedByUserId");

                    b.Property<string>("Name");

                    b.Property<int?>("WinnerForceId");

                    b.Property<int?>("WinnerScore");

                    b.HasKey("GameId")
                        .HasName("PK_GameModel_Id");

                    b.HasIndex("AddedByUserId");

                    b.HasIndex("LoserForceId");

                    b.HasIndex("ModifiedByUserId");

                    b.HasIndex("WinnerForceId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("SheetsApi.Shared.GameForceMap", b =>
                {
                    b.Property<int>("ForceId");

                    b.Property<int>("GameId");

                    b.HasKey("ForceId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("GameForceMap");
                });

            modelBuilder.Entity("SheetsApi.Shared.RuleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddedByUserId");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("ModifiedByUserId");

                    b.Property<string>("Name");

                    b.Property<int?>("SheetModelSheetId");

                    b.Property<string>("Text");

                    b.Property<int?>("WeaponModelId");

                    b.HasKey("Id")
                        .HasName("PK_RuleModel_Id");

                    b.HasIndex("AddedByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.HasIndex("SheetModelSheetId");

                    b.HasIndex("WeaponModelId");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("SheetsApi.Shared.SheetsUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id")
                        .HasName("PK_SheetsUser_Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SheetsApi.Shared.WeaponModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddedByUserId");

                    b.Property<int>("ArmorPenetration");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("Damage");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("ModifiedByUserId");

                    b.Property<string>("Name");

                    b.Property<int>("Range");

                    b.Property<int?>("SheetModelSheetId");

                    b.Property<int>("Strength");

                    b.Property<int?>("TypeId");

                    b.HasKey("Id")
                        .HasName("PK_WeaponModel_Id");

                    b.HasIndex("AddedByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.HasIndex("SheetModelSheetId");

                    b.HasIndex("TypeId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("SheetsApi.Shared.WeaponTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddedByUserId");

                    b.Property<string>("Attacks");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("ModifiedByUserId");

                    b.Property<string>("Name");

                    b.Property<int>("Type");

                    b.HasKey("Id")
                        .HasName("PK_WeaponTypeModel_Id");

                    b.HasIndex("AddedByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("WeaponTypes");
                });

            modelBuilder.Entity("SheetsApi.Sheets.SheetModel", b =>
                {
                    b.Property<int>("SheetId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddedByUserId");

                    b.Property<int>("Attacks");

                    b.Property<int>("BallisticSkill");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("ForceModelForceId");

                    b.Property<int>("InvulnerableSave");

                    b.Property<int>("Leadership");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("ModifiedByUserId");

                    b.Property<int>("Movement");

                    b.Property<string>("Name");

                    b.Property<int>("Save");

                    b.Property<int>("Strength");

                    b.Property<int>("Toughness");

                    b.Property<int>("WeaponSkill");

                    b.Property<int>("Wounds");

                    b.HasKey("SheetId")
                        .HasName("PK_SheetModel_Id");

                    b.HasIndex("AddedByUserId");

                    b.HasIndex("ForceModelForceId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("Sheets");
                });

            modelBuilder.Entity("SheetsApi.Forces.ForceModel", b =>
                {
                    b.HasOne("SheetsApi.Shared.SheetsUser", "AddedByUser")
                        .WithMany()
                        .HasForeignKey("AddedByUserId");

                    b.HasOne("SheetsApi.Shared.SheetsUser", "ModifiedByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId");
                });

            modelBuilder.Entity("SheetsApi.Games.GameModel", b =>
                {
                    b.HasOne("SheetsApi.Shared.SheetsUser", "AddedByUser")
                        .WithMany()
                        .HasForeignKey("AddedByUserId");

                    b.HasOne("SheetsApi.Forces.ForceModel", "Loser")
                        .WithMany()
                        .HasForeignKey("LoserForceId");

                    b.HasOne("SheetsApi.Shared.SheetsUser", "ModifiedByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId");

                    b.HasOne("SheetsApi.Forces.ForceModel", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerForceId");
                });

            modelBuilder.Entity("SheetsApi.Shared.GameForceMap", b =>
                {
                    b.HasOne("SheetsApi.Forces.ForceModel", "Force")
                        .WithMany("GameForceMaps")
                        .HasForeignKey("ForceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SheetsApi.Games.GameModel", "Game")
                        .WithMany("GameForceMap")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SheetsApi.Shared.RuleModel", b =>
                {
                    b.HasOne("SheetsApi.Shared.SheetsUser", "AddedByUser")
                        .WithMany()
                        .HasForeignKey("AddedByUserId");

                    b.HasOne("SheetsApi.Shared.SheetsUser", "ModifiedByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId");

                    b.HasOne("SheetsApi.Sheets.SheetModel")
                        .WithMany("Rules")
                        .HasForeignKey("SheetModelSheetId");

                    b.HasOne("SheetsApi.Shared.WeaponModel")
                        .WithMany("Rules")
                        .HasForeignKey("WeaponModelId");
                });

            modelBuilder.Entity("SheetsApi.Shared.WeaponModel", b =>
                {
                    b.HasOne("SheetsApi.Shared.SheetsUser", "AddedByUser")
                        .WithMany()
                        .HasForeignKey("AddedByUserId");

                    b.HasOne("SheetsApi.Shared.SheetsUser", "ModifiedByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId");

                    b.HasOne("SheetsApi.Sheets.SheetModel")
                        .WithMany("Weapons")
                        .HasForeignKey("SheetModelSheetId");

                    b.HasOne("SheetsApi.Shared.WeaponTypeModel", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("SheetsApi.Shared.WeaponTypeModel", b =>
                {
                    b.HasOne("SheetsApi.Shared.SheetsUser", "AddedByUser")
                        .WithMany()
                        .HasForeignKey("AddedByUserId");

                    b.HasOne("SheetsApi.Shared.SheetsUser", "ModifiedByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId");
                });

            modelBuilder.Entity("SheetsApi.Sheets.SheetModel", b =>
                {
                    b.HasOne("SheetsApi.Shared.SheetsUser", "AddedByUser")
                        .WithMany()
                        .HasForeignKey("AddedByUserId");

                    b.HasOne("SheetsApi.Forces.ForceModel")
                        .WithMany("Sheets")
                        .HasForeignKey("ForceModelForceId");

                    b.HasOne("SheetsApi.Shared.SheetsUser", "ModifiedByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
