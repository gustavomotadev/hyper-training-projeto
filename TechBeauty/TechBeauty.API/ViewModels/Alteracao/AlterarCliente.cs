using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.Interfaces;

namespace TechBeauty.API.ViewModels.Alteracao
{
    public class AlterarCliente : IValidavel
    {
        [Required]
        public string Nome { get; set; }

        public bool Validar()
        {
            return (!String.IsNullOrWhiteSpace(Nome));
        }
    }
}
