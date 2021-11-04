using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechBeauty.API.ViewModels
{
    public class CriarPagamento
    {
        [Required]
        public DateTime DataPagamento { get; set; }
        [Required]
        public int OrdemServicoId { get; set; }
        [Required]
        public int FormaPagamentoId { get; set; }
        [Required]
        public int CaixaDiarioId { get; set; }
        
    }
}
