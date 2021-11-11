using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.Interfaces;

namespace TechBeauty.API.ViewModels
{
    public class CriarServico :IValidavel
    {
        [Required]
        public string Nome { get;  set; }
        [Required]
        public decimal Preco { get;  set; }
        [Required]
        public string Descricao { get;  set; }
        [Required]
        public int DuracaoEmMin { get;  set; }

        public bool Validar()
        {
            return (!String.IsNullOrWhiteSpace(Nome) &&
                 Preco > 0M &&
                 !String.IsNullOrWhiteSpace(Descricao) &&
                 DuracaoEmMin > 0);
        }
    }
}
