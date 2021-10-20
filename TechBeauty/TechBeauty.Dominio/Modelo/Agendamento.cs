using System;

namespace TechBeauty.Dominio.Modelo
{
    public class Agendamento
    {
        public int Id { get; set; }
        public Servico Servico { get; set; }
        public Colaborador Colaborador { get; set; }
        public string PessoaAtendida { get; set; }
        public DateTime DataHora { get; set; }
        public OrdemServico OrdemServico { get; set; }
        public DateTime DataHoraCriacao { get; set; }
        public DateTime DataHoraExecucao { get; set; }
    }
}
