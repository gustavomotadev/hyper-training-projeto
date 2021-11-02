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

        private RemuneracaoDiaria() { }

        private RemuneracaoDiaria(Colaborador colaborador,
            TimeSpan horasTrabalhadas, List<RemuneracaoDiariaServico> servicosRealizados)
        {
            Colaborador = colaborador;
            HorasTrabalhadas = horasTrabalhadas;
            RemuneracoesServicos = servicosRealizados;

            ValorSalario = CalcularSalario();
            ValorComissao = CalcularComissao();
            ValorHoraExtra = CalcularHoraExtra();
        }

        public RemuneracaoDiaria NovaRemuneracaoDiaria(Colaborador colaborador, 
            TimeSpan horasTrabalhadas, List<RemuneracaoDiariaServico> servicosRealizados)
        {
            if (colaborador != null &&
                horasTrabalhadas <= PadraoRemuneracao.JornadaMaxima &&
                servicosRealizados != null &&
                servicosRealizados.Count > 0 &&
                !servicosRealizados.Any(x => x == null))
            {
                return new RemuneracaoDiaria(colaborador, horasTrabalhadas, servicosRealizados);
            }
            else
            {
                return null;
            }
        }

        private decimal CalcularSalario()
        {
            return (HorasTrabalhadas.Minutes * Colaborador.PadraoRemuneracao.SalarioHora) / 60.00M;
        }

        private decimal CalcularComissao()
        {
            decimal total = RemuneracoesServicos.Sum(x => x.Servico.Preco);
            return total * Colaborador.PadraoRemuneracao.PercentualComissao; 
        }

        private decimal CalcularHoraExtra()
        {
            if (HorasTrabalhadas > Colaborador.PadraoRemuneracao.JornadaEsperada)
            {
                return ((HorasTrabalhadas- Colaborador.PadraoRemuneracao.JornadaEsperada).Minutes *
                    Colaborador.PadraoRemuneracao.SalarioHora) / 60.00M;
            }
            else 
            {
                return 0.00M;
            }
        }
    }
}
