﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TechBeauty.Dominio.Modelo
{
    class Expediente
    {
        public int Id { get; set; }
        public DateTime DataHoraAbertura { get; init; }
        public DateTime DataHoraFechamento { get; init; }
        public List<Escalado> Escalados { get; private set; }
        public List<Agendamento> AgendamentosDoDia { get; private set; } = new List<Agendamento>();

        private Expediente(int id, DateTime dataHoraAbertura, DateTime dataHoraFechamento)
        {
            Id = id;
            DataHoraAbertura = dataHoraAbertura;
            DataHoraFechamento = dataHoraFechamento;
        }

        public Expediente NovoExpediente(int id, DateTime dataHoraAbertura, DateTime dataHoraFechamento,
            List<Escalado> escalados)
        {
            if (dataHoraAbertura.Date == dataHoraFechamento.Date &&
                dataHoraAbertura < dataHoraFechamento &&
                escalados != null &&
                escalados.Count > 0 &&
                !escalados.Any(x => x == null))
            {
                var expediente = new Expediente(id, dataHoraAbertura, dataHoraFechamento);
                expediente.Escalados = escalados;
                return expediente;
            }
            else
            {
                return null;
            }
        }

        public Escalado ObterEscaladoPorId(int id) =>
            Escalados.FirstOrDefault(x => x.Id == id);

        public bool AdicionarEscalado(Escalado escalado)
        {
            if (escalado != null &&
                escalado.DataHoraEntrada.Date >= DataHoraAbertura.Date &&
                escalado.DataHoraSaida.Date <= DataHoraFechamento.Date &&
                !Escalados.Any(x => x.Colaborador.Id == escalado.Colaborador.Id))
            {
                Escalados.Add(escalado);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Agendamento ObterAgendamentoPorId(int id) =>
            AgendamentosDoDia.FirstOrDefault(x => x.Id == id);

        public List<Agendamento> AgendamentosDoEscalado(Escalado escalado)
        {
            if (escalado != null)
            {
                return AgendamentosDoDia.Where(x => x.Colaborador.Id == escalado.Colaborador.Id).ToList();
            }
            else
            {
                return null;
            }
        }

        private bool AgendamentoCabeNaEscala(Escalado escalado, Agendamento agendamento)
        {
            if (escalado != null &&
                agendamento != null)
            {
                if (agendamento.DataHoraExecucao >= escalado.DataHoraEntrada &&
                    agendamento.DataHoraFinal <= escalado.DataHoraSaida)
                {
                    var agendamentosFeitos = AgendamentosDoEscalado(escalado);
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
                var escalado =
                Escalados.FirstOrDefault(x => x.Colaborador.Id == agendamento.Colaborador.Id);
                if (escalado != null && AgendamentoCabeNaEscala(escalado, agendamento))
                {
                    AgendamentosDoDia.Add(agendamento);
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

        public List<Escalado> ObterPrestadoresDeServico(List<Servico> servicos)
        {
            if (servicos != null &&
                servicos.Count > 0 &&
                !servicos.Any(x => x == null))
            {
                var prestadores = new List<Escalado>();
                foreach (var escalado in Escalados)
                {
                    if (!Enumerable.Except(servicos, escalado.Colaborador.Servicos).Any())
                    {
                        prestadores.Add(escalado);
                    }
                }
                return prestadores;
            }
            else
            {
                return null;
            }
        }
    }
}
