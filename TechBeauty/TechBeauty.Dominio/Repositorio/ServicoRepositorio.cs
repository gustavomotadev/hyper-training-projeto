using System.Collections.Generic;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dominio.Repositorio
{
    public class ServicoRepositorio
    {
        public List<Servico> TabelaServico { get; private set; } = new List<Servico>();

        public ServicoRepositorio()
        {
            Preencher();
        }

        public List<Servico> Incluir(Servico servico)
        {
            TabelaServico.Add(servico);
            return TabelaServico;
        }

        public void Preencher()
        {
            (string, decimal, string, int)[] valoresServico =
                {
                ("Corte", 15.0M, "aaa", 20),
                ("Pintura", 15.0M, "aaa", 20),
                ("Manicure", 15.0M, "aaa", 20)
                };

            for (int i = 0; i < valoresServico.Length; i++)
            {
                Incluir(Servico.Criar(i + 1, valoresServico[i].Item1, valoresServico[i].Item2, valoresServico[i].Item3, valoresServico[i].Item4));
            }
        }
    }
}
