using System;
using System.Collections.Generic;

namespace TechBeauty.Dominio.Modelo
{
    public class Cliente : Pessoa
    {
        public static Cliente Criar(int id, string nome, string cpf, DateTime dataNascimento, 
            List<Contato> contatos)
        {
            var cliente = new Cliente();
            cliente.Id = id;
            cliente.Nome = nome;
            cliente.CPF = cpf;
            cliente.DataNascimento = dataNascimento;
            cliente.Contatos = contatos;
            return cliente;
        }
    }
}
