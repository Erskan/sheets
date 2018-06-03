using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SheetsApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sheets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddedByUserId = table.Column<int>(nullable: true),
                    Attacks = table.Column<int>(nullable: false),
                    BallisticSkill = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    InvulnerableSave = table.Column<int>(nullable: false),
                    Leadership = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedByUserId = table.Column<int>(nullable: true),
                    Movement = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Save = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Toughness = table.Column<int>(nullable: false),
                    WeaponSkill = table.Column<int>(nullable: false),
                    Wounds = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sheets_Users_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sheets_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeaponTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddedByUserId = table.Column<int>(nullable: true),
                    Attacks = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedByUserId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeaponTypes_Users_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeaponTypes_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddedByUserId = table.Column<int>(nullable: true),
                    ArmorPenetration = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Damage = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedByUserId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Range = table.Column<int>(nullable: false),
                    SheetId = table.Column<int>(nullable: true),
                    Strength = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapons_Users_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weapons_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weapons_Sheets_SheetId",
                        column: x => x.SheetId,
                        principalTable: "Sheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weapons_WeaponTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "WeaponTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddedByUserId = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedByUserId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SheetId = table.Column<int>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    WeaponId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rules_Users_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rules_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rules_Sheets_SheetId",
                        column: x => x.SheetId,
                        principalTable: "Sheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rules_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rules_AddedByUserId",
                table: "Rules",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rules_ModifiedByUserId",
                table: "Rules",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rules_SheetId",
                table: "Rules",
                column: "SheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Rules_WeaponId",
                table: "Rules",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Sheets_AddedByUserId",
                table: "Sheets",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sheets_ModifiedByUserId",
                table: "Sheets",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_AddedByUserId",
                table: "Weapons",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_ModifiedByUserId",
                table: "Weapons",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_SheetId",
                table: "Weapons",
                column: "SheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_TypeId",
                table: "Weapons",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponTypes_AddedByUserId",
                table: "WeaponTypes",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponTypes_ModifiedByUserId",
                table: "WeaponTypes",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Sheets");

            migrationBuilder.DropTable(
                name: "WeaponTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
