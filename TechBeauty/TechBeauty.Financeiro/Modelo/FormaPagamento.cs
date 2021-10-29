using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBeauty.Financeiro.Modelo
{
    public class FormaPagamento
    {
        public int Id { get; private set; }
        public string Tipo { get; private set; }


        private FormaPagamento(int id)
        {
            Id = id;
        }

        public static FormaPagamento NovaFormaPagamento(int idFormaPagamento, string tipo)
        {
            if (! String.IsNullOrWhiteSpace(tipo))
            {
                var formaPagamento = new FormaPagamento(idFormaPagamento);
                formaPagamento.Tipo = tipo;
                return formaPagamento;
            }
            else
            {
                return null;
            }
        }

    }
}
