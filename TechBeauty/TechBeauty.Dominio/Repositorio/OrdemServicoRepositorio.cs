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
        public List<OrdemServico> TabelaOrdemServico { get; private set; } = new List<OrdemServico>();

        public OrdemServicoRepositorio(ClienteRepositorio repoCliente, AgendamentoRepositorio repoAgendamento) => 
            Preencher(repoCliente, repoAgendamento);

        public void Incluir(OrdemServico ordemServico) => TabelaOrdemServico.Add(ordemServico);
        

        public OrdemServico SelecionarPorId(int id) => TabelaOrdemServico.FirstOrDefault(x => x.Id == id);

        public void Excluir(int id) => TabelaOrdemServico.Remove(SelecionarPorId(id));

        public void Preencher(ClienteRepositorio repoCliente, AgendamentoRepositorio repoAgendamento)
        {
            (int id, decimal precoTotal, int duracaoTotal, int idCliente, 
                StatusOS status, int[] idAgendamentos)[] valoresOrdemServico =
                {
                    (1, 30.00M, 40, 1, StatusOS.Concluido, new int[]{1})
                };

            foreach (var ordemServico in valoresOrdemServico)
            {
                var cliente = repoCliente.SelecionarPorId(ordemServico.idCliente);
                var agendamentos = new List<Agendamento>();
                foreach (var idAgendamento in ordemServico.idAgendamentos)
                {
                    agendamentos.Add(repoAgendamento.SelecionarPorId(idAgendamento));
                }
                //TODO
                //Incluir(OrdemServico.NovaOS());
            }
        }
    }
}
