using System.Collections.Generic;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dominio.Repositorio
{
    public class EnderecoRepositorio
    {
        public List<Endereco> TabelaEndereco { get; private set; } = new List<Endereco>();

        public EnderecoRepositorio()
        {
            Preencher();
        }

        public List<Endereco> Incluir(Endereco endereco)
        {
            TabelaEndereco.Add(endereco);
            return TabelaEndereco;
        }

        public void Preencher()
        {
            (string, string, string, string, string)[] valoresEndereco =
                {
                ("Rua A", "Cidade A", "BA", "s/n", "Edf. A"),
                ("Rua B", "Cidade B", "DF", "1", "Edf. B"),
                ("Rua C", "Cidade C", "SP", "2", "Edf. C")
                };

            for (int i = 0; i < valoresEndereco.Length; i++)
            {
                Incluir(Endereco.Criar(i + 1, valoresEndereco[i].Item1, valoresEndereco[i].Item2, valoresEndereco[i].Item3, valoresEndereco[i].Item4, valoresEndereco[i].Item5));
            }
        }
    }
}
