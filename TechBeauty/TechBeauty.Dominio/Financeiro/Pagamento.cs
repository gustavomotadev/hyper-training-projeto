using System;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dominio.Financeiro
{
    public class Pagamento
    {
        public int Id { get; init; }
        public int OrdemServicoId { get; set; } //ef
        public OrdemServico OrdemServico { get; init; }
        public int FormaPagamentoId { get; set; } //ef
        public FormaPagamento FormaPagamento { get; init; }
        public int CaixaDiarioId { get; set; } //ef
        public CaixaDiario CaixaDiario { get; set; } //ef
        public DateTime DataPagamento { get; init; }

        private Pagamento() { }

        private Pagamento(CaixaDiario caixaDiario, OrdemServico ordemServico, FormaPagamento formasPagamento,
            DateTime dataPagamento)
        {
            CaixaDiario = caixaDiario;
            OrdemServico = ordemServico;
            FormaPagamento = formasPagamento;
            DataPagamento = dataPagamento;
        }

        public static Pagamento NovoPagamento(CaixaDiario caixaDiario, OrdemServico ordemServico, 
            FormaPagamento formaPagamento, DateTime dataPagamento)
        {
            if (ordemServico != null &&
                formaPagamento != null &&
                caixaDiario != null)
            {
                var novoPagamento = new Pagamento(caixaDiario, ordemServico, formaPagamento, dataPagamento);
                return novoPagamento;
            }
            else
            {
                return null;
            }
        }
    }
}
