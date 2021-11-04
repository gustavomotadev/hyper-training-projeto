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
    public class ControleCargo : ControllerBase
    {
        private readonly RepositorioBase<Cargo> _cargo;

        public ControleCargo()
        {
            _cargo = new RepositorioBase<Cargo>();
        }

        [HttpGet]
        [Route(template: "Cargo")]
        public IActionResult Get()
        {
            var todos = _cargo;
            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "Cargo/{id}")]
        public IActionResult GetPorId([FromRoute] int id)
        {
            var escolhido = _cargo.SelecionarPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }

        [HttpPost(template: "Cargo")]
        public IActionResult Post([FromBody] CriarCargo viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var novo = Cargo.NovoCargo(viewModel.Nome, viewModel.Descricao);

            _cargo.Incluir(novo);

            return Created(uri: $"TechBeautyV1/Cargo/{novo.Id}", novo);
        }

        [HttpDelete(template: "Cargo/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var excluido = _cargo.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            _cargo.Excluir(excluido);
            return Ok(excluido);
        }
    }
}
