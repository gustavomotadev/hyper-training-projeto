using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dados.Map
{
    class ServicoMap : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.ToTable("Servico");

            builder.HasKey(x => x.Id);

            builder.HasMany<Agendamento>
                (s => s.Agendamentos)
                .WithOne(a => a.Servico)
                .HasForeignKey(a => a.ServicoId);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(x => x.Preco)
                .HasColumnType("decimal(6,2)")
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.DuracaoEmMin)
                .HasColumnType("int")
                .IsRequired();

            builder.HasMany<Colaborador>
                (s => s.Colaboradores)
                .WithMany(c => c.Servicos);
        }
    }
}
