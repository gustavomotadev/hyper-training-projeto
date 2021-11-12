using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dominio.Financeiro
{
    public class RemuneracaoDiaria
    {
        public int Id { get; set; }
        public int ColaboradorId { get; private set; } //ef
        [JsonIgnore]
        public Colaborador Colaborador { get; init; }
        public List<Servico> Servicos { get; private set; } = new List<Servico>(); //ef
        public int CaixaDiarioId { get; private set; } //ef
        [JsonIgnore]
        public CaixaDiario CaixaDiario { get; private set; } //ef
        public TimeSpan HorasTrabalhadas { get; init; }
        public decimal ValorSalario { get; private set; }
        public decimal ValorComissao { get; private set; }
        public decimal ValorHoraExtra { get; private set; }
        public decimal ValorTotal => ValorSalario + ValorComissao + ValorHoraExtra;

        private RemuneracaoDiaria() { }

        private RemuneracaoDiaria(int caixaDiarioId, int colaboradorId,
            TimeSpan horasTrabalhadas)
        {
            CaixaDiarioId = caixaDiarioId;
            ColaboradorId = colaboradorId;
            HorasTrabalhadas = horasTrabalhadas;
        }

        public static RemuneracaoDiaria NovaRemuneracaoDiaria(int caixaDiarioId, int colaboradorId,
            TimeSpan horasTrabalhadas)
        {
            if (horasTrabalhadas <= PadraoRemuneracao.JornadaMaxima)
            {
                return new RemuneracaoDiaria(caixaDiarioId, colaboradorId, horasTrabalhadas);
            }
            else
            {
                return null;
            }
        }

        public bool AdicionarServico(Servico servico)
        {
            if (servico is not null)
            {
                Servicos.Add(servico);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CalcularTudo()
        {
            CalcularSalario();
            CalcularComissao();
            CalcularHoraExtra();
        }

        private void CalcularSalario()
        {
            ValorSalario = ((HorasTrabalhadas.Hours*60 + HorasTrabalhadas.Minutes) * Colaborador.PadraoRemuneracao.SalarioHora) / 60.00M;
        }

        private void CalcularComissao()
        {
            decimal total = Servicos.Sum(x => x.Preco);
            ValorComissao = total * Colaborador.PadraoRemuneracao.PercentualComissao; 
        }

        private void CalcularHoraExtra()
        {
            if (HorasTrabalhadas > Colaborador.PadraoRemuneracao.JornadaEsperada)
            {
                var horasExtras = HorasTrabalhadas - Colaborador.PadraoRemuneracao.JornadaEsperada;
                ValorHoraExtra = (((horasExtras.Hours*60 + horasExtras.Minutes) *
                    Colaborador.PadraoRemuneracao.SalarioHora) / 60.00M) * 
                    (1+Colaborador.PadraoRemuneracao.AdicionalHoraExtra);
            }
            else 
            {
                ValorHoraExtra = 0.00M;
            }
        }
    }
}
