using Microsoft.EntityFrameworkCore.Migrations;

namespace TechBeauty.Dados.Migrations
{
    public partial class tentativaapi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CargoContratoTrabalho_ContratoTrabalho_ContratosTrabalhosId",
                table: "CargoContratoTrabalho");

            migrationBuilder.RenameColumn(
                name: "ContratosTrabalhosId",
                table: "CargoContratoTrabalho",
                newName: "ContratosId");

            migrationBuilder.RenameIndex(
                name: "IX_CargoContratoTrabalho_ContratosTrabalhosId",
                table: "CargoContratoTrabalho",
                newName: "IX_CargoContratoTrabalho_ContratosId");

            migrationBuilder.AddForeignKey(
                name: "FK_CargoContratoTrabalho_ContratoTrabalho_ContratosId",
                table: "CargoContratoTrabalho",
                column: "ContratosId",
                principalTable: "ContratoTrabalho",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CargoContratoTrabalho_ContratoTrabalho_ContratosId",
                table: "CargoContratoTrabalho");

            migrationBuilder.RenameColumn(
                name: "ContratosId",
                table: "CargoContratoTrabalho",
                newName: "ContratosTrabalhosId");

            migrationBuilder.RenameIndex(
                name: "IX_CargoContratoTrabalho_ContratosId",
                table: "CargoContratoTrabalho",
                newName: "IX_CargoContratoTrabalho_ContratosTrabalhosId");

            migrationBuilder.AddForeignKey(
                name: "FK_CargoContratoTrabalho_ContratoTrabalho_ContratosTrabalhosId",
                table: "CargoContratoTrabalho",
                column: "ContratosTrabalhosId",
                principalTable: "ContratoTrabalho",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
