using System.Collections.Generic;
using System.Linq;
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

        public void Incluir(Endereco endereco)
        {
            TabelaEndereco.Add(endereco);
        }

        public Endereco SelecionarPorId(int id) => TabelaEndereco.FirstOrDefault(x => x.Id == id);

        public void Alterar(int id, string logradouro, string cidade, string uf, string numero, string complemento)
        {
            SelecionarPorId(id).Alterar(logradouro, cidade, uf, numero, complemento);
        }

        public void Excluir(int id)
        {
            TabelaEndereco.Remove(SelecionarPorId(id));
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
