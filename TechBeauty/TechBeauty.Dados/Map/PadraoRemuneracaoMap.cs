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

            //TODO
        }
    }
}
