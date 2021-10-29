using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Financeiro.Modelo
{
    public class PadraoRemuneracao
    {
        private static readonly TimeSpan jornadaMaxima = new TimeSpan(8,0,0);
        private static readonly decimal adicionalHoraExtraMinimo = 0.5M;
        private static readonly decimal adicionalNoturnoMinimo = 0.2M;
        public static decimal SalarioMinimoHora { get; private set; } = 5.00M;
        public Colaborador Colaborador { get; init; }
        public TimeSpan JornadaEsperada { get; private set; }
        public decimal SalarioHora { get; private set; }
        public decimal Comissao { get; private set; }
        public decimal AdicionalNoturno { get; private set; }
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
            decimal salarioHora, decimal comissao, decimal adicionalNoturno, decimal adicionalHoraExtra)
        {
            if (colaborador != null &&
                jornadaEsperada <= jornadaMaxima &&
                salarioHora >= SalarioMinimoHora &&
                comissao < 1 &&
                comissao >= 0 &&
                adicionalHoraExtra < 1 &&
                adicionalHoraExtra >= adicionalHoraExtraMinimo &&
                adicionalNoturno < 1 &&
                adicionalNoturno >= 0 &&
                !(colaborador.Contrato.RegimeContratual.NomeRegimeContratual == "clt" &&
                    adicionalNoturno < adicionalNoturnoMinimo))
            { 
                var novaFormaRemunerar = new PadraoRemuneracao(colaborador);
                novaFormaRemunerar.JornadaEsperada = jornadaEsperada;
                novaFormaRemunerar.SalarioHora = salarioHora;
                novaFormaRemunerar.Comissao = comissao;
                novaFormaRemunerar.AdicionalNoturno = adicionalNoturno;
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

        public bool AlterarComissao(decimal comissao)
        {
            if (comissao >= 0 &&
                comissao < 1)
            {
                Comissao = comissao;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AlterarAdicionalNoturno(decimal adicionalNoturno)
        {
            if (adicionalNoturno >= 0 &&
                adicionalNoturno < 1 &&
                !(Colaborador.Contrato.RegimeContratual.NomeRegimeContratual == "clt" &&
                    adicionalNoturno < adicionalNoturnoMinimo))
            {
                AdicionalNoturno = adicionalNoturno;
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
