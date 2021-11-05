using System;
using System.Collections.Generic;
using System.Linq;

namespace TechBeauty.Dominio.Financeiro
{
    public class CaixaDiario
    {
        public static decimal CustoFixoPadrao { get; private set; } = 90.00M;
        public static decimal PercentualEncargos { get; private set; } = 55.06M;
        public static decimal PercentualSimplesNacional { get; private set; } = 0.06M;
        public int Id { get; init; }
        public List<Pagamento> Pagamentos { get; private set; } = new List<Pagamento>();
        public List<RemuneracaoDiaria> Remuneracoes { get; private set; } = new List<RemuneracaoDiaria>();
        public DateTime Data { get; init; }
        public decimal TotalSalario { get; private set; } = 0;
        public decimal TotalComissao { get; private set; } = 0;
        public decimal TotalHoraExtra { get; private set; } = 0;
        public decimal CustoFixo { get; private set; }
        public decimal EncargosTrabalhistas { get; private set; } = 0;
        public decimal SimplesNacional { get; private set; } = 0;
        public decimal ReceitaBruta { get; private set; } = 0;
        public decimal ReceitaLiquida { get; private set; } = 0;

        private CaixaDiario() { }

        private CaixaDiario(DateTime data, decimal? custoFixo)
        {
            Data = data;
            if (custoFixo is not null)
            {
                CustoFixo = (decimal) custoFixo;
            }
            else
            {
                CustoFixo = CustoFixoPadrao;
            }

            ReceitaLiquida -= CustoFixo;
        }

        public static CaixaDiario NovoCaixaDiario(DateTime data, decimal? custoFixo)
        {
            if (custoFixo == null ||
                custoFixo >= 0)
            {
                return new CaixaDiario(data, custoFixo);
            }
            else
            {
                return null;
            }
        }

        public bool AdicionarPagamento(Pagamento pagamento)
        {
            if (pagamento is not null)
            {
                Pagamentos.Add(pagamento);
                decimal simples = PercentualSimplesNacional * pagamento.OrdemServico.PrecoTotal;
                ReceitaBruta += pagamento.OrdemServico.PrecoTotal;
                SimplesNacional += simples;
                ReceitaLiquida += pagamento.OrdemServico.PrecoTotal - simples;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AdicionarRemuneracao(RemuneracaoDiaria remuneracao)
        {
            if (remuneracao is not null)
            {
                Remuneracoes.Add(remuneracao);
                var encargos = PercentualEncargos * remuneracao.ValorSalario;
                TotalSalario += remuneracao.ValorSalario;
                TotalComissao += remuneracao.ValorComissao;
                TotalHoraExtra += remuneracao.ValorHoraExtra;
                EncargosTrabalhistas += encargos;
                ReceitaLiquida += -remuneracao.ValorSalario - remuneracao.ValorComissao - remuneracao.ValorHoraExtra - encargos;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CalcularTudo()
        {
            CalcularTotalSalario();
            CalcularTotalComissao();
            CalcularTotalHoraExtra();
            CalcularEncargosTrabalhistas();
            CalcularSimplesNacional();
            CalcularReceitaBruta();
            CalcularReceitaLiquida();
        }

        private void CalcularTotalSalario()
        {
            TotalSalario = Remuneracoes.Sum(x => x.ValorSalario);
        }

        private void CalcularTotalComissao()
        {
            TotalComissao = Remuneracoes.Sum(x => x.ValorComissao);
        }

        private void CalcularTotalHoraExtra()
        {
            TotalHoraExtra = Remuneracoes.Sum(x => x.ValorHoraExtra);
        }

        private void CalcularEncargosTrabalhistas()
        {
            EncargosTrabalhistas = PercentualEncargos * TotalSalario;
        }

        private void CalcularSimplesNacional()
        {
            SimplesNacional = PercentualSimplesNacional * ReceitaBruta;
        }

        private void CalcularReceitaBruta()
        {
            ReceitaBruta = Pagamentos.Sum(x => x.OrdemServico.PrecoTotal);
        }

        private void CalcularReceitaLiquida()
        {
            ReceitaLiquida = ReceitaBruta - TotalSalario - TotalComissao - TotalHoraExtra - CustoFixo - EncargosTrabalhistas - SimplesNacional;
        }
    }
}
