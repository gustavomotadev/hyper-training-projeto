using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dominio.Repositorio
{
    public class ClienteRepositorio
    {
        public List<Cliente> TabelaCliente { get; private set; } = new List<Cliente>();

        public ClienteRepositorio()
        {
            Preencher();
        }

        public void Incluir(Cliente cliente) => TabelaCliente.Add(cliente);

        public Cliente SelecionarPorId(int id) => TabelaCliente.FirstOrDefault(x => x.Id == id);

        public void Alterar(int id, string nome, string cpf, DateTime dataNascimento, 
            List<Contato> contatos)
        {
            SelecionarPorId(id).Alterar(nome, cpf, dataNascimento, contatos);
        }

        public void Exlucir(int id) => TabelaCliente.Remove(SelecionarPorId(id)); 
        
        public void Preencher()
        {

        }
    }
}
