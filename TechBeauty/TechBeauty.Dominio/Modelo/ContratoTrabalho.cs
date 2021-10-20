using System;
using System.Collections.Generic;

namespace TechBeauty.Dominio.Modelo
{
    public class ContratoTrabalho
    {
        public int Id { get; set; }
        public int MyProperty { get; set; }
        public RegimeContratual RegimeContratual { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataDesligamento { get; set; }
        public List<Cargo> Cargos { get; set; }
        public string CnpjCTPS { get; set; }
    }
}
