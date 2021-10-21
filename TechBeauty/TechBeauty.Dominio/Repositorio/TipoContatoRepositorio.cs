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

        public void Alterar(int id, string valor)
        {
            TabelaTipoContato.FirstOrDefault(x => x.Id == id).Alterar(id, valor);
        }

        public TipoContato SelecionarPorId(int id)
        {
            return TabelaTipoContato.FirstOrDefault(x => x.Id == id);
        }

        public void Excluir(int id)
        {
            TabelaTipoContato.Remove(SelecionarPorId(id));
        }

        public void Preencher()
        {
            string[] valoresTipoContato = { "Celular", "Telefone Fixo", "E-mail", "WhatsApp", "Telegram", "Facebook", "Instagram", "Twitter", "TikTok" };

            for (int i = 0; i < valoresTipoContato.Length; i++)
            {
                Incluir(TipoContato.Criar(i + 1, valoresTipoContato[i]));
            }
        }
    }
}
