using Microsoft.EntityFrameworkCore.Migrations;

namespace TechBeauty.Dados.Migrations
{
    public partial class ajuste_remuneracaoDiaria_servico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RemuneracaoDiaria_Servico");

            migrationBuilder.CreateTable(
                name: "RemuneracaoDiariaServico",
                columns: table => new
                {
                    RemuneracoesId = table.Column<int>(type: "int", nullable: false),
                    ServicosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemuneracaoDiariaServico", x => new { x.RemuneracoesId, x.ServicosId });
                    table.ForeignKey(
                        name: "FK_RemuneracaoDiariaServico_RemuneracaoDiaria_RemuneracoesId",
                        column: x => x.RemuneracoesId,
                        principalTable: "RemuneracaoDiaria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RemuneracaoDiariaServico_Servico_ServicosId",
                        column: x => x.ServicosId,
                        principalTable: "Servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RemuneracaoDiariaServico_ServicosId",
                table: "RemuneracaoDiariaServico",
                column: "ServicosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RemuneracaoDiariaServico");

            migrationBuilder.CreateTable(
                name: "RemuneracaoDiaria_Servico",
                columns: table => new
                {
                    RemuneracaoDiariaId = table.Column<int>(type: "int", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemuneracaoDiaria_Servico", x => new { x.RemuneracaoDiariaId, x.ServicoId });
                    table.ForeignKey(
                        name: "FK_RemuneracaoDiaria_Servico_RemuneracaoDiaria_RemuneracaoDiariaId",
                        column: x => x.RemuneracaoDiariaId,
                        principalTable: "RemuneracaoDiaria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RemuneracaoDiaria_Servico_Servico_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RemuneracaoDiaria_Servico_ServicoId",
                table: "RemuneracaoDiaria_Servico",
                column: "ServicoId");
        }
    }
}
