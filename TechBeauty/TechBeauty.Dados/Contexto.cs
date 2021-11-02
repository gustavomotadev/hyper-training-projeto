using Microsoft.EntityFrameworkCore;
using System;
using TechBeauty.Dados.Map;
using TechBeauty.Dominio.Financeiro;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dados
{
    public class Contexto : DbContext
    {
        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<CaixaDiario> CaixaDiario { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<CargoContratoTrabalho> CargoContratoTrabalho { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<ColaboradorServico> ColaboradorServico { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<ContratoTrabalho> ContratoTrabalho { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Expediente> Expediente { get; set; }
        public DbSet<FormaPagamento> FormaPagamento { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<OrdemServico> OrdemServico { get; set; }
        public DbSet<PadraoRemuneracao> PadraoRemuneracao { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<RegimeContratual> RegimeContratual { get; set; }
        public DbSet<RemuneracaoDiaria> RemuneracaoDiaria { get; set; }
        public DbSet<RemuneracaoDiariaServico> RemuneracaoDiariaServico { get; set; }
        public DbSet<Servico> Servico { get; set; }
        public DbSet<TipoContato> TipoContato { get; set; }
        public DbSet<Turno> Turno { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // User ID=carson; Password=123, caso seja autenticação usuário e senha do DB.
            optionsBuilder.UseSqlServer("Password=admin;Persist Security Info=True;User ID=tech-beauty-admin;Initial Catalog=TechBeauty;Data Source=DESKTOP-MOTA"); //Trusted é para autenticação com usuário do Windows.
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CargoContratoTrabalhoMap());
            modelBuilder.ApplyConfiguration(new RegimeContratualMap());
            modelBuilder.ApplyConfiguration(new ContratoTrabalhoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
