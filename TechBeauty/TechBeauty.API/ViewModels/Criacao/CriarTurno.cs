using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.Interfaces;

namespace TechBeauty.API.ViewModels.Criacao
{
    public class CriarTurno : IValidavel
    {
        [Required]
        public int ExpedienteId { get; set; }
        [Required]
        public int ColaboradorId { get; set; }
        [Required]
        public DateTime DataHoraEntrada { get; set; }
        [Required]
        public DateTime DataHoraSaida { get; set; }

        public bool Validar()
        {
            return (DataHoraEntrada.Date == DataHoraSaida.Date &&
                DataHoraEntrada < DataHoraSaida);
        }
    }
}
