using System;
using System.Collections.Generic;

namespace TechBeauty.Dominio.Financeiro
{
    public class FormaPagamento
    {
        public int Id { get; init; } = 0;
        public string Valor { get; init; }
        public List<Pagamento> Pagamentos { get; set; } //ef

        private FormaPagamento() { }

        private FormaPagamento(string valor)
        {
            Valor = valor;
        }

        public static FormaPagamento NovaFormaPagamento(string valor)
        {
            if (! String.IsNullOrWhiteSpace(valor))
            {
                var formaPagamento = new FormaPagamento(valor);
                return formaPagamento;
            }
            else
            {
                return null;
            }
        }

    }
}
