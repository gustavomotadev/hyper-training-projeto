using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dominio.Repositorio
{
    public class EscalaRepositorio
    {
        public List<Escala> TabelaEscala { get; set; } = new List<Escala>();

        public EscalaRepositorio()
        {
            //incompleto
            Preencher();
        }

        public void Incluir(Escala escala) => TabelaEscala.Add(escala);

        public Escala SelecionarPorId(int id) => TabelaEscala.FirstOrDefault(x => x.Id == id);

        public void Alterar(int id, DateTime dataHoraEntrada, DateTime dataHoraSaida,
            Colaborador colaborador) => SelecionarPorId(id).Alterar(dataHoraEntrada, dataHoraSaida, colaborador);

        public void Excluir(int id) => TabelaEscala.Remove(SelecionarPorId(id));

        public void Preencher()
        {
            //incompleto
        }
    }
}
