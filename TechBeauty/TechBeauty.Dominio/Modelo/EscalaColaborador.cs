using System;

namespace TechBeauty.Dominio.Modelo
{
    public class EscalaColaborador
    {
        public int Id { get; init; }
        public DateTime DataHoraEntrada { get; init; }
        public DateTime DataHoraSaida { get; init; }
        public Colaborador Colaborador { get; init; }
        public bool HorarioCumprido { get; private set; }

        private EscalaColaborador(int id, DateTime dataHoraEntrada, DateTime dataHoraSaida,
            Colaborador colaborador)
        {
            Id = id;
            DataHoraEntrada = dataHoraEntrada;
            DataHoraEntrada = dataHoraSaida;
            Colaborador = colaborador;
        }
        public static EscalaColaborador NovaEscala(int idEscala, DateTime dataHoraEntrada, 
            DateTime dataHoraSaida, Colaborador colaborador)
        {
            var escala = new EscalaColaborador(idEscala, dataHoraEntrada, dataHoraSaida, colaborador);
            escala.HorarioCumprido = false;
            return escala;
        }

        public void RegistrarPonto() => HorarioCumprido = true;

    }
}
