using System;

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
        public Expediente Expediente { get; private set; } //ef

        private Turno() { }

        private Turno(DateTime dataHoraEntrada, DateTime dataHoraSaida,
            int colaboradorId)
        {
            DataHoraEntrada = dataHoraEntrada;
            DataHoraEntrada = dataHoraSaida;
            ColaboradorId = colaboradorId;
        }

        public static Turno NovoTurno(DateTime dataHoraEntrada, 
            DateTime dataHoraSaida, int colaboradorId)
        {
                var turno = new Turno(dataHoraEntrada, dataHoraSaida, colaboradorId);
                return turno;
        }

        public void RegistrarPontoEntrada(DateTime dataHora) => 
            RegistroEntrada = dataHora;

        public void RegistrarPontoSaida(DateTime dataHora) =>
            RegistroSaida = dataHora;

    }
}
