using System;

namespace TechBeauty.Dominio.Modelo
{
    public class Escalado
    {
        public int Id { get; init; }
        public DateTime DataHoraEntrada { get; init; }
        public DateTime DataHoraSaida { get; init; }
        public Colaborador Colaborador { get; init; }
        public bool HorarioCumprido { get; private set; }

        private Escalado(int id, DateTime dataHoraEntrada, DateTime dataHoraSaida,
            Colaborador colaborador)
        {
            Id = id;
            DataHoraEntrada = dataHoraEntrada;
            DataHoraEntrada = dataHoraSaida;
            Colaborador = colaborador;
        }

        public static Escalado NovaEscala(int idEscala, DateTime dataHoraEntrada, 
            DateTime dataHoraSaida, Colaborador colaborador)
        {
            if (colaborador != null &&
                dataHoraEntrada.Date == dataHoraSaida.Date &&
                dataHoraEntrada < dataHoraSaida)
            {
                var escala = new Escalado(idEscala, dataHoraEntrada, dataHoraSaida, colaborador);
                escala.HorarioCumprido = false;
                return escala;
            }
            else
            {
                return null;
            }
        }

        public void RegistrarPonto() => HorarioCumprido = true;

    }
}
