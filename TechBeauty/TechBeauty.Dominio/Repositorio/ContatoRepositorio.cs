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

        public List<Contato> Incluir(Contato contato)
        {
            TabelaContato.Add(contato);
            return TabelaContato;
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
            (int, string)[] valoresContato = { (3, "abc@mail.com") };

            for (int i = 0; i < valoresContato.Length; i++)
            {
                //puxar o tipocontato pelo Item1
                Incluir(Contato.Criar(i + 1, repoTipoContato.SelecionarPorId(valoresContato[i].Item1), valoresContato[i].Item2));
            }
        }
    }
}
