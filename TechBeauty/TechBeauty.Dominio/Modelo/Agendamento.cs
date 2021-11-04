using System;
using System.Linq;
using TechBeauty.Dominio.Modelo.Enumeracoes;

namespace TechBeauty.Dominio.Modelo
{
    public class Agendamento
    {
        public int Id { get; init; }
        public int ServicoId { get; set; } //ef
        public Servico Servico { get; init; }
        public int ColaboradorId { get; set; } //ef
        public Colaborador Colaborador { get; init; }
        public int OrdemServicoId { get; set; } //ef
        public OrdemServico OrdemServico { get; set; } //ef
        public int ExpedienteId { get; set; } //ef
        public Expediente Expediente { get; set; } //ef
        public string PessoaAtendida { get; init; }
        public DateTime DataHoraCriacao { get; init; }
        public DateTime DataHoraExecucao { get; init; }
        public StatusAgendamento StatusAgendamento { get; set; } = StatusAgendamento.Agendado;
        public int DuracaoEmMin => Servico.DuracaoEmMin; //fora do banco
        public DateTime DataHoraFinal => DataHoraExecucao.AddMinutes(DuracaoEmMin); //fora do banco

        private Agendamento() { }

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
