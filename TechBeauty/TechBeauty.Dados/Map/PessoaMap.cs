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
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.CPF)
                .HasColumnType("char(11)")
                .IsRequired();

            builder.Property(x => x.DataNascimento)
                .HasColumnType("date")
                .IsRequired();

            builder.HasMany<Contato>
                (p => p.Contatos)
                .WithOne(c => c.Pessoa)
                .HasForeignKey(c => c.PessoaId);
        }
    }
}
