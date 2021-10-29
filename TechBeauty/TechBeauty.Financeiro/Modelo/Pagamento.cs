using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Financeiro.Modelo
{
    public class Pagamento
    {
        public int Id { get; init; }
        public OrdemServico OrdemServico { get; init; }
        public FormaPagamento FormaPagamento { get; init; }
        public DateTime DataPagamento { get; init; }

        private Pagamento(int id, OrdemServico ordemServico, FormaPagamento formasPagamento,
            DateTime dataPagamento)
        {
            Id = id;
            OrdemServico = ordemServico;
            FormaPagamento = formasPagamento;
            DataPagamento = dataPagamento;
        }

        public static Pagamento NovoPagamento(int idPagamento, OrdemServico ordemServico, 
            FormaPagamento formaPagamento, DateTime dataPagamento)
        {
            if (ordemServico != null &&
                formaPagamento != null)
            {
                var novoPagamento = new Pagamento(idPagamento, ordemServico, formaPagamento, dataPagamento);
                return novoPagamento;
            }
            else
            {
                return null;
            }
        }
    }
}
