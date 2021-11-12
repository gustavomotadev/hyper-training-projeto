using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBeauty.Dominio.Modelo;
using Microsoft.EntityFrameworkCore;

namespace TechBeauty.Dados.Repositorios
{
    public class RepositorioExpediente : RepositorioBase<Expediente>
    {
        public override Expediente SelecionarCompletoPorChave(params object[] chave)
        {
            var expediente = SelecionarPorChave(chave);

            if (expediente is null) return null;

            _contexto.Entry(expediente).Collection(e => e.Turnos).Load();
            _contexto.Entry(expediente).Collection(e => e.Agendamentos).Load();

            /*
            //teste de carregar mais níveis adentro
            for (int i = 0; i < expediente.Turnos.Count; i++)
            {
                _contexto.Entry(expediente.Turnos[i]).Reference(t => t.Colaborador).Load();
            }
            */

            return expediente;
        }

    }
}
