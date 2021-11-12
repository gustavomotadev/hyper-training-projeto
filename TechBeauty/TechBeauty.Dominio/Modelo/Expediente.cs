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
        public List<Turno> Turnos { get; private set; } = new List<Turno>();
        public List<Agendamento> Agendamentos { get; private set; } = new List<Agendamento>();

        private Expediente() { }

        private Expediente(DateTime dataHoraAbertura, DateTime dataHoraFechamento)
        {
            DataHoraAbertura = dataHoraAbertura;
            DataHoraFechamento = dataHoraFechamento;
        }

        public static Expediente NovoExpediente(DateTime dataHoraAbertura, DateTime dataHoraFechamento)
        {
                var expediente = new Expediente(dataHoraAbertura, dataHoraFechamento);
                return expediente;
        }

        public Turno ObterTurnoPorId(int id) =>
            Turnos.FirstOrDefault(x => x.Id == id);

        //TO DO - AlterarExpediente();

        /*
        public bool AdicionarTurno(Turno turno)
        {
            if (turno != null &&
                turno.DataHoraEntrada.Date >= DataHoraAbertura.Date &&
                turno.DataHoraSaida.Date <= DataHoraFechamento.Date &&
                !Turnos.Any(x => x.ColaboradorId == turno.ColaboradorId))
            {
                Turnos.Add(turno);
                return true;
            }
            else
            {
                return false;
            }
        }
        */

        public bool TurnoCabe(Turno turno)
        {
            if (turno != null &&
                turno.DataHoraEntrada >= DataHoraAbertura &&
                turno.DataHoraSaida <= DataHoraFechamento &&
                !Turnos.Any(x => x.ColaboradorId == turno.ColaboradorId))
            {
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
                return Agendamentos.Where(x => x.ColaboradorId == turno.ColaboradorId).ToList();
            }
            else
            {
                return null;
            }
        }

        public bool AgendamentoCabeNoTurno(Turno turno, Agendamento agendamento)
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

        public bool AgendamentoCabe(Agendamento agendamento)
        {
            if (agendamento != null)
            {
                var turno =
                Turnos.FirstOrDefault(x => x.ColaboradorId == agendamento.ColaboradorId);
                if (turno != null && AgendamentoCabeNoTurno(turno, agendamento))
                {
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

        /*
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
        */

        /*
        //TODO ?
        //essa funcao é mais complicada de implementar com ORM
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
