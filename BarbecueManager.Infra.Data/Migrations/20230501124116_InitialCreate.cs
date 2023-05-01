using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarbecueManager.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barbecues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "varchar(200)", nullable: false),
                    Observation = table.Column<string>(type: "varchar(200)", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ContributionAmountWithDrinks = table.Column<decimal>(type: "TEXT", nullable: false),
                    ContributionAmountWithoutDrinks = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbecues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fullname = table.Column<string>(type: "varchar(200)", nullable: false),
                    ContributionAmount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonBarbecues",
                columns: table => new
                {
                    BarbecuesId = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonBarbecues", x => new { x.BarbecuesId, x.PersonsId });
                    table.ForeignKey(
                        name: "FK_PersonBarbecues_Barbecues_BarbecuesId",
                        column: x => x.BarbecuesId,
                        principalTable: "Barbecues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonBarbecues_Persons_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonBarbecues_PersonsId",
                table: "PersonBarbecues",
                column: "PersonsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonBarbecues");

            migrationBuilder.DropTable(
                name: "Barbecues");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
