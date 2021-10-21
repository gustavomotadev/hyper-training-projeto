using System;
using System.Collections.Generic;

namespace TechBeauty.Dominio.Modelo
{
    public class ContratoTrabalho
    {
        public int Id { get; private set; }
        public int MyProperty { get; private set; }
        public RegimeContratual RegimeContratual { get; private set; }
        public DateTime DataEntrada { get; private set; }
        public DateTime? DataDesligamento { get; private set; }
        public List<Cargo> Cargos { get; private set; }
        public string CnpjCTPS { get; private set; }
    }
}
