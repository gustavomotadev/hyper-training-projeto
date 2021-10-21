using System.Collections.Generic;
using System.Linq;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dominio.Repositorio
{
    public class ServicoRepositorio
    {
        public List<Servico> TabelaServico { get; private set; } = new List<Servico>();

        public ServicoRepositorio()
        {
            Preencher();
        }

        public void Incluir(Servico servico)
        {
            TabelaServico.Add(servico);
            
        }

        public Servico SelecionarPorId(int id) => TabelaServico.FirstOrDefault(x => x.Id == id);

        public void Alterar(int id, string nome, decimal preco, string descricao, int duracaoEmMin)
        {
            SelecionarPorId(id).Alterar(nome, preco, descricao, duracaoEmMin);
        }

        public void Excluir(int id)
        {
            TabelaServico.Remove(SelecionarPorId(id));
        }

        public void Preencher()
        {
            (string, decimal, string, int)[] valoresServico =
                {
                ("Corte", 15.0M, "aaa", 20),
                ("Pintura", 15.0M, "aaa", 20),
                ("Manicure", 15.0M, "aaa", 20)
                };

            for (int i = 0; i < valoresServico.Length; i++)
            {
                Incluir(Servico.Criar(i + 1, valoresServico[i].Item1, valoresServico[i].Item2, valoresServico[i].Item3, valoresServico[i].Item4));
            }
        }
    }
}
