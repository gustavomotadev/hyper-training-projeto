using System;
using System.Collections.Generic;
using System.Linq;

namespace TechBeauty.Dominio.Modelo
{
    public class Cliente : Pessoa
    {
        public List<OrdemServico> OrdensServicos { get; set; } = new List<OrdemServico>(); //EF

        private Cliente() { }

        private Cliente(string cpf, DateTime dataNascimento)
        {
            CPF = cpf;
            DataNascimento = dataNascimento;
        }
        public static Cliente NovoCliente(string nome, string cpf, DateTime dataNascimento, 
            List<Contato> contatos)
        {
            var cliente = new Cliente(cpf, dataNascimento);
            cliente.Nome = nome;
            cliente.Contatos = contatos;
            return cliente;
        }
    }
}
