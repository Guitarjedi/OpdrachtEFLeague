using Microsoft.EntityFrameworkCore.Migrations;

namespace FootBallLib.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Stamnummer = table.Column<int>(type: "int", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bijnaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trainer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Stamnummer);
                });

            migrationBuilder.CreateTable(
                name: "Spelers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rugnummer = table.Column<int>(type: "int", nullable: false),
                    Waarde = table.Column<long>(type: "bigint", nullable: false),
                    TeamStamnummer = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spelers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spelers_Teams_TeamStamnummer",
                        column: x => x.TeamStamnummer,
                        principalTable: "Teams",
                        principalColumn: "Stamnummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spelers_TeamStamnummer",
                table: "Spelers",
                column: "TeamStamnummer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spelers");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
