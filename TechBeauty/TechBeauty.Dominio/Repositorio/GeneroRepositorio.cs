using System.Collections.Generic;
using System.Linq;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dominio.Repositorio
{
    public class GeneroRepositorio
    {
        public List<Genero> TabelaGenero { get; private set; } = new List<Genero>();

        public GeneroRepositorio()
        {
            Preencher();
        }

        public List<Genero> Incluir(Genero genero)
        {
            TabelaGenero.Add(genero);
            return TabelaGenero;
        }

        public Genero SelecionarPorId(int id) => TabelaGenero.FirstOrDefault(x => x.Id == id);

        public void Alterar(int id, string valor)
        {
            SelecionarPorId(id).Alterar(valor);
        }

        public void Excluir(int id)
        {
            TabelaGenero.Remove(SelecionarPorId(id));
        }

        public void Preencher()
        {
            string[] valoresGenero = { "Masculino", "Feminino", "Mulher Trans", "Homem Trans", "Não Binário", "Agênero" };

            for (int i = 0; i < valoresGenero.Length; i++)
            {
                Incluir(Genero.Criar(i + 1, valoresGenero[i]));
            }

        }
    }
}
