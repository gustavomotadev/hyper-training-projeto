using System.Collections.Generic;
using System.Linq;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dominio.Repositorio
{
    public class TipoContatoRepositorio
    {
        public List<TipoContato> TabelaTipoContato { get; private set; } = new List<TipoContato>();

        public TipoContatoRepositorio()
        {
            Preencher();
        }

        public List<TipoContato> Incluir(TipoContato tipoContato)
        {
            TabelaTipoContato.Add(tipoContato);
            return TabelaTipoContato;
        }

        public TipoContato SelecionarPorId(int id) => TabelaTipoContato.FirstOrDefault(x => x.Id == id);

        public void Alterar(int id, string valor)
        {
            SelecionarPorId(id).Alterar(valor);
        }
        public void Excluir(int id)
        {
            TabelaTipoContato.Remove(SelecionarPorId(id));
        }

        public void Preencher()
        {
            (int id, string valor)[] valoresTipoContato = 
                { 
                    (1, "Celular"), 
                    (2, "Telefone Fixo"), 
                    (3, "E-mail"), 
                    (4, "WhatsApp"), 
                    (5, "Telegram"), 
                    (6, "Facebook"), 
                    (7, "Instagram"), 
                    (8, "Twitter"), 
                    (9, "TikTok") 
                };

            foreach (var contato in valoresTipoContato)
            {
                Incluir(TipoContato.Criar(contato.id, contato.valor));
            }
        }
    }
}
