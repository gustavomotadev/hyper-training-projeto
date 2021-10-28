using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Modulo_Financeiro.Modelo
{
    public class Pagamento
    {
        public int Id { get; private set; }
        public OrdemServico OS { get; private set; }
        public FormaPagamento FormasPagamento { get; private set; }
        public DateTime DataPagamento { get; private set; }

        private Pagamento(int id)
        {
            Id = id;
        }
        public static Pagamento NovoPagamento(int idPagamento, OrdemServico os, FormaPagamento formasPagamento,
         DateTime dataPagamento)
        {
            var novoPgt = new Pagamento(idPagamento);
            novoPgt.OS = os;
            novoPgt.FormasPagamento = formasPagamento;
            novoPgt.DataPagamento = dataPagamento;
            return novoPgt;
        }
    }
}
