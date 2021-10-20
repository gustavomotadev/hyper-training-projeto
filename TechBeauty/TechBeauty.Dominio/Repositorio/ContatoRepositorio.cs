using System.Collections.Generic;
using System.Linq;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dominio.Repositorio
{
    public class ContatoRepositorio
    {
        public List<Contato> TabelaContato { get; private set; } = new List<Contato>();
        public List<TipoContato> TabelaTipoContato { get; private set; }

        public ContatoRepositorio(List<TipoContato> tabelaTipoContato)
        {
            TabelaTipoContato = tabelaTipoContato;
            Preencher();
        }

        public List<Contato> Incluir(Contato contato)
        {
            TabelaContato.Add(contato);
            return TabelaContato;
        }

        public void Preencher()
        {
            (int, string)[] valoresContato = { (3, "abc@mail.com") };

            for (int i = 0; i < valoresContato.Length; i++)
            {
                //puxar o tipocontato pelo Item1
                Incluir(Contato.Criar(i + 1, TabelaTipoContato.FirstOrDefault(x => x.Id == valoresContato[i].Item1), valoresContato[i].Item2));
            }
        }
    }
}
