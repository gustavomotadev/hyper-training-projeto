using System;
using System.Collections.Generic;

namespace TechBeauty.Dominio.Modelo
{
    public class ContratoTrabalho
    {
        public int Id { get; init; }
        public RegimeContratual RegimeContratual { get; private set; }
        public DateTime DataEntrada { get; private set; }
        public DateTime? DataDesligamento { get; private set; }
        public List<Cargo> Cargos { get; private set; }
        public string CnpjCTPS { get; private set; }

        public ContratoTrabalho(int id)
        {
            Id = id;
        }
        public static ContratoTrabalho Criar(int idContratoTrabalho, RegimeContratual regimeContratual, DateTime dataEntrada,
            DateTime? dataDesligamento, List<Cargo> cargos, string cnpjCTPS)
        {
            var contratoTrabalho = new ContratoTrabalho(idContratoTrabalho);
            contratoTrabalho.RegimeContratual = regimeContratual;
            contratoTrabalho.DataEntrada = dataEntrada;
            contratoTrabalho.DataDesligamento = dataDesligamento;
            contratoTrabalho.Cargos = cargos;
            contratoTrabalho.CnpjCTPS = cnpjCTPS;
            return contratoTrabalho;
        }
        public void Alterar(RegimeContratual regimeContratual, DateTime dataEntrada,
            DateTime? dataDesligamento, List<Cargo> cargos, string cnpjCTPS)
        {

            RegimeContratual = regimeContratual;
            DataEntrada = dataEntrada;
            DataDesligamento = dataDesligamento;
            Cargos = cargos;
            CnpjCTPS = cnpjCTPS;
        }
    }
}
