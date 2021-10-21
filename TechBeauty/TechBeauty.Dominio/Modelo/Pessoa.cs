using System;
using System.Collections.Generic;

namespace TechBeauty.Dominio.Modelo
{
    public abstract class Pessoa
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public List<Contato> Contatos { get; private set; }
    }
}
