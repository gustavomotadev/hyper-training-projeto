using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.ViewModels.Criacao;
using TechBeauty.Dados.Repositorios;
using TechBeauty.Dominio.Financeiro;

namespace TechBeauty.API.Controladores
{
    [ApiController]
    [Route(template: "TechBeautyV1")]
    public class ControlePagamento : ControllerBase
    {
        [HttpGet]
        [Route(template: "Pagamento")]
        public IActionResult GetPagamento()
        {
            var todos = RepositorioDominio.Pagamento.SelecionarTodos();
            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "Pagamento/{id}")]
        public IActionResult GetPagamentoPorId([FromRoute] int id)
        {
            var escolhido = RepositorioDominio.Pagamento.SelecionarPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }

        [HttpPost(template: "Pagamento")]
        public IActionResult PostPagamento([FromBody] CriarPagamento viewModel)
        {
            if (!ModelState.IsValid || !viewModel.Validar()) return BadRequest();

            var os = RepositorioDominio.OrdemServico.SelecionarPorChave(viewModel.OrdemServicoId);

            if (os is null) return BadRequest();

            var formaPgto = RepositorioDominio.FormaPagamento.SelecionarPorChave(viewModel.FormaPagamentoId);

            if (formaPgto is null) return BadRequest();
            
            var caixaDiario = RepositorioDominio.CaixaDiario.SelecionarPorChave(viewModel.CaixaDiarioId);

            if (caixaDiario is null) return BadRequest();

            var novo = Pagamento.NovoPagamento(viewModel.CaixaDiarioId, viewModel.OrdemServicoId, 
                viewModel.FormaPagamentoId, viewModel.DataPagamento);

            RepositorioDominio.Pagamento.Incluir(novo);

            return Created(uri: $"TechBeautyV1/Pagamento/{novo.Id}", novo);
        }

        [HttpDelete(template: "Pagamento/{id}")]
        public IActionResult DeletePagamento([FromRoute] int id)
        {
            var excluido = RepositorioDominio.Pagamento.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            RepositorioDominio.Pagamento.Excluir(excluido);
            return Ok(excluido);
        }
    }
}
