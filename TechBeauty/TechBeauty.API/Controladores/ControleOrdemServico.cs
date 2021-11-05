using Microsoft.AspNetCore.Mvc;
using TechBeauty.API.ViewModels;
using TechBeauty.Dados.Repositorios;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.API.Controladores
{
    [ApiController]
    [Route(template: "TechBeautyV1")]
    public class ControleOrdemServico : Controller
    {
        [HttpGet]
        [Route(template: "OrdemServico")]
        public IActionResult Get()
        {
            var todos = RepositorioDominio.OrdemServico.SelecionarTodos();
            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "OrdemServico/{id}")]
        public IActionResult GetPorId([FromRoute] int id)
        {
            var escolhido = RepositorioDominio.OrdemServico.SelecionarPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }

        [HttpPost(template: "OrdemServico")]
        public IActionResult Post([FromBody] CriarOrdemServico viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var cliente = RepositorioDominio.Cliente.SelecionarPorChave(viewModel.ClienteId);

            if (cliente is null) return BadRequest();

            var novo = OrdemServico.NovaOS(cliente);

            RepositorioDominio.OrdemServico.Incluir(novo);

            return Created(uri: $"TechBeautyV1/OrdemServico/{novo.Id}", novo);
        }

        [HttpDelete(template: "OrdemServico/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var excluido = RepositorioDominio.OrdemServico.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            RepositorioDominio.OrdemServico.Excluir(excluido);
            return Ok(excluido);
        }
    }
}
