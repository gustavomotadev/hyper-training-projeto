using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dados.Map
{
    class CargoContratoTrabalhoMap : IEntityTypeConfiguration<CargoContratoTrabalho>
    {
        public void Configure(EntityTypeBuilder<CargoContratoTrabalho> builder)
        {
            builder.ToTable("Cargo_ContratoTrabalho");

            builder.HasKey(x => new { x.CargoId, x.ContratoTrabalhoId });

            builder.HasOne(c => c.Cargo)
                .WithMany(cct => cct.CargosContratosTrabalho)
                .HasForeignKey(c => c.CargoId);

            builder.HasOne(ct => ct.ContratoTrabalho)
                .WithMany(cct => cct.CargosContratosTrabalho)
                .HasForeignKey(ct => ct.ContratoTrabalhoId);

            builder.Property(x => x.Id)
                .UseIdentityColumn();
        }
    }
}
