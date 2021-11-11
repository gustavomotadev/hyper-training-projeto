using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.Interfaces;

namespace TechBeauty.API.ViewModels.Alteracao
{
    public class AlterarCaixaDiario : IValidavel
    {
      
        public DateTime Data { get; set; }

        public decimal? CustoFixo { get; set; }

        public bool Validar()
        {
            return (CustoFixo == null ||
                CustoFixo >= 0);
        }
    }
}
