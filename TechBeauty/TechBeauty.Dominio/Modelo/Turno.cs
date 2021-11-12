using System;
using System.Text.Json.Serialization;

namespace TechBeauty.Dominio.Modelo
{
    public class Turno
    {
        public int Id { get; init; }
        public DateTime DataHoraEntrada { get; init; }
        public DateTime DataHoraSaida { get; init; }
        public int ColaboradorId { get; private set; } //ef
        public Colaborador Colaborador { get; init; }
        public DateTime? RegistroEntrada { get; private set; } = null;
        public DateTime? RegistroSaida { get; private set; } = null;
        public int ExpedienteId { get; private set; } //ef
        [JsonIgnore]
        public Expediente Expediente { get; private set; } //ef

        private Turno() { }

        private Turno(DateTime dataHoraEntrada, DateTime dataHoraSaida,
            int colaboradorId, int expedienteId)
        {
            DataHoraEntrada = dataHoraEntrada;
            DataHoraSaida = dataHoraSaida;
            ColaboradorId = colaboradorId;
            ExpedienteId = expedienteId;
        }

        public static Turno NovoTurno(DateTime dataHoraEntrada, 
            DateTime dataHoraSaida, int colaboradorId, int expedienteId)
        {
                var turno = new Turno(dataHoraEntrada, dataHoraSaida, colaboradorId, expedienteId);
                return turno;
        }

        public void RegistrarPontoEntrada(DateTime dataHora) => 
            RegistroEntrada = dataHora;

        public void RegistrarPontoSaida(DateTime dataHora) =>
            RegistroSaida = dataHora;

    }
}
