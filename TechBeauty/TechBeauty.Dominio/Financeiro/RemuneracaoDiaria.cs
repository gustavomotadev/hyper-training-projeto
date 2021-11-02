using System;
using System.Collections.Generic;
using System.Linq;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dominio.Financeiro
{
    public class RemuneracaoDiaria
    {
        public int Id { get; set; }
        public int ColaboradorId { get; set; } //ef
        public Colaborador Colaborador { get; init; }
        public List<RemuneracaoDiariaServico> RemuneracoesServicos { get; set; } //ef
        public int CaixaDiarioId { get; set; } //ef
        public CaixaDiario CaixaDiario { get; set; } //ef
        public TimeSpan HorasTrabalhadas { get; init; }
        public decimal ValorSalario { get; init; }
        public decimal ValorComissao { get; init; }
        public decimal ValorHoraExtra { get; init; }
        public decimal ValorTotal => ValorSalario + ValorComissao + ValorHoraExtra; 

        private RemuneracaoDiaria(PadraoRemuneracao padraoRemuneracao,
            TimeSpan horasTrabalhadas, List<Servico> servicosRealizados)
        {
            PadraoRemuneracao = padraoRemuneracao;
            HorasTrabalhadas = horasTrabalhadas;
            ServicosRealizados = servicosRealizados;

            ValorSalario = CalcularSalario();
            ValorComissao = CalcularComissao();
            ValorHoraExtra = CalcularHoraExtra();
        }

        public RemuneracaoDiaria NovaRemuneracaoDiaria(PadraoRemuneracao padraoRemuneracao, 
            TimeSpan horasTrabalhadas, List<Servico> servicosRealizados)
        {
            if (padraoRemuneracao != null &&
                horasTrabalhadas <= PadraoRemuneracao.JornadaMaxima &&
                servicosRealizados != null &&
                servicosRealizados.Count > 0 &&
                !servicosRealizados.Any(x => x == null))
            {
                return new RemuneracaoDiaria(padraoRemuneracao, horasTrabalhadas, servicosRealizados);
            }
            else
            {
                return null;
            }
        }

        private decimal CalcularSalario()
        {
            return (HorasTrabalhadas.Minutes * PadraoRemuneracao.SalarioHora) / 60.00M;
        }

        private decimal CalcularComissao()
        {
            decimal total = ServicosRealizados.Sum(x => x.Preco);
            return total * PadraoRemuneracao.PercentualComissao; 
        }

        private decimal CalcularHoraExtra()
        {
            if (HorasTrabalhadas > PadraoRemuneracao.JornadaEsperada)
            {
                return ((HorasTrabalhadas-PadraoRemuneracao.JornadaEsperada).Minutes * 
                    PadraoRemuneracao.SalarioHora) / 60.00M;
            }
            else 
            {
                return 0.00M;
            }
        }
    }
}
