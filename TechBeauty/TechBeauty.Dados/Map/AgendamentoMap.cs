using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dados.Map
{
    class AgendamentoMap : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable("Agendamento");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PessoaAtendida)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(x => x.DataHoraCriacao)
                .HasColumnType("smalldatetime")
                .IsRequired();

            builder.Property(x => x.DataHoraExecucao)
                .HasColumnType("smalldatetime")
                .IsRequired();

            builder.Property(x => x.StatusAgendamento)
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
