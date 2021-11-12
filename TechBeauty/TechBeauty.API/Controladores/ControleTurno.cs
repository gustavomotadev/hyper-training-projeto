using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.ViewModels.Alteracao;
using TechBeauty.API.ViewModels.Criacao;
using TechBeauty.Dados.Repositorios;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.API.Controladores
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
        public IActionResult GetTurnoPorId([FromRoute] int id)
        {
            var escolhido = RepositorioDominio.Turno.SelecionarPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }

        [HttpPost(template: "Turno")]
        public IActionResult PostTurno([FromBody] CriarTurno viewModel)
        {
            if (!ModelState.IsValid || !viewModel.Validar()) return BadRequest();

            var colaborador = RepositorioDominio.Colaborador.SelecionarPorChave(viewModel.ColaboradorId);
            if (colaborador is null) return BadRequest();

            var expediente = RepositorioDominio.Expediente.SelecionarCompletoPorChave(viewModel.ExpedienteId);
            if (expediente is null) return BadRequest();

            var novo = Turno.NovoTurno(viewModel.DataHoraEntrada, viewModel.DataHoraSaida, 
                viewModel.ColaboradorId, viewModel.ExpedienteId);

            //só permitir criação de turno dentro do horário do expediente e somente um turno por colaborador por expediente
            if (!expediente.TurnoCabe(novo)) return BadRequest();

            RepositorioDominio.Turno.Incluir(novo);

            return Created(uri: $"TechBeautyV1/Turno/{novo.Id}", novo);
        }

        [HttpPut(template: "Turno/{id}")]
        public IActionResult PutTurno([FromRoute] int id, [FromBody] AlterarTurno viewModel)
        {
            if (!ModelState.IsValid || !viewModel.Validar()) return BadRequest();

            var turno = RepositorioDominio.Turno.SelecionarPorChave(id);
            if (turno is null) return BadRequest();

            turno.RegistrarPontoEntrada(viewModel.RegistroEntrada);
            turno.RegistrarPontoSaida(viewModel.RegistroSaida);

            RepositorioDominio.Turno.Alterar(turno);
            return Ok();
        }

        [HttpDelete(template: "Turno/{id}")]
        public IActionResult DeleteTurno([FromRoute] int id)
        {
            var excluido = RepositorioDominio.Turno.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            RepositorioDominio.Turno.Excluir(excluido);
            return Ok(excluido);
        }
    }
}
