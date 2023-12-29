using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frizerie.Migrations
{
    public partial class NextMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rateing",
                table: "Barber",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rateing",
                table: "Barber");
        }
    }
}
