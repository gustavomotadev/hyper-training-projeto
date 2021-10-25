using System;
using System.Collections.Generic;
using System.Linq;

namespace TechBeauty.Dominio.Modelo
{
    class Expediente
    {
        public int Id { get; set; }
        public DateTime DataHoraAbertura { get; init; }
        public DateTime DataHoraFechamento { get; init; }
        public List<ColaboradorEscalado> ColaboradoresEscalados { get; private set; }
        public List<Agendamento> AgendamentosDoDia { get; private set; } = new List<Agendamento>();

        private Expediente(int id, DateTime dataHoraAbertura, DateTime dataHoraFechamento)
        {
            Id = id;
            DataHoraAbertura = dataHoraAbertura;
            DataHoraFechamento = dataHoraFechamento;
        }

        public void NovoExpediente(int id, DateTime dataHoraAbertura, DateTime dataHoraFechamento, 
            List<ColaboradorEscalado> colaboradoresEscalados)
        {
            var expediente = new Expediente(id, dataHoraAbertura, dataHoraFechamento);
            expediente.ColaboradoresEscalados = colaboradoresEscalados;
        }

        public void AdicionarColaboradorEscalado(ColaboradorEscalado colaboradorEscalado) => 
            ColaboradoresEscalados.Add(colaboradorEscalado);

        public ColaboradorEscalado ObterColaboradorEscaladoPorId(int id) => 
            ColaboradoresEscalados.FirstOrDefault(x => x.Id == id);

        public void AdicionarAgendamento(Agendamento agendamento) =>
            AgendamentosDoDia.Add(agendamento);

        public Agendamento ObterAgendamentoPorId(int id) =>
            AgendamentosDoDia.FirstOrDefault(x => x.Id == id);


    }
}
