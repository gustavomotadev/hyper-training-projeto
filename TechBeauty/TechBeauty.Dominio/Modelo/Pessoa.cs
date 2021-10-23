using System;
using System.Collections.Generic;

namespace TechBeauty.Dominio.Modelo
{
    public abstract class Pessoa
    {
        public int Id { get; protected init; }
        public string Nome { get; protected set; }
        public string CPF { get; protected set; }
        public DateTime DataNascimento { get; protected set; }
        public List<Contato> Contatos { get; protected set; }

        public void Alterar(string nome, string cpf, 
            DateTime dataNascimento, List<Contato> contatos)
        {
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
            Contatos = contatos;

        }
    }
}
