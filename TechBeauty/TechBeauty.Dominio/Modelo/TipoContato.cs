using System;
using System.Collections.Generic;

namespace TechBeauty.Dominio.Modelo
{
    public class TipoContato
    {
        public int Id { get; init; }
        public string Valor { get; init; }
        public List<Contato> Contatos { get; set; } //ef

        private TipoContato() { }

        private TipoContato(string valor)
        {
            Valor = valor;
        }

        public static TipoContato NovoTipoContato(string valor)
        {
            if (!String.IsNullOrWhiteSpace(valor))
            {
                return new TipoContato(valor);
            }
            else
            {
                return null;
            }
        }
    }
}
