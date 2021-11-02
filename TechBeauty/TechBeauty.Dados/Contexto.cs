using Microsoft.EntityFrameworkCore;
using System;
using TechBeauty.Dados.Map;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dados
{
    public class Contexto : DbContext
    {
        public DbSet<CargoContratoTrabalho> CargoContratoTrabalho { get; set; }
        public DbSet<RegimeContratual> RegimeContratual { get; set; }
        public DbSet<ContratoTrabalho> ContratoTrabalho { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // User ID=carson; Password=123, caso seja autenticação usuário e senha do DB.
            optionsBuilder.UseSqlServer("Password=admin;Persist Security Info=True;User ID=tech-beauty-admin;Initial Catalog=TechBeauty;Data Source=DESKTOP-MOTA"); //Trusted é para autenticação com usuário do Windows.
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AgendamentoMap());
            modelBuilder.ApplyConfiguration(new CaixaDiarioMap());
            modelBuilder.ApplyConfiguration(new CargoContratoTrabalhoMap());
            modelBuilder.ApplyConfiguration(new CargoMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ColaboradorMap());
            modelBuilder.ApplyConfiguration(new ColaboradorServicoMap());
            modelBuilder.ApplyConfiguration(new ContatoMap());
            modelBuilder.ApplyConfiguration(new ContratoTrabalhoMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new ExpedienteMap());
            modelBuilder.ApplyConfiguration(new FormaPagamentoMap());
            modelBuilder.ApplyConfiguration(new GeneroMap());
            modelBuilder.ApplyConfiguration(new OrdemServicoMap());
            modelBuilder.ApplyConfiguration(new PadraoRemuneracaoMap());
            modelBuilder.ApplyConfiguration(new PagamentoMap());
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new RegimeContratualMap());
            modelBuilder.ApplyConfiguration(new RemuneracaoDiariaMap());
            modelBuilder.ApplyConfiguration(new RemuneracaoDiariaServicoMap());
            modelBuilder.ApplyConfiguration(new ServicoMap());
            modelBuilder.ApplyConfiguration(new TipoContatoMap());
            modelBuilder.ApplyConfiguration(new TurnoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
