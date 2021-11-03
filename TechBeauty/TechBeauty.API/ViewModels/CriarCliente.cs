using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechBeauty.API.ViewModels
{
    public class CriarCliente
    {
        //Dados de Pessoa
        [Required]
        public string Nome { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }

        //Contato obrigatório
        [Required]
        public int TipoContato1Id { get; set; }
        [Required]
        public string Contato1 { get; set; }

        //Contatos opcionais
        public int TipoContato2Id { get; set; }
        public string Contato2 { get; set; }
        public int TipoContato3Id { get; set; }
        public string Contato3 { get; set; }
    }
}
