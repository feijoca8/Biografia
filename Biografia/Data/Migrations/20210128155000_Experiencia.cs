using Microsoft.EntityFrameworkCore.Migrations;

namespace Biografia.Data.Migrations
{
    public partial class Experiencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experiencia",
                columns: table => new
                {
                    ExperienciaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(nullable: true),
                    Duracao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiencia", x => x.ExperienciaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Experiencia");
        }
    }
}
