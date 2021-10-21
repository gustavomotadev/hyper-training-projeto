using System.Collections.Generic;
using System.Linq;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dominio.Repositorio
{
    public class RegimeContratualRepositorio
    {
        public List<RegimeContratual> TabelaRegimeContratual { get; private set; } = new List<RegimeContratual>();

        public RegimeContratualRepositorio()
        {
            Preencher();
        }

        public List<RegimeContratual> Incluir(RegimeContratual regimeContratual)
        {
            TabelaRegimeContratual.Add(regimeContratual);
            return TabelaRegimeContratual;
        }

        public RegimeContratual SelecionarPorId(int id) => 
            TabelaRegimeContratual.FirstOrDefault(x => x.Id == id);

        public void Alterar(int id, string nome)
        {
            SelecionarPorId(id).Alterar(id, nome);
        }

        public void Excluir(int id)
        {
            TabelaRegimeContratual.Remove(SelecionarPorId(id));
        }

        public void Preencher()
        {
            string[] valoresRegimeContratual = { "CLT", "PJ" };

            for (int i = 0; i < valoresRegimeContratual.Length; i++)
            {
                Incluir(RegimeContratual.Criar(i + 1, valoresRegimeContratual[i]));
            }
        }
    }
}
