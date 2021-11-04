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
    public class ControleGenero : ControllerBase
    {
        [HttpGet]
        [Route(template: "Genero")]
        public IActionResult Get()
        {
            var todos = RepositorioDominio.Genero.SelecionarTodos();
            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "Genero/{id}")]
        public IActionResult GetPorId([FromRoute] int id)
        {
            var escolhido = RepositorioDominio.Genero.SelecionarPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }

        [HttpPost(template: "Genero")]
        public IActionResult Post([FromBody] CriarGenero viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var novo = Genero.AdicionarGenero(viewModel.Valor);

            RepositorioDominio.Genero.Incluir(novo);

            return Created(uri: $"TechBeautyV1/Genero/{novo.Id}", novo);
        }

        [HttpDelete(template: "Genero/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var excluido = RepositorioDominio.Genero.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            RepositorioDominio.Genero.Excluir(excluido);
            return Ok(excluido);
        }


    }
}
