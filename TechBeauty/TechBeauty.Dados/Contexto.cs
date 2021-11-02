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
            optionsBuilder.UseSqlServer("Server=DESKTOP-9LK3UQP; Database=TechBeautyDB; Trusted_Connection=True"); //Trusted é para autenticação com usuário do Windows.
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
