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
            string[] valoresTipoContato = { "Celular", "Telefone Fixo", "E-mail", "WhatsApp", "Telegram", "Facebook", "Instagram", "Twitter", "TikTok" };

            for (int i = 0; i < valoresTipoContato.Length; i++)
            {
                Incluir(TipoContato.Criar(i + 1, valoresTipoContato[i]));
            }
        }
    }
}
