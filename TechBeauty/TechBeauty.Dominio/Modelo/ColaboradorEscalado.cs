using System;

namespace TechBeauty.Dominio.Modelo
{
    public class ColaboradorEscalado
    {
        public int Id { get; init; }
        public DateTime DataHoraEntrada { get; init; }
        public DateTime DataHoraSaida { get; init; }
        public Colaborador Colaborador { get; init; }
        public bool HorarioCumprido { get; private set; }

        private ColaboradorEscalado(int id, DateTime dataHoraEntrada, DateTime dataHoraSaida,
            Colaborador colaborador)
        {
            Id = id;
            DataHoraEntrada = dataHoraEntrada;
            DataHoraEntrada = dataHoraSaida;
            Colaborador = colaborador;
        }
        public static ColaboradorEscalado NovaEscala(int idEscala, DateTime dataHoraEntrada, 
            DateTime dataHoraSaida, Colaborador colaborador)
        {
            var escala = new ColaboradorEscalado(idEscala, dataHoraEntrada, dataHoraSaida, colaborador);
            escala.HorarioCumprido = false;
            return escala;
        }

        public void RegistrarPonto() => HorarioCumprido = true;

    }
}
