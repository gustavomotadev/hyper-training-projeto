using System;
using System.Collections.Generic;

namespace TechBeauty.Dominio.Modelo
{
    public abstract class Pessoa
    {
        public int Id { get; protected init; }
        public string Nome { get; protected set; }
        public string CPF { get; init; }
        public DateTime DataNascimento { get; init; }
        public List<Contato> Contatos { get; protected set; }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }


    }
}
