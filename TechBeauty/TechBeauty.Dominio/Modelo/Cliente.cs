using System;
using System.Collections.Generic;

namespace TechBeauty.Dominio.Modelo
{
    public class Cliente : Pessoa
    {

        public Cliente(int id)
        {
            Id = id;
        }
        public static Cliente Criar(int idCliente, string nome, string cpf, DateTime dataNascimento, 
            List<Contato> contatos)
        {
            var cliente = new Cliente(idCliente);
            cliente.Nome = nome;
            cliente.CPF = cpf;
            cliente.DataNascimento = dataNascimento;
            cliente.Contatos = contatos;
            return cliente;
        }
    }
}
