using System;
using System.Collections.Generic;

namespace TechBeauty.Dominio.Financeiro
{
    public class FormaPagamento
    {
        public int Id { get; init; }
        public string Valor { get; init; }
        public List<Pagamento> Pagamentos { get; private set; } //ef

        private FormaPagamento() { }

        private FormaPagamento(string valor)
        {
            Valor = valor;
        }

        public static FormaPagamento NovaFormaPagamento(string valor)
        {
                var formaPagamento = new FormaPagamento(valor);
                return formaPagamento;
        }
        //TO DO - AlterarFormaPagamento();
    }
}
