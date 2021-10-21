using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBeauty.Dominio.Modelo;
using TechBeauty.Dominio.Modelo.Enumeradores;

namespace TechBeauty.Dominio.Repositorio
{
    public class OSRepositorio
    {
        public List<OrdemServico> TabelaOS { get; private set; } = new List<OrdemServico>();

        public List<Cliente> TabelaCliente { get; private set; }

        public OSRepositorio(List<Cliente> tabelaCliente)
        {
            TabelaCliente = tabelaCliente;
            Preencher();
        }

        public List<OrdemServico> Incluir(OrdemServico os)
        {
            TabelaOS.Add(os);
            return TabelaOS;
        }

        public OrdemServico SelecionarPorId(int id) => TabelaOS.FirstOrDefault(x => x.Id == id);

        public void Alterar(int id, decimal precoTotal,
            int duracaoTotal, Cliente cliente, StatusOS statusOs)
        {
            SelecionarPorId(id).Alterar(precoTotal, duracaoTotal, cliente, statusOs);
        }

        public void Excluir(int id)
        {
            TabelaOS.Remove(SelecionarPorId(id));
        }

        public void Preencher()
        {

        }
    }
}
