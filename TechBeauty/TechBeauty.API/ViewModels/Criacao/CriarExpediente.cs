using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.Interfaces;

namespace TechBeauty.API.ViewModels.Criacao
{
    public class CriarExpediente :IValidavel
    {
        [Required]
        public DateTime DataHoraAbertura { get; set; }
        [Required]
        public DateTime DataHoraFechamento { get; set; }

        public bool Validar()
        {
            return (DataHoraAbertura.Date == DataHoraFechamento.Date &&
                DataHoraAbertura < DataHoraFechamento);
        }
    }
}
