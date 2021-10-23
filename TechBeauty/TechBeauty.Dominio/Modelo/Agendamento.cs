using System;
using TechBeauty.Dominio.Modelo.Enumeradores;

namespace TechBeauty.Dominio.Modelo
{
    public class Agendamento
    {
        public int Id { get; init; }
        public Servico Servico { get; init; }
        public Colaborador Colaborador { get; init; }
        public string PessoaAtendida { get; init; }
        public DateTime DataHoraCriacao { get; init; }
        public DateTime DataHoraExecucao { get; init; }
        public StatusAgendamento StatusAgendamento { get; set; } = StatusAgendamento.Agendado;
        public int DuracaoEmMin => Servico.DuracaoEmMin;
        public DateTime DataHoraFinal => DataHoraExecucao.AddMinutes(DuracaoEmMin);

        private Agendamento(int id, Servico servico, Colaborador colaborador, string pessoaAtendida,
          DateTime dataHoraCriacao, DateTime dataHoraExecucao)
        {
            Id = id;
            Servico = servico;
            Colaborador = colaborador;
            PessoaAtendida = pessoaAtendida;
            DataHoraCriacao = dataHoraCriacao;
            DataHoraExecucao = dataHoraExecucao;
        }

        public static Agendamento NovoAgendamento(int idDoAgendamento, Servico servico, Colaborador colaborador, 
            string pessoaAtendida, DateTime dataHoraCriacao, DateTime dataHoraExecucao) =>
            new Agendamento(idDoAgendamento, servico, colaborador, pessoaAtendida,
            dataHoraCriacao, dataHoraExecucao);

        public void AlterarStatusAgendamento(StatusAgendamento statusDoAgendamento) =>
            StatusAgendamento = statusDoAgendamento;
    }
}
