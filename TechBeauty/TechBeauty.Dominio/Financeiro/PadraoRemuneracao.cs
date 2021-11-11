using System;
using System.Linq;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dominio.Financeiro
{
    public class PadraoRemuneracao
    {
        public static TimeSpan JornadaMaxima => new TimeSpan(8, 0, 0);
        public static decimal AdicionalHoraExtraMinimo => 0.5M;
        //public static decimal SalarioMinimoHora { get; private set; } = 5.00M;
        public int Id { get; set; }
        public int ColaboradorId { get; set; } //ef
        public Colaborador Colaborador { get; init; }
        public TimeSpan JornadaEsperada { get; private set; }
        public decimal SalarioHora { get; private set; }
        public decimal PercentualComissao { get; private set; }
        public decimal AdicionalHoraExtra { get; private set; }

        private PadraoRemuneracao() { }

        /*
        private PadraoRemuneracao(Colaborador colaborador)
        {
            Colaborador = colaborador;
        }
        */

        /*
        public static void AtualizarSalarioMin(decimal salarioMinHora)
        {
            SalarioMinimoHora = salarioMinHora;
        }
        */

        public static PadraoRemuneracao NovoPadraoRemuneracao(int colaboradorId, TimeSpan jornadaEsperada,
            decimal salarioHora, decimal percentualComissao, decimal adicionalHoraExtra)
        {
            var novaFormaRemunerar = new PadraoRemuneracao();
            novaFormaRemunerar.ColaboradorId = colaboradorId;
            novaFormaRemunerar.JornadaEsperada = jornadaEsperada;
            novaFormaRemunerar.SalarioHora = salarioHora;
            novaFormaRemunerar.PercentualComissao = percentualComissao;
            novaFormaRemunerar.AdicionalHoraExtra = adicionalHoraExtra;
            return novaFormaRemunerar;
        }

        public bool AlterarJornadaEsperada(TimeSpan jornadaEsperada)
        {
            if (jornadaEsperada <= JornadaMaxima)
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
            /*
            if (salarioHora >= SalarioMinimoHora)
            {
                SalarioHora = salarioHora;
                return true;
            }
            else
            {
                return false;
            }
            */
            SalarioHora = salarioHora;
            return true;
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
            if (adicionalHoraExtra >= AdicionalHoraExtraMinimo &&
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
