using Microsoft.EntityFrameworkCore.Migrations;

namespace TechBeauty.Dados.Migrations
{
    public partial class ajuste_cargo_contrato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargo_ContratoTrabalho");

            migrationBuilder.CreateTable(
                name: "CargoContratoTrabalho",
                columns: table => new
                {
                    CargosId = table.Column<int>(type: "int", nullable: false),
                    ContratosTrabalhosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoContratoTrabalho", x => new { x.CargosId, x.ContratosTrabalhosId });
                    table.ForeignKey(
                        name: "FK_CargoContratoTrabalho_Cargo_CargosId",
                        column: x => x.CargosId,
                        principalTable: "Cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CargoContratoTrabalho_ContratoTrabalho_ContratosTrabalhosId",
                        column: x => x.ContratosTrabalhosId,
                        principalTable: "ContratoTrabalho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CargoContratoTrabalho_ContratosTrabalhosId",
                table: "CargoContratoTrabalho",
                column: "ContratosTrabalhosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CargoContratoTrabalho");

            migrationBuilder.CreateTable(
                name: "Cargo_ContratoTrabalho",
                columns: table => new
                {
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    ContratoTrabalhoId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo_ContratoTrabalho", x => new { x.CargoId, x.ContratoTrabalhoId });
                    table.ForeignKey(
                        name: "FK_Cargo_ContratoTrabalho_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cargo_ContratoTrabalho_ContratoTrabalho_ContratoTrabalhoId",
                        column: x => x.ContratoTrabalhoId,
                        principalTable: "ContratoTrabalho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_ContratoTrabalho_ContratoTrabalhoId",
                table: "Cargo_ContratoTrabalho",
                column: "ContratoTrabalhoId");
        }
    }
}
