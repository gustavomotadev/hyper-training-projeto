using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.ViewModels;
using TechBeauty.Dados.Repositorios;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.API.Controladores
{
    [ApiController]
    [Route(template: "TechBeautyV1")]
    public class ControleExpediente : ControllerBase
    {
        [HttpGet]
        [Route(template: "Expediente")]
        public IActionResult Get()
        {
            var todos = RepositorioDominio.Expediente.SelecionarTodos();
            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "Expediente/{id}")]
        public IActionResult GetPorId([FromRoute] int id)
        {
            var escolhido = RepositorioDominio.Expediente.SelecionarPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }

        [HttpPost(template: "Expediente")]
        public IActionResult Post([FromBody] CriarExpediente viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            // TODO 

            /*var novo = Expediente.NovoExpediente(caixaDiario, colaborador,
                new TimeSpan(viewModel.HorasTrabalhadas.horas, viewModel.HorasTrabalhadas.minutos, 0),
                servicosRealizados);

            RepositorioDominio.Expediente.Incluir(novo);

            return Created(uri: $"TechBeautyV1/Expediente/{novo.Id}", novo);*/
        }

        [HttpDelete(template: "Expediente/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var excluido = RepositorioDominio.Expediente.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            RepositorioDominio.Expediente.Excluir(excluido);
            return Ok(excluido);
        }
    }
}
