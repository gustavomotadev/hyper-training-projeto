using System.Collections.Generic;
using System.Linq;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dominio.Repositorio
{
    public class ContatoRepositorio
    {
        public List<Contato> TabelaContato { get; private set; } = new List<Contato>();

        public ContatoRepositorio(TipoContatoRepositorio repoTipoContato)
        {
            Preencher(repoTipoContato);
        }

        public void Incluir(Contato contato)
        {
            TabelaContato.Add(contato);
            
        }

        public Contato SelecionarPorId(int id) => TabelaContato.FirstOrDefault(x => x.Id == id);

        public void Alterar(int id, TipoContato tipo, string valor)
        {
            SelecionarPorId(id).Alterar(tipo, valor);
        }

        public void Excluir(int id)
        {
            TabelaContato.Remove(SelecionarPorId(id));
        }

        public void Preencher(TipoContatoRepositorio repoTipoContato)
        {
            (int id, int idTipoContato, string valor)[] valoresContato = 
                { 
                    (1, 3, "abc@mail.com") 
                };

            foreach (var contato in valoresContato)
            {
                Incluir(Contato.Criar(contato.id, repoTipoContato.SelecionarPorId(contato.idTipoContato), contato.valor));
            }
        }
    }
}
