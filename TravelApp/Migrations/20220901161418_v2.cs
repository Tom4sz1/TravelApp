using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelApp.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Continent",
                columns: table => new
                {
                    ContinentId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continent", x => x.ContinentId);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<string>(nullable: false),
                    ContinentId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    AccessToTheSea = table.Column<bool>(nullable: false),
                    MountainousTerrain = table.Column<bool>(nullable: false),
                    WoodedArea = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                    table.ForeignKey(
                        name: "FK_Country_Continent_ContinentId",
                        column: x => x.ContinentId,
                        principalTable: "Continent",
                        principalColumn: "ContinentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Town",
                columns: table => new
                {
                    TownId = table.Column<string>(nullable: false),
                    CountryId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    AccessToSea = table.Column<bool>(nullable: false),
                    MountainousTerrain = table.Column<bool>(nullable: false),
                    WoodedArea = table.Column<bool>(nullable: false),
                    HistoricalPlace = table.Column<bool>(nullable: false),
                    PlaceWithNature = table.Column<bool>(nullable: false),
                    TownCreator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Town", x => x.TownId);
                    table.ForeignKey(
                        name: "FK_Town_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Description",
                columns: table => new
                {
                    DescriptionId = table.Column<string>(nullable: false),
                    TownID = table.Column<string>(nullable: true),
                    Descripe = table.Column<string>(nullable: true),
                    Autor = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Description", x => x.DescriptionId);
                    table.ForeignKey(
                        name: "FK_Description_Town_TownID",
                        column: x => x.TownID,
                        principalTable: "Town",
                        principalColumn: "TownId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Country_ContinentId",
                table: "Country",
                column: "ContinentId");

            migrationBuilder.CreateIndex(
                name: "IX_Description_TownID",
                table: "Description",
                column: "TownID");

            migrationBuilder.CreateIndex(
                name: "IX_Town_CountryId",
                table: "Town",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Description");

            migrationBuilder.DropTable(
                name: "Town");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Continent");
        }
    }
}
