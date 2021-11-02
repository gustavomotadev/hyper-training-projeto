using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dados.Map
{
    public class ExpedienteMap : IEntityTypeConfiguration<Expediente>
    {
        public void Configure(EntityTypeBuilder<Expediente> builder)
        {
            builder.ToTable("Expediente");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataHoraAbertura)
                .HasColumnType("smalldatetime")
                .IsRequired();

            builder.Property(x => x.DataHoraFechamento)
                .HasColumnType("smalldatetime")
                .IsRequired();

            builder.HasMany<Agendamento>
                (e => e.Agendamentos)
                .WithOne(a => a.Expediente)
                .HasForeignKey(a => a.ExpedienteId);

            builder.HasMany<Turno>
                (e => e.Turnos)
                .WithOne(t => t.Expediente)
                .HasForeignKey(t => t.ExpedienteId);

        }
    }
}
