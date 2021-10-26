using System;

namespace TechBeauty.Dominio.Modelo
{
    public class Turno
    {
        public int Id { get; init; }
        public DateTime DataHoraEntrada { get; init; }
        public DateTime DataHoraSaida { get; init; }
        public Colaborador Colaborador { get; init; }
        public bool HorarioCumprido { get; private set; }

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
                turno.HorarioCumprido = false;
                return turno;
            }
            else
            {
                return null;
            }
        }

        public void RegistrarPonto() => HorarioCumprido = true;

    }
}
