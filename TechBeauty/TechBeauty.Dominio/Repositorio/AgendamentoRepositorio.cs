using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dominio.Repositorio
{
    public class AgendamentoRepositorio
    {
        public List<Agendamento> TabelaAgendamento { get; set; } = new List<Agendamento>();

        public AgendamentoRepositorio(ServicoRepositorio repoServico, ColaboradorRepositorio repoColaborador,
            OrdemServicoRepositorio repoOrdemServico) => Preencher(repoServico, repoColaborador, repoOrdemServico);

        public void Incluir(Agendamento agendamento) => TabelaAgendamento.Add(agendamento);

        public Agendamento SelecionarPorId(int id) => TabelaAgendamento.FirstOrDefault(x=> x.Id == id);

        public void Alterar(int id, Servico servico, Colaborador colaborador, string pessoaAtendida,
          DateTime dataHora, OrdemServico os, DateTime dataHoraCriacao, DateTime dataHoraExecucao) =>
            SelecionarPorId(id).Alterar(servico, colaborador, pessoaAtendida, dataHora, os, dataHoraCriacao,
                dataHoraExecucao);

        public void Excluir(int id) => TabelaAgendamento.Remove(SelecionarPorId(id));
        
        public void Preencher(ServicoRepositorio repoServico, ColaboradorRepositorio repoColaborador,
            OrdemServicoRepositorio repoOrdemServico)
        {
            (int id, int idServico, int idColaborador, string pessoaAtendida, DateTime dataHora, 
                int idOrdemServico, DateTime dataHoraCriacao, DateTime dataHoraExecucao)[] 
                valoresAgendamento =
                {
                    (1, 1, 1, "Robervaldo", new DateTime(2021, 10, 21), 1, 
                    new DateTime(2021, 10, 21, 9, 0, 0), new DateTime(2021, 10, 21, 10, 0, 0))
                };

            foreach (var agendamento in valoresAgendamento)
            {
                var servico = repoServico.SelecionarPorId(agendamento.idServico);
                var colaborador = repoColaborador.SelecionarPorId(agendamento.idColaborador);
                var ordemServico = repoOrdemServico.SelecionarPorId(agendamento.idOrdemServico);
                Incluir(Agendamento.Criar(agendamento.id, servico, colaborador, agendamento.pessoaAtendida,
                    agendamento.dataHora, ordemServico, agendamento.dataHoraCriacao, agendamento.dataHoraExecucao));
            }
        }


    }
}
