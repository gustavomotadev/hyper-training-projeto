using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBeauty.Dominio.Financeiro;

namespace TechBeauty.Dados.Map
{
    public class RemuneracaoDiariaMap : IEntityTypeConfiguration<RemuneracaoDiaria>
    {
        public void Configure(EntityTypeBuilder<RemuneracaoDiaria> builder)
        {
            builder.ToTable("RemuneracaoDiaria");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.HorasTrabalhadas)
                .HasColumnType("time")
                .IsRequired();

            builder.Property(x => x.ValorSalario)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(x => x.ValorComissao)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(x => x.ValorHoraExtra)
                .HasColumnType("decimal(10,2)")
                .IsRequired();
        }
    }
}
