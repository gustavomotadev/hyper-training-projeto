using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TechBeauty.API.ViewModels.Criacao;
using TechBeauty.Dados.Repositorios;
using TechBeauty.Dominio.Financeiro;
using TechBeauty.Dominio.Modelo;
using TechBeauty.Dominio.Modelo.Enumeracoes;

namespace TechBeauty.API.Controladores
{
    [ApiController]
    [Route(template: "TechBeautyV1")]
    public class ControleColaborador : ControllerBase
    {
        [HttpGet]
        [Route(template: "Colaborador")]
        public IActionResult Get()
        {
            var todos = RepositorioDominio.Colaborador.SelecionarTodos();
            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "Colaborador/{id}")]
        public IActionResult GetPorId([FromRoute] int id)
        {
            var escolhido = RepositorioDominio.Colaborador.SelecionarPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }

        [HttpPost(template: "Colaborador")]
        public IActionResult Post([FromBody] CriarColaborador viewModel)
        {
            if (!ModelState.IsValid || !viewModel.Validar()) return BadRequest();

            Endereco endereco = null;
            if (viewModel.EnderecoId is not null)
            {
                endereco = RepositorioDominio.Endereco.SelecionarPorChave(viewModel.EnderecoId);
                if (endereco is null) return BadRequest();
            }
            else
            {
                endereco = Endereco.NovoEndereco(viewModel.Logradouro, viewModel.Bairro, viewModel.Cidade, 
                    (UnidadeFederativa) viewModel.UF, viewModel.CEP, viewModel.Numero, viewModel.Complemento);
            }

            var genero = RepositorioDominio.Genero.SelecionarPorChave(viewModel.GeneroId);
            if (genero is null) return BadRequest();

            var regime = RepositorioDominio.RegimeContratual.SelecionarPorChave(viewModel.RegimeContratualId);
            if (regime is null) return BadRequest();

            RepositorioDominio.Endereco.Incluir(endereco);

            var novo = Colaborador.NovoColaborador(viewModel.Nome, viewModel.CPF, viewModel.DataNascimento.Date,
                endereco.Id, viewModel.GeneroId, viewModel.NomeSocial);

            RepositorioDominio.Colaborador.Incluir(novo);

            var contrato = ContratoTrabalho.NovoContratoTrabalho(viewModel.RegimeContratualId, viewModel.DataEntrada,
                viewModel.DataDesligamento, viewModel.CNPJ_CTPS, novo.Id);

            RepositorioDominio.ContratoTrabalho.Incluir(contrato);

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
                contato = Contato.NovoContato((int) viewModel.TipoContato2Id, viewModel.Contato2, novo.Id); //final
                contatos.Add(contato);
            }

            if (viewModel.TipoContato3Id is not null &&
                viewModel.Contato3 is not null)
            {
                tipoContato = RepositorioDominio.TipoContato.SelecionarPorChave(viewModel.TipoContato3Id);
                if (tipoContato is null) return BadRequest();
                contato = Contato.NovoContato((int) viewModel.TipoContato3Id, viewModel.Contato3, novo.Id); //final
                contatos.Add(contato);
            }

            foreach (var c in contatos)
            {
                RepositorioDominio.Contato.Incluir(c);
            }

            //var servicos = new List<Servico>();
            Servico servico = null;
            foreach (var servicoId in viewModel.IdServicos)
            {
                servico = RepositorioDominio.Servico.SelecionarPorChave(servicoId);
                if (servico is null) return BadRequest();
                //servicos.Add(servico);
                novo.AdicionarServico(servico);
            }
            //novo.Servicos = servicos;
            RepositorioDominio.Colaborador.Alterar(novo);

            //var cargos = new List<Cargo>();
            Cargo cargo = null;
            foreach (var cargoId in viewModel.IdCargos)
            {
                cargo = RepositorioDominio.Cargo.SelecionarPorChave(cargoId);
                if (cargo is null) return BadRequest();
                //cargos.Add(cargo);
                contrato.AdicionarCargo(cargo);
            }
            //contrato.Cargos = cargos;
            RepositorioDominio.ContratoTrabalho.Alterar(contrato);

            var padraoRemuneracao = PadraoRemuneracao.NovoPadraoRemuneracao(novo.Id,
                viewModel.JornadaEsperada, viewModel.SalarioHora, viewModel.PercentualComissao,
                viewModel.AdicionalHoraExtra);
            RepositorioDominio.PadraoRemuneracao.Incluir(padraoRemuneracao);

            return Created(uri: $"TechBeautyV1/Colaborador/{novo.Id}", novo);
        }

        [HttpPost(template: "Colaborador/{id}/Contato")]
        public IActionResult Post([FromRoute] int id, [FromBody] AdicionarContato viewModel)
        {
            if (!ModelState.IsValid || !viewModel.Validar()) return BadRequest();

            var colaborador = RepositorioDominio.Colaborador.SelecionarPorChave(id);
            if (colaborador is null) return BadRequest();

            var tipoContato = RepositorioDominio.TipoContato.SelecionarPorChave(viewModel.TipoContatoId);
            if (tipoContato is null) return BadRequest();

            var contato = Contato.NovoContato(viewModel.TipoContatoId, viewModel.Contato, id);

            RepositorioDominio.Contato.Incluir(contato);

            return Created(uri: $"TechBeautyV1/Colaborador/{id}", contato);
        }

        [HttpPost(template: "Colaborador/{id}/Contrato")]
        public IActionResult Post([FromRoute] int id, [FromBody] AdicionarContrato viewModel)
        {
            if (!ModelState.IsValid || !viewModel.Validar()) return BadRequest();

            var colaborador = RepositorioDominio.Colaborador.SelecionarPorChave(id);
            if (colaborador is null) return BadRequest();

            var contrato = ContratoTrabalho.NovoContratoTrabalho(viewModel.RegimeContratualId, viewModel.DataEntrada,
                viewModel.DataDesligamento, viewModel.CNPJ_CTPS, colaborador.Id);

            RepositorioDominio.ContratoTrabalho.Incluir(contrato);

            return Created(uri: $"TechBeautyV1/Colaborador/{id}", contrato);
        }

        [HttpDelete(template: "Colaborador/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var excluido = RepositorioDominio.Colaborador.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            RepositorioDominio.Colaborador.Excluir(excluido);
            return Ok(excluido);
        }
    }
}
