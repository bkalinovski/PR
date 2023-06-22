using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PR.Persistance.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tara",
                columns: table => new
                {
                    CodTara = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Continent = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tara", x => x.CodTara);
                });

            migrationBuilder.CreateTable(
                name: "Oras",
                columns: table => new
                {
                    CodOras = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    NumarLocuitori = table.Column<int>(type: "int", nullable: false),
                    CodTara = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oras", x => x.CodOras);
                    table.ForeignKey(
                        name: "FK_Oras_Tara_CodTara",
                        column: x => x.CodTara,
                        principalTable: "Tara",
                        principalColumn: "CodTara",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oras_CodTara",
                table: "Oras",
                column: "CodTara");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oras");

            migrationBuilder.DropTable(
                name: "Tara");
        }
    }
}
