using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TechBeauty.Financeiro.Modelo;

namespace TechBeauty.Dados.Map
{
    class FormaPagamentoMap : IEntityTypeConfiguration<FormaPagamento>
    {
        public void Configure(EntityTypeBuilder<FormaPagamento> builder)
        {
            builder.ToTable("FormaPagamento");

            builder.HasKey(x => x.Id);

            builder.HasMany<Pagamento>
                (fp => fp.Pagamentos)
                .WithOne(p => p.FormaPagamento)
                .HasForeignKey(p => p.FormaPagamentoId);

            builder.Property(x => x.Valor)
                .HasColumnType("varchar(30)")
                .IsRequired();
        }
    }
}
