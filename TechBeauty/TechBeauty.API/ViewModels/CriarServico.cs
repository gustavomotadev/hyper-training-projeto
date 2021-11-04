using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechBeauty.API.ViewModels
{
    public class CriarServico
    {
        [Required]
        public string Nome { get;  set; }
        [Required]
        public decimal Preco { get;  set; }
        [Required]
        public string Descricao { get;  set; }
        [Required]
        public int DuracaoEmMin { get;  set; }
    }
}
