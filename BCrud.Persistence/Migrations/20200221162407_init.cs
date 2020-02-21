using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BCrud.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TradeLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    TradeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TradeLevels_Trades_TradeId",
                        column: x => x.TradeId,
                        principalTable: "Trades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Syllabi",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    TradeId = table.Column<Guid>(nullable: false),
                    TradeLevelId = table.Column<Guid>(nullable: false),
                    Languages = table.Column<string>(nullable: false),
                    SyllabusFilename = table.Column<string>(nullable: true),
                    SyllabusUrl = table.Column<string>(nullable: true),
                    TestPlanFilename = table.Column<string>(nullable: true),
                    TestPlanUrl = table.Column<string>(nullable: true),
                    DevelopmentOfficer = table.Column<string>(nullable: false),
                    Manager = table.Column<string>(nullable: false),
                    ActiveDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Syllabi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Syllabi_Trades_TradeId",
                        column: x => x.TradeId,
                        principalTable: "Trades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Syllabi_TradeLevels_TradeLevelId",
                        column: x => x.TradeLevelId,
                        principalTable: "TradeLevels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Syllabi_TradeId",
                table: "Syllabi",
                column: "TradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Syllabi_TradeLevelId",
                table: "Syllabi",
                column: "TradeLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeLevels_TradeId",
                table: "TradeLevels",
                column: "TradeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Syllabi");

            migrationBuilder.DropTable(
                name: "TradeLevels");

            migrationBuilder.DropTable(
                name: "Trades");
        }
    }
}
