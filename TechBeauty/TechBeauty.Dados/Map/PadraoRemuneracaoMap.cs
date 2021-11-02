using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBeauty.Dominio.Financeiro;

namespace TechBeauty.Dados.Map
{
    class PadraoRemuneracaoMap : IEntityTypeConfiguration<PadraoRemuneracao>
    {
        public void Configure(EntityTypeBuilder<PadraoRemuneracao> builder)
        {
            builder.ToTable("PadraoRemuneracao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.JornadaEsperada)
                .HasColumnType("time")
                .IsRequired();

            builder.Property(x => x.SalarioHora)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(x => x.PercentualComissao)
                .HasColumnType("decimal(2,2)")
                .IsRequired();

            builder.Property(x => x.AdicionalHoraExtra)
                .HasColumnType("decimal(2,2)")
                .IsRequired();
        }
    }
}
