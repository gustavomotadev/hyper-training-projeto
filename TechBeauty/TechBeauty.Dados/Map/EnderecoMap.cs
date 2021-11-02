using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dados.Map
{
    class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(x => x.Id);
            
            builder.HasMany<Colaborador>
                (e => e.Colaboradores)
                .WithOne(c => c.Endereco)
                .HasForeignKey(c => c.EnderecoId);

            builder.Property(x => x.Logradouro)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(x => x.Bairro)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(x => x.Cidade)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(x => x.UF)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Numero)
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(x => x.Complemento)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.CEP)
                .HasColumnType("char(8)")
                .IsRequired();
        }
    }
}
