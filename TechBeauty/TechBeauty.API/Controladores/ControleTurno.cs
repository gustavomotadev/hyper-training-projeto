using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.Dados.Repositorios;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.API.ViewModels
{
    [ApiController]
    [Route(template: "TechBeautyV1")]
    public class ControleTurno : ControllerBase
    {
        [HttpGet]
        [Route(template: "Turno")]
        public IActionResult Get()
        {
            var todos = RepositorioDominio.Turno.SelecionarTodos();
            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "Turno/{id}")]
        public IActionResult GetPorId([FromRoute] int id)
        {
            var escolhido = RepositorioDominio.Turno.SelecionarPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }

        [HttpPost(template: "Turno")]
        public IActionResult Post([FromBody] CriarTurno viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();
            var colaborador = RepositorioDominio.Colaborador.SelecionarPorChave(viewModel.ColaboradorId);
            if (colaborador is null) return BadRequest();
            var novo = Turno.NovoTurno(viewModel.DataHoraEntrada, viewModel.DataHoraSaida, colaborador);

            RepositorioDominio.Turno.Incluir(novo);

            return Created(uri: $"TechBeautyV1/Turno/{novo.Id}", novo);
        }

        [HttpDelete(template: "Turno/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var excluido = RepositorioDominio.Turno.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            RepositorioDominio.Turno.Excluir(excluido);
            return Ok(excluido);
        }
    }
}
