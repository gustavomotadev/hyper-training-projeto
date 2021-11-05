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
    public class ControleAgendamento : Controller
    {
        [HttpGet]
        [Route(template: "Agendamento")]
        public IActionResult Get()
        {
            var todos = RepositorioDominio.Agendamento.SelecionarTodos();
            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "Agendamento/{id}")]
        public IActionResult GetPorId([FromRoute] int id)
        {
            var escolhido = RepositorioDominio.Agendamento.SelecionarPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }

        // TO DO - Cosntrutor de Agendamento.
        /*[HttpPost(template: "Agendamento")]
        public IActionResult Post([FromBody] CriarAgendamento viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var servico = RepositorioDominio.Servico.SelecionarPorChave(viewModel.ServicoId);

            if (servico is null) return BadRequest();

            var colaborador = RepositorioDominio.Servico.SelecionarPorChave(viewModel.ColaboradorId);

            if (colaborador is null) return BadRequest();

            var os = RepositorioDominio.OrdemServico.SelecionarPorChave(viewModel.OrdemServicoId);

            if (os is null) return BadRequest();

            var expediente = RepositorioDominio.Expediente.SelecionarPorChave(viewModel.ExpedienteId);

            if (expediente is null) return BadRequest();

            var novo = Agendamento.NovoAgendamento(servico, colaborador, viewModel.PessoaAtendida, 
                viewModel.DataHoraExecucao);

            RepositorioDominio.Agendamento.Incluir(novo);

            return Created(uri: $"TechBeautyV1/Agendamento/{novo.Id}", novo);
        }*/

        [HttpDelete(template: "Agendamento/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var excluido = RepositorioDominio.Agendamento.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            RepositorioDominio.Agendamento.Excluir(excluido);
            return Ok(excluido);
        }
    }
}
