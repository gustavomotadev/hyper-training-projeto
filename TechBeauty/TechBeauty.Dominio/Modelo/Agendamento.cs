using System;

namespace TechBeauty.Dominio.Modelo
{
    public class Agendamento
    {
        public int Id { get; init; }
        public Servico Servico { get; private set; }
        public Colaborador Colaborador { get; private set; }
        public string PessoaAtendida { get; private set; }
        public DateTime DataHora { get; private set; }
        public DateTime DataHoraCriacao { get; private set; }
        public DateTime DataHoraExecucao { get; private set; }

        public Agendamento(int id)
        {
            Id = id;
        }

        public static Agendamento Criar(int idAgendamento, Servico servico, Colaborador colaborador, string pessoaAtendida,
          DateTime dataHora, DateTime dataHoraCriacao, DateTime dataHoraExecucao)
        {
            var agendamento = new Agendamento(idAgendamento);
            
            agendamento.Servico = servico;
            agendamento.Colaborador = colaborador;
            agendamento.PessoaAtendida = pessoaAtendida;
            agendamento.DataHora = dataHora;
            agendamento.DataHoraCriacao = dataHoraCriacao;
            agendamento.DataHoraExecucao = dataHoraExecucao;

            return agendamento;
        }

        public void Alterar(Servico servico, Colaborador colaborador, string pessoaAtendida,
          DateTime dataHora, DateTime dataHoraCriacao, DateTime dataHoraExecucao)
        {
            Servico = servico;
            PessoaAtendida = pessoaAtendida;
            DataHora = dataHora;
            DataHoraCriacao = dataHoraCriacao;
            DataHoraExecucao = dataHoraExecucao;
        }
    }
}
