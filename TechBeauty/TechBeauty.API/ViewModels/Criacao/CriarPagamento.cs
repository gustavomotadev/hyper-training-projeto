using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.Interfaces;

namespace TechBeauty.API.ViewModels.Criacao
{
    public class CriarPagamento : IValidavel
    {
        [Required]
        public DateTime DataPagamento { get; set; }
        [Required]
        public int OrdemServicoId { get; set; }
        [Required]
        public int FormaPagamentoId { get; set; }
        [Required]
        public int CaixaDiarioId { get; set; }

        public bool Validar()
        {
            return true;
        }
    }
}
