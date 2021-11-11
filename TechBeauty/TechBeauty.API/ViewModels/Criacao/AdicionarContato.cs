using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.Interfaces;

namespace TechBeauty.API.ViewModels.Criacao
{
    public class AdicionarContato : IValidavel
    {
        //[Required]
        //public int PessoaId { get; set; }
        [Required]
        public int TipoContatoId { get; set; }
        [Required]
        public string Contato { get; set; }

        public bool Validar()
        {
            return (!String.IsNullOrWhiteSpace(Contato));
        }
    }
}
