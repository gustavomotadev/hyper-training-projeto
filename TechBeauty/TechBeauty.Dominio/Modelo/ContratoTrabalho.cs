using System;
using System.Collections.Generic;

namespace TechBeauty.Dominio.Modelo
{
    public class ContratoTrabalho
    {
        public int Id { get; init; }
        public RegimeContratual RegimeContratual { get; init; }
        public DateTime DataEntrada { get; init; }
        public DateTime? DataDesligamento { get; private set; }
        public List<Cargo> Cargos { get; private set; }
        public string CnpjCTPS { get; init; }

        public ContratoTrabalho(int id, RegimeContratual regimeContratual, DateTime dataEntrada)
        {
            Id = id;
            RegimeContratual = regimeContratual;
            DataEntrada = dataEntrada;
        }
        public static ContratoTrabalho NovoContratoTrabalho(int idContratoTrabalho, RegimeContratual regimeContratual, DateTime dataEntrada,
            DateTime? dataDesligamento, List<Cargo> cargos, string cnpjCTPS)
        {
            var contratoTrabalho = new ContratoTrabalho(idContratoTrabalho, regimeContratual, dataEntrada);
            contratoTrabalho.DataDesligamento = dataDesligamento;
            contratoTrabalho.Cargos = cargos;
            return contratoTrabalho;
        }
        public void Alterar(RegimeContratual regimeContratual, DateTime dataEntrada,
            DateTime? dataDesligamento, List<Cargo> cargos, string cnpjCTPS)
        {
            DataDesligamento = dataDesligamento;
            Cargos = cargos;
        }

        public void AlterarDataDesligamento(DateTime dataDesligamento)
        {
            DataDesligamento = dataDesligamento;
        }
    }
}
