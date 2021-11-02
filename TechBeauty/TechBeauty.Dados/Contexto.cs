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
            modelBuilder.ApplyConfiguration(new CargoContratoTrabalhoMap());
            modelBuilder.ApplyConfiguration(new RegimeContratualMap());
            modelBuilder.ApplyConfiguration(new ContratoTrabalhoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
