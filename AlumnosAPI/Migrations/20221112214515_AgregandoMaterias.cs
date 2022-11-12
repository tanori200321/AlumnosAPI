using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlumnosAPI.Migrations
{
    public partial class AgregandoMaterias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Materias",
                table: "Alumnos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Materias",
                table: "Alumnos");
        }
    }
}
