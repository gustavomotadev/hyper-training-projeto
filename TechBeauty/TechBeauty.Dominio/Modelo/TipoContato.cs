using System;

namespace TechBeauty.Dominio.Modelo
{
    public class TipoContato
    {
        public int Id { get; init; }
        public string Valor { get; init; }

        private TipoContato(int id, string valor)
        {
            Id = id;
            Valor = valor;
        }

        public static TipoContato NovoTipoContato(int idTipoContato, string valor)
        {
            if (!String.IsNullOrWhiteSpace(valor))
            {
                return new TipoContato(idTipoContato, valor);
            }
            else
            {
                return null;
            }
        }
    }
}
