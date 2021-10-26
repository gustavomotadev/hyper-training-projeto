using System;
using System.Collections.Generic;
using System.Linq;

namespace TechBeauty.Dominio.Modelo
{
    public abstract class Pessoa
    {
        public int Id { get; protected init; }
        public string Nome { get; protected set; }
        public string CPF { get; protected init; }
        public DateTime DataNascimento { get; protected init; }
        public List<Contato> Contatos { get; protected set; }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }
        public void AdicionarContato(Contato contato)
        {
            Contatos.Add(contato);
        }

        public Contato SelecionarPorId(int id)
        {
            return Contatos.FirstOrDefault(x => x.Id == id);
        }

        public bool RemoverContato(int id)
        {
            if (Contatos.Count > 1)
            {
                return Contatos.Remove(SelecionarPorId(id));
            }
            else
            {
                return false;
            }
        }

        public bool RemoverContato(Contato contato)
        {
            if (Contatos.Count > 1)
            {
                return Contatos.Remove(contato);
            }
            else
            {
                return false;
            }
        }

        public bool AlterarUmContato(int idDoContatoAntigo, string novoValor)
        {
            var contatoAntigo = SelecionarPorId(idDoContatoAntigo);
            if (contatoAntigo is not null)
            {
                contatoAntigo.AlterarContato(novoValor);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AlterarUmContato(Contato contatoAntigo, string novoValor)
        {
            // SelecionarPorId aqui serve para verificar se esse contato é dessa pessoa mesmo
            var contatoAntigoPresente = SelecionarPorId(contatoAntigo.Id);
            if (contatoAntigoPresente is not null)
            {
                contatoAntigoPresente.AlterarContato(novoValor);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int ObterIdade()
        {
            var idade = DateTime.Today.Year - DataNascimento.Year;
            if (DataNascimento.Date.AddYears(idade) > DateTime.Today) return idade -= 1;
            else return idade;
        }

        public static int ObterIdade(DateTime dataNascimento)
        {
            var idade = DateTime.Today.Year - dataNascimento.Year;
            if (dataNascimento.Date.AddYears(idade) > DateTime.Today) return idade -= 1;
            else return idade;
        }
    }
}
