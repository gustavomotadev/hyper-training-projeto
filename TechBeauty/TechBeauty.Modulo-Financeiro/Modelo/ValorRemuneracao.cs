using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Modulo_Financeiro.Modelo
{
    public class ValorRemuneracao
    {
        public static decimal SalarioMinino { get; private set; }
        public Colaborador Colaborador { get; private set; }
        public DateTime HorasTrabalhadas { get; private set; }
        public decimal SalarioHora { get; private set; }
        public decimal Comissao { get; private set; }
        public decimal AdicionalNoturno { get; private set; }
        public decimal AdicionalHrExtra { get; private set; }



    }
}
