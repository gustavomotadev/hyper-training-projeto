using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.ViewModels.Criacao;
using TechBeauty.Dominio.Financeiro;

namespace TechBeauty.API.ViewModels.Alteracao
{
    public class AlterarPadraoRemuneracao
    {
        public CriarTimeSpan JornadaEsperada { get; set; }
        public decimal? SalarioHora { get; set; }
        public decimal? PercentualComissao { get; set; }
        public decimal? AdicionalHoraExtra { get; set; }

        public bool ValidarJornadaEsperada()
        {
            return (JornadaEsperada is not null &&
                new TimeSpan(JornadaEsperada.Horas, JornadaEsperada.Minutos, 0) 
                <= PadraoRemuneracao.JornadaMaxima);
        }

        public bool ValidarSalarioHora()
        {
            return (SalarioHora is not null &&
                SalarioHora > 0);
        }

        public bool ValidarPercentualComissao()
        {
            return (PercentualComissao is not null &&
                PercentualComissao < 1 &&
                PercentualComissao >= 0);
        }

        public bool ValidarAdicionalHoraExtra()
        {
            return (AdicionalHoraExtra is not null &&
                AdicionalHoraExtra < 1 &&
                AdicionalHoraExtra >= PadraoRemuneracao.AdicionalHoraExtraMinimo);
        }
    }
}
