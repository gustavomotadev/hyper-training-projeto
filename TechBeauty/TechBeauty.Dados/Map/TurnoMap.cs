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
    public class TurnoMap : IEntityTypeConfiguration<Turno>
    {
        public void Configure(EntityTypeBuilder<Turno> builder)
        {
            builder.ToTable("Turno");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataHoraEntrada)
                .HasColumnType("smalldatetime")
                .IsRequired();

            builder.Property(x => x.DataHoraSaida)
               .HasColumnType("smalldatetime")
               .IsRequired();

            builder.Property(x => x.RegistroEntrada)
               .HasColumnType("smalldatetime");


            builder.Property(x => x.RegistroSaida)
               .HasColumnType("smalldatetime");
               
        }
    }
}
