using System.Collections.Generic;
using TechBeauty.Dominio.Modelo.Enumeradores;

namespace TechBeauty.Dominio.Modelo
{
    public class OrdemServico
    {
        public int Id { get; private set; }
        public decimal PrecoTotal { get; private set; }
        public int DuracaoTotal { get; private set; }
        public Cliente Cliente { get; private set; }
        public StatusOS StatusOS { get; private set; }
        public List<Agendamento> Agendamentos { get; private set; }

        public static OrdemServico Criar(int id, decimal precoTotal, 
            int duracaoTotal, Cliente cliente, StatusOS statusOs, List<Agendamento> agendamentos)
        {
            var os = new OrdemServico();
            os.Id = id;
            os.PrecoTotal = precoTotal;
            os.DuracaoTotal = duracaoTotal;
            os.Cliente = cliente;
            os.StatusOS = statusOs;
            os.Agendamentos = agendamentos;
            return os;
        }

        public void Alterar(decimal precoTotal, int duracaoTotal, Cliente cliente, StatusOS statusOs, 
            List<Agendamento> agendamentos)
        {
            PrecoTotal = precoTotal;
            DuracaoTotal = duracaoTotal;
            Cliente = cliente;
            StatusOS = statusOs;
            Agendamentos = agendamentos;
        }
    }
}
