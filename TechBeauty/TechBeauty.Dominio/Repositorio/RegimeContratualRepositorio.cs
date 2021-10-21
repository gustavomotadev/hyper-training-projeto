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

        public void Incluir(RegimeContratual regimeContratual)
        {
            TabelaRegimeContratual.Add(regimeContratual);
        }

        public RegimeContratual SelecionarPorId(int id) => 
            TabelaRegimeContratual.FirstOrDefault(x => x.Id == id);

        public void Alterar(int id, string nome)
        {
            SelecionarPorId(id).Alterar(nome);
        }

        public void Excluir(int id)
        {
            TabelaRegimeContratual.Remove(SelecionarPorId(id));
        }

        public void Preencher()
        {
            (int id, string nome)[] valoresRegimeContratual = 
                { 
                    (1, "CLT"), 
                    (2, "PJ") 
                };

            foreach (var regimeContratual in valoresRegimeContratual)
            {
                Incluir(RegimeContratual.Criar(regimeContratual.id, regimeContratual.nome));
            }
        }
    }
}
