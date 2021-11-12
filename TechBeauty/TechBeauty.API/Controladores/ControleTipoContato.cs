using Microsoft.AspNetCore.Mvc;
using TechBeauty.API.ViewModels.Criacao;
using TechBeauty.Dados.Repositorios;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.API.Controladores
{
    [ApiController]
    [Route(template: "TechBeautyV1")]
    public class ControleTipoContato : ControllerBase
    {
        [HttpGet]
        [Route(template: "TipoContato")]
        public IActionResult GetTipoContato()
        {
            var todos = RepositorioDominio.TipoContato.SelecionarTodos();
            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "TipoContato/{id}")]
        public IActionResult GetTipoContatoPorId([FromRoute] int id)
        {
            var escolhido = RepositorioDominio.TipoContato.SelecionarPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }

        [HttpPost(template: "TipoContato")]
        public IActionResult PostTipoContato([FromBody] CriarTipoContato viewModel)
        {
            if (!ModelState.IsValid || viewModel.Validar()) return BadRequest();

            var novo = TipoContato.NovoTipoContato(viewModel.Valor);

            RepositorioDominio.TipoContato.Incluir(novo);

            return Created(uri: $"TechBeautyV1/TipoContato/{novo.Id}", novo);
        }

        [HttpDelete(template: "TipoContato/{id}")]
        public IActionResult DeleteTipoContato([FromRoute] int id)
        {
            var excluido = RepositorioDominio.TipoContato.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            RepositorioDominio.TipoContato.Excluir(excluido);
            return Ok(excluido);
        }


    }
}
