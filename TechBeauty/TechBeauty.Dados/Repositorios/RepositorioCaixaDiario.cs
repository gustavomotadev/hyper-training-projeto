using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBeauty.Dominio.Financeiro;

namespace TechBeauty.Dados.Repositorios
{
    public class RepositorioCaixaDiario : RepositorioBase<CaixaDiario>
    {
        public override CaixaDiario SelecionarCompletoPorChave(params object[] chave)
        {
            var caixadiario = SelecionarPorChave(chave);

            if (caixadiario is null) return null;

            _contexto.Entry(caixadiario).Collection(c => c.Pagamentos).Load();
            _contexto.Entry(caixadiario).Collection(c => c.Remuneracoes).Load();

            for (int i = 0; i < caixadiario.Remuneracoes.Count; i++)
            {
                _contexto.Entry(caixadiario.Remuneracoes[i]).Reference(r => r.Colaborador).Load();
                _contexto.Entry(caixadiario.Remuneracoes[i].Colaborador).Reference(c => c.PadraoRemuneracao).Load();
                _contexto.Entry(caixadiario.Remuneracoes[i]).Collection(r => r.Servicos).Load();

                caixadiario.Remuneracoes[i].CalcularTudo();
            }

            caixadiario.CalcularTudo();

            return caixadiario;
        }
    }
}
