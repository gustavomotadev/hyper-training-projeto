using System;
using System.Collections.Generic;
using System.Linq;

namespace TechBeauty.Dominio.Modelo
{
    public class Cliente : Pessoa
    {
        public List<OrdemServico> OrdensServicos { get; set; } //EF

        private Cliente() { }

        private Cliente(int id, string cpf, DateTime dataNascimento)
        {
            Id = id;
            CPF = cpf;
            DataNascimento = dataNascimento;
        }
        public static Cliente NovoCliente(int idCliente, string nome, string cpf, DateTime dataNascimento, 
            List<Contato> contatos)
        {
            if (!String.IsNullOrWhiteSpace(nome) &&
                !String.IsNullOrWhiteSpace(cpf) &&
                Pessoa.ObterIdade(dataNascimento) >= 18 &&
                Pessoa.ObterIdade(dataNascimento) <= 100 &&
                contatos != null && 
                contatos.Count > 0 && 
                !contatos.Any(x => x == null))
            {
                var cliente = new Cliente(idCliente, cpf, dataNascimento);
                cliente.Nome = nome;
                cliente.Contatos = contatos;
                return cliente;

            } else
            {
                return null;
            }
            
        }
    }
}
