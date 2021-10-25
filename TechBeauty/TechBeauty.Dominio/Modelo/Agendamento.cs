using System;
using System.Linq;
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
            string pessoaAtendida, DateTime dataHoraCriacao, DateTime dataHoraExecucao)
        {
            if (servico != null &&
                colaborador != null &&
                pessoaAtendida != null &&
                colaborador.Servicos.Any(x => x.Id == servico.Id) &&
                !String.IsNullOrWhiteSpace(pessoaAtendida) &&
                dataHoraExecucao.AddMinutes(servico.DuracaoEmMin).Date == dataHoraExecucao.Date)
            {
                return new Agendamento(idDoAgendamento, servico, colaborador, pessoaAtendida,
                    dataHoraCriacao, dataHoraExecucao);
            }
            else
            {
                return null;
            }
        }    

        public void AlterarStatusAgendamento(StatusAgendamento statusDoAgendamento) =>
            StatusAgendamento = statusDoAgendamento;
    }
}
