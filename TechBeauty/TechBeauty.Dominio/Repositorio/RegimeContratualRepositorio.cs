using System.Collections.Generic;
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
