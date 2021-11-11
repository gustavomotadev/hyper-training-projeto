using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.Interfaces;

namespace TechBeauty.API.ViewModels.Alteracao
{
    public class AlterarRegimeContratual : IValidavel
    {
        public string Valor { get; set; }

        public bool Validar()
        {
            return (!String.IsNullOrWhiteSpace(Valor));
        }
    }
}
