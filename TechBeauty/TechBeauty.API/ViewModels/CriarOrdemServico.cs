using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechBeauty.API.ViewModels
{
    public class CriarOrdemServico
    {
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public List<int> Agendamentos { get; set; }
    }
}
