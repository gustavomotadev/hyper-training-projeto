using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.ViewModels;
using TechBeauty.Dados.Repositorios;
using TechBeauty.Dominio.Financeiro;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.API.Controladores
{
    [ApiController]
    [Route(template: "TechBeautyV1")]
    public class ControleRemuneracaoDiaria : ControllerBase
    {
        [HttpGet]
        [Route(template: "RemuneracaoDiaria")]
        public IActionResult Get()
        {
            var todos = RepositorioDominio.RemuneracaoDiaria.SelecionarTodos();
            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "RemuneracaoDiaria/{id}")]
        public IActionResult GetPorId([FromRoute] int id)
        {
            var escolhido = RepositorioDominio.RemuneracaoDiaria.SelecionarPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }

        [HttpPost(template: "RemuneracaoDiaria")]
        public IActionResult Post([FromBody] CriarRemuneracaoDiaria viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var colaborador = RepositorioDominio.Colaborador.SelecionarPorChave(viewModel.ColaboradorId);

            if (colaborador is null) return BadRequest();

            var caixaDiario = RepositorioDominio.CaixaDiario.SelecionarPorChave(viewModel.CaixaDiarioId);

            if (caixaDiario is null) return BadRequest();

            List<Servico> servicosRealizados = new List<Servico>();

            foreach (var servicoId in viewModel.ServicosRealizadosId)
            {
                var servico = RepositorioDominio.Servico.SelecionarPorChave(servicoId);
                if (servico is null) return BadRequest();

                servicosRealizados.Add(servico);
            }

            var novo = RemuneracaoDiaria.NovaRemuneracaoDiaria(caixaDiario, colaborador, 
                new TimeSpan(viewModel.HorasTrabalhadas.horas, viewModel.HorasTrabalhadas.minutos, 0), 
                servicosRealizados);

            RepositorioDominio.RemuneracaoDiaria.Incluir(novo);

            return Created(uri: $"TechBeautyV1/RemuneracaoDiaria/{novo.Id}", novo);
        }

        [HttpDelete(template: "RemuneracaoDiaria/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var excluido = RepositorioDominio.RemuneracaoDiaria.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            RepositorioDominio.RemuneracaoDiaria.Excluir(excluido);
            return Ok(excluido);
        }
    }
}
