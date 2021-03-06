using System;
using System.Collections.Generic;
using System.Linq;

namespace TechBeauty.Dominio.Modelo
{
    public class ContratoTrabalho
    {
        public int Id { get; init; }
        public int RegimeContratualId { get; private set; } //ef
        public RegimeContratual RegimeContratual { get; init; }
        public int ColaboradorId { get; private set; } //ef
        public Colaborador Colaborador { get; init; }
        public DateTime DataEntrada { get; init; }
        public DateTime? DataDesligamento { get; private set; }
        public List<Cargo> Cargos { get; private set; } = new List<Cargo>(); //ef
        public string CNPJ_CTPS { get; init; }
        public bool Vigente { get; private set; } = true;

        private ContratoTrabalho() { }

        private ContratoTrabalho(int regimeContratualId, DateTime dataEntrada, string cnpjCTPS)
        {
            RegimeContratualId = regimeContratualId;
            DataEntrada = dataEntrada;
            CNPJ_CTPS = cnpjCTPS;
        }

        public static ContratoTrabalho NovoContratoTrabalho(int regimeContratualId, DateTime dataEntrada,
            DateTime? dataDesligamento, string cnpjCTPS, int colaboradorId)
        {
            var contratoTrabalho = new ContratoTrabalho(regimeContratualId, dataEntrada, cnpjCTPS);
            contratoTrabalho.DataDesligamento = dataDesligamento;
            contratoTrabalho.ColaboradorId = colaboradorId;
            return contratoTrabalho;
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

        public Cargo ObterCargoPorId(int id) => Cargos.FirstOrDefault(x => x.Id == id);

        /*
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
        */

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

        public void alterarVigencia(bool vigente)
        {
            Vigente = vigente;
        }
    }
}
