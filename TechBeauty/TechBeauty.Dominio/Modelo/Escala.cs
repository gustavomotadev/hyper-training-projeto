using System;

namespace TechBeauty.Dominio.Modelo
{
    public class Escala
    {
        public int Id { get; init; }
        public DateTime DataHoraEntrada { get; private set; }
        public DateTime DataHoraSaida { get; private set; }
        public Colaborador Colaborador { get; private set; }

        public Escala(int id)
        {
            Id = id;
        }
        public static Escala NovaEscala(int idEscala, DateTime dataHoraEntrada, DateTime dataHoraSaida, 
            Colaborador colaborador)
        {
            var escala = new Escala(idEscala);
            escala.DataHoraEntrada = dataHoraEntrada;
            escala.DataHoraEntrada = dataHoraSaida;
            escala.Colaborador = colaborador;
            return escala;
        }

        public void Alterar(DateTime dataHoraEntrada, DateTime dataHoraSaida,
            Colaborador colaborador)
        {
            DataHoraEntrada = dataHoraEntrada;
            DataHoraSaida = dataHoraSaida;
            Colaborador = colaborador;
        }

    }
}
