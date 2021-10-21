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

        public List<Servico> Incluir(Servico servico)
        {
            TabelaServico.Add(servico);
            return TabelaServico;
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
            (int id, string nome, decimal preco, string descricao, int duracaoEmMin)[] valoresServico =
                {
                    (1, "Corte", 15.0M, "aaa", 20),
                    (2, "Pintura", 15.0M, "aaa", 20),
                    (3, "Manicure", 15.0M, "aaa", 20)
                };

            foreach (var servico in valoresServico)
            {
                Incluir(Servico.Criar(servico.id, servico.nome, servico.preco, servico.descricao, servico.duracaoEmMin));
            }
        }
    }
}
