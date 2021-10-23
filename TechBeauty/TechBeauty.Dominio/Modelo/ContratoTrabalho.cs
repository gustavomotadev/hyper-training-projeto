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

        private ContratoTrabalho(int id, RegimeContratual regimeContratual, DateTime dataEntrada, string cnpjCTPS)
        {
            Id = id;
            RegimeContratual = regimeContratual;
            DataEntrada = dataEntrada;
            CnpjCTPS = cnpjCTPS;
        }
        public static ContratoTrabalho NovoContratoTrabalho(int idContratoTrabalho, RegimeContratual regimeContratual, DateTime dataEntrada,
            DateTime? dataDesligamento, List<Cargo> cargos, string cnpjCTPS)
        {
            var contratoTrabalho = new ContratoTrabalho(idContratoTrabalho, regimeContratual, dataEntrada, cnpjCTPS);
            contratoTrabalho.DataDesligamento = dataDesligamento;
            contratoTrabalho.Cargos = cargos;
            return contratoTrabalho;
        }

        public void AlterarDataDesligamento(DateTime dataDesligamento)
        {
            DataDesligamento = dataDesligamento;
        }

        public void AdicionarCargo(Cargo cargo)
        {
            Cargos.Add(cargo);
        }

        public Cargo SelecionarPorId(int  id)
        {
            return Cargos.FirstOrDefault(x => x.Id == id);
        }

        public bool RemoverCargo(int id)
        {
            if (Cargos.Count > 1)
            {
                return Cargos.Remove(SelecionarPorId(id));
            }
            else
            {
                return false;
            }
        }

        public bool RemoverCargo(Cargo cargo)
        {
            if (Cargos.Count > 1)
            {
                return Cargos.Remove(cargo);
            }
            else
            {
                return false;
            }
        }
    }
}
