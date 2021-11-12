using System;
using System.Text.Json.Serialization;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dominio.Financeiro
{
    public class Pagamento
    {
        public int Id { get; init; }
        public int OrdemServicoId { get; private set; } //ef
        public OrdemServico OrdemServico { get; init; }
        public int FormaPagamentoId { get; private set; } //ef
        public FormaPagamento FormaPagamento { get; init; }
        public int CaixaDiarioId { get; private set; } //ef
        [JsonIgnore]
        public CaixaDiario CaixaDiario { get; private set; } //ef
        public DateTime DataPagamento { get; init; }

        private Pagamento() { }

        private Pagamento(int caixaDiarioId, int ordemServicoId, int formasPagamentoId,
            DateTime dataPagamento)
        {
            CaixaDiarioId = caixaDiarioId;
            OrdemServicoId = ordemServicoId;
            FormaPagamentoId = formasPagamentoId;
            DataPagamento = dataPagamento;
        }

        public static Pagamento NovoPagamento(int caixaDiarioId, int ordemServicoId, 
            int formasPagamentoId, DateTime dataPagamento)
        {
            
                var novoPagamento = new Pagamento(caixaDiarioId, ordemServicoId, formasPagamentoId, dataPagamento);
                return novoPagamento;
        }
    }
}
