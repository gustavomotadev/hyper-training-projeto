using System.Collections.Generic;
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

        public List<Cargo> Incluir(Cargo cargo)
        {
            TabelaCargo.Add(cargo);
            return TabelaCargo;
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
