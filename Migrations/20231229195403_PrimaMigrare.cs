using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frizerie.Migrations
{
    public partial class PrimaMigrare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barber",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barber", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BarberShop",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrTelefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rateing = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarberShop", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Serviciu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip_Serviciu = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    BarberID = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Data_Programare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BarberShopID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serviciu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Serviciu_Barber_BarberID",
                        column: x => x.BarberID,
                        principalTable: "Barber",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Serviciu_BarberShop_BarberShopID",
                        column: x => x.BarberShopID,
                        principalTable: "BarberShop",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Serviciu_BarberID",
                table: "Serviciu",
                column: "BarberID");

            migrationBuilder.CreateIndex(
                name: "IX_Serviciu_BarberShopID",
                table: "Serviciu",
                column: "BarberShopID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Serviciu");

            migrationBuilder.DropTable(
                name: "Barber");

            migrationBuilder.DropTable(
                name: "BarberShop");
        }
    }
}
