using System;
using System.Collections.Generic;
using System.Linq;

namespace TechBeauty.Dominio.Modelo
{
    public class ContratoTrabalho
    {
        public int Id { get; init; }
        public int RegimeContratualId { get; set; } //ef
        public RegimeContratual RegimeContratual { get; init; }
        public DateTime DataEntrada { get; init; }
        public DateTime? DataDesligamento { get; private set; }
        public List<CargoContratoTrabalho> CargosContratosTrabalho { get; set; } //ef
        public string CNPJ_CTPS { get; init; }
        public bool Vigente { get; set; }

        private ContratoTrabalho(int id, RegimeContratual regimeContratual, DateTime dataEntrada, string cnpjCTPS)
        {
            Id = id;
            RegimeContratual = regimeContratual;
            DataEntrada = dataEntrada;
            CNPJ_CTPS = cnpjCTPS;
        }

        public static ContratoTrabalho NovoContratoTrabalho(int idContratoTrabalho, RegimeContratual regimeContratual, DateTime dataEntrada,
            DateTime? dataDesligamento, List<Cargo> cargos, string cnpjCTPS)
        {
            if (regimeContratual != null &&
                cargos != null &&
                cargos.Count > 0 &&
                !cargos.Any(x => x == null) &&
                !String.IsNullOrWhiteSpace(cnpjCTPS) &&
                ((dataDesligamento != null && dataDesligamento > dataEntrada) || dataDesligamento == null))
            {
                var contratoTrabalho = new ContratoTrabalho(idContratoTrabalho, regimeContratual, dataEntrada, cnpjCTPS);
                contratoTrabalho.DataDesligamento = dataDesligamento;
                contratoTrabalho.Cargos = cargos;
                return contratoTrabalho;
            }
            else
            {
                return null;
            }
        }

        public bool AlterarDataDesligamento(DateTime? dataDesligamento)
        {
            if ((dataDesligamento != null && dataDesligamento > DataEntrada) || dataDesligamento == null)
            {
                DataDesligamento = dataDesligamento;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AdicionarCargo(Cargo cargo)
        {
            if (cargo != null)
            {
                Cargos.Add(cargo);
                return true;
            }
            else
            {
                return false;
            }
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
            if (Cargos.Count > 1 &&
                cargo != null)
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
