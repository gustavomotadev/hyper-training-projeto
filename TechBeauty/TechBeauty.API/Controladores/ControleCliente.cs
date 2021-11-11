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
    public class ControleCliente : ControllerBase
    {
        [HttpGet]
        [Route(template: "Cliente")]
        public IActionResult Get()
        {
            var todos = RepositorioDominio.Cliente.SelecionarTodos();
            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "Cliente/{id}")]
        public IActionResult GetPorId([FromRoute] int id)
        {
            var escolhido = RepositorioDominio.Cliente.SelecionarPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }

        [HttpPost(template: "Cliente")]
        public IActionResult Post([FromBody] CriarCliente viewModel)
        {
            if (!ModelState.IsValid || !viewModel.Validar()) return BadRequest();

            var novo = Cliente.NovoCliente(viewModel.Nome, viewModel.CPF, viewModel.DataNascimento);

            RepositorioDominio.Cliente.Incluir(novo);

            var contatos = new List<Contato>();

            var tipoContato = RepositorioDominio.TipoContato.SelecionarPorChave(viewModel.TipoContato1Id);
            if (tipoContato is null) return BadRequest();
            var contato = Contato.NovoContato(viewModel.TipoContato1Id, viewModel.Contato1, novo.Id); //final
            contatos.Add(contato);

            if (viewModel.TipoContato2Id is not null &&
                viewModel.Contato2 is not null)
            {
                tipoContato = RepositorioDominio.TipoContato.SelecionarPorChave(viewModel.TipoContato2Id);
                if (tipoContato is null) return BadRequest();
                contato = Contato.NovoContato((int)viewModel.TipoContato2Id, viewModel.Contato2, novo.Id); //final
                contatos.Add(contato);
            }

            if (viewModel.TipoContato3Id is not null &&
                viewModel.Contato3 is not null)
            {
                tipoContato = RepositorioDominio.TipoContato.SelecionarPorChave(viewModel.TipoContato3Id);
                if (tipoContato is null) return BadRequest();
                contato = Contato.NovoContato((int)viewModel.TipoContato3Id, viewModel.Contato3, novo.Id); //final
                contatos.Add(contato);
            }

            foreach (var c in contatos)
            {
                RepositorioDominio.Contato.Incluir(c);
            }

            return Created(uri: $"TechBeautyV1/Cliente/{novo.Id}", novo);
        }

        [HttpPut(template: "Cliente/{id}")]
        public IActionResult Post([FromRoute] int id, [FromBody] AlterarCliente viewModel)
        {
            if (!ModelState.IsValid || !viewModel.Validar()) return BadRequest();

            var cliente = RepositorioDominio.Cliente.SelecionarPorChave(id);
            if (cliente is null) return BadRequest();

            cliente.AlterarNome(viewModel.Nome);

            RepositorioDominio.Cliente.Alterar(cliente);
            return Ok();
        }

        [HttpDelete(template: "Cliente/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var excluido = RepositorioDominio.Cliente.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            RepositorioDominio.Cliente.Excluir(excluido);
            return Ok(excluido);
        }
    }
}
