using System;

namespace TechBeauty.Dominio.Modelo
{
    public class Contato
    {
        public int Id { get; init; }
        public int TipoContatoId { get; set; } //ef
        public TipoContato TipoContato { get; init; }
        public string Valor { get; private set; }
        public int PessoaId { get; set; } //ef
        public Pessoa Pessoa { get; set; } //ef

        private Contato() { }

        private Contato(int tipoContatoId)
        {
            TipoContatoId = tipoContatoId;
        }

        public static Contato NovoContato(int tipoContatoId, string valor, int pessoaId)
        {
            var contato = new Contato(tipoContatoId);
            contato.Valor = valor;
            contato.PessoaId = pessoaId;
            return contato;
        }

        public bool AlterarContato(string novoValor)
        {
            if (!String.IsNullOrWhiteSpace(novoValor))
            {
                Valor = novoValor;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
