using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBeauty.Financeiro.Modelo
{
    public class FormaPagamento
    {
        public int Id { get; init; }
        public string Valor { get; init; }


        private FormaPagamento(int id, string valor)
        {
            Id = id;
            Valor = valor;
        }

        public static FormaPagamento NovaFormaPagamento(int idFormaPagamento, string valor)
        {
            if (! String.IsNullOrWhiteSpace(valor))
            {
                var formaPagamento = new FormaPagamento(idFormaPagamento, valor);
                return formaPagamento;
            }
            else
            {
                return null;
            }
        }

    }
}
