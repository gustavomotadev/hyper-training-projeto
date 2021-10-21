using System.Collections.Generic;
using System.Linq;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dominio.Repositorio
{
    public class CargoRepositorio
    {
        public List<Cargo> TabelaCargo { get; private set; } = new List<Cargo>();

        public CargoRepositorio()
        {
            Preencher();
        }

        public void Incluir(Cargo cargo)
        {
            TabelaCargo.Add(cargo);
        }

        public Cargo SelecionarPorId(int id) => TabelaCargo.FirstOrDefault(x => x.Id == id);

        public void Alterar(int id, string nome, string descricao)
        {
            SelecionarPorId(id).Alterar(nome, descricao);
        }

        public void Excluir(int id)
        {
            TabelaCargo.Remove(SelecionarPorId(id));
        }

        public void Preencher()
        {
            (int id, string nome, string descricao)[] valoresCargo = 
                { 
                (1, "Cabelereira", "a"), 
                (2, "Manicure", "b"), 
                (3, "Pedicure", "c"), 
                (4, "Depiladora", "d"), 
                (5, "Colorista", "e"), 
                (6, "Massagista", "f") 
                };

            foreach (var cargo in valoresCargo)
            {
                Incluir(Cargo.Criar(cargo.id, cargo.nome, cargo.descricao));
            }
        }
    }
}
