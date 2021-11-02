using System.Collections.Generic;
using System.Linq;
using TechBeauty.Dominio.Financeiro;
using TechBeauty.Dominio.Modelo.Enumeracoes;

namespace TechBeauty.Dominio.Modelo
{
    public class OrdemServico
    {
        public int Id { get; init; }
        public int ClienteId { get; set; } //ef
        public Cliente Cliente { get; init; }
        public StatusOS StatusOS { get; private set; } = StatusOS.Pendente;
        public List<Agendamento> Agendamentos { get; private set; }
        public Pagamento Pagamento { get; set; } //ef
        public decimal PrecoTotal => Agendamentos.Sum(x => x.Servico.Preco);
        public int DuracaoTotal => Agendamentos.Sum(x => x.Servico.DuracaoEmMin);

        private OrdemServico(int id, Cliente cliente)
        {
            Id = id;
            Cliente = cliente;
        }

        public static OrdemServico NovaOS(int idDaOS, Cliente clienteDaOS, List<Agendamento> agendamentosIniciaisDaOS)
        {
            if (clienteDaOS != null &&
                agendamentosIniciaisDaOS != null &&
                agendamentosIniciaisDaOS.Count > 0 &&
                !agendamentosIniciaisDaOS.Any(x => x == null))
            {
                var os = new OrdemServico(idDaOS, clienteDaOS);
                os.Agendamentos = agendamentosIniciaisDaOS;
                return os;
            }

            return null;
            
        }

        public void AlterarStatusDaOS(StatusOS statusDaOS)
        {
            StatusOS = statusDaOS;
        }

        public bool AdicionarAgendamento(Agendamento agendamento)
        {
            if (agendamento != null)
            {
                Agendamentos.Add(agendamento);
                return true;
            }

            return false; 
        }

        public Agendamento ObterAgendamentoPorId(int id) {
            return Agendamentos.FirstOrDefault(x => x.Id == id);
        }


        public bool RemoverAgendamento(int id)
        {
            if (Agendamentos.Count > 1)
            {
                Agendamentos.Remove(ObterAgendamentoPorId(id));
                return true;
            }
            return false;
        }

        public bool RemoverAgendamento(Agendamento agendamentoAntigo)
        {
            if (Agendamentos.Count > 1)
            {
                Agendamentos.Remove(agendamentoAntigo);
                return true;
            }

            return false;
        }

    }
}
