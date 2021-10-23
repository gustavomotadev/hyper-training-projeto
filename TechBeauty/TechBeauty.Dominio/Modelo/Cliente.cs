using System;
using System.Collections.Generic;

namespace TechBeauty.Dominio.Modelo
{
    public class Cliente : Pessoa
    {

        private Cliente(int id, string cpf, DateTime dataNascimento)
        {
            Id = id;
            CPF = cpf;
            DataNascimento = dataNascimento;
        }
        public static Cliente NovoCliente(int idCliente, string nome, string cpf, DateTime dataNascimento, 
            List<Contato> contatos)
        {
            var cliente = new Cliente(idCliente, cpf, dataNascimento);
            cliente.Nome = nome;
            cliente.Contatos = contatos;
            return cliente;
        }
    }
}
