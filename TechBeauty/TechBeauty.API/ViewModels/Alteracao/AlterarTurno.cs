using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.Interfaces;

namespace TechBeauty.API.ViewModels.Alteracao
{
    public class AlterarTurno : IValidavel
    {
        [Required]
        public DateTime RegistroEntrada { get; set; }
        [Required]
        public DateTime RegistroSaida { get; set; }

        public bool Validar()
        {
            return (RegistroEntrada.Date == RegistroSaida.Date &&
                RegistroEntrada < RegistroSaida);
        }
    }
}
