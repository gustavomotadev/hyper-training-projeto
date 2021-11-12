using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TechBeauty.API.ViewModels.Criacao;
using TechBeauty.Dados.Repositorios;
using TechBeauty.Dominio.Financeiro;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.API.Controladores //TO DO
{
    [ApiController]
    [Route(template: "TechBeautyV1")]
    public class ControleCaixaDiario : ControllerBase
    {
        [HttpGet]
        [Route(template: "CaixaDiario")]
        public IActionResult GetCaixaDiario()
        {
            var todos = RepositorioDominio.CaixaDiario.SelecionarTodos();
            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "CaixaDiario/{id}")]
        public IActionResult GetCaixaDiarioPorId([FromRoute] int id)
        {
            var escolhido = RepositorioDominio.CaixaDiario.SelecionarCompletoPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }

        [HttpPost(template: "CaixaDiario")] //TO DO
        public IActionResult PostCaixaDiario([FromBody] CriarCaixaDiario viewModel)
        {
            if (!ModelState.IsValid || !viewModel.Validar()) return BadRequest();

            var jaExiste = RepositorioDominio.CaixaDiario.SelecionarUmPorCondicao(
                c => c.Data.Date == viewModel.Data.Date);
            if (jaExiste is not null) return BadRequest();

            var novo = CaixaDiario.NovoCaixaDiario(viewModel.Data.Date, viewModel.CustoFixo);

            RepositorioDominio.CaixaDiario.Incluir(novo);

            return Created(uri: $"TechBeautyV1/CaixaDiario/{novo.Id}", novo);
        }

        [HttpPut]
        [Route(template: "CaixaDiario/{id}/CalcularRemuneracoes")]
        public IActionResult CalcularRemuneracoes([FromRoute] int id)
        {
            var escolhido = RepositorioDominio.CaixaDiario.SelecionarPorChave(id);
            if (escolhido is null) return NotFound();

            var expedienteTemp = RepositorioDominio.Expediente.SelecionarUmPorCondicao(
                e => e.DataHoraAbertura.Date == escolhido.Data.Date);
            if (expedienteTemp is null) return NotFound();

            var expediente = RepositorioDominio.Expediente.SelecionarCompletoPorChave(expedienteTemp.Id);
            if (expediente is null) return NotFound();

            var remuneracoes = new List<RemuneracaoDiaria>();
            foreach (var turno in expediente.Turnos)
            {
                var remuneracao = RemuneracaoDiaria.NovaRemuneracaoDiaria(id, turno.ColaboradorId, 
                    turno.DataHoraSaida - turno.DataHoraEntrada);

                remuneracoes.Add(remuneracao);
            }

            RepositorioDominio.RemuneracaoDiaria.ExcluirVariosPorCondicao(r => r.CaixaDiarioId == id);

            foreach (var r in remuneracoes)
            {
                RepositorioDominio.RemuneracaoDiaria.Incluir(r);

                foreach (var agendamento in expediente.Agendamentos)
                {
                    if (agendamento.ColaboradorId == r.ColaboradorId)
                    {
                        var servico = RepositorioDominio.Servico.SelecionarPorChave(agendamento.ServicoId);
                        if (servico is null) return NotFound();
                        r.AdicionarServico(servico);
                    }
                }

                RepositorioDominio.RemuneracaoDiaria.Alterar(r);
            }

            return Ok(); //TODO
        }

        [HttpDelete(template: "CaixaDiario/{id}")]
        public IActionResult DeleteCaixaDiario([FromRoute] int id)
        {
            var excluido = RepositorioDominio.CaixaDiario.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            RepositorioDominio.CaixaDiario.Excluir(excluido);
            return Ok(excluido);
        }
    }
}
