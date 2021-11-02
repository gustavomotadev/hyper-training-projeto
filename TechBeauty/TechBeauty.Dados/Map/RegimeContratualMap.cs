using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dados.Map
{
    class RegimeContratualMap : IEntityTypeConfiguration<RegimeContratual>
    {
        public void Configure(EntityTypeBuilder<RegimeContratual> builder)
        {
            builder.ToTable("RegimeContratual");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Valor)
                .HasColumnType("varchar(20)")
                .IsRequired();
            builder.HasMany<ContratoTrabalho>
                (r => r.ContratosDeTrabalho)
                .WithOne(c => c.RegimeContratual)
                .HasForeignKey(c => c.RegimeContratualId);
        }
    }
}
