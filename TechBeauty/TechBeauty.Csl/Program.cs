using System;
using System.Collections.Generic;
using System.Linq;
using TechBeauty.Dominio.Modelo;
using TechBeauty.Dominio.Repositorio;

namespace TechBeauty.Csl
{
    class Program
    {

        static void Main(string[] args)
        {
            var repoGenero = new GeneroRepositorio();
            var repoCargo = new CargoRepositorio();
            var repoTipoContato = new TipoContatoRepositorio();
            var repoRegimeContratual = new RegimeContratualRepositorio();
            var repoServico = new ServicoRepositorio();
            var repoEndereco = new EnderecoRepositorio();
            var repoContato = new ContatoRepositorio(repoTipoContato);
            var repoContratoTrabalho = new ContratoTrabalhoRepositorio(repoRegimeContratual, repoCargo);
            var repoCliente = new ClienteRepositorio(repoContato);
            var repoOrdemServico = new OrdemServicoRepositorio(repoCliente);
            var repoColaborador = new ColaboradorRepositorio(repoContato, repoServico, repoEndereco, repoGenero,
                repoContratoTrabalho);
            var repoEscala = new EscalaRepositorio(repoColaborador);
            var repoAgendamento = new AgendamentoRepositorio(repoServico, repoColaborador, repoOrdemServico);


            foreach (var x in repoGenero.TabelaGenero)
            {
                Console.WriteLine(x.Valor);
            }
            foreach (var x in repoCargo.TabelaCargo)
            {
                Console.WriteLine(x.Nome);
            }
            foreach (var x in repoTipoContato.TabelaTipoContato)
            {
                Console.WriteLine(x.Valor);
            }
            foreach (var x in repoRegimeContratual.TabelaRegimeContratual)
            {
                Console.WriteLine(x.Nome);
            }
            foreach (var x in repoServico.TabelaServico)
            {
                Console.WriteLine(x.Nome);
            }
            foreach (var x in repoEndereco.TabelaEndereco)
            {
                Console.WriteLine(x.Logradouro);
            }
            foreach (var x in repoContato.TabelaContato)
            {
                Console.WriteLine(x.Valor);
            }
            foreach (var x in repoContratoTrabalho.TabelaContratoTrabalho)
            {
                Console.WriteLine(x.CnpjCTPS);
            }
            foreach (var x in repoCliente.TabelaCliente)
            {
                Console.WriteLine($"Nome: {x.Nome}  Data Nascimento: {x.DataNascimento}  " +
                    $"CPF: {x.CPF}");
            }
            foreach (var x in repoOrdemServico.TabelaOS)
            {
                Console.WriteLine($"Número da OS: {x.Id} Cliente: {x.Cliente.Nome} " +
                    $"Preço: R$ {x.PrecoTotal} Status: {x.StatusOS} ");
            }
            foreach (var x in repoColaborador.TabelaColaborador)
            {
                Console.WriteLine($"Nome: {x.Nome}  Genero: {x.Genero.Valor}  " +
                    $"Regime: {x.Contrato.RegimeContratual.Nome}");
            }
            foreach (var x in repoEscala.TabelaEscala)
            {
                Console.WriteLine($"Colaborador: {x.Colaborador.Nome}  CPF: {x.Colaborador.CPF} " +
                    $"Entrada: {x.DataHoraEntrada}" + 
                    $" Saida: {x.DataHoraSaida} " );
            }
            foreach (var x in repoAgendamento.TabelaAgendamento)
            {
                Console.WriteLine($"Colaborador: {x.Colaborador.Nome}  Pessoa Atendida: {x.PessoaAtendida} " +
                    $"Servico: {x.Servico.Nome} Hora: {x.DataHoraExecucao}");
            }

        }
    }
}
