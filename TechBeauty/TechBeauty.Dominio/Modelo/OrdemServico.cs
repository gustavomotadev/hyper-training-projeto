using System.Collections.Generic;
using System.Linq;
using TechBeauty.Dominio.Financeiro;
using TechBeauty.Dominio.Modelo.Enumeracoes;

namespace TechBeauty.Dominio.Modelo
{
    public class OrdemServico
    {
        public int Id { get; init; }
        public int ClienteId { get; private set; } //ef
        public Cliente Cliente { get; init; }
        public StatusOS StatusOS { get; private set; } = StatusOS.Pendente;
        public List<Agendamento> Agendamentos { get; private set; } = new List<Agendamento>();
        public Pagamento Pagamento { get; private set; } //ef
        public decimal PrecoTotal => Agendamentos.Sum(x => x.Servico.Preco);
        public int DuracaoTotal => Agendamentos.Sum(x => x.Servico.DuracaoEmMin);

        private OrdemServico() { }

        private OrdemServico(int clienteId)
        {
            ClienteId = clienteId;
        }

        public static OrdemServico NovaOS(int clienteIdDaOS)
        {
            
                var os = new OrdemServico(clienteIdDaOS);
                return os;
            
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
    }
}
