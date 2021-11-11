using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.Interfaces;

namespace TechBeauty.API.ViewModels
{
    public class CriarTipoContato : IValidavel
    {
        [Required]
        public string Valor { get; set; }

        public bool Validar()
        {
            return !String.IsNullOrWhiteSpace(Valor);
        }
    }
}
