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
    public class ControleServico : ControllerBase
    {
        [HttpGet]
        [Route(template: "Servico")]
        public IActionResult GetServico()
        {
            var todos = RepositorioDominio.Servico.SelecionarTodos();
            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "Servico/{id}")]
        public IActionResult GetServicoPorId([FromRoute] int id)
        {
            var escolhido = RepositorioDominio.Servico.SelecionarPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }

        [HttpPost(template: "Servico")]
        public IActionResult PostServico([FromBody] CriarServico viewModel)
        {
            if (!ModelState.IsValid || viewModel.Validar()) return BadRequest();

            var novo = Servico.NovoServico(viewModel.Nome, viewModel.Preco, viewModel.Descricao, 
                viewModel.DuracaoEmMin);

            RepositorioDominio.Servico.Incluir(novo);

            return Created(uri: $"TechBeautyV1/Servico/{novo.Id}", novo);
        }

        [HttpPut(template: "Servico/{id}")]
        public IActionResult PutServico([FromRoute] int id, [FromBody] AlterarServico viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var servico = RepositorioDominio.Servico.SelecionarPorChave(id);
            if (servico is null) return BadRequest();

            bool modificado = false;
            if (viewModel.ValidarNome())
            {
                servico.AlterarNome(viewModel.Nome);
                modificado = true;
            }
            if (viewModel.ValidarPreco())
            {
                servico.AlterarPreco((decimal) viewModel.Preco);
                modificado = true;
            }
            if (viewModel.ValidarDescricao())
            {
                servico.AlterarDescricao(viewModel.Descricao);
                modificado = true;
            }
            if (viewModel.ValidarDuracaoEmMin())
            {
                servico.AlterarDuracao((int) viewModel.DuracaoEmMin);
                modificado = true;
            }

            if (modificado)
            {
                RepositorioDominio.Servico.Alterar(servico);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete(template: "Servico/{id}")]
        public IActionResult DeleteServico([FromRoute] int id)
        {
            var excluido = RepositorioDominio.Servico.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            RepositorioDominio.Servico.Excluir(excluido);
            return Ok(excluido);
        }
    }
}
