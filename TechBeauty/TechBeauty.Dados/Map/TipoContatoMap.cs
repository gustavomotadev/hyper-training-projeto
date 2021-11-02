using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dados.Map
{
    class TipoContatoMap : IEntityTypeConfiguration<TipoContato>
    {
        public void Configure(EntityTypeBuilder<TipoContato> builder)
        {
            builder.ToTable("TipoContato");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Valor)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.HasMany<Contato>
                (tc => tc.Contatos)
                .WithOne(c => c.TipoContato)
                .HasForeignKey(c => c.TipoContatoId);
        }
    }
}
