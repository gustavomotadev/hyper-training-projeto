using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBeauty.Dominio.Financeiro;

namespace TechBeauty.Dados.Map
{
    public class RemuneracaoDiariaServicoMap : IEntityTypeConfiguration<RemuneracaoDiariaServico>
    {
        public void Configure(EntityTypeBuilder<RemuneracaoDiariaServico> builder)
        {
            builder.ToTable("RemuneracaoDiaria_Servico");

            builder.HasKey(x => new { x.RemuneracaoDiariaId, x.ServicoId });

            builder.HasOne(rds => rds.RemuneracaoDiaria)
                .WithMany(r => r.RemuneracoesServicos)
                .HasForeignKey(rds => rds.RemuneracaoDiariaId);

            builder.HasOne(rds => rds.Servico)
                .WithMany(s => s.RemuneracoesServicos)
                .HasForeignKey(rds => rds.ServicoId);

            builder.Property(x => x.Id)
                .UseIdentityColumn();
        }
    }
}
