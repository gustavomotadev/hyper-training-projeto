using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dados.Map
{
    class GeneroMap : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.ToTable("Genero");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Valor)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.HasMany<Colaborador>
                (g => g.Colaboradores)
                .WithOne(c => c.Genero)
                .HasForeignKey(c => c.GeneroId);
        }
    }
}
