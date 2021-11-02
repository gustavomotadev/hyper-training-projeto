using System;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dominio.Financeiro
{
    public class PadraoRemuneracao
    {
        private static readonly TimeSpan jornadaMaxima = new TimeSpan(8,0,0);
        private static readonly decimal adicionalHoraExtraMinimo = 0.5M;
        public static TimeSpan JornadaMaxima => jornadaMaxima;
        public static decimal SalarioMinimoHora { get; private set; } = 5.00M;
        public int Id { get; set; }
        public int ColaboradorId { get; set; } //ef
        public Colaborador Colaborador { get; init; }
        public TimeSpan JornadaEsperada { get; private set; }
        public decimal SalarioHora { get; private set; }
        public decimal PercentualComissao { get; private set; }
        public decimal AdicionalHoraExtra { get; private set; }

        private PadraoRemuneracao(Colaborador colaborador)
        {
            Colaborador = colaborador;
        }

        public static void AtualizarSalarioMin(decimal salarioMinHora)
        {
            SalarioMinimoHora = salarioMinHora;
        }

        public static PadraoRemuneracao NovoPadraoRemuneracao(Colaborador colaborador, TimeSpan jornadaEsperada,
            decimal salarioHora, decimal percentualComissao, decimal adicionalHoraExtra)
        {
            if (colaborador != null &&
                jornadaEsperada <= jornadaMaxima &&
                (salarioHora >= SalarioMinimoHora || colaborador.Contrato.RegimeContratual.Valor == "pj") &&
                percentualComissao < 1 &&
                percentualComissao >= 0 &&
                adicionalHoraExtra < 1 &&
                adicionalHoraExtra >= adicionalHoraExtraMinimo)
            { 
                var novaFormaRemunerar = new PadraoRemuneracao(colaborador);
                novaFormaRemunerar.JornadaEsperada = jornadaEsperada;
                novaFormaRemunerar.SalarioHora = salarioHora;
                novaFormaRemunerar.PercentualComissao = percentualComissao;
                novaFormaRemunerar.AdicionalHoraExtra = adicionalHoraExtra;
                return novaFormaRemunerar;
            }
            else
            {
                return null;
            }
            
        }

        public bool AlterarJornadaEsperada(TimeSpan jornadaEsperada)
        {
            if (jornadaEsperada <= jornadaMaxima)
            {
                JornadaEsperada = jornadaEsperada;
                return true;
            } 
            else
            {
                return false;
            }
        }

        public bool AlterarSalarioHora(decimal salarioHora)
        {
            if (salarioHora >= SalarioMinimoHora)
            {
                SalarioHora = salarioHora;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AlterarPercentualComissao(decimal percentualComissao)
        {
            if (percentualComissao >= 0 &&
                percentualComissao < 1)
            {
                PercentualComissao = percentualComissao;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AlterarAdicionalHoraExtra(decimal adicionalHoraExtra)
        {
            if (adicionalHoraExtra >= adicionalHoraExtraMinimo &&
                adicionalHoraExtra < 1)
            {
                AdicionalHoraExtra = adicionalHoraExtra;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
