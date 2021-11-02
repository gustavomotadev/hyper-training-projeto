using System;
using System.Collections.Generic;

namespace TechBeauty.Dominio.Financeiro
{
    public class FormaPagamento
    {
        public int Id { get; init; }
        public string Valor { get; init; }
        public List<Pagamento> Pagamentos { get; set; } //ef

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
