using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechBeauty.API.ViewModels
{
    public class CriarRemuneracaoDiaria
    {
        [Required]
        public int ColaboradorId { get; set; }
        [Required]
        public int CaixaDiarioId { get; set; }
        [Required]
        public TimeSpan HorasTrabalhadas { get; set; }
        [Required]
        public List<int> ServicosRealizados { get; set; }

    }
}
