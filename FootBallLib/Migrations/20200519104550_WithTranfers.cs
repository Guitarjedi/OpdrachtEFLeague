using Microsoft.EntityFrameworkCore.Migrations;

namespace FootBallLib.Migrations
{
    public partial class WithTranfers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tranfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpelerId = table.Column<int>(type: "int", nullable: true),
                    OldTeamStamnummer = table.Column<int>(type: "int", nullable: true),
                    NewTeamStamnummer = table.Column<int>(type: "int", nullable: true),
                    TranferPrijs = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tranfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tranfers_Spelers_SpelerId",
                        column: x => x.SpelerId,
                        principalTable: "Spelers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tranfers_Teams_NewTeamStamnummer",
                        column: x => x.NewTeamStamnummer,
                        principalTable: "Teams",
                        principalColumn: "Stamnummer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tranfers_Teams_OldTeamStamnummer",
                        column: x => x.OldTeamStamnummer,
                        principalTable: "Teams",
                        principalColumn: "Stamnummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tranfers_NewTeamStamnummer",
                table: "Tranfers",
                column: "NewTeamStamnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Tranfers_OldTeamStamnummer",
                table: "Tranfers",
                column: "OldTeamStamnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Tranfers_SpelerId",
                table: "Tranfers",
                column: "SpelerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tranfers");
        }
    }
}
