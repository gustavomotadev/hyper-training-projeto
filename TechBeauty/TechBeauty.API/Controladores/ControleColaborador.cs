using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TechBeauty.API.ViewModels.Alteracao;
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
        public IActionResult GetColaborador()
        {
            var todos = RepositorioDominio.Colaborador.SelecionarTodos();
            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "Colaborador/{id}")]
        public IActionResult GetColaboradorPorId([FromRoute] int id)
        {
            var escolhido = RepositorioDominio.Colaborador.SelecionarPorChave(id);
            if (escolhido is not null) return Ok(escolhido);
            else return NotFound();
        }

        [HttpPost(template: "Colaborador")]
        public IActionResult PostColaborador([FromBody] CriarColaborador viewModel)
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
        public IActionResult PostColaboradorContato([FromRoute] int id, [FromBody] AdicionarContato viewModel)
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
        public IActionResult PostColaboradorContrato([FromRoute] int id, [FromBody] AdicionarContrato viewModel)
        {
            if (!ModelState.IsValid || !viewModel.Validar()) return BadRequest();

            var colaborador = RepositorioDominio.Colaborador.SelecionarPorChave(id);
            if (colaborador is null) return BadRequest();

            var contrato = ContratoTrabalho.NovoContratoTrabalho(viewModel.RegimeContratualId, viewModel.DataEntrada,
                viewModel.DataDesligamento, viewModel.CNPJ_CTPS, colaborador.Id);

            RepositorioDominio.ContratoTrabalho.Incluir(contrato);

            return Created(uri: $"TechBeautyV1/Colaborador/{id}", contrato);
        }

        [HttpPut(template: "Colaborador/{id}/Servico")]
        public IActionResult PutColaboradorServico([FromRoute] int id, [FromBody] AdicionarServico viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var colaborador = RepositorioDominio.Colaborador.SelecionarPorChave(id);
            if (colaborador is null) return BadRequest();

            var servico = RepositorioDominio.Servico.SelecionarPorChave(viewModel.ServicoId);
            if (servico is null) return BadRequest();

            colaborador.AdicionarServico(servico);
            RepositorioDominio.Colaborador.Alterar(colaborador);

            return Ok();
        }

        [HttpPut(template: "Colaborador/{colaboradorId}/Contrato/{contratoId}/Cargo")]
        public IActionResult PutColaboradorContratoCargo([FromRoute] int colaboradorId, [FromRoute] int contratoId,
            [FromBody] AdicionarCargo viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var colaborador = RepositorioDominio.Colaborador.SelecionarPorChave(colaboradorId);
            if (colaborador is null) return BadRequest();

            var contrato = RepositorioDominio.ContratoTrabalho.SelecionarPorChave(contratoId);
            if (colaborador is null) return BadRequest();

            var cargo = RepositorioDominio.Cargo.SelecionarPorChave(viewModel.CargoId);
            if (cargo is null) return BadRequest();

            contrato.AdicionarCargo(cargo);
            RepositorioDominio.ContratoTrabalho.Alterar(contrato);

            return Ok();
        }

        [HttpPut(template: "Colaborador/{id}")]
        public IActionResult PutColaborador([FromRoute] int id, [FromBody] AlterarColaborador viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var colaborador = RepositorioDominio.Colaborador.SelecionarPorChave(id);
            if (colaborador is null) return BadRequest();

            bool modificado = false;
            if (viewModel.ValidarNome())
            {
                colaborador.AlterarNome(viewModel.Nome);
                modificado = true;
            }
            if (viewModel.ValidarNomeSocial())
            {
                colaborador.AlterarNomeSocial(viewModel.NomeSocial);
                modificado = true;
            }
            
            if (modificado)
            {
                RepositorioDominio.Colaborador.Alterar(colaborador);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut(template: "Colaborador/{colaboradorId}/Contrato/{contratoId}")]
        public IActionResult PutColaboradorContrato([FromRoute] int colaboradorId, [FromRoute] int contratoId, 
            [FromBody] AlterarContrato viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var colaborador = RepositorioDominio.Colaborador.SelecionarPorChave(colaboradorId);
            if (colaborador is null) return BadRequest();

            var contrato = RepositorioDominio.ContratoTrabalho.SelecionarPorChave(contratoId);
            if (contrato is null) return BadRequest();

            bool modificado = false;
            if (viewModel.ValidarDataDesligamento())
            {
                contrato.AlterarDataDesligamento(viewModel.DataDesligamento);
                modificado = true;
            }
            if (viewModel.ValidarVigente())
            {
                contrato.alterarVigencia((bool) viewModel.Vigente);
                modificado = true;
            }

            if (modificado)
            {
                RepositorioDominio.ContratoTrabalho.Alterar(contrato);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut(template: "Colaborador/{id}/Endereco")]
        public IActionResult PutColaboradorEndereco([FromRoute] int id, [FromBody] AlterarEndereco viewModel)
        {
            if (!ModelState.IsValid || !viewModel.Validar()) return BadRequest();

            var colaborador = RepositorioDominio.Colaborador.SelecionarPorChave(id);
            if (colaborador is null) return BadRequest();

            var endereco = RepositorioDominio.Endereco.SelecionarPorChave(colaborador.EnderecoId);
            if (endereco is null) return BadRequest();

            endereco.MudarDeEndereco(viewModel.Logradouro, viewModel.Numero, viewModel.Bairro,
                viewModel.Cidade, (UnidadeFederativa) viewModel.UF, viewModel.CEP, viewModel.Complemento);

            RepositorioDominio.Endereco.Alterar(endereco);
            return Ok();
        }

        [HttpPut(template: "Colaborador/{id}/PadraoRemuneracao")]
        public IActionResult PutColaboradorPadraoRemuneracao([FromRoute] int id, [FromBody] AlterarPadraoRemuneracao viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var colaborador = RepositorioDominio.Colaborador.SelecionarPorChave(id);
            if (colaborador is null) return BadRequest();

            var padraoRemuneracao = RepositorioDominio.PadraoRemuneracao.SelecionarUmPorCondicao(p => p.ColaboradorId == id);
            if (padraoRemuneracao is null) return BadRequest();

            bool modificado = false;
            if (viewModel.ValidarJornadaEsperada())
            {
                padraoRemuneracao.AlterarJornadaEsperada(
                    new TimeSpan(viewModel.JornadaEsperada.Horas, viewModel.JornadaEsperada.Minutos, 0));
                modificado = true;
            }
            if (viewModel.ValidarSalarioHora())
            {
                padraoRemuneracao.AlterarSalarioHora((decimal) viewModel.SalarioHora);
                modificado = true;
            }
            if (viewModel.ValidarPercentualComissao())
            {
                padraoRemuneracao.AlterarPercentualComissao((decimal) viewModel.PercentualComissao);
                modificado = true;
            }
            if (viewModel.ValidarAdicionalHoraExtra())
            {
                padraoRemuneracao.AlterarAdicionalHoraExtra((decimal)viewModel.AdicionalHoraExtra);
                modificado = true;
            }

            if (modificado)
            {
                RepositorioDominio.PadraoRemuneracao.Alterar(padraoRemuneracao);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete(template: "Colaborador/{id}")]
        public IActionResult DeleteColaborador([FromRoute] int id)
        {
            var excluido = RepositorioDominio.Colaborador.SelecionarPorChave(id);
            if (excluido == null) return NotFound();

            RepositorioDominio.Colaborador.Excluir(excluido);
            return Ok(excluido);
        }
    }
}
