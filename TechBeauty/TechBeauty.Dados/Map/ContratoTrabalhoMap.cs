using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dados.Map
{
    public class ContratoTrabalhoMap : IEntityTypeConfiguration<ContratoTrabalho>
    {
        public void Configure(EntityTypeBuilder<ContratoTrabalho> builder)
        {
            builder.ToTable("ContratoTrabalho");
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataEntrada)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(x => x.DataDesligamento)
                .HasColumnType("date");

            builder.Property(x => x.CNPJ_CTPS)
                .HasColumnType("varchar(14)")
                .IsRequired();

            builder.HasMany<Cargo>
                (ct => ct.Cargos)
                .WithMany(c => c.Contratos);

        }
    }
}
