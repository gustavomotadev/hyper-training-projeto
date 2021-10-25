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
        public List<ColaboradorEscalado> TabelaEscala { get; set; } = new List<ColaboradorEscalado>();

        public EscalaRepositorio(ColaboradorRepositorio repoColaborador)
        {
            Preencher(repoColaborador);
        }

        public void Incluir(ColaboradorEscalado escala) => TabelaEscala.Add(escala);

        public ColaboradorEscalado SelecionarPorId(int id) => TabelaEscala.FirstOrDefault(x => x.Id == id);

        public void Alterar(int id, DateTime dataHoraEntrada, DateTime dataHoraSaida,
            Colaborador colaborador) => SelecionarPorId(id).Alterar(dataHoraEntrada, dataHoraSaida, 
                colaborador);

        public void Excluir(int id) => TabelaEscala.Remove(SelecionarPorId(id));

        public void Preencher(ColaboradorRepositorio repoColaborador)
        {
            (int id, DateTime dataHoraEntrada, DateTime dataHoraSaida,
            int idColaborador)[] valoresEscala =
            {
                (1, new DateTime(2021, 10, 21, 08, 30,00), new DateTime(2021, 10, 21, 15, 30, 00), 1)
            };

            foreach (var escala in valoresEscala)
            {
                var colaborador = repoColaborador.SelecionarPorId(escala.idColaborador);
                Incluir(ColaboradorEscalado.Criar(escala.id, escala.dataHoraEntrada,
                    escala.dataHoraSaida, colaborador));
            }
        }
    }
}
