using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechBeauty.API.ViewModels
{
    public class CriarCliente
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public List<CriarContato> Contatos { get; set; } //TODO: viewmodel aninhado ?
    }
}
