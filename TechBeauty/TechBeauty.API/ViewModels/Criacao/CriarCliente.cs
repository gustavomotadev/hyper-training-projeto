using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechBeauty.API.Interfaces;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.API.ViewModels
{
    public class CriarCliente : IValidavel
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
        public int? TipoContato2Id { get; set; }
        public string Contato2 { get; set; }
        public int? TipoContato3Id { get; set; }
        public string Contato3 { get; set; }

        public bool Validar()
        {
            //TODO validacao de CPF
            return (!String.IsNullOrWhiteSpace(Nome) &&
                !String.IsNullOrWhiteSpace(CPF) &&
                Pessoa.ObterIdade(DataNascimento) >= 18 &&
                Pessoa.ObterIdade(DataNascimento) <= 100 &&
                ((TipoContato2Id is null && Contato2 is null) || (TipoContato2Id is not null && Contato2 is not null)) &&
                ((TipoContato3Id is null && Contato3 is null) || (TipoContato3Id is not null && Contato3 is not null)));
        }
    }
}
