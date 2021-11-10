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
        public int ColaboradorId { get; set; } //ef
        public Colaborador Colaborador { get; init; }
        public DateTime DataEntrada { get; init; }
        public DateTime? DataDesligamento { get; private set; }
        public List<Cargo> Cargos { get; set; } //ef
        public string CNPJ_CTPS { get; init; }
        public bool Vigente { get; set; } = true;

        private ContratoTrabalho() { }

        private ContratoTrabalho(int regimeContratualId, DateTime dataEntrada, string cnpjCTPS)
        {
            RegimeContratualId = regimeContratualId;
            DataEntrada = dataEntrada;
            CNPJ_CTPS = cnpjCTPS;
        }

        public static ContratoTrabalho NovoContratoTrabalho(int regimeContratualId, DateTime dataEntrada,
            DateTime? dataDesligamento, List<Cargo> cargos, string cnpjCTPS, int colaboradorId)
        {
            if (!String.IsNullOrWhiteSpace(cnpjCTPS) &&
                ((dataDesligamento != null && dataDesligamento > dataEntrada) || dataDesligamento == null))
            {
                var contratoTrabalho = new ContratoTrabalho(regimeContratualId, dataEntrada, cnpjCTPS);
                contratoTrabalho.DataDesligamento = dataDesligamento;
                contratoTrabalho.Cargos = cargos;
                contratoTrabalho.ColaboradorId = colaboradorId;
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
