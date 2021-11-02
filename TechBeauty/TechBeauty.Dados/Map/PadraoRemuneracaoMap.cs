using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBeauty.Financeiro.Modelo;

namespace TechBeauty.Dados.Map
{
    class PadraoRemuneracaoMap : IEntityTypeConfiguration<PadraoRemuneracao>
    {
        public void Configure(EntityTypeBuilder<PadraoRemuneracao> builder)
        {
            builder.ToTable("PadraoRemuneracao");

            builder.HasKey(x => x.Id);

            builder.HasOne()
        }
    }
}
