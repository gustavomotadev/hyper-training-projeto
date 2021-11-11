using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.Interfaces;
using TechBeauty.Dominio.Financeiro;

namespace TechBeauty.API.ViewModels.Criacao
{
    public class CriarRemuneracaoDiaria : IValidavel
    {
        [Required]
        public int ColaboradorId { get; set; }
        [Required]
        public int CaixaDiarioId { get; set; }
        [Required]
        public CriarTimeSpan HorasTrabalhadas { get; set; }
        [Required]
        public List<int> ServicosRealizadosId { get; set; }

        public bool Validar()
        {
            return (new TimeSpan(HorasTrabalhadas.horas, HorasTrabalhadas.minutos, 0) 
                <= PadraoRemuneracao.JornadaMaxima);
        }
    }
}
