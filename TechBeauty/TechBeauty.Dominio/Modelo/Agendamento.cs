using System;

namespace TechBeauty.Dominio.Modelo
{
    public class Agendamento
    {
        public int Id { get; private set; }
        public Servico Servico { get; private set; }
        public Colaborador Colaborador { get; private set; }
        public string PessoaAtendida { get; private set; }
        public DateTime DataHora { get; private set; }
        public OrdemServico OrdemServico { get; private set; }
        public DateTime DataHoraCriacao { get; private set; }
        public DateTime DataHoraExecucao { get; private set; }

        public static Agendamento Criar(int id, Servico servico, Colaborador colaborador, string pessoaAtendida,
          DateTime dataHora, OrdemServico ordemServico, DateTime dataHoraCriacao, DateTime dataHoraExecucao)
        {
            var agendamento = new Agendamento();
            agendamento.Id = id;
            agendamento.Servico = servico;
            agendamento.Colaborador = colaborador;
            agendamento.PessoaAtendida = pessoaAtendida;
            agendamento.DataHora = dataHora;
            agendamento.OrdemServico = ordemServico;
            agendamento.DataHoraCriacao = dataHoraCriacao;
            agendamento.DataHoraExecucao = dataHoraExecucao;

            return agendamento;
        }

        public void Alterar(Servico servico, Colaborador colaborador, string pessoaAtendida,
          DateTime dataHora, OrdemServico ordemServico, DateTime dataHoraCriacao, DateTime dataHoraExecucao)
        {
            Servico = servico;
            PessoaAtendida = pessoaAtendida;
            DataHora = dataHora;
            OrdemServico = ordemServico;
            DataHoraCriacao = dataHoraCriacao;
            DataHoraExecucao = dataHoraExecucao;
        }
    }
}
