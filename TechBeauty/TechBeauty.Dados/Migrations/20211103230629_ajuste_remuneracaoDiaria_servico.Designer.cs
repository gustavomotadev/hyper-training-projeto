﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechBeauty.Dados;

namespace TechBeauty.Dados.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20211103230629_ajuste_remuneracaoDiaria_servico")]
    partial class ajuste_remuneracaoDiaria_servico
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CargoContratoTrabalho", b =>
                {
                    b.Property<int>("CargosId")
                        .HasColumnType("int");

                    b.Property<int>("ContratosTrabalhosId")
                        .HasColumnType("int");

                    b.HasKey("CargosId", "ContratosTrabalhosId");

                    b.HasIndex("ContratosTrabalhosId");

                    b.ToTable("CargoContratoTrabalho");
                });

            modelBuilder.Entity("ColaboradorServico", b =>
                {
                    b.Property<int>("ColaboradoresId")
                        .HasColumnType("int");

                    b.Property<int>("ServicosId")
                        .HasColumnType("int");

                    b.HasKey("ColaboradoresId", "ServicosId");

                    b.HasIndex("ServicosId");

                    b.ToTable("ColaboradorServico");
                });

            modelBuilder.Entity("RemuneracaoDiariaServico", b =>
                {
                    b.Property<int>("RemuneracoesId")
                        .HasColumnType("int");

                    b.Property<int>("ServicosId")
                        .HasColumnType("int");

                    b.HasKey("RemuneracoesId", "ServicosId");

                    b.HasIndex("ServicosId");

                    b.ToTable("RemuneracaoDiariaServico");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Financeiro.CaixaDiario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CustoFixo")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("date");

                    b.Property<decimal>("EncargosTrabalhistas")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("ReceitaBruta")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("ReceitaLiquida")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("SimplesNacional")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("TotalComissao")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("TotalHoraExtra")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("TotalSalario")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("CaixaDiario");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Financeiro.FormaPagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("FormaPagamento");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Financeiro.PadraoRemuneracao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AdicionalHoraExtra")
                        .HasColumnType("decimal(2,2)");

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("JornadaEsperada")
                        .HasColumnType("time");

                    b.Property<decimal>("PercentualComissao")
                        .HasColumnType("decimal(2,2)");

                    b.Property<decimal>("SalarioHora")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("ColaboradorId")
                        .IsUnique();

                    b.ToTable("PadraoRemuneracao");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Financeiro.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CaixaDiarioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("FormaPagamentoId")
                        .HasColumnType("int");

                    b.Property<int>("OrdemServicoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CaixaDiarioId");

                    b.HasIndex("FormaPagamentoId");

                    b.HasIndex("OrdemServicoId")
                        .IsUnique();

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Financeiro.RemuneracaoDiaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CaixaDiarioId")
                        .HasColumnType("int");

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("HorasTrabalhadas")
                        .HasColumnType("time");

                    b.Property<decimal>("ValorComissao")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("ValorHoraExtra")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("ValorSalario")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("CaixaDiarioId");

                    b.HasIndex("ColaboradorId");

                    b.ToTable("RemuneracaoDiaria");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.Agendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataHoraCriacao")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("DataHoraExecucao")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("ExpedienteId")
                        .HasColumnType("int");

                    b.Property<int>("OrdemServicoId")
                        .HasColumnType("int");

                    b.Property<string>("PessoaAtendida")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.Property<int>("StatusAgendamento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColaboradorId");

                    b.HasIndex("ExpedienteId");

                    b.HasIndex("OrdemServicoId");

                    b.HasIndex("ServicoId");

                    b.ToTable("Agendamento");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Cargo");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<int>("TipoContatoId")
                        .HasColumnType("int");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.HasIndex("TipoContatoId");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.ContratoTrabalho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ_CTPS")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataDesligamento")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("date");

                    b.Property<int>("RegimeContratualId")
                        .HasColumnType("int");

                    b.Property<bool>("Vigente")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ColaboradorId");

                    b.HasIndex("RegimeContratualId");

                    b.ToTable("ContratoTrabalho");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("char(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<int>("UF")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.Expediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataHoraAbertura")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("DataHoraFechamento")
                        .HasColumnType("smalldatetime");

                    b.HasKey("Id");

                    b.ToTable("Expediente");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Genero");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.OrdemServico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("StatusOS")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("OrdemServico");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("char(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.RegimeContratual", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("RegimeContratual");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<int>("DuracaoEmMin")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("Id");

                    b.ToTable("Servico");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.TipoContato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("TipoContato");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.Turno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataHoraEntrada")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("DataHoraSaida")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("ExpedienteId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RegistroEntrada")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime?>("RegistroSaida")
                        .HasColumnType("smalldatetime");

                    b.HasKey("Id");

                    b.HasIndex("ColaboradorId");

                    b.HasIndex("ExpedienteId");

                    b.ToTable("Turno");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.Cliente", b =>
                {
                    b.HasBaseType("TechBeauty.Dominio.Modelo.Pessoa");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.Colaborador", b =>
                {
                    b.HasBaseType("TechBeauty.Dominio.Modelo.Pessoa");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("NomeSocial")
                        .HasColumnType("varchar(100)");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("GeneroId");

                    b.ToTable("Colaborador");
                });

            modelBuilder.Entity("CargoContratoTrabalho", b =>
                {
                    b.HasOne("TechBeauty.Dominio.Modelo.Cargo", null)
                        .WithMany()
                        .HasForeignKey("CargosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechBeauty.Dominio.Modelo.ContratoTrabalho", null)
                        .WithMany()
                        .HasForeignKey("ContratosTrabalhosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ColaboradorServico", b =>
                {
                    b.HasOne("TechBeauty.Dominio.Modelo.Colaborador", null)
                        .WithMany()
                        .HasForeignKey("ColaboradoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechBeauty.Dominio.Modelo.Servico", null)
                        .WithMany()
                        .HasForeignKey("ServicosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RemuneracaoDiariaServico", b =>
                {
                    b.HasOne("TechBeauty.Dominio.Financeiro.RemuneracaoDiaria", null)
                        .WithMany()
                        .HasForeignKey("RemuneracoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechBeauty.Dominio.Modelo.Servico", null)
                        .WithMany()
                        .HasForeignKey("ServicosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TechBeauty.Dominio.Financeiro.PadraoRemuneracao", b =>
                {
                    b.HasOne("TechBeauty.Dominio.Modelo.Colaborador", "Colaborador")
                        .WithOne("PadraoRemuneracao")
                        .HasForeignKey("TechBeauty.Dominio.Financeiro.PadraoRemuneracao", "ColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colaborador");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Financeiro.Pagamento", b =>
                {
                    b.HasOne("TechBeauty.Dominio.Financeiro.CaixaDiario", "CaixaDiario")
                        .WithMany("Pagamentos")
                        .HasForeignKey("CaixaDiarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechBeauty.Dominio.Financeiro.FormaPagamento", "FormaPagamento")
                        .WithMany("Pagamentos")
                        .HasForeignKey("FormaPagamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechBeauty.Dominio.Modelo.OrdemServico", "OrdemServico")
                        .WithOne("Pagamento")
                        .HasForeignKey("TechBeauty.Dominio.Financeiro.Pagamento", "OrdemServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CaixaDiario");

                    b.Navigation("FormaPagamento");

                    b.Navigation("OrdemServico");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Financeiro.RemuneracaoDiaria", b =>
                {
                    b.HasOne("TechBeauty.Dominio.Financeiro.CaixaDiario", "CaixaDiario")
                        .WithMany("Remuneracoes")
                        .HasForeignKey("CaixaDiarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechBeauty.Dominio.Modelo.Colaborador", "Colaborador")
                        .WithMany("Remuneracoes")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CaixaDiario");

                    b.Navigation("Colaborador");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.Agendamento", b =>
                {
                    b.HasOne("TechBeauty.Dominio.Modelo.Colaborador", "Colaborador")
                        .WithMany("Agendamentos")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechBeauty.Dominio.Modelo.Expediente", "Expediente")
                        .WithMany("Agendamentos")
                        .HasForeignKey("ExpedienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechBeauty.Dominio.Modelo.OrdemServico", "OrdemServico")
                        .WithMany("Agendamentos")
                        .HasForeignKey("OrdemServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechBeauty.Dominio.Modelo.Servico", "Servico")
                        .WithMany("Agendamentos")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colaborador");

                    b.Navigation("Expediente");

                    b.Navigation("OrdemServico");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.Contato", b =>
                {
                    b.HasOne("TechBeauty.Dominio.Modelo.Pessoa", "Pessoa")
                        .WithMany("Contatos")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechBeauty.Dominio.Modelo.TipoContato", "TipoContato")
                        .WithMany("Contatos")
                        .HasForeignKey("TipoContatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");

                    b.Navigation("TipoContato");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.ContratoTrabalho", b =>
                {
                    b.HasOne("TechBeauty.Dominio.Modelo.Colaborador", "Colaborador")
                        .WithMany("Contratos")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechBeauty.Dominio.Modelo.RegimeContratual", "RegimeContratual")
                        .WithMany("ContratosDeTrabalho")
                        .HasForeignKey("RegimeContratualId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colaborador");

                    b.Navigation("RegimeContratual");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.OrdemServico", b =>
                {
                    b.HasOne("TechBeauty.Dominio.Modelo.Cliente", "Cliente")
                        .WithMany("OrdensServicos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.Turno", b =>
                {
                    b.HasOne("TechBeauty.Dominio.Modelo.Colaborador", "Colaborador")
                        .WithMany("Turnos")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechBeauty.Dominio.Modelo.Expediente", "Expediente")
                        .WithMany("Turnos")
                        .HasForeignKey("ExpedienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colaborador");

                    b.Navigation("Expediente");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.Cliente", b =>
                {
                    b.HasOne("TechBeauty.Dominio.Modelo.Pessoa", null)
                        .WithOne()
                        .HasForeignKey("TechBeauty.Dominio.Modelo.Cliente", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.Colaborador", b =>
                {
                    b.HasOne("TechBeauty.Dominio.Modelo.Endereco", "Endereco")
                        .WithMany("Colaboradores")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechBeauty.Dominio.Modelo.Genero", "Genero")
                        .WithMany("Colaboradores")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechBeauty.Dominio.Modelo.Pessoa", null)
                        .WithOne()
                        .HasForeignKey("TechBeauty.Dominio.Modelo.Colaborador", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Financeiro.CaixaDiario", b =>
                {
                    b.Navigation("Pagamentos");

                    b.Navigation("Remuneracoes");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Financeiro.FormaPagamento", b =>
                {
                    b.Navigation("Pagamentos");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.Endereco", b =>
                {
                    b.Navigation("Colaboradores");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.Expediente", b =>
                {
                    b.Navigation("Agendamentos");

                    b.Navigation("Turnos");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.Genero", b =>
                {
                    b.Navigation("Colaboradores");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.OrdemServico", b =>
                {
                    b.Navigation("Agendamentos");

                    b.Navigation("Pagamento");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.Pessoa", b =>
                {
                    b.Navigation("Contatos");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.RegimeContratual", b =>
                {
                    b.Navigation("ContratosDeTrabalho");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.Servico", b =>
                {
                    b.Navigation("Agendamentos");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.TipoContato", b =>
                {
                    b.Navigation("Contatos");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.Cliente", b =>
                {
                    b.Navigation("OrdensServicos");
                });

            modelBuilder.Entity("TechBeauty.Dominio.Modelo.Colaborador", b =>
                {
                    b.Navigation("Agendamentos");

                    b.Navigation("Contratos");

                    b.Navigation("PadraoRemuneracao");

                    b.Navigation("Remuneracoes");

                    b.Navigation("Turnos");
                });
#pragma warning restore 612, 618
        }
    }
}
