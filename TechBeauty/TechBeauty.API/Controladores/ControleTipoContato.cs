using Microsoft.AspNetCore.Mvc;
using TechBeauty.API.ViewModels;
using TechBeauty.Dados.Repositorios;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.API.Controladores
{
    [ApiController]
    [Route(template: "TechBeautyV1")]
    public class ControleTipoContato : ControllerBase
    {
        private readonly RepositorioBase<TipoContato> _tipoContato;

        public ControleTipoContato()
        {
            _tipoContato = new RepositorioBase<TipoContato>();
        }

        [HttpGet]
        [Route(template: "TipoContato")]
        public IActionResult Get()
        {
            var todos = _tipoContato.SelecionarTodos();
            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "TipoContato/{id}")]
        public IActionResult GetPorId([FromRoute] int id)
        {
            var escolhido = _tipoContato.SelecionarPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }

        [HttpPost(template: "TipoContato")]
        public IActionResult Post([FromBody] CriarTipoContato viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var novo = TipoContato.NovoTipoContato(viewModel.Valor);

            _tipoContato.Incluir(novo);

            return Created(uri: $"TechBeautyV1/TipoContato/{novo.Id}", novo);
        }

        [HttpDelete(template: "TipoContato/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var excluido = _tipoContato.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            _tipoContato.Excluir(excluido);
            return Ok(excluido);
        }


    }
}
