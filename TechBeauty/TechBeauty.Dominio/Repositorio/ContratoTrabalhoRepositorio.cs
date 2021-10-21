using System;
using System.Collections.Generic;
using System.Linq;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dominio.Repositorio
{
    public class ContratoTrabalhoRepositorio
    {
        public List<ContratoTrabalho> TabelaContratoTrabalho { get; private set; } = new List<ContratoTrabalho>();

        public ContratoTrabalhoRepositorio(RegimeContratualRepositorio repoRegimeContratual,
            CargoRepositorio repoCargo) => Preencher(repoRegimeContratual, repoCargo);

        public void Incluir(ContratoTrabalho contratoTrabalho) => TabelaContratoTrabalho.Add(contratoTrabalho);

        public ContratoTrabalho SelecionarPorId(int id) => TabelaContratoTrabalho.FirstOrDefault(x => x.Id == id);

        public void Alterar(int id, RegimeContratual regimeContratual, DateTime dataEntrada,
            DateTime? dataDesligamento, List<Cargo> cargos, string cnpjCTPS) =>
            SelecionarPorId(id).Alterar(regimeContratual, dataEntrada, dataDesligamento, cargos, cnpjCTPS);

        public void Excluir(int id) => TabelaContratoTrabalho.Remove(SelecionarPorId(id));

        public void Preencher(RegimeContratualRepositorio repoRegimeContratual, CargoRepositorio repoCargo)
        {
            (int idRegimeContratual, DateTime dataEntrada, DateTime? dataDesligamento, 
                int[] idCargos, string cnpjCTPS)[] valoresContratoTrabalho = 
                { 
                    (1, new DateTime(2021, 10, 4), null, new int[] { 1, 2 }, "12345678") 
                };

            for (int i = 0; i < valoresContratoTrabalho.Length; i++)
            {
                var regime = repoRegimeContratual.SelecionarPorId(valoresContratoTrabalho[i].idRegimeContratual);
                var cargos = new List<Cargo>();
                foreach (var idCargo in valoresContratoTrabalho[i].idCargos)
                {
                    cargos.Add(repoCargo.SelecionarPorId(idCargo));
                }
                Incluir(ContratoTrabalho.Criar(i + 1, regime, valoresContratoTrabalho[i].dataEntrada,
                    valoresContratoTrabalho[i].dataDesligamento, cargos, valoresContratoTrabalho[i].cnpjCTPS));
            }
        }
    }
}
