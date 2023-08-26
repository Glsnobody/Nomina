using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NominaWeb.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioHora = table.Column<double>(type: "float", nullable: false),
                    CantidadHoras = table.Column<int>(type: "int", nullable: false),
                    MontoGanado = table.Column<double>(type: "float", nullable: false),
                    Incentivos = table.Column<double>(type: "float", nullable: false),
                    TotalGanado = table.Column<double>(type: "float", nullable: false),
                    ISR = table.Column<double>(type: "float", nullable: false),
                    Avances = table.Column<double>(type: "float", nullable: false),
                    TotalDeducciones = table.Column<double>(type: "float", nullable: false),
                    TotalRecibir = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profesores");
        }
    }
}
