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
        public List<Servico> Servicos { get; set; } //ef
        public int CaixaDiarioId { get; set; } //ef
        public CaixaDiario CaixaDiario { get; set; } //ef
        public TimeSpan HorasTrabalhadas { get; init; }
        public decimal ValorSalario { get; init; }
        public decimal ValorComissao { get; init; }
        public decimal ValorHoraExtra { get; init; }
        public decimal ValorTotal => ValorSalario + ValorComissao + ValorHoraExtra;

        private RemuneracaoDiaria() { }

        private RemuneracaoDiaria(int caixaDiarioId, int colaboradorId,
            TimeSpan horasTrabalhadas)
        {
            CaixaDiarioId = caixaDiarioId;
            ColaboradorId = colaboradorId;
            HorasTrabalhadas = horasTrabalhadas;

            ValorSalario = CalcularSalario();
            ValorComissao = CalcularComissao();
            ValorHoraExtra = CalcularHoraExtra();
        }

        public static RemuneracaoDiaria NovaRemuneracaoDiaria(int caixaDiarioId, int colaboradorId,
            TimeSpan horasTrabalhadas, List<Servico> servicosRealizados)
        {
            if (horasTrabalhadas <= PadraoRemuneracao.JornadaMaxima &&
                servicosRealizados != null &&
                servicosRealizados.Count > 0 &&
                !servicosRealizados.Any(x => x == null))
            {
                return new RemuneracaoDiaria(caixaDiarioId, colaboradorId, horasTrabalhadas, servicosRealizados);
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
            decimal total = Servicos.Sum(x => x.Preco);
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
