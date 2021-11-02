using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TechBeauty.Financeiro.Modelo;

namespace TechBeauty.Dados.Map
{
    class CaixaDiarioMap : IEntityTypeConfiguration<CaixaDiario>
    {
        public void Configure(EntityTypeBuilder<CaixaDiario> builder)
        {
            builder.ToTable("CaixaDiario");

            builder.HasKey(x => x.Id);

            builder.HasMany<Pagamento>
                (cd => cd.Pagamentos)
                .WithOne(p => p.CaixaDiario)
                .HasForeignKey(p => p.CaixaDiarioId);

            builder.HasMany<RemuneracaoDiaria>
                (cd => cd.Remuneracoes)
                .WithOne(r => r.CaixaDiario)
                .HasForeignKey(r => r.CaixaDiarioId);

            builder.Property(x => x.TotalSalario)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(x => x.TotalComissao)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(x => x.TotalHoraExtra)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(x => x.CustoFixo)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(x => x.EncargosTrabalhistas)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(x => x.SimplesNacional)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(x => x.ReceitaBruta)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(x => x.ReceitaLiquida)
                .HasColumnType("decimal(10,2)")
                .IsRequired();
        }
    }
}
