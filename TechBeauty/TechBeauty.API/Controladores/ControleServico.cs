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
    public class ControleServico : ControllerBase
    {
        [HttpGet]
        [Route(template: "Servico")]
        public IActionResult Get()
        {
            var todos = RepositorioDominio.Servico.SelecionarTodos();
            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "Servico/{id}")]
        public IActionResult GetPorId([FromRoute] int id)
        {
            var escolhido = RepositorioDominio.Servico.SelecionarPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }

        [HttpPost(template: "Servico")]
        public IActionResult Post([FromBody] CriarServico viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var novo = Servico.NovoServico(viewModel.Nome, viewModel.Preco, viewModel.Descricao, 
                viewModel.DuracaoEmMin);

            RepositorioDominio.Servico.Incluir(novo);

            return Created(uri: $"TechBeautyV1/Servico/{novo.Id}", novo);
        }

        [HttpDelete(template: "Servico/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var excluido = RepositorioDominio.Servico.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            RepositorioDominio.Servico.Excluir(excluido);
            return Ok(excluido);
        }
    }
}
