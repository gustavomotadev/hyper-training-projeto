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
            (int id, string logradouro, string cidade, string uf, string numero, string complemento)[] 
                valoresEndereco =
                {
                    (1, "Rua A", "Cidade A", "BA", "s/n", "Edf. A"),
                    (2, "Rua B", "Cidade B", "DF", "1", "Edf. B"),
                    (3, "Rua C", "Cidade C", "SP", "2", "Edf. C")
                };

            foreach (var endereco in valoresEndereco)
            {
                Incluir(Endereco.Criar(endereco.id, endereco.logradouro, endereco.cidade, endereco.uf, 
                    endereco.numero, endereco.complemento));
            }
        }
    }
}
