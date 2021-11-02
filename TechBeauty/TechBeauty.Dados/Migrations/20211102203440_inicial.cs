using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechBeauty.Dados.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaixaDiario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "date", nullable: false),
                    TotalSalario = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TotalComissao = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TotalHoraExtra = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CustoFixo = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    EncargosTrabalhistas = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    SimplesNacional = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ReceitaBruta = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ReceitaLiquida = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaixaDiario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "varchar(200)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(50)", nullable: false),
                    UF = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<string>(type: "varchar(15)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(100)", nullable: false),
                    CEP = table.Column<string>(type: "char(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expediente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHoraAbertura = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    DataHoraFechamento = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expediente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormaPagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    CPF = table.Column<string>(type: "char(11)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegimeContratual",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegimeContratual", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(150)", nullable: false),
                    DuracaoEmMin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoContato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoContato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Pessoa_Id",
                        column: x => x.Id,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false),
                    NomeSocial = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaborador_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colaborador_Genero_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colaborador_Pessoa_Id",
                        column: x => x.Id,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoContatoId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<string>(type: "varchar(256)", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contato_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contato_TipoContato_TipoContatoId",
                        column: x => x.TipoContatoId,
                        principalTable: "TipoContato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdemServico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    StatusOS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemServico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdemServico_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Colaborador_Servico",
                columns: table => new
                {
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador_Servico", x => new { x.ColaboradorId, x.ServicoId });
                    table.ForeignKey(
                        name: "FK_Colaborador_Servico_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colaborador_Servico_Servico_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContratoTrabalho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegimeContratualId = table.Column<int>(type: "int", nullable: false),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "date", nullable: false),
                    DataDesligamento = table.Column<DateTime>(type: "date", nullable: true),
                    CNPJ_CTPS = table.Column<string>(type: "varchar(14)", nullable: false),
                    Vigente = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratoTrabalho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContratoTrabalho_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratoTrabalho_RegimeContratual_RegimeContratualId",
                        column: x => x.RegimeContratualId,
                        principalTable: "RegimeContratual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PadraoRemuneracao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    JornadaEsperada = table.Column<TimeSpan>(type: "time", nullable: false),
                    SalarioHora = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PercentualComissao = table.Column<decimal>(type: "decimal(2,2)", nullable: false),
                    AdicionalHoraExtra = table.Column<decimal>(type: "decimal(2,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PadraoRemuneracao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PadraoRemuneracao_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RemuneracaoDiaria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    CaixaDiarioId = table.Column<int>(type: "int", nullable: false),
                    HorasTrabalhadas = table.Column<TimeSpan>(type: "time", nullable: false),
                    ValorSalario = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorComissao = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorHoraExtra = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemuneracaoDiaria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RemuneracaoDiaria_CaixaDiario_CaixaDiarioId",
                        column: x => x.CaixaDiarioId,
                        principalTable: "CaixaDiario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RemuneracaoDiaria_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHoraEntrada = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    DataHoraSaida = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    RegistroEntrada = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    RegistroSaida = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ExpedienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turno_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turno_Expediente_ExpedienteId",
                        column: x => x.ExpedienteId,
                        principalTable: "Expediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicoId = table.Column<int>(type: "int", nullable: false),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    OrdemServicoId = table.Column<int>(type: "int", nullable: false),
                    ExpedienteId = table.Column<int>(type: "int", nullable: false),
                    PessoaAtendida = table.Column<string>(type: "varchar(30)", nullable: false),
                    DataHoraCriacao = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    DataHoraExecucao = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    StatusAgendamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamento_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamento_Expediente_ExpedienteId",
                        column: x => x.ExpedienteId,
                        principalTable: "Expediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamento_OrdemServico_OrdemServicoId",
                        column: x => x.OrdemServicoId,
                        principalTable: "OrdemServico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamento_Servico_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdemServicoId = table.Column<int>(type: "int", nullable: false),
                    FormaPagamentoId = table.Column<int>(type: "int", nullable: false),
                    CaixaDiarioId = table.Column<int>(type: "int", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamento_CaixaDiario_CaixaDiarioId",
                        column: x => x.CaixaDiarioId,
                        principalTable: "CaixaDiario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagamento_FormaPagamento_FormaPagamentoId",
                        column: x => x.FormaPagamentoId,
                        principalTable: "FormaPagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagamento_OrdemServico_OrdemServicoId",
                        column: x => x.OrdemServicoId,
                        principalTable: "OrdemServico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Agendamento_ColaboradorId",
                table: "Agendamento",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_ExpedienteId",
                table: "Agendamento",
                column: "ExpedienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_OrdemServicoId",
                table: "Agendamento",
                column: "OrdemServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_ServicoId",
                table: "Agendamento",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_ContratoTrabalho_ContratoTrabalhoId",
                table: "Cargo_ContratoTrabalho",
                column: "ContratoTrabalhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_EnderecoId",
                table: "Colaborador",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_GeneroId",
                table: "Colaborador",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_Servico_ServicoId",
                table: "Colaborador_Servico",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contato_PessoaId",
                table: "Contato",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contato_TipoContatoId",
                table: "Contato",
                column: "TipoContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratoTrabalho_ColaboradorId",
                table: "ContratoTrabalho",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratoTrabalho_RegimeContratualId",
                table: "ContratoTrabalho",
                column: "RegimeContratualId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_ClienteId",
                table: "OrdemServico",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PadraoRemuneracao_ColaboradorId",
                table: "PadraoRemuneracao",
                column: "ColaboradorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_CaixaDiarioId",
                table: "Pagamento",
                column: "CaixaDiarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_FormaPagamentoId",
                table: "Pagamento",
                column: "FormaPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_OrdemServicoId",
                table: "Pagamento",
                column: "OrdemServicoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RemuneracaoDiaria_CaixaDiarioId",
                table: "RemuneracaoDiaria",
                column: "CaixaDiarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RemuneracaoDiaria_ColaboradorId",
                table: "RemuneracaoDiaria",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_RemuneracaoDiaria_Servico_ServicoId",
                table: "RemuneracaoDiaria_Servico",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turno_ColaboradorId",
                table: "Turno",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Turno_ExpedienteId",
                table: "Turno",
                column: "ExpedienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamento");

            migrationBuilder.DropTable(
                name: "Cargo_ContratoTrabalho");

            migrationBuilder.DropTable(
                name: "Colaborador_Servico");

            migrationBuilder.DropTable(
                name: "Contato");

            migrationBuilder.DropTable(
                name: "PadraoRemuneracao");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "RemuneracaoDiaria_Servico");

            migrationBuilder.DropTable(
                name: "Turno");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "ContratoTrabalho");

            migrationBuilder.DropTable(
                name: "TipoContato");

            migrationBuilder.DropTable(
                name: "FormaPagamento");

            migrationBuilder.DropTable(
                name: "OrdemServico");

            migrationBuilder.DropTable(
                name: "RemuneracaoDiaria");

            migrationBuilder.DropTable(
                name: "Servico");

            migrationBuilder.DropTable(
                name: "Expediente");

            migrationBuilder.DropTable(
                name: "RegimeContratual");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "CaixaDiario");

            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
