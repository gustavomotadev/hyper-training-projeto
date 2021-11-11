using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechBeauty.API.Interfaces;
using TechBeauty.Dominio.Modelo.Enumeracoes;

namespace TechBeauty.API.ViewModels.Alteracao
{
    public class AlterarEndereco : IValidavel
    {
        [Required]
        public string Logradouro { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public int UF { get; set; }
        [Required]
        public string Numero { get; set; } = "s/n";
        [Required]
        public string Complemento { get; set; } = "";
        [Required]
        public string CEP { get; set; }

        public bool Validar()
        {
            if (!String.IsNullOrWhiteSpace(Logradouro) &&
                    !String.IsNullOrWhiteSpace(Bairro) &&
                    !String.IsNullOrWhiteSpace(Cidade) &&
                    !String.IsNullOrWhiteSpace(CEP) &&
                    ValidarCEP() &&
                    Enum.IsDefined(typeof(UnidadeFederativa), UF))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidarCEP()
        {
            return Regex.IsMatch(CEP, @"^\d{8}$");
        }
    }
}
