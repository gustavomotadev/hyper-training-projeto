using System.Collections.Generic;
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
