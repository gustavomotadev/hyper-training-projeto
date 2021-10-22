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

        public void Incluir(Genero genero)
        {
            TabelaGenero.Add(genero);
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
            (int id, string valor)[] valoresGenero = 
                { 
                    (1, "Masculino"), 
                    (2, "Feminino"), 
                    (3, "Mulher Trans"), 
                    (4, "Homem Trans"), 
                    (5, "Não Binário"), 
                    (6, "Agênero") 
                };

            foreach (var genero in valoresGenero)
            {
                Incluir(Genero.Criar(genero.id, genero.valor));
            }

        }
    }
}
