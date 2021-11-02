using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBeauty.Financeiro.Modelo
{
    class CaixaDiario
    {
        public static decimal CustoFixoPadrao { get; private set; } = 90.00M;
        public static decimal PercentualEncargos { get; private set; } = 55.06M;
        public static decimal PercentualSimplesNacional { get; private set; } = 0.06M;
        public DateTime Data { get; init; }
        public List<Pagamento> Pagamentos { get; init; }
        public List<RemuneracaoDiaria> Remuneracoes { get; init; }
        public decimal TotalSalario { get; init; }
        public decimal TotalComissao { get; init; }
        public decimal TotalHoraExtra { get; init; }
        public decimal CustoFixo { get; init; }
        public decimal EncargosTrabalhistas { get; init; }
        public decimal SimplesNacional { get; init; }
        public decimal ReceitaBruta { get; init; }
        public decimal ReceitaLiquida { get; init; }

        private CaixaDiario(DateTime data, List<Pagamento> pagamentos, List<RemuneracaoDiaria> remuneracoes, decimal custoFixo)
        {
            Data = data;
            Pagamentos = pagamentos;
            Remuneracoes = remuneracoes;
            CustoFixo = custoFixo;

            TotalSalario = CalcularTotalSalario();
            TotalComissao = CalcularTotalComissao();
            TotalHoraExtra = CalcularTotalHoraExtra();
            EncargosTrabalhistas = CalcularEncargosTrabalhistas();
            SimplesNacional = CalcularSimplesNacional();
            ReceitaBruta = CalcularReceitaBruta();
            ReceitaLiquida = CalcularReceitaLiquida();
        }

        public CaixaDiario NovoCaixaDiario(DateTime data, List<Pagamento> pagamentos, List<RemuneracaoDiaria> remuneracoes, decimal custoFixo)
        {
            if (pagamentos != null &&
                pagamentos.Count > 0 &&
                !pagamentos.Any(x => x == null) &&
                remuneracoes != null &&
                remuneracoes.Count > 0 &&
                !remuneracoes.Any(x => x == null) &&
                custoFixo >= 0)
            {
                return new CaixaDiario(data, pagamentos, remuneracoes, custoFixo);
            }
            else
            {
                return null;
            }
        }

        public CaixaDiario NovoCaixaDiario(DateTime data, List<Pagamento> pagamentos, List<RemuneracaoDiaria> remuneracoes)
        {
            if (pagamentos != null &&
                pagamentos.Count > 0 &&
                !pagamentos.Any(x => x == null) &&
                remuneracoes != null &&
                remuneracoes.Count > 0 &&
                !remuneracoes.Any(x => x == null))
            {
                return new CaixaDiario(data, pagamentos, remuneracoes, CustoFixoPadrao);
            }
            else
            {
                return null;
            }
        }

        private decimal CalcularTotalSalario()
        {
            return Remuneracoes.Sum(x => x.ValorSalario);
        }

        private decimal CalcularTotalComissao()
        {
            return Remuneracoes.Sum(x => x.ValorComissao);
        }

        private decimal CalcularTotalHoraExtra()
        {
            return Remuneracoes.Sum(x => x.ValorHoraExtra);
        }

        private decimal CalcularEncargosTrabalhistas()
        {
            return PercentualEncargos * TotalSalario;
        }

        private decimal CalcularSimplesNacional()
        {
            return PercentualSimplesNacional * ReceitaBruta;
        }

        private decimal CalcularReceitaBruta()
        {
            return Pagamentos.Sum(x => x.OrdemServico.PrecoTotal);
        }

        private decimal CalcularReceitaLiquida()
        {
            return ReceitaBruta - TotalSalario - TotalComissao - TotalHoraExtra - CustoFixo - EncargosTrabalhistas - SimplesNacional;
        }
    }
}
