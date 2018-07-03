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
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheetsUser_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Forces",
                columns: table => new
                {
                    ForceId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddedByUserId = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "date('now')"),
                    Modified = table.Column<DateTime>(nullable: false, defaultValueSql: "date('now')"),
                    ModifiedByUserId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForceModel_Id", x => x.ForceId);
                    table.ForeignKey(
                        name: "FK_Forces_Users_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Forces_Users_ModifiedByUserId",
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
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "date('now')"),
                    Modified = table.Column<DateTime>(nullable: false, defaultValueSql: "date('now')"),
                    ModifiedByUserId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponTypeModel_Id", x => x.Id);
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
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddedByUserId = table.Column<int>(nullable: true),
                    Completed = table.Column<DateTime>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "date('now')"),
                    LoserForceId = table.Column<int>(nullable: true),
                    LoserScore = table.Column<int>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false, defaultValueSql: "date('now')"),
                    ModifiedByUserId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    WinnerForceId = table.Column<int>(nullable: true),
                    WinnerScore = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameModel_Id", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_Users_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Forces_LoserForceId",
                        column: x => x.LoserForceId,
                        principalTable: "Forces",
                        principalColumn: "ForceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Forces_WinnerForceId",
                        column: x => x.WinnerForceId,
                        principalTable: "Forces",
                        principalColumn: "ForceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sheets",
                columns: table => new
                {
                    SheetId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddedByUserId = table.Column<int>(nullable: true),
                    Attacks = table.Column<int>(nullable: false),
                    BallisticSkill = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "date('now')"),
                    ForceModelForceId = table.Column<int>(nullable: true),
                    InvulnerableSave = table.Column<int>(nullable: false),
                    Leadership = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false, defaultValueSql: "date('now')"),
                    ModifiedByUserId = table.Column<int>(nullable: true),
                    Movement = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Points = table.Column<int>(nullable: false),
                    Save = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Toughness = table.Column<int>(nullable: false),
                    WeaponSkill = table.Column<int>(nullable: false),
                    Wounds = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheetModel_Id", x => x.SheetId);
                    table.ForeignKey(
                        name: "FK_Sheets_Users_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sheets_Forces_ForceModelForceId",
                        column: x => x.ForceModelForceId,
                        principalTable: "Forces",
                        principalColumn: "ForceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sheets_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameForceMap",
                columns: table => new
                {
                    ForceId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameForceMap", x => new { x.ForceId, x.GameId });
                    table.ForeignKey(
                        name: "FK_GameForceMap_Forces_ForceId",
                        column: x => x.ForceId,
                        principalTable: "Forces",
                        principalColumn: "ForceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameForceMap_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddedByUserId = table.Column<int>(nullable: true),
                    ArmorPenetration = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "date('now')"),
                    Damage = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false, defaultValueSql: "date('now')"),
                    ModifiedByUserId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Points = table.Column<int>(nullable: false),
                    Range = table.Column<int>(nullable: false),
                    SheetModelSheetId = table.Column<int>(nullable: true),
                    Strength = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponModel_Id", x => x.Id);
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
                        name: "FK_Weapons_Sheets_SheetModelSheetId",
                        column: x => x.SheetModelSheetId,
                        principalTable: "Sheets",
                        principalColumn: "SheetId",
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
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "date('now')"),
                    Modified = table.Column<DateTime>(nullable: false, defaultValueSql: "date('now')"),
                    ModifiedByUserId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Points = table.Column<int>(nullable: false),
                    SheetModelSheetId = table.Column<int>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    WeaponModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleModel_Id", x => x.Id);
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
                        name: "FK_Rules_Sheets_SheetModelSheetId",
                        column: x => x.SheetModelSheetId,
                        principalTable: "Sheets",
                        principalColumn: "SheetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rules_Weapons_WeaponModelId",
                        column: x => x.WeaponModelId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forces_AddedByUserId",
                table: "Forces",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Forces_ModifiedByUserId",
                table: "Forces",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameForceMap_GameId",
                table: "GameForceMap",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_AddedByUserId",
                table: "Games",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_LoserForceId",
                table: "Games",
                column: "LoserForceId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_ModifiedByUserId",
                table: "Games",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_WinnerForceId",
                table: "Games",
                column: "WinnerForceId");

            migrationBuilder.CreateIndex(
                name: "IX_Rules_AddedByUserId",
                table: "Rules",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rules_ModifiedByUserId",
                table: "Rules",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rules_SheetModelSheetId",
                table: "Rules",
                column: "SheetModelSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Rules_WeaponModelId",
                table: "Rules",
                column: "WeaponModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Sheets_AddedByUserId",
                table: "Sheets",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sheets_ForceModelForceId",
                table: "Sheets",
                column: "ForceModelForceId");

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
                name: "IX_Weapons_SheetModelSheetId",
                table: "Weapons",
                column: "SheetModelSheetId");

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
                name: "GameForceMap");

            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Sheets");

            migrationBuilder.DropTable(
                name: "WeaponTypes");

            migrationBuilder.DropTable(
                name: "Forces");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
