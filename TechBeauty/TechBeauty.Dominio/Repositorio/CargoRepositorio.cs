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
            (string, string)[] valoresCargo = { ("Cabelereira", "a"), ("Manicure", "b"), ("Pedicure", "c"), ("Depiladora", "d"), ("Colorista", "e"), ("Massagista", "f") };

            for (int i = 0; i < valoresCargo.Length; i++)
            {
                Incluir(Cargo.Criar(i + 1, valoresCargo[i].Item1, valoresCargo[i].Item2));
            }
        }
    }
}
