using System;

namespace TechBeauty.Dominio.Modelo
{
    public class Escala
    {
        public int Id { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime DataHoraSaida { get; set; }
        public Colaborador Colaborador { get; set; }
    }
}
