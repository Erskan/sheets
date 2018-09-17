using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SheetsApi.Migrations
{
    public partial class AddCombatant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Combatants",
                columns: table => new
                {
                    CombatantId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddedByUserId = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "date('now')"),
                    ForceId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false, defaultValueSql: "date('now')"),
                    ModifiedByUserId = table.Column<int>(nullable: true),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CombatantModel_Id", x => x.CombatantId);
                    table.ForeignKey(
                        name: "FK_Combatants_Users_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Combatants_Forces_ForceId",
                        column: x => x.ForceId,
                        principalTable: "Forces",
                        principalColumn: "ForceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Combatants_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Combatants_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Combatants_AddedByUserId",
                table: "Combatants",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Combatants_ForceId",
                table: "Combatants",
                column: "ForceId");

            migrationBuilder.CreateIndex(
                name: "IX_Combatants_GameId",
                table: "Combatants",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Combatants_ModifiedByUserId",
                table: "Combatants",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Combatants");
        }
    }
}
