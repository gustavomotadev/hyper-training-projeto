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

        public EscalaRepositorio(ColaboradorRepositorio repoColaborador)
        {
            Preencher(repoColaborador);
        }

        public void Incluir(Escala escala) => TabelaEscala.Add(escala);

        public Escala SelecionarPorId(int id) => TabelaEscala.FirstOrDefault(x => x.Id == id);

        public void Alterar(int id, DateTime dataHoraEntrada, DateTime dataHoraSaida,
            Colaborador colaborador) => SelecionarPorId(id).Alterar(dataHoraEntrada, dataHoraSaida, 
                colaborador);

        public void Excluir(int id) => TabelaEscala.Remove(SelecionarPorId(id));

        public void Preencher(ColaboradorRepositorio repoColaborador)
        {
            (DateTime dataHoraEntrada, DateTime dataHoraSaida,
            int idColaborador)[] valoresEscala =
            {
                (new DateTime(2021, 10, 21, 08, 30,00), new DateTime(2021, 10, 21, 15, 30, 00), 1)
            };

            for (int i = 0; i < valoresEscala.Length; i++)
            {
                var colaborador = repoColaborador.SelecionarPorId(valoresEscala[i].idColaborador);
                Incluir(Escala.Criar(i+1, valoresEscala[i].dataHoraEntrada,
                    valoresEscala[i].dataHoraSaida, colaborador));
            }
        }
    }
}
