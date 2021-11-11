using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.Interfaces;

namespace TechBeauty.API.ViewModels.Alteracao
{
    public class AlterarTurno : IValidavel
    {
        public DateTime? RegistroEntrada { get; set; }
        
        public DateTime? RegistroSaida { get; set; }

        public bool Validar()
        {
            return (RegistroEntrada is not null &&
                RegistroSaida is not null &&
                RegistroEntrada.Value.Date == RegistroSaida.Value.Date &&
                RegistroEntrada < RegistroSaida);
        }
    }
}
