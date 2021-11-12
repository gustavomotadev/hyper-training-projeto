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
    public class ControleCargo : ControllerBase
    {
        [HttpGet]
        [Route(template: "Cargo")]
        public IActionResult GetCargo()
        {
            var todos = RepositorioDominio.Cargo.SelecionarTodos();
            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "Cargo/{id}")]
        public IActionResult GetCargoPorId([FromRoute] int id)
        {
            var escolhido = RepositorioDominio.Cargo.SelecionarPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }

        [HttpPost(template: "Cargo")]
        public IActionResult PostCargo([FromBody] CriarCargo viewModel)
        {
            if (!ModelState.IsValid || !viewModel.Validar()) return BadRequest();

            var novo = Cargo.NovoCargo(viewModel.Nome, viewModel.Descricao);

            RepositorioDominio.Cargo.Incluir(novo);

            return Created(uri: $"TechBeautyV1/Cargo/{novo.Id}", novo);
        }

        [HttpPut(template: "Cargo/{id}")]
        public IActionResult PutCargo([FromRoute] int id, [FromBody] AlterarCargo viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var cargo = RepositorioDominio.Cargo.SelecionarPorChave(id);
            if (cargo is null) return BadRequest();

            bool modificado = false;
            if (viewModel.ValidarNome())
            {
                cargo.AlterarNome(viewModel.Nome);
                modificado = true;
            }
            if (viewModel.ValidarDescricao())
            {
                cargo.AlterarDescricao(viewModel.Descricao);
                modificado = true;
            }

            if (modificado)
            {
                RepositorioDominio.Cargo.Alterar(cargo);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete(template: "Cargo/{id}")]
        public IActionResult DeleteCargo([FromRoute] int id)
        {
            var excluido = RepositorioDominio.Cargo.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            RepositorioDominio.Cargo.Excluir(excluido);
            return Ok(excluido);
        }
    }
}
