using System;
using System.Collections.Generic;
using System.Linq;

namespace TechBeauty.Dominio.Modelo
{
    public class Expediente
    {
        public int Id { get; set; }
        public DateTime DataHoraAbertura { get; init; }
        public DateTime DataHoraFechamento { get; init; }
        public List<Turno> Turnos { get; private set; }
        public List<Agendamento> Agendamentos { get; private set; } = new List<Agendamento>();

        private Expediente() { }

        private Expediente(int id, DateTime dataHoraAbertura, DateTime dataHoraFechamento)
        {
            Id = id;
            DataHoraAbertura = dataHoraAbertura;
            DataHoraFechamento = dataHoraFechamento;
        }

        public Expediente NovoExpediente(int id, DateTime dataHoraAbertura, DateTime dataHoraFechamento,
            List<Turno> turnos)
        {
            if (dataHoraAbertura.Date == dataHoraFechamento.Date &&
                dataHoraAbertura < dataHoraFechamento &&
                turnos != null &&
                turnos.Count > 0 &&
                !turnos.Any(x => x == null))
            {
                var expediente = new Expediente(id, dataHoraAbertura, dataHoraFechamento);
                expediente.Turnos = turnos;
                return expediente;
            }
            else
            {
                return null;
            }
        }

        public Turno ObterTurnoPorId(int id) =>
            Turnos.FirstOrDefault(x => x.Id == id);

        public bool AdicionarTurno(Turno turno)
        {
            if (turno != null &&
                turno.DataHoraEntrada.Date >= DataHoraAbertura.Date &&
                turno.DataHoraSaida.Date <= DataHoraFechamento.Date &&
                !Turnos.Any(x => x.Colaborador.Id == turno.Colaborador.Id))
            {
                Turnos.Add(turno);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Agendamento ObterAgendamentoPorId(int id) =>
            Agendamentos.FirstOrDefault(x => x.Id == id);

        public List<Agendamento> AgendamentosDoTurno(Turno turno)
        {
            if (turno != null)
            {
                return Agendamentos.Where(x => x.Colaborador.Id == turno.Colaborador.Id).ToList();
            }
            else
            {
                return null;
            }
        }

        private bool AgendamentoCabeNoTurno(Turno turno, Agendamento agendamento)
        {
            if (turno != null &&
                agendamento != null)
            {
                if (agendamento.DataHoraExecucao >= turno.DataHoraEntrada &&
                    agendamento.DataHoraFinal <= turno.DataHoraSaida)
                {
                    var agendamentosFeitos = AgendamentosDoTurno(turno);
                    if (agendamentosFeitos.Count == 0)
                    {
                        return true;
                    }
                    else
                    {
                        if (agendamento.DataHoraFinal <= agendamentosFeitos[1].DataHoraExecucao ||
                            agendamento.DataHoraExecucao >= agendamentosFeitos[-1].DataHoraFinal)
                        {
                            return true;
                        }
                        else if (agendamentosFeitos.Count > 1)
                        {
                            for (int i = 1; i < agendamentosFeitos.Count; i++)
                            {
                                if (agendamento.DataHoraExecucao >= agendamentosFeitos[i - 1].DataHoraFinal &&
                                    agendamento.DataHoraFinal <= agendamentosFeitos[i].DataHoraExecucao)
                                {
                                    return true;
                                }
                            }
                            return false;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool AdicionarAgendamento(Agendamento agendamento)
        {
            if (agendamento != null)
            {
                var turno =
                Turnos.FirstOrDefault(x => x.Colaborador.Id == agendamento.Colaborador.Id);
                if (turno != null && AgendamentoCabeNoTurno(turno, agendamento))
                {
                    Agendamentos.Add(agendamento);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //TODO: reimplementar essa funcao
        /*
        public List<Turno> ObterPrestadoresDeServico(List<Servico> servicos)
        {
            if (servicos != null &&
                servicos.Count > 0 &&
                !servicos.Any(x => x == null))
            {
                var prestadores = new List<Turno>();
                foreach (var turno in Turnos)
                {
                    if (!Enumerable.Except(servicos, turno.Colaborador.Servicos).Any())
                    {
                        prestadores.Add(turno);
                    }
                }
                return prestadores;
            }
            else
            {
                return null;
            }
        }
        */
    }
}
