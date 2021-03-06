using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.ViewModels.Alteracao;
using TechBeauty.API.ViewModels.Criacao;
using TechBeauty.Dados.Repositorios;
using TechBeauty.Dominio.Modelo;
using TechBeauty.Dominio.Modelo.Enumeracoes;

namespace TechBeauty.API.Controladores
{
    [ApiController]
    [Route(template: "TechBeautyV1")]
    public class ControleAgendamento : Controller
    {
        [HttpGet]
        [Route(template: "Agendamento")]
        public IActionResult GetAgendamento()
        {
            var todos = RepositorioDominio.Agendamento.SelecionarTodos();
            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "Agendamento/{id}")]
        public IActionResult GetAgendamentoPorId([FromRoute] int id)
        {
            var escolhido = RepositorioDominio.Agendamento.SelecionarPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }
        
        [HttpPost(template: "Agendamento")]
        public IActionResult PostAgendamento([FromBody] CriarAgendamento viewModel)
        {
            if (!ModelState.IsValid || !viewModel.Validar()) return BadRequest();

            var servico = RepositorioDominio.Servico.SelecionarPorChave(viewModel.ServicoId);

            if (servico is null) return BadRequest();

            var colaborador = RepositorioDominio.Colaborador.SelecionarPorChave(viewModel.ColaboradorId);

            if (colaborador is null) return BadRequest();

            var os = RepositorioDominio.OrdemServico.SelecionarPorChave(viewModel.OrdemServicoId);

            if (os is null) return BadRequest();

            var expediente = RepositorioDominio.Expediente.SelecionarCompletoPorChave(viewModel.ExpedienteId);

            if (expediente is null) return BadRequest();

            var novo = Agendamento.NovoAgendamento(viewModel.ServicoId, viewModel.ColaboradorId,
                viewModel.OrdemServicoId, viewModel.ExpedienteId, viewModel.PessoaAtendida, 
                DateTime.Now, viewModel.DataHoraExecucao);

            //checar se tem espaço para o agendamento
            if (!expediente.AgendamentoCabe(novo)) return BadRequest();

            //agendamento deve ter mesma data da os
            if (os.Data.Date != novo.DataHoraExecucao.Date) return BadRequest();

            RepositorioDominio.Agendamento.Incluir(novo);

            return Created(uri: $"TechBeautyV1/Agendamento/{novo.Id}", novo);
        }

        [HttpPut(template: "Agendamento/{id}")]
        public IActionResult PutAgendamento([FromRoute] int id, [FromBody] AlterarAgendamento viewModel)
        {
            if (!ModelState.IsValid || !viewModel.Validar()) return BadRequest();

            var agendamento = RepositorioDominio.Agendamento.SelecionarPorChave(id);
            if (agendamento is null) return BadRequest();

            agendamento.AlterarStatusAgendamento((StatusAgendamento) viewModel.StatusAgendamento);

            RepositorioDominio.Agendamento.Alterar(agendamento);
            return Ok();
        }

        [HttpDelete(template: "Agendamento/{id}")]
        public IActionResult DeleteAgendamento([FromRoute] int id)
        {
            var excluido = RepositorioDominio.Agendamento.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            RepositorioDominio.Agendamento.Excluir(excluido);
            return Ok(excluido);
        }
    }
}
