using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.Interfaces;

namespace TechBeauty.API.ViewModels.Alteracao
{
    public class AlterarTurno : IValidavel
    {
        public DateTime DataHoraEntrada { get; set; }
        
        public DateTime DataHoraSaida { get; set; }

        public bool Validar()
        {
            return (DataHoraEntrada.Date == DataHoraSaida.Date &&
                DataHoraEntrada < DataHoraSaida);
        }
    }
}
