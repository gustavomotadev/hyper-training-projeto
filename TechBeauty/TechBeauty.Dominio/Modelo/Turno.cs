using System;

namespace TechBeauty.Dominio.Modelo
{
    public class Turno
    {
        public int Id { get; init; }
        public DateTime DataHoraEntrada { get; init; }
        public DateTime DataHoraSaida { get; init; }
        public int ColaboradorId { get; set; } //ef
        public Colaborador Colaborador { get; init; }
        public DateTime? RegistroEntrada { get; set; } = null;
        public DateTime? RegistroSaida { get; set; } = null;
        public int ExpedienteId { get; set; } //ef
        public Expediente Expediente { get; set; } //ef

        private Turno() { }

        private Turno(int id, DateTime dataHoraEntrada, DateTime dataHoraSaida,
            Colaborador colaborador)
        {
            Id = id;
            DataHoraEntrada = dataHoraEntrada;
            DataHoraEntrada = dataHoraSaida;
            Colaborador = colaborador;
        }

        public static Turno NovoTurno(int idTurno, DateTime dataHoraEntrada, 
            DateTime dataHoraSaida, Colaborador colaborador)
        {
            if (colaborador != null &&
                dataHoraEntrada.Date == dataHoraSaida.Date &&
                dataHoraEntrada < dataHoraSaida)
            {
                var turno = new Turno(idTurno, dataHoraEntrada, dataHoraSaida, colaborador);
                return turno;
            }
            else
            {
                return null;
            }
        }

        public void RegistrarPontoEntrada(DateTime dataHora) => 
            RegistroEntrada = dataHora;

        public void RegistrarPontoSaida(DateTime dataHora) =>
            RegistroSaida = dataHora;

    }
}
