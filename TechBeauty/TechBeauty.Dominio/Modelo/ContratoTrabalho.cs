using System;
using System.Collections.Generic;
using System.Linq;

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

        public void AdicionarCargo(Cargo cargo)
        {
            Cargos.Add(cargo);
        }

        public bool RemoverCargo(int id, Cargo cargo)
        {
            if (Cargos.Count > 1)
            {
                Cargos.Remove(Cargos.FirstOrDefault(x => x.Id == id));
                return true;
            }
            return false;
        }
    }
}
