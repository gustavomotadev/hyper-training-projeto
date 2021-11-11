using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBeauty.Dominio.Financeiro;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dados.Map
{
    public class OrdemServicoMap : IEntityTypeConfiguration<OrdemServico>
    {
        public void Configure(EntityTypeBuilder<OrdemServico> builder)
        {
            builder.ToTable("OrdemServico");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.StatusOS)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Data)
                .HasColumnType("date")
                .IsRequired();

            builder.HasMany<Agendamento>
                (os => os.Agendamentos)
                .WithOne(a => a.OrdemServico)
                .HasForeignKey(a => a.OrdemServicoId);

            builder.HasOne(x => x.Pagamento)
                .WithOne(os => os.OrdemServico)
                .HasForeignKey<Pagamento>(p => p.OrdemServicoId);

        }
    }
}
