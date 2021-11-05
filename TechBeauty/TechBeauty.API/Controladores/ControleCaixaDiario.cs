using Microsoft.AspNetCore.Mvc;
using TechBeauty.API.ViewModels;
using TechBeauty.Dados.Repositorios;
using TechBeauty.Dominio.Financeiro;

namespace TechBeauty.API.Controladores //TO DO
{
    [ApiController]
    [Route(template: "TechBeautyV1")]
    public class ControleCaixaDiario : ControllerBase
    {
        [HttpGet]
        [Route(template: "CaixaDiario")]
        public IActionResult Get()
        {
            var todos = RepositorioDominio.CaixaDiario.SelecionarTodos();
            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "CaixaDiario/{id}")]
        public IActionResult GetPorId([FromRoute] int id)
        {
            var escolhido = RepositorioDominio.CaixaDiario.SelecionarPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }

        [HttpPost(template: "CaixaDiario")] //TO DO
        public IActionResult Post([FromBody] CriarCaixaDiario viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();
            
            var novo = CaixaDiario.NovoCaixaDiario(viewModel.Data.Date, viewModel.CustoFixo);

            RepositorioDominio.CaixaDiario.Incluir(novo);

            return Created(uri: $"TechBeautyV1/CaixaDiario/{novo.Id}", novo);
        }

        [HttpDelete(template: "CaixaDiario/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var excluido = RepositorioDominio.CaixaDiario.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            RepositorioDominio.CaixaDiario.Excluir(excluido);
            return Ok(excluido);
        }
    }
}
