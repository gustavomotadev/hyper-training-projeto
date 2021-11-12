using Microsoft.AspNetCore.Mvc;
using TechBeauty.API.ViewModels.Alteracao;
using TechBeauty.API.ViewModels.Criacao;
using TechBeauty.Dados.Repositorios;
using TechBeauty.Dominio.Modelo;
using TechBeauty.Dominio.Modelo.Enumeracoes;

namespace TechBeauty.API.Controladores
{
    [ApiController]
    [Route(template: "TechBeautyV1")]
    public class ControleOrdemServico : Controller
    {
        [HttpGet]
        [Route(template: "OrdemServico")]
        public IActionResult GetOrdemServico()
        {
            var todos = RepositorioDominio.OrdemServico.SelecionarTodos();
            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "OrdemServico/{id}")]
        public IActionResult GetOrdemServicoPorId([FromRoute] int id)
        {
            var escolhido = RepositorioDominio.OrdemServico.SelecionarPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }

        [HttpPost(template: "OrdemServico")]
        public IActionResult PostOrdemServico([FromBody] CriarOrdemServico viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var cliente = RepositorioDominio.Cliente.SelecionarPorChave(viewModel.ClienteId);

            if (cliente is null) return BadRequest();

            var novo = OrdemServico.NovaOS(viewModel.ClienteId, viewModel.Data);

            RepositorioDominio.OrdemServico.Incluir(novo);

            return Created(uri: $"TechBeautyV1/OrdemServico/{novo.Id}", novo);
        }

        [HttpPut(template: "OrdemServico/{id}")]
        public IActionResult PostOrdemServico([FromRoute] int id, [FromBody] AlterarOrdemServico viewModel)
        {
            if (!ModelState.IsValid || !viewModel.Validar()) return BadRequest();

            var os = RepositorioDominio.OrdemServico.SelecionarPorChave(id);
            if (os is null) return BadRequest();

            os.AlterarStatusDaOS((StatusOS) viewModel.StatusOS);

            RepositorioDominio.OrdemServico.Alterar(os);
            return Ok();
        }

        [HttpDelete(template: "OrdemServico/{id}")]
        public IActionResult DeleteOrdemServico([FromRoute] int id)
        {
            var excluido = RepositorioDominio.OrdemServico.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            RepositorioDominio.OrdemServico.Excluir(excluido);
            return Ok(excluido);
        }
    }
}
