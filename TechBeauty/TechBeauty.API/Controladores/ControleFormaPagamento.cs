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
    public class ControleFormaPagamento : ControllerBase
    {
        [HttpGet]
        [Route(template: "FormaPagamento")]
        public IActionResult Get()
        {
            var todos = RepositorioDominio.FormaPagamento.SelecionarTodos();
            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "FormaPagamento/{id}")]
        public IActionResult GetPorId([FromRoute] int id)
        {
            var escolhido = RepositorioDominio.FormaPagamento.SelecionarPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }

        [HttpPost(template: "FormaPagamento")]
        public IActionResult Post([FromBody] CriarFormaPagamento viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var novo = FormaPagamento.NovaFormaPagamento(viewModel.Valor);

            RepositorioDominio.FormaPagamento.Incluir(novo);

            return Created(uri: $"TechBeautyV1/FormaPagamento/{novo.Id}", novo);
        }

        [HttpDelete(template: "FormaPagamento/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var excluido = RepositorioDominio.FormaPagamento.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            RepositorioDominio.FormaPagamento.Excluir(excluido);
            return Ok(excluido);
        }
    }
}
