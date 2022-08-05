using Microsoft.EntityFrameworkCore.Migrations;

namespace Nevus.Data.Migrations
{
    public partial class CreacionCampoNuevoDepartamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstaActivo",
                table: "Departamento",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstaActivo",
                table: "Departamento");
        }
    }
}
