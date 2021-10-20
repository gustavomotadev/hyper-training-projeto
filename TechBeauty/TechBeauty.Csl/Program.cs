using System;
using System.Collections.Generic;
using System.Linq;
using TechBeauty.Dominio.Modelo;
using TechBeauty.Dominio.Repositorio;

namespace TechBeauty.Csl
{
    class Program
    {
        private static GeneroRepositorio repoGenero;
        private static CargoRepositorio repoCargo;
        private static TipoContatoRepositorio repoTipoContato;
        private static RegimeContratualRepositorio repoRegimeContratual;
        private static ServicoRepositorio repoServico;
        private static EnderecoRepositorio repoEndereco;
        private static ContatoRepositorio repoContato;

        static void Main(string[] args)
        {
            repoGenero = new GeneroRepositorio();
            repoCargo = new CargoRepositorio();
            repoTipoContato = new TipoContatoRepositorio();
            repoRegimeContratual = new RegimeContratualRepositorio();
            repoServico = new ServicoRepositorio();
            repoEndereco = new EnderecoRepositorio();
            repoContato = new ContatoRepositorio(repoTipoContato.TabelaTipoContato);

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
        }
    }
}
