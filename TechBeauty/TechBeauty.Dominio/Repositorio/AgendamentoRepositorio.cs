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

        public AgendamentoRepositorio()
        {
            //Incompleto
            Preencher();
        }

        public void Incluir(Agendamento agendamento) => TabelaAgendamento.Add(agendamento);

        public Agendamento SelecionarPorId(int id) => TabelaAgendamento.FirstOrDefault(x=> x.Id == id);

        public void Alterar(int id, Servico servico, Colaborador colaborador, string pessoaAtendida,
          DateTime dataHora, OrdemServico os, DateTime dataHoraCriacao, DateTime dataHoraExecucao) =>
            SelecionarPorId(id).Alterar(servico, colaborador, pessoaAtendida, dataHora, os, dataHoraCriacao,
                dataHoraExecucao);

        public void Excluir(int id) => TabelaAgendamento.Remove(SelecionarPorId(id));
        
        public void Preencher()
        {
            //incompleto
        }


    }
}
