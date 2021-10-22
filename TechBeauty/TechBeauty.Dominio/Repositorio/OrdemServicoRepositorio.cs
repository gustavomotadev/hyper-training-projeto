using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBeauty.Dominio.Modelo;
using TechBeauty.Dominio.Modelo.Enumeradores;

namespace TechBeauty.Dominio.Repositorio
{
    public class OrdemServicoRepositorio
    {
        public List<OrdemServico> TabelaOS { get; private set; } = new List<OrdemServico>();

        public OrdemServicoRepositorio(ClienteRepositorio cliente) => Preencher(cliente);

        public void Incluir(OrdemServico os) => TabelaOS.Add(os);
        

        public OrdemServico SelecionarPorId(int id) => TabelaOS.FirstOrDefault(x => x.Id == id);

        public void Alterar(int id, decimal precoTotal,
            int duracaoTotal, Cliente cliente, StatusOS statusOs)
        {
            SelecionarPorId(id).Alterar(precoTotal, duracaoTotal, cliente, statusOs);
        }

        public void Excluir(int id) => TabelaOS.Remove(SelecionarPorId(id));

        public void Preencher(ClienteRepositorio repoCliente)
        {
            (int id, decimal precoTotal, int duracaoTotal, int idCliente, 
                StatusOS status)[] valoresOrdemServico =
                {
                    (1, 30.00M, 40, 1, StatusOS.Concluido)
                };

            foreach (var ordemServico in valoresOrdemServico)
            {
                var cliente = repoCliente.SelecionarPorId(ordemServico.idCliente);
                Incluir(OrdemServico.Criar(ordemServico.id, ordemServico.precoTotal,
                    ordemServico.duracaoTotal, cliente, ordemServico.status));
            }
        }
    }
}
