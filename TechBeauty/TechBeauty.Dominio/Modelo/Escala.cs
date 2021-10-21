using System;

namespace TechBeauty.Dominio.Modelo
{
    public class Escala
    {
        public int Id { get; private set; }
        public DateTime DataHoraEntrada { get; private set; }
        public DateTime DataHoraSaida { get; private set; }
        public Colaborador Colaborador { get; private set; }
    }
}
