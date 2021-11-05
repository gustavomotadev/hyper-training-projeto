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
        public List<Pagamento> Pagamentos { get; init; } = new List<Pagamento>();
        public List<RemuneracaoDiaria> Remuneracoes { get; init; } = new List<RemuneracaoDiaria>();
        public DateTime Data { get; init; }
        public decimal TotalSalario { get; init; }
        public decimal TotalComissao { get; init; }
        public decimal TotalHoraExtra { get; init; }
        public decimal CustoFixo { get; init; }
        public decimal EncargosTrabalhistas { get; init; }
        public decimal SimplesNacional { get; init; }
        public decimal ReceitaBruta { get; init; }
        public decimal ReceitaLiquida { get; init; }

        private CaixaDiario() { }
        //TO DO
        private CaixaDiario(DateTime data, decimal custoFixo)
        {
            Data = data;
            CustoFixo = custoFixo;

            TotalSalario = CalcularTotalSalario();
            TotalComissao = CalcularTotalComissao();
            TotalHoraExtra = CalcularTotalHoraExtra();
            EncargosTrabalhistas = CalcularEncargosTrabalhistas();
            SimplesNacional = CalcularSimplesNacional();
            ReceitaBruta = CalcularReceitaBruta();
            ReceitaLiquida = CalcularReceitaLiquida();
        }
        //TO DO
        private CaixaDiario(DateTime data)
        {
            Data = data;

            TotalSalario = CalcularTotalSalario();
            TotalComissao = CalcularTotalComissao();
            TotalHoraExtra = CalcularTotalHoraExtra();
            EncargosTrabalhistas = CalcularEncargosTrabalhistas();
            SimplesNacional = CalcularSimplesNacional();
            ReceitaBruta = CalcularReceitaBruta();
            ReceitaLiquida = CalcularReceitaLiquida();
        }

        public static CaixaDiario NovoCaixaDiario(DateTime data, decimal custoFixo)
        {
            if (custoFixo >= 0)
            {
                return new CaixaDiario(data, custoFixo);
            }
            else
            {
                return null;
            }
        }

        public CaixaDiario NovoCaixaDiario(DateTime data)
        {
            
            return new CaixaDiario(data, CustoFixoPadrao);
            
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
