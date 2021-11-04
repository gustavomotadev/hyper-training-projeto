using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class ControleRegimeContratual : ControllerBase
    {
        private readonly RepositorioBase<RegimeContratual> _repoRegimeContratual;

        public ControleRegimeContratual()
        {
            _repoRegimeContratual = new RepositorioBase<RegimeContratual>();
        }

        [HttpGet]
        [Route(template: "RegimeContratual")] 
        public IActionResult Get()
        {
            var todos = _repoRegimeContratual.SelecionarTodos();
            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "RegimeContratual/{id}")]
        public IActionResult GetPorId([FromRoute] int id)
        {
            var escolhido = _repoRegimeContratual.SelecionarPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }

        [HttpPost(template: "RegimeContratual")]
        public IActionResult Post([FromBody] CriarRegimeContratual viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var novo = RegimeContratual.NovoRegimeContratual(viewModel.Valor);

            _repoRegimeContratual.Incluir(novo);

            return Created(uri: $"TechBeautyV1/RegimeContratual/{novo.Id}", novo);
        }

        [HttpDelete(template: "RegimeContratual/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var excluido = _repoRegimeContratual.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            _repoRegimeContratual.Excluir(excluido);
            return Ok(excluido);
        }
    }
}
