using Microsoft.AspNetCore.Mvc;
using TechBeauty.API.ViewModels.Criacao;
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
        public IActionResult GetCaixaDiario()
        {
            var todos = RepositorioDominio.CaixaDiario.SelecionarTodos();
            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "CaixaDiario/{id}")]
        public IActionResult GetCaixaDiarioPorId([FromRoute] int id)
        {
            var escolhido = RepositorioDominio.CaixaDiario.SelecionarPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }

        [HttpPost(template: "CaixaDiario")] //TO DO
        public IActionResult PostCaixaDiario([FromBody] CriarCaixaDiario viewModel)
        {
            if (!ModelState.IsValid || !viewModel.Validar()) return BadRequest();
            
            var novo = CaixaDiario.NovoCaixaDiario(viewModel.Data.Date, viewModel.CustoFixo);

            RepositorioDominio.CaixaDiario.Incluir(novo);

            return Created(uri: $"TechBeautyV1/CaixaDiario/{novo.Id}", novo);
        }

        [HttpDelete(template: "CaixaDiario/{id}")]
        public IActionResult DeleteCaixaDiario([FromRoute] int id)
        {
            var excluido = RepositorioDominio.CaixaDiario.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            RepositorioDominio.CaixaDiario.Excluir(excluido);
            return Ok(excluido);
        }
    }
}
