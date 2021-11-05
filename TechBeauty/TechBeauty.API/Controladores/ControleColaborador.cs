using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TechBeauty.API.ViewModels;
using TechBeauty.Dados.Repositorios;
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
            if (!ModelState.IsValid ||
                !viewModel.validarEndereco()) 
                return BadRequest();

            ///*
            var contatos = new List<Contato>();

            var tipoContato = RepositorioDominio.TipoContato.SelecionarPorChave(viewModel.TipoContato1Id);
            if (tipoContato is null) return BadRequest();
            var contato = Contato.NovoContato(tipoContato, viewModel.Contato1);
            contatos.Add(contato);

            if (viewModel.TipoContato2Id is not null &&
                viewModel.Contato2 is not null)
            {
                tipoContato = RepositorioDominio.TipoContato.SelecionarPorChave(viewModel.TipoContato2Id);
                if (tipoContato is null) return BadRequest();
                contato = Contato.NovoContato(tipoContato, viewModel.Contato2);
                contatos.Add(contato);
            }

            if (viewModel.TipoContato3Id is not null &&
                viewModel.Contato3 is not null)
            {
                tipoContato = RepositorioDominio.TipoContato.SelecionarPorChave(viewModel.TipoContato3Id);
                if (tipoContato is null) return BadRequest();
                contato = Contato.NovoContato(tipoContato, viewModel.Contato3);
                contatos.Add(contato);
            }

            var servicos = new List<Servico>();
            Servico servico = null;
            foreach (var servicoId in viewModel.IdServicos)
            {
                servico = RepositorioDominio.Servico.SelecionarPorChave(servicoId);
                if (servico is null) return BadRequest();
                servicos.Add(servico);
            }

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

            var cargos = new List<Cargo>();
            Cargo cargo = null;
            foreach (var cargoId in viewModel.IdCargos)
            {
                cargo = RepositorioDominio.Cargo.SelecionarPorChave(cargoId);
                if (cargo is null) return BadRequest();
                cargos.Add(cargo);
            }

            var contrato = ContratoTrabalho.NovoContratoTrabalho(regime, viewModel.DataEntrada, 
                viewModel.DataDesligamento, cargos, viewModel.CNPJ_CTPS);

            var novo = Colaborador.NovoColaborador(viewModel.Nome, viewModel.CPF, viewModel.DataNascimento.Date, 
                contatos, servicos, endereco, genero, contrato, viewModel.NomeSocial);

            //if (novo is null) return NotFound();

            ///*
            RepositorioDominio.Endereco.Incluir(endereco);

            RepositorioDominio.Colaborador.Incluir(novo);

            RepositorioDominio.ContratoTrabalho.Incluir(contrato);

            foreach (var c in contatos)
            {
                RepositorioDominio.Contato.Incluir(c);
            }
            

            return Created(uri: $"TechBeautyV1/Colaborador/{novo.Id}", novo);
            //*/
            //*/

            //return Ok(); //debug
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
