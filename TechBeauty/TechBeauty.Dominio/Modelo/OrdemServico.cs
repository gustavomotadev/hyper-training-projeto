using System.Collections.Generic;
using TechBeauty.Dominio.Modelo.Enumeradores;

namespace TechBeauty.Dominio.Modelo
{
    public class OrdemServico
    {
        public int Id { get; init; }
        public decimal PrecoTotal { get; }
        public int DuracaoTotal { get; }
        public Cliente Cliente { get; init; }
        public StatusOS StatusOS { get; private set; } = StatusOS.Pendente;
        public List<Agendamento> Agendamentos { get; private set; }

        private OrdemServico(int id, Cliente cliente)
        {
            Id = id;
            Cliente = cliente;
        }

        public static OrdemServico NovaOS(int idDaOS, Cliente clienteDaOS, List<Agendamento> agendamentosIniciaisDaOS)
        {
            var os = new OrdemServico(idDaOS, clienteDaOS);
            os.Agendamentos = agendamentosIniciaisDaOS;
            return os;
        }

        public void AlterarStatusDaOS(StatusOS statusDaOS)
        {
            StatusOS = statusDaOS;
        }

        public void AdicionarAgendamento(Agendamento agendamento)
        {
            Agendamentos.Add(agendamento);
        }
    }
}
