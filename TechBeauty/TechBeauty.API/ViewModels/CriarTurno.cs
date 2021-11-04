using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechBeauty.API.ViewModels
{
    public class CriarTurno
    {
        [Required]
        public int ExpedienteId { get; set; }
        [Required]
        public int ColaboradorId { get; set; }
        [Required]
        public DateTime DataHoraEntrada { get; set; }
        [Required]
        public DateTime DataHoraSaida { get; set; } 
       
    }
}
