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
            if (dataHoraEntrada.Date == dataHoraSaida.Date &&
                dataHoraEntrada < dataHoraSaida)
            {
                var turno = new Turno(dataHoraEntrada, dataHoraSaida, colaboradorId);
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
