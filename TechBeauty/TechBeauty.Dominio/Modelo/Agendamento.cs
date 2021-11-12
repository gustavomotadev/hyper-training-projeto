using System;
using System.Linq;
using System.Text.Json.Serialization;
using TechBeauty.Dominio.Modelo.Enumeracoes;

namespace TechBeauty.Dominio.Modelo
{
    public class Agendamento
    {
        public int Id { get; init; }
        public int ServicoId { get; private set; } //ef
        public Servico Servico { get; init; }
        public int ColaboradorId { get; private set; } //ef
        public Colaborador Colaborador { get; init; }
        public int OrdemServicoId { get; private set; } //ef
        public OrdemServico OrdemServico { get; private set; } //ef
        public int ExpedienteId { get; private set; } //ef
        [JsonIgnore]
        public Expediente Expediente { get; private set; } //ef
        public string PessoaAtendida { get; init; }
        public DateTime DataHoraCriacao { get; init; }
        public DateTime DataHoraExecucao { get; init; }
        public StatusAgendamento StatusAgendamento { get; set; } = StatusAgendamento.Agendado;
        [JsonIgnore] //TODO AJUSTAR ISSO
        public int DuracaoEmMin => (Servico == null) ? 0 : Servico.DuracaoEmMin; //fora do banco //TODO GAMBIARRA
        public DateTime DataHoraFinal => DataHoraExecucao.AddMinutes(DuracaoEmMin); //fora do banco

        private Agendamento() { }

        private Agendamento(int servicoId, int colaboradorId,
            string pessoaAtendida, DateTime dataHoraCriacao, DateTime dataHoraExecucao)
        {
            ServicoId = servicoId;
            ColaboradorId = colaboradorId;
            PessoaAtendida = pessoaAtendida;
            DataHoraCriacao = dataHoraCriacao;
            DataHoraExecucao = dataHoraExecucao;
        }

        public static Agendamento NovoAgendamento(int servicoId, int colaboradorId, int ordemServicoId, 
            int expedienteId, string pessoaAtendida, DateTime dataHoraCriacao, DateTime dataHoraExecucao)
        {
            var agendamento = new Agendamento(servicoId, colaboradorId, pessoaAtendida,
                dataHoraCriacao, dataHoraExecucao);
            agendamento.OrdemServicoId = ordemServicoId;
            agendamento.ExpedienteId = expedienteId;
            return agendamento;
        }    

        public void AlterarStatusAgendamento(StatusAgendamento statusDoAgendamento) =>
            StatusAgendamento = statusDoAgendamento;
    }
}
