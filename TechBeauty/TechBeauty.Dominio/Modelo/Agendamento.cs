using System;

namespace TechBeauty.Dominio.Modelo
{
    public class Agendamento
    {
        public int Id { get; private set; }
        public Servico Servico { get; private set; }
        public Colaborador Colaborador { get; private set; }
        public string PessoaAtendida { get; private set; }
        public DateTime DataHora { get; private set; }
        public OrdemServico OrdemServico { get; private set; }
        public DateTime DataHoraCriacao { get; private set; }
        public DateTime DataHoraExecucao { get; private set; }
    }
}
