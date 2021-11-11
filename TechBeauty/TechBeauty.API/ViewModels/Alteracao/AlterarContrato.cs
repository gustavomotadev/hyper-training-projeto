using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechBeauty.API.ViewModels.Alteracao
{
    public class AlterarContrato
    {
        public DateTime? DataDesligamento { get; set; }
        public bool? Vigente { get; set; }

        public bool ValidarDataDesligamento()
        {
            return (DataDesligamento is not null);
        }

        public bool ValidarVigente()
        {
            return (Vigente is not null);
        }
    }
}
