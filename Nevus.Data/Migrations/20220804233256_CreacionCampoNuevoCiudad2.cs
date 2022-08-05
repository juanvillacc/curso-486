using Microsoft.EntityFrameworkCore.Migrations;

namespace Nevus.Data.Migrations
{
    public partial class CreacionCampoNuevoCiudad2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abreviatura",
                table: "Ciudad",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abreviatura",
                table: "Ciudad");
        }
    }
}
