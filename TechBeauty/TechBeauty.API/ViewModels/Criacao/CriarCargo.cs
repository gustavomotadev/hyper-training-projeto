using System;
using System.ComponentModel.DataAnnotations;
using TechBeauty.API.Interfaces;

namespace TechBeauty.API.ViewModels
{
    public class CriarCargo : IValidavel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }

        public bool Validar()
        {
            return (!String.IsNullOrWhiteSpace(Nome) && !String.IsNullOrWhiteSpace(Descricao));
        }
    }
}
