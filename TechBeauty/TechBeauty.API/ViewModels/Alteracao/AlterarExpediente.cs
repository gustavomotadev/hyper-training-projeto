using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.Interfaces;

namespace TechBeauty.API.ViewModels.Alteracao
{
    public class AlterarExpediente : IValidavel
    {
        
        public DateTime DataHoraAbertura { get; set; }
        
        public DateTime DataHoraFechamento { get; set; }

        public bool Validar()
        {
            return (DataHoraAbertura.Date == DataHoraFechamento.Date &&
                DataHoraAbertura < DataHoraFechamento);
        }
    }
}
