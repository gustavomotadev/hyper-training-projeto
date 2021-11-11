using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.Interfaces;
using TechBeauty.Dominio.Modelo.Enumeracoes;

namespace TechBeauty.API.ViewModels.Alteracao
{
    public class AlterarAgendamento : IValidavel
    {
        [Required]
        public int StatusAgendamento { get; set; }

        public bool Validar()
        {
            return (Enum.IsDefined(typeof(StatusAgendamento), StatusAgendamento));
        }
    }
}
