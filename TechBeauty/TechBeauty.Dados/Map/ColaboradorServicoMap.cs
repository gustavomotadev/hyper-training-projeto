using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dados.Map
{
    class ColaboradorServicoMap : IEntityTypeConfiguration<ColaboradorServico>
    {
        public void Configure(EntityTypeBuilder<ColaboradorServico> builder)
        {
            builder.ToTable("Colaborador_Servico");

            builder.HasKey(x => new { x.ColaboradorId, x.ServicoId });

            builder.HasOne(cs => cs.Colaborador)
                .WithMany(s => s.ColaboradoresServicos)
                .HasForeignKey(cs => cs.ColaboradorId);

            builder.HasOne(cs => cs.Servico)
                .WithMany(c => c.ColaboradoresServicos)
                .HasForeignKey(cs => cs.ServicoId);

            builder.Property(x => x.Id)
                .UseIdentityColumn();
        }
    }
}
