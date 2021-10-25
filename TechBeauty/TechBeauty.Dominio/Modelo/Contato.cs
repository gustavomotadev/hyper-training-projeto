using System;

namespace TechBeauty.Dominio.Modelo
{
    public class Contato
    {
        public int Id { get; init; }
        public TipoContato Tipo { get; init; }
        public string Valor { get; private set; }

        private Contato(int id, TipoContato tipo)
        {
            Id = id;
            Tipo = tipo;
        }

        public static Contato NovoContato(int idContato, TipoContato tipo, string valor)
        {
            if (tipo != null &&
                valor != null &&
                !String.IsNullOrWhiteSpace(valor))
            {
                var contato = new Contato(idContato, tipo);
                contato.Valor = valor;
                return contato;
            }
            else
            {
                return null;
            }
        }

        public bool AlterarContato(string novoValor)
        {
            if (novoValor != null &&
                !String.IsNullOrWhiteSpace(novoValor))
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
