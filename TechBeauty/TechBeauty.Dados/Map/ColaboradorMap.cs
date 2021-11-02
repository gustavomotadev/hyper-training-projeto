using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBeauty.Dominio.Financeiro;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dados.Map
{
    public class ColaboradorMap : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.ToTable("Colaborador");

            builder.Property(x => x.NomeSocial)
                .HasColumnType("varchar(100)");

            builder.HasMany<ContratoTrabalho>
                (c => c.Contratos)
                .WithOne(c => c.Colaborador)
                .HasForeignKey(c => c.ColaboradorId);

            builder.HasMany<Turno>
                (c => c.Turnos)
                .WithOne(c => c.Colaborador)
                .HasForeignKey(c => c.ColaboradorId);

            builder.HasMany<Agendamento>
             (c => c.Agendamentos)
             .WithOne(c => c.Colaborador)
             .HasForeignKey(c => c.ColaboradorId);

            builder.HasOne(x => x.PadraoRemuneracao)
                .WithOne(p => p.Colaborador)
                .HasForeignKey<PadraoRemuneracao>(p => p.ColaboradorId);

            builder.HasMany<RemuneracaoDiaria>
                (c => c.Remuneracoes)
                .WithOne(r => r.Colaborador)
                .HasForeignKey(r => r.ColaboradorId);
        }
    }
}
